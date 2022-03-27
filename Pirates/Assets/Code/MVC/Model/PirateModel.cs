using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        private float _animationSynCoefficient = 0.6f / 0.7f;
        public bool isGrounded = false;

        #endregion


        #region Properties

        public float AnimationDurationIdle => 0.7f;
        public float WalkSpeed => 2.0f;
        public float AnimationDurationWalk => WalkSpeed * AnimationDurationIdle * _animationSynCoefficient;
        public float JumpForce => 300.0f;

        public Vector3 StartPosition => new Vector3(0.0f, 2.0f, 0.0f);

        #endregion

    }
}
