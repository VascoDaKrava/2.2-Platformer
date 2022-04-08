using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestCoinTowerView : QuestTargetView
    {

        #region Fields

        [Space]
        [SerializeField]
        private SpriteRenderer[] _boxes;

        [Space]
        [SerializeField]
        private Sprite _openbox;

        [Space]
        [SerializeField]
        private Rigidbody2D _body;

        #endregion


        #region Properties

        public SpriteRenderer[] Boxes => _boxes;

        public Sprite Openbox => _openbox;
        public Rigidbody2D TowerBody => _body;

        #endregion

    }
}
