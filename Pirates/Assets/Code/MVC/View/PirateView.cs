using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _bodySpriteRenderer;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        #endregion


        #region Properties

        public SpriteRenderer PlayerSpriteRenderer => _bodySpriteRenderer;
        public Rigidbody2D PlayerRigidbody => _rigidbody;
        public Action<GameObject> OnTriggerEvent { get; set; }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject);
            OnTriggerEvent?.Invoke(collision.gameObject);
        }

        #endregion

    }
}
