using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonController : IUpdatable
    {

        #region Fields

        private BulletPool _bulletPool;
        private CannonModel _model;
        private CannonView _view;
        private Transform _pirateTransform;

        #endregion


        #region CodeLifeCicles

        public CannonController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager, Transform pirateTransform)
        {
            _model = new CannonModel();
            _view = GameObject.Instantiate(resourcesManager.Cannon, _model.StartPosition, Quaternion.identity).GetComponent<CannonView>();

            _pirateTransform = pirateTransform;

            _bulletPool = new BulletPool(_model.BulletsInPool, monoBehaviourManager, resourcesManager);

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region Methods

        private void Aiming()
        {
            _view.BurrelTransform.rotation =
                Quaternion.AngleAxis(
                    (_pirateTransform.position.y > _view.BurrelTransform.position.y ? -1 : 1) *
                    Mathf.Clamp(Vector3.Angle(Vector3.left, _pirateTransform.position - _view.BurrelTransform.position), 0.0f, _model.MaxBurrelAngle),
                    Vector3.forward
                    );
        }

        private void Shoot()
        {
            if (_model.TimeToNextShoot > 0.0f)
            {
                _model.TimeToNextShoot -= Time.deltaTime;
            }
            else
            {
                _model.TimeToNextShoot = _model.RateOfFire / 60.0f;
                _bulletPool.PopFromPool(_view.BulletStartTransform);
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            Aiming();
            Shoot();
        }

        #endregion

    }
}
