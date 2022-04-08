using System;


namespace PiratesGame
{
    public abstract class QuestController : IDisposable
    {

        #region Fields

        protected int _currentStep;
        protected QuestTargetView _targetView;

        #endregion


        #region CodeLifeCycles

        public QuestController(QuestTargetView view)
        {
            _targetView = view;

            _targetView.OnStepFinish += OnStepHandler;
            _targetView.OnQuestDone += OnQuestDoneHandler;
        }

        #endregion


        #region Methods

        public virtual void OnStepHandler()
        {
        }

        public virtual void OnQuestDoneHandler()
        {
            Dispose();
        }

        #endregion


        #region IDisposable

        public virtual void Dispose()
        {
            _targetView.OnStepFinish -= OnStepHandler;
            _targetView.OnQuestDone -= OnQuestDoneHandler;
        }

        #endregion

    }
}
