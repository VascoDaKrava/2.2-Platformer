using System;
using UnityEngine;


namespace PiratesGame
{
    public abstract class QuestTargetView : MonoBehaviour, IQuestTargetable
    {

        #region Properties

        public Action OnQuestDone;
        public Action OnStepFinish;

        #endregion


        #region IQuestTargetable

        public void QuestDone()
        {
            OnQuestDone?.Invoke();
        }

        public void QuestStepFinish()
        {
            OnStepFinish?.Invoke();
        }

        #endregion

    }
}
