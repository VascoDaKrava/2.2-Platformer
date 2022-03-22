using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        private float _animationSynCoefficient = 0.6f;

        public bool isGrounded = false;
        public bool isMotorStop = false;

        #endregion


        #region Properties

        public float AnimationDurationIdle => 0.7f;
        public float AnimationDurationWalk => _animationSynCoefficient / WalkSpeed;
        public float AnimationDurationDie => 0.5f;
        public float WalkSpeed => 2.0f;
        public float JumpForce => 300.0f;

        public Vector3 StartPosition => new Vector3(0.0f, 2.0f, 0.0f);

        #endregion

    }
}
