using System;
using Pathfinding;
using UnityEngine;


namespace PiratesGame
{
    public sealed class GhostController : IUpdatable, IDisposable
    {

        #region Fields

        private int _currentPointNumber = -1;

        private MonoBehaviourManager _monoBehaviourManager;

        private GhostModel _ghostModel;
        private GhostView _ghostView;
        private Transform[] _airPoints;
        private AIPath _path;
        private AIDestinationSetter _destinationSetter;
        private SpriteRenderer _ghostSpriteRenderer;

        #endregion


        #region ClassLifeCycles

        public GhostController(Transform[] airPoints, GhostView ghostView, MonoBehaviourManager monoBehaviourManager)
        {
            _airPoints = airPoints;
            _ghostView = ghostView;
            _monoBehaviourManager = monoBehaviourManager;

            _ghostModel = new GhostModel();

            _path = _ghostView.Path;
            _destinationSetter = _ghostView.DestinationSetter;
            _ghostSpriteRenderer = _ghostView.SpriteRenderer;

            SetNextPoint();

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
            _ghostView.OnTriggerEnter += CatchPlayer;
            _ghostView.OnTriggerExit += LosePlayer;
        }

        #endregion


        #region Methods

        private void CatchPlayer(Collider2D other)
        {
            if (other.CompareTag(TagsAndLayers.TAG_PLAYER))
            {
                _ghostModel.IsCatchPlayer = true;
                _ghostSpriteRenderer.color = _ghostModel.Color;
                _destinationSetter.target = other.transform;
            }
        }

        private void LosePlayer(Collider2D other)
        {
            if (other.CompareTag(TagsAndLayers.TAG_PLAYER))
            {
                _ghostModel.IsCatchPlayer = false;
                _ghostSpriteRenderer.color = _ghostModel.Color;
                _destinationSetter.target = _airPoints[_currentPointNumber];
            }
        }

        private void SetNextPoint()
        {
            _currentPointNumber = (_currentPointNumber + 1) % _airPoints.Length;
            _destinationSetter.target = _airPoints[_currentPointNumber];
        }

        private void CorrectViewOnDirection()
        {
            _ghostSpriteRenderer.flipX = _path.velocity.x >= 0;
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (_path.reachedDestination && !_ghostModel.IsCatchPlayer)
            {
                SetNextPoint();
            }

            CorrectViewOnDirection();
        }

        public void LetFixedUpdate() { }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
            _ghostView.OnTriggerEnter -= CatchPlayer;
            _ghostView.OnTriggerExit -= LosePlayer;
        }

        #endregion

    }
}
