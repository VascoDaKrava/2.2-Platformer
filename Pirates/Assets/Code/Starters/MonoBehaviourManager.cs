using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class MonoBehaviourManager : MonoBehaviour
    {

        #region Fields

        private Dictionary<UpdatableTypes, List<IUpdatable>> _updatables;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _updatables = new Dictionary<UpdatableTypes, List<IUpdatable>>();
            _updatables.Add(UpdatableTypes.Update, new List<IUpdatable>());
            _updatables.Add(UpdatableTypes.FixedUpdate, new List<IUpdatable>());
            _updatables.Add(UpdatableTypes.AddCandidateUpdate, new List<IUpdatable>());
            _updatables.Add(UpdatableTypes.RemoveCandidateUpdate, new List<IUpdatable>());
            _updatables.Add(UpdatableTypes.AddCandidateUpdateFixed, new List<IUpdatable>());
            _updatables.Add(UpdatableTypes.RemoveCandidateUpdateFixed, new List<IUpdatable>());

            new RootStarter(this);
        }

        private void Update()
        {
            foreach (IUpdatable item in _updatables[UpdatableTypes.Update])
            {
                item.LetUpdate();
            }
        }

        private void FixedUpdate()
        {
            foreach (IUpdatable item in _updatables[UpdatableTypes.FixedUpdate])
            {
                item.LetFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            foreach (KeyValuePair<UpdatableTypes, List<IUpdatable>> pair in _updatables)
            {
                if (pair.Value.Count > 0)
                {
                    switch (pair.Key)
                    {
                        case UpdatableTypes.AddCandidateUpdate:
                            _updatables[UpdatableTypes.Update].AddRange(pair.Value);
                            pair.Value.Clear();
                            break;

                        case UpdatableTypes.RemoveCandidateUpdate:
                            foreach (IUpdatable item in _updatables[pair.Key])
                            {
                                if (_updatables[UpdatableTypes.Update].Contains(item))
                                {
                                    _updatables[UpdatableTypes.Update].Remove(item);
                                }
                            }
                            _updatables[pair.Key].Clear();
                            break;

                        case UpdatableTypes.AddCandidateUpdateFixed:
                            _updatables[UpdatableTypes.FixedUpdate].AddRange(pair.Value);
                            pair.Value.Clear();
                            break;

                        case UpdatableTypes.RemoveCandidateUpdateFixed:
                            foreach (IUpdatable item in _updatables[pair.Key])
                            {
                                if (_updatables[UpdatableTypes.FixedUpdate].Contains(item))
                                {
                                    _updatables[UpdatableTypes.FixedUpdate].Remove(item);
                                }
                            }
                            _updatables[pair.Key].Clear();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Add/remove item to/from list for Update/FixedUpdate (in the current LateUpdate)
        /// </summary>
        /// <param name="updatableObject">IUpdatable object to add/remove</param>
        /// <param name="updatableType">Type of list</param>
        public void ChangeUpdateList(IUpdatable updatableObject, UpdatableTypes updatableType)
        {
            _updatables[updatableType].Add(updatableObject);
        }

        #endregion

    }
}