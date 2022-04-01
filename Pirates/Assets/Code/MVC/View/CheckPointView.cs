using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class CheckPointView : MonoBehaviour
    {

        #region Properties

        public Action<Transform> OnTrigger;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTrigger.Invoke(collision.transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTrigger.Invoke(other.transform);
        }

        #endregion

    }
}
