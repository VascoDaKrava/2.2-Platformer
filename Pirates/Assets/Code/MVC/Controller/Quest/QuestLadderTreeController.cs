using System;


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

    }
}
