using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class CameraController : IUpdatable, IDisposable
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;
        private Transform _playerTransform;
        private Camera _camera;

        #endregion


        #region CodeLifeCycles

        public CameraController(MonoBehaviourManager monoBehaviourManager, Transform playerTransfom, Camera camera)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _playerTransform = playerTransfom;
            _camera = camera;

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            _camera.transform.position = new Vector3(_playerTransform.position.x, _camera.transform.position.y, _camera.transform.position.z);
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
