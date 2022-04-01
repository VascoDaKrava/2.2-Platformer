using UnityEngine;


namespace PiratesGame
{
    public sealed class SceneObjectLinks : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private GameObject _sliderPlatform;

        [SerializeField]
        private Transform _point1;

        [SerializeField]
        private Transform _point2;

        [SerializeField]
        private Transform _spikeBall;

        #endregion


        #region Properties

        public GameObject SliderPlatform => _sliderPlatform;
        public Transform CheckPoint1 => _point1;
        public Transform CheckPoint2 => _point2;
        public Transform SpikeBall => _spikeBall;

        #endregion

    }
}
