using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _bodySpriteRenderer;

        #endregion


        #region Properties

        public SpriteRenderer SpriteRenderer => _bodySpriteRenderer;

        #endregion

    }
}
