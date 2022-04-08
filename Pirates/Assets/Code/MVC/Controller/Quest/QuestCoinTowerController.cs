using System;


namespace PiratesGame
{
    public sealed class QuestCoinTowerController : IDisposable
    {

        #region Fields

        private int _currentBox;
        private QuestCoinTowerView _towerView;

        #endregion


        #region CodeLifeCycles

        public QuestCoinTowerController(QuestCoinTowerView view)
        {
            _towerView = view;

            _towerView.OnStepFinish += OnStepHandler;
            _towerView.OnQuestDone += OnQuestDoneHandler;
        }

        #endregion


        #region Methods

        private void OnStepHandler()
        {
            if (_currentBox < _towerView.Boxes.Length)
            {
                _towerView.Boxes[_currentBox].sprite = _towerView.Openbox;
                _currentBox++;
            }
        }

        private void OnQuestDoneHandler()
        {
            _towerView.TowerBody.constraints = UnityEngine.RigidbodyConstraints2D.None;
            Dispose();
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _towerView.OnStepFinish -= OnStepHandler;
            _towerView.OnQuestDone -= OnQuestDoneHandler;
        }

        #endregion

    }
}
