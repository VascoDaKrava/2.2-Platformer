using System.IO;


namespace PiratesGame
{
    /// <summary>
    /// Contain path to resources
    /// </summary>
    public static class ResourcesPath
    {

        #region Fields

        private const string FOLDER_ANIMATION = "Animations";

        private const string FILE_ANIMATION_PIRATE_ATTACK = "PirateAnimationsAttack";
        private const string FILE_ANIMATION_PIRATE_DIE = "PirateAnimationsDie";
        private const string FILE_ANIMATION_PIRATE_HURT = "PirateAnimationsHurt";
        private const string FILE_ANIMATION_PIRATE_IDLE = "PirateAnimationsIdle";
        private const string FILE_ANIMATION_PIRATE_JUMP = "PirateAnimationsJump";
        private const string FILE_ANIMATION_PIRATE_RUN = "PirateAnimationsRun";
        private const string FILE_ANIMATION_PIRATE_WALK = "PirateAnimationsWalk";

        private const string FILE_ANIMATION_SHOOT = "ShootAnimations";
        private const string FILE_ANIMATION_EXPLOSION = "ExplosionAnimations";

        public const string PIRATE = "Player";
        public const string CANNON = "Cannon";

        #endregion


        #region Properties

        public static string PIRATE_ATTACK => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_ATTACK);
        public static string PIRATE_DIE => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_DIE);
        public static string PIRATE_HURT => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_HURT);
        public static string PIRATE_IDLE => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_IDLE);
        public static string PIRATE_JUMP => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_JUMP);
        public static string PIRATE_RUN => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_RUN);
        public static string PIRATE_WALK => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_WALK);

        public static string CANNON_SHOOT => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_SHOOT);
        public static string EXPLOSION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_EXPLOSION);

        #endregion

    }
}
