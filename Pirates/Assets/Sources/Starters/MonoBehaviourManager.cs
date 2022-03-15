using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class MonoBehaviourManager : MonoBehaviour
    {

        #region Fields

        private List<IUpdatable> _updatables;
        private List<IUpdatable> _candidatsForAddingToUpdatables;
        private List<IUpdatable> _candidatsForRemovingFromUpdatables;
        private RootStarter _rootStarter;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _updatables = new List<IUpdatable>();
            _candidatsForAddingToUpdatables = new List<IUpdatable>();
            _candidatsForRemovingFromUpdatables = new List<IUpdatable>();

            _rootStarter = new RootStarter(this);
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables)
            {
                item.LetUpdate();
            }
        }

        private void LateUpdate()
        {
            if (_candidatsForAddingToUpdatables.Count > 0)
            {
                _updatables.AddRange(_candidatsForAddingToUpdatables);
                _candidatsForAddingToUpdatables.Clear();
            }

            if (_candidatsForRemovingFromUpdatables.Count > 0)
            {
                foreach (IUpdatable item in _candidatsForRemovingFromUpdatables)
                {
                    _updatables.Remove(item);
                }
                _candidatsForRemovingFromUpdatables.Clear();
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Add item to list for Update (in the current LateUpdate)
        /// </summary>
        /// <param name="updatableObject"></param>
        public void AddToUpdateList(IUpdatable updatableObject)
        {
            _candidatsForAddingToUpdatables.Add(updatableObject);
        }

        /// <summary>
        /// Remove item from list for Update
        /// </summary>
        /// <param name="updatableObject"></param>
        public void RemoveFromUpdateList(IUpdatable updatableObject)
        {
            _candidatsForRemovingFromUpdatables.Add(updatableObject);
        }

        #endregion

    }
}