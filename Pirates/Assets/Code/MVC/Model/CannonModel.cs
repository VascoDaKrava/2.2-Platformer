using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonModel
    {

        #region Fields

        private float _timeToNextShoot = 0.0f;

        /// <summary>
        /// Shots per minute
        /// </summary>
        private float _rateOfFire => 20.0f;

        #endregion


        #region Properties

        public int BulletsInPool => 5;
        public int Layer => Layers.Back;
        public float MaxBurrelAngle => 70.0f;
        public float ShootAnimationDuration => 0.2f;
        public Vector3 StartPosition => new Vector3(2.5f, -0.6f, 0.0f);

        public float TimeToNextShoot
        {
            get => _timeToNextShoot;
            set => _timeToNextShoot = value;
        }

        #endregion


        #region CodeLifeCycles

        public CannonModel()
        {
            ResetTime();
        }

        #endregion


        #region Methods

        public void ResetTime()
        {
            _timeToNextShoot = 60.0f / _rateOfFire;
        }

        #endregion

    }
}
