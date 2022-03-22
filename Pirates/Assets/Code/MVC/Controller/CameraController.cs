using UnityEngine;


namespace PiratesGame
{
    public sealed class CameraController : IUpdatable
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;
        private Transform _playerTransform;
        private Camera _camera;

        #endregion


        #region CodeLifeCycles

        public CameraController(MonoBehaviourManager monoBehaviourManager, Transform playerTransfom)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _playerTransform = playerTransfom;
            _camera = Camera.main;

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        ~CameraController()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }
        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            _camera.transform.position = new Vector3(_playerTransform.position.x, _camera.transform.position.y, _camera.transform.position.z);
        }

        public void LetFixedUpdate() { }

        #endregion

    }
}
