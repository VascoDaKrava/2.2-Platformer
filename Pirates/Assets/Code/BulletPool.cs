using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletPool
    {

        #region Fields

        private Transform _startPoint;
        private Stack<BulletController> _bulletsStack;

        #endregion


        #region ClassLifeCycles

        public BulletPool(int capacity, MonoBehaviourManager monoBehaviourManager, ResourcesManager resourcesManager, Transform startPoint)
        {
            _startPoint = startPoint;

            _bulletsStack = new Stack<BulletController>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                new BulletController(monoBehaviourManager, this, resourcesManager, _startPoint);
            }
        }

        #endregion


        #region Methods

        public void PopFromPool()
        {
            if (_bulletsStack.Count > 0)
            {
                _bulletsStack.Peek().SetActive(true);
                _bulletsStack.Pop();
            }
        }

        public void PushToPool(BulletController bulletController)
        {
            _bulletsStack.Push(bulletController);
        }

        #endregion

    }
}
