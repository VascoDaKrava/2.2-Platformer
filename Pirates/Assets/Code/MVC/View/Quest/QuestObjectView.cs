using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestObjectView : MonoBehaviour
    {

        #region Properties

        public Action<GameObject> OnEnterred;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnterred?.Invoke(collision.gameObject);
        }

        #endregion

    }
}
