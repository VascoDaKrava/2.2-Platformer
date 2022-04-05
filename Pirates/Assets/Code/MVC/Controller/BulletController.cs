using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletController : IUpdatable
    {

        #region Fields

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


        #region ClassLifeCycles

        public BulletController(MonoBehaviourManager monoBehaviourManager, BulletPool bulletPool, ResourcesManager resourcesManager, Transform startPoint)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _pool = bulletPool;
            _startPoint = startPoint;

            _model = new BulletModel();
            _view = GameObject.Instantiate(resourcesManager.CannonBall, startPoint.position, startPoint.rotation);

            _animator = new SimpleAnimator(resourcesManager.ExplosionSprites, _model.ExplosionAnimationDuration, false, _view.SpriteRenderer, _monoBehaviourManager);

            SetActive(false);
        }

        #endregion


        #region Methods

        public void SetActive(bool state)
        {
            _view.gameObject.SetActive(state);

            if (state)
            {
                _view.transform.position = _startPoint.position;
                _view.transform.rotation = _startPoint.rotation;

                _view.BulletRigidbody.AddForce(_view.transform.up * _model.BulletStartForce);
                _currentTimeToLive = _model.TimeToLive;
                _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate); ;
            }
            else
            {
                _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
                _pool.PushToPool(this);
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
                    _animator.Play();
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
                SetActive(false);
                _isWaitForDie = false;
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            CheckLive();
        }

        public void LetFixedUpdate() { }

        #endregion

    }
}
