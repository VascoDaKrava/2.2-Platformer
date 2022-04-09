using System;


namespace PiratesGame
{
    public sealed class QuestCoinTowerController : QuestController
    {

        #region Fields

        private int _currentBox;
        private QuestCoinTowerView _towerView;

        #endregion


        #region CodeLifeCycles

        public QuestCoinTowerController(QuestCoinTowerView view) : base(view)
        {
            _towerView = view;
        }

        #endregion


        #region Methods

        public override void OnStepHandler()
        {
            if (_currentBox < _towerView.Boxes.Length)
            {
                _towerView.Boxes[_currentBox].sprite = _towerView.Openbox;
                _currentBox++;
            }
        }

        public override void OnQuestDoneHandler()
        {
            _towerView.TowerBody.constraints = UnityEngine.RigidbodyConstraints2D.None;
        }

        #endregion

    }
}
