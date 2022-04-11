using UnityEngine;


namespace PiratesGame
{
    public sealed class SceneObjectLinks : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SliderJointView _sliderJointView;

        [Space]
        [SerializeField]
        private Transform[] _groundPoints;

        [SerializeField]
        private Transform _spikeBall;

        [Space]
        [SerializeField]
        private Transform[] _airPoints;

        [SerializeField]
        private GhostView _ghostView;

        [Space]
        [SerializeField]
        private CoinView[] _coins;

        [Space]
        [SerializeField]
        private QuestCoinTowerView _questCoinTowerView;

        [Space]
        [SerializeField]
        private QuestLadderTreeView _questLadderTreeView;

        #endregion


        #region Properties

        public SliderJointView SliderPlatform => _sliderJointView;
        public Transform[] GroundPoints => _groundPoints;
        public Transform SpikeBall => _spikeBall;
        public Transform[] AirPoints => _airPoints;
        public GhostView Ghost => _ghostView;
        public CoinView[] Coins => _coins;
        public QuestCoinTowerView TowerView => _questCoinTowerView;
        public QuestLadderTreeView LadderTreeView => _questLadderTreeView;


        #endregion

    }
}
