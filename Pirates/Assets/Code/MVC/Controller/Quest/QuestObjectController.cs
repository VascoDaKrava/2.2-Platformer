using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestObjectController : IQuestable, IDisposable
    {

        #region Fields

        private IQuestCheckable _questChecker;
        private QuestObjectView _questObjectView;

        #endregion


        #region Properties

        public event Action<IQuestable, QuestObjectView> Completed;
        public bool IsCompete { get; private set; }

        #endregion


        #region CodeLifeCycles

        public QuestObjectController(IQuestCheckable questCheckable, QuestObjectView questObjectView)
        {
            _questChecker = questCheckable;
            _questObjectView = questObjectView;

            _questObjectView.OnEnterred += OnEnterredQuestObject;
        }

        #endregion


        #region Methods

        public void ResetQuest()
        {
            IsCompete = false;
            _questObjectView.OnEnterred += OnEnterredQuestObject;
        }

        private void OnEnterredQuestObject(GameObject activator, QuestObjectView caller)
        {
            if (_questChecker.TryComplete(activator))
            {
                IsCompete = true;
                Completed?.Invoke(this, caller);
                Dispose();
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _questObjectView.OnEnterred -= OnEnterredQuestObject;
        }

        #endregion

    }
}
