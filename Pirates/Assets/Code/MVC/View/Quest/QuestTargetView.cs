using System;
using UnityEngine;


namespace PiratesGame
{
    public abstract class QuestTargetView : MonoBehaviour, IQuestTargetable
    {

        #region Properties

        public Action OnQuestDone;
        public Action OnStepFinish;
        public Action<int> OnStepFinishInt;

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

        public void QuestStepFinish(int activatorID)
        {
            OnStepFinishInt?.Invoke(activatorID);
        }

        #endregion

    }
}
