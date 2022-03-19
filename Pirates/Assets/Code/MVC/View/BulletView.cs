using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _explosionSpriteRenderer;

        #endregion


        #region Properties

        public SpriteRenderer SpriteRenderer => _explosionSpriteRenderer;

        #endregion

    }
}
