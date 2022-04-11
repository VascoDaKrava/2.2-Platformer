using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestLadderTreeView : QuestTargetView
    {

        #region Fields

        [Space]
        [SerializeField]
        private GameObject[] _ladders;

        #endregion


        #region Properties

        public GameObject[] Ladders => _ladders;

        #endregion

    }
}
