using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class ParallaxController : IUpdatable, IDisposable
    {

        #region Fields

        private int _imagesQuantity = 3;

        private float _offsetX;
        private Transform _camera;
        private GameObject[] _backGrounds;

        private MonoBehaviourManager _monoBehaviourManager;

        #endregion


        #region CodeLifeCycles

        public ParallaxController(ParallaxView view, Camera camera, MonoBehaviourManager monoBehaviourManager)
        {
            _camera = camera.transform;
            _offsetX = view.OffsetX;
            _monoBehaviourManager = monoBehaviourManager;

            _backGrounds = new GameObject[_imagesQuantity];

            CreateParallax(view, ref _backGrounds);

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region Methods

        private void CreateParallax(ParallaxView background, ref GameObject[] parallax)
        {
            for (int i = 0; i < parallax.Length; i++)
            {
                parallax[i] = GameObject.Instantiate(background.gameObject);
            }

            Move(parallax[0], -_offsetX);
            Move(parallax[2], _offsetX);
        }

        private void Move(GameObject image, float offsetX)
        {
            image.transform.position = new Vector3(image.transform.position.x + offsetX, image.transform.position.y, image.transform.position.z);
        }

        private void Move(GameObject[] images, float offsetX)
        {
            foreach (var image in images)
            {
                image.transform.position = new Vector3(image.transform.position.x + offsetX, image.transform.position.y, image.transform.position.z);
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (_camera.position.x - _backGrounds[0].transform.position.x < 0)
            {
                Move(_backGrounds, -_offsetX);
            }
            else
            {
                if (_backGrounds[2].transform.position.x - _camera.position.x < 0)
                {
                    Move(_backGrounds, _offsetX);
                }
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
