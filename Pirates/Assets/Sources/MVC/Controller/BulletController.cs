using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletController : IUpdatable
    {

        #region Fields

        private bool _isActive;
        private BulletModel _model;
        private BulletView _view;
        private BulletPool _pool;
        private MonoBehaviourManager _monoBehaviourManager;
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
                        _monoBehaviourManager.AddToUpdateList(this);
                    }
                    else
                    {
                        _monoBehaviourManager.RemoveFromUpdateList(this);
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

            _isActive = true;

            SetActive = false;
        }

        #endregion


        #region Methods

        private void DoFly()
        {

        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
        }

        #endregion

    }
}
