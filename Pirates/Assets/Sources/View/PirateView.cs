using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateView : MonoBehaviour
    {

        #region Properties

        public SpriteRenderer SpriteRenderer { get; private set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        #endregion

    }
}
