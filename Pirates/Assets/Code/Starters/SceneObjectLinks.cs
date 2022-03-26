using UnityEngine;


namespace PiratesGame
{
    public sealed class SceneObjectLinks : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private GameObject _sliderPlatform;

        #endregion


        #region Properties

        public GameObject SliderPlatform => _sliderPlatform;

        #endregion

    }
}
