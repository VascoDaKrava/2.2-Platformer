using System;
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
        public Action<GameObject> OnTriggerStay { get; set; }
        public Action<GameObject> OnTriggerExit { get; set; }

        #endregion


        #region UnityMethods

        private void OnTriggerStay2D(Collider2D collision)
        {
            OnTriggerStay?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            OnTriggerExit?.Invoke(collision.gameObject);
        }

        #endregion

    }
}
