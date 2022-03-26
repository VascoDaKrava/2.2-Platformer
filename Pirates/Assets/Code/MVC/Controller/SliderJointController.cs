using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class SliderJointController : IUpdatable, IDisposable
    {

        #region Fields

        private JointMotor2D _motor;
        private MonoBehaviourManager _monoBehaviourManager;

        private SliderJoint2D _sliderJoint;
        private SliderJointView _sliderJointView;

        #endregion


        #region CodeLifeCycles

        public SliderJointController(MonoBehaviourManager monoBehaviourManager, SliderJointView sliderView)
        {
            _sliderJointView = sliderView;
            _monoBehaviourManager = monoBehaviourManager;

            _sliderJoint = _sliderJointView.PlatformSliderJoint;
            _motor = _sliderJoint.motor;

            _sliderJointView.OnTriggerStay += OnTriggerStayHandle;
            _sliderJointView.OnTriggerExit += OnTriggerExitHandle;
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region Methods

        private void OnTriggerStayHandle(GameObject otherGameObject)
        {
            SetRemoteVelocity(otherGameObject, _sliderJoint.attachedRigidbody.velocity);
        }

        private void OnTriggerExitHandle(GameObject otherGameObject)
        {
            SetRemoteVelocity(otherGameObject, Vector2.zero);
        }

        private void SetRemoteVelocity(GameObject otherGameObject, Vector2 velocity)
        {
            if (otherGameObject.TryGetComponent<PirateView>(out PirateView playerView))
            {
                playerView.ExtraVelocity = velocity;
            }
            else
            {
                if (otherGameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D otherRigidBody))
                {
                    otherRigidBody.velocity = velocity;
                }
            }
        }

        private void ChangeMotorSpeedDirection()
        {
            if (_sliderJoint.limitState == JointLimitState2D.LowerLimit && _motor.motorSpeed < 0.0f ||
                _sliderJoint.limitState == JointLimitState2D.UpperLimit && _motor.motorSpeed > 0.0f)
            {
                _motor.motorSpeed = -_motor.motorSpeed;
                _sliderJoint.motor = _motor;
            }
        }

        #endregion


        #region IUpdatable

        public void LetFixedUpdate() { }

        public void LetUpdate()
        {
            ChangeMotorSpeedDirection();
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _sliderJointView.OnTriggerStay -= OnTriggerStayHandle;
            _sliderJointView.OnTriggerExit -= OnTriggerExitHandle;
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }

        #endregion

    }
}
