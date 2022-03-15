using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateModel
    {

        #region Properties

        public float AnimationFrameInterval => 0.1f;
        public float Speed => 0.6f;
        public float GroundLevel => -0.6f;

        public Vector3 StartPosition = new Vector3(0.0f, -0.6f, 0.0f);

        #endregion

    }
}
