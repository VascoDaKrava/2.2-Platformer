using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        public bool IsFly = false;

        #endregion


        #region Properties

        public float AnimationDuration => 0.7f;
        public float GroundLevel => -1.6f;
        public float WalkSpeed => 0.6f;
        public float JumpForce => 300.0f;

        public Vector3 StartPosition => new Vector3(0.0f, GroundLevel, 0.0f);

        #endregion

    }
}
