using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        public float VerticalVelocity = 0.0f;
        public bool IsFly = false;

        #endregion


        #region Properties

        public float G => 9.8f;
        public float AnimationDuration => 0.7f;
        public float GroundLevel => -1.6f;
        public float WalkSpeed => 0.6f;
        public float JumpPower => 6.0f;

        public Vector3 StartPosition => new Vector3(0.0f, GroundLevel, 0.0f);

        #endregion

    }
}
