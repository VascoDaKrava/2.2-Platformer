using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletController : IUpdatable
    {

        #region Properties

        public bool SetActive;

        public Transform SetStartPoint;

        #endregion


        #region ClassLifeCycles

        public BulletController(MonoBehaviourManager monoBehaviourManager, BulletPool bulletPool)
        {
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
