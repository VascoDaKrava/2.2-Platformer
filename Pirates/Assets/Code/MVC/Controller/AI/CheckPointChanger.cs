using Pathfinding;
using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class CheckPointChanger : IDisposable, IUpdatable
    {

        #region Fields

        private static float CONTROL_DISTANCE = 0.5f;

        private int _currentPointNumber = -1;

        private MonoBehaviourManager _monoBehaviourManager;

        private Transform[] _checkPoints;
        private Transform _spikeBall;

        private AIDestinationSetter _destinationSetter;

        #endregion


        #region ClassLifeCycles

        public CheckPointChanger(Transform spikeBall, Transform [] checkPoints, MonoBehaviourManager monoBehaviourManager)
        {
            _checkPoints = checkPoints;
            _spikeBall = spikeBall;
            _monoBehaviourManager = monoBehaviourManager;

            _destinationSetter = _spikeBall.GetComponent<AIDestinationSetter>();

            SetNextPoint();

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region Methods

        private void SetNextPoint()
        {
            _currentPointNumber = (_currentPointNumber + 1) % _checkPoints.Length;
            _destinationSetter.target = _checkPoints[_currentPointNumber];
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (Vector3.Distance(_spikeBall.position, _checkPoints[_currentPointNumber].position) <= CONTROL_DISTANCE)
            {
                SetNextPoint();
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
