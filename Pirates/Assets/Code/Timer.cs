using System;
using System.Collections;
using UnityEngine;


namespace PiratesGame
{
    public sealed class Timer : MonoBehaviour
    {

        #region Fields

        private event Action _timerFinishedEvent;

        #endregion


        #region Properties

        public event Action TimerFinishedEvent
        {
            add { _timerFinishedEvent += value; }
            remove { _timerFinishedEvent -= value; }
        }

        #endregion


        #region UnityMethods

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSecondsRealtime(time);
            _timerFinishedEvent.Invoke();
        }

        #endregion


        #region Methods

        public void StartTimer(float time)
        {
            StartCoroutine(Wait(time));
        }

        #endregion

    }
}
