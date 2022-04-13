using UnityEngine;


namespace PiratesGame
{
    public sealed class ParallaxView : MonoBehaviour
    {

        #region Fields

        [Space]
        [SerializeField]
        private GameObject _background;

        [Space]
        [SerializeField]
        private float _offsetX;

        #endregion


        #region Properties

        public GameObject Background => _background;
        public float OffsetX => _offsetX;

        #endregion

    }
}
