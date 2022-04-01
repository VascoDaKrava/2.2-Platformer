using Pathfinding;
using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class CheckPointChanger : IDisposable, IUpdatable
    {

        #region Fields

        private static float CONTROL_DISTANCE = 0.5f;

        private MonoBehaviourManager _monoBehaviourManager;

        private Transform _checkPoint1;
        private Transform _checkPoint2;
        private Transform _spikeBall;

        private AIDestinationSetter _spikeBallDestinationSetter;

        #endregion


        #region ClassLifeCycles

        public CheckPointChanger(Transform spikeBall, Transform checkPoint1, Transform checkPoint2, MonoBehaviourManager monoBehaviourManager)
        {
            _checkPoint1 = checkPoint1;
            _checkPoint2 = checkPoint2;
            _spikeBall = spikeBall;
            _monoBehaviourManager = monoBehaviourManager;

            _spikeBallDestinationSetter = _spikeBall.GetComponent<AIDestinationSetter>();

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (Vector3.Distance(_spikeBall.position, _checkPoint1.position) <= CONTROL_DISTANCE)
            {
                _spikeBallDestinationSetter.target = _checkPoint2;
            }
            else if (Vector3.Distance(_spikeBall.position, _checkPoint2.position) <= CONTROL_DISTANCE)
            {
                _spikeBallDestinationSetter.target = _checkPoint1;
            }
        }

        public void LetFixedUpdate() { }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }

        #endregion

    }
}
