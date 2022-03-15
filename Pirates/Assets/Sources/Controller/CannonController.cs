using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonController : IUpdatable
    {

        #region Fields

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
