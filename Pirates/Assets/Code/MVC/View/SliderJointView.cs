using UnityEngine;


namespace PiratesGame
{
    public sealed class SliderJointView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SliderJoint2D _sliderJoint;

        #endregion


        #region Properties

        public SliderJoint2D PlatformSliderJoint => _sliderJoint;

        #endregion

    }
}
