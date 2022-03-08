using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateView : MonoBehaviour
    {

        #region Properties

        public SpriteRenderer SpriteRenderer { get; private set; }

        #endregion


        #region UnityMethods

        private void Start()
        {
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        #endregion

    }
}
