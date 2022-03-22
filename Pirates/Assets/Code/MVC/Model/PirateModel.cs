using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Fields

        public bool isGrounded = false;

        #endregion


        #region Properties

        public float AnimationDuration => 0.7f;
        public float WalkSpeed => 0.6f;
        public float JumpForce => 300.0f;

        public Vector3 StartPosition => new Vector3(0.0f, 2.0f, 0.0f);

        #endregion

    }
}
