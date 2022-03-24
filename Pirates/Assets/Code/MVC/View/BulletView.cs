using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _explosionSpriteRenderer;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        #endregion


        #region Properties

        public SpriteRenderer SpriteRenderer => _explosionSpriteRenderer;
        public Rigidbody2D BulletRigidbody => _rigidbody;

        #endregion

    }
}
