using UnityEngine;


namespace PiratesGame
{
    public sealed class SceneObjectLinks : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SliderJointView _sliderJointView;

        [SerializeField]
        private Transform _point1;

        [SerializeField]
        private Transform _point2;

        [SerializeField]
        private Transform _spikeBall;

        [SerializeField]
        private Transform[] _airPoints;

        [SerializeField]
        private GhostView _ghostView;

        [SerializeField]
        private CoinView[] _coins;

        #endregion


        #region Properties

        public SliderJointView SliderPlatform => _sliderJointView;
        public Transform CheckPoint1 => _point1;
        public Transform CheckPoint2 => _point2;
        public Transform SpikeBall => _spikeBall;
        public Transform[] AirPoints => _airPoints;
        public GhostView Ghost => _ghostView;
        public CoinView[] Coins => _coins;

        #endregion

    }
}
