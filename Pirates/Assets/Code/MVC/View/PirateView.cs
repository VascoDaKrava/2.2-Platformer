using System;
using UnityEngine;


namespace PiratesGame
{
    [RequireComponent(typeof(Timer))]
    public sealed class PirateView : MonoBehaviour
    {

        #region Fields

        public Action<Vector2> OnAddExtraVelocity;
        public Action<GameObject> OnTriggerEvent;

        [SerializeField]
        private SpriteRenderer _bodySpriteRenderer;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        #endregion


        #region Properties

        public Vector2 ExtraVelocity { get; set; }
        public Rigidbody2D PlayerRigidbody => _rigidbody;
        public SpriteRenderer PlayerSpriteRenderer => _bodySpriteRenderer;
        public Timer Timer { get; private set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            Timer = GetComponent<Timer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEvent?.Invoke(collision.gameObject);
        }

        #endregion

    }
}
