using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletController : IUpdatable
    {

        #region Fields

        private BulletModel _model;
        private BulletView _view;

        #endregion


        #region Properties

        public bool SetActive;

        public Transform SetStartPoint;

        #endregion


        #region ClassLifeCycles

        public BulletController(MonoBehaviourManager monoBehaviourManager, BulletPool bulletPool, ResourcesManager resourcesManager, Transform startPoint)
        {
            _model = new BulletModel();
            _view = GameObject.Instantiate(resourcesManager.Cannon, startPoint.position, startPoint.rotation).GetComponent<BulletView>();

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
        }

        #endregion

    }
}
