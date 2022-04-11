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

            foreach (var ladder in _ladderTreeView.Ladders)
            {
                ladder.SetActive(false);
            }
        }

        #endregion


        #region Methods

        public override void OnChainStepHandler(int activatorID)
        {
            _ladderTreeView.Ladders[activatorID].SetActive(true);
        }

        #endregion

    }
}
