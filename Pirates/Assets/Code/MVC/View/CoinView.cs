using UnityEngine;


namespace PiratesGame
{
    public sealed class CoinView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        #endregion


        #region Properties

        public SpriteRenderer CoinSpriteRenderer => _spriteRenderer;

        #endregion

    }
}
