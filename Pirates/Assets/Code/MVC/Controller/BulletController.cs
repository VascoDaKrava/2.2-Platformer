using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletController : IUpdatable
    {

        #region Fields

        private bool _isActive;
        private bool _isWaitForDie;
        private BulletModel _model;
        private BulletView _view;
        private BulletPool _pool;
        private float _currentTimeToLive;
        private float _waitForEndAnimation;
        private MonoBehaviourManager _monoBehaviourManager;
        private SimpleAnimator _animator;
        private Transform _startPoint;

        #endregion


        #region Properties

        public bool SetActive
        {
            get => _isActive;

            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    _view.gameObject.SetActive(value);
                    if (value)
                    {
                        _view.transform.position = _startPoint.position;
                        _view.transform.rotation = _startPoint.rotation;
                        _model.HorizontalVelocity = _startPoint.up.normalized.x * _model.BulletSpeed;
                        _model.VerticalVelocity = _startPoint.up.normalized.y * _model.BulletSpeed;
                        _model.IsFly = true;
                        _currentTimeToLive = _model.TimeToLive;
                        _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate); ;
                    }
                    else
                    {
                        _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
                        _pool.PushToPool(this);
                    }
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public BulletController(MonoBehaviourManager monoBehaviourManager, BulletPool bulletPool, ResourcesManager resourcesManager, Transform startPoint)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _pool = bulletPool;
            _startPoint = startPoint;

            _model = new BulletModel();
            _view = GameObject.Instantiate(resourcesManager.CannonBall, startPoint.position, startPoint.rotation).GetComponent<BulletView>();

            _animator = new SimpleAnimator(resourcesManager.ExplosionSprites, _model.ExplosionAnimationDuration, _view.SpriteRenderer, monoBehaviourManager);

            _isActive = true;

            SetActive = false;
        }

        #endregion


        #region Methods

        private void DoFly()
        {
            if (_model.IsFly)
            {
                _view.transform.position += _model.HorizontalVelocity * Vector3.right * Time.deltaTime;
                _view.transform.position += _model.VerticalVelocity * Vector3.up * Time.deltaTime;
                _model.VerticalVelocity -= _model.G * Time.deltaTime;

                if (_view.transform.position.y <= _model.GroundLevel)
                {
                    _model.HorizontalVelocity *= _model.ReboundFactor;
                    _model.VerticalVelocity *= -_model.ReboundFactor;
                }

                if (Mathf.Approximately(_model.HorizontalVelocity, 0.0f) && Mathf.Approximately(_model.VerticalVelocity, 0.0f))
                {
                    _model.IsFly = false;
                }
            }
        }

        private void CheckLive()
        {
            if (_currentTimeToLive >= 0.0f)
            {
                _currentTimeToLive -= Time.deltaTime;
            }
            else
            {
                if (_isWaitForDie)
                {
                    WaitForDie();
                }
                else
                {
                    _isWaitForDie = true;
                    _waitForEndAnimation = _model.ExplosionAnimationDuration;
                    _animator.PlayOnce();
                }
            }
        }

        private void WaitForDie()
        {
            if (_waitForEndAnimation >= 0)
            {
                _waitForEndAnimation -= Time.deltaTime;
            }
            else
            {
                SetActive = false;
                _isWaitForDie = false;
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            DoFly();
            CheckLive();
        }

        #endregion

    }
}
