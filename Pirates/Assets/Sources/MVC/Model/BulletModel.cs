namespace PiratesGame
{
    public sealed class BulletModel
    {

        #region Fields

        public float VerticalVelocity = 0.0f;
        public float HorizontalVelocity = 0.0f;
        public bool IsFly = true;

        #endregion


        #region Properties

        public float G => 9.8f;
        public float BulletSpeed => 5.0f;
        public float ExplosionAnimationDuration => 0.2f;
        public float GroundLevel => -1.6f;
        public float ReboundFactor => 0.7f;
        public float TimeToLive => 7.0f;

        #endregion

    }
}
