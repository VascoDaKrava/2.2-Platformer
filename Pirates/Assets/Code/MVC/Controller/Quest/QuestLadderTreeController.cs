namespace PiratesGame
{
    public sealed class QuestLadderTreeController : QuestController
    {

        #region Fields

        private QuestLadderTreeView _ladderTreeView;

        #endregion


        #region CodeLifeCycles

        public QuestLadderTreeController(QuestLadderTreeView view) : base(view)
        {
            _ladderTreeView = view;
        }

        #endregion


        #region Methods

        public override void OnStepHandler()
        {
            //if (_ladderTreeView.)
        }

        public override void OnQuestDoneHandler()
        {

        }

        #endregion

    }
}
