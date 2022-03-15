using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonModel
    {

        #region Fields

        public float TimeToNextShoot = 0.0f;

        #endregion


        #region Properties

        public int BulletsInPool => 10;
        public float MaxBurrelAngle => 70.0f;

        /// <summary>
        /// Shots per minute
        /// </summary>
        public float RateOfFire => 20.0f;
        
        public Vector3 StartPosition => new Vector3(2.5f, -0.6f, 0.0f);

        #endregion

    }
}
