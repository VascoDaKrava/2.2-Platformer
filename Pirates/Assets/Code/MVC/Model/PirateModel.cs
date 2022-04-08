using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        public bool isGrounded = false;
        public bool isMotorStop = false;

        private float _animationSynCoefficient = 0.6f;

        #endregion


        #region Properties

        public int FrameSkipForJumpCheck => Mathf.RoundToInt(JumpForce / -Physics2D.gravity.y);
        public float AnimationDurationDie => 0.5f;
        public float AnimationDurationIdle => 0.7f;
        public float AnimationDurationWalk => _animationSynCoefficient / WalkSpeed;
        public float TimeToReset => 3.5f;
        public float WalkSpeed => 2.0f;
        public float JumpForce => 300.0f;

        public Vector3 StartPosition => new Vector3(0.0f, 6.0f, 0.0f);

        #endregion

    }
}
