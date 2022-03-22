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

        private const string FILE_ANIMATION_COIN = "CoinAnimations";

        public const string PIRATE = "Player";
        public const string CANNON = "Cannon";
        public const string CANNON_BALL = "CannonBall";

        #endregion


        #region Properties

        public static string PIRATE_ATTACK_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_ATTACK);
        public static string PIRATE_DIE_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_DIE);
        public static string PIRATE_HURT_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_HURT);
        public static string PIRATE_IDLE_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_IDLE);
        public static string PIRATE_JUMP_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_JUMP);
        public static string PIRATE_RUN_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_RUN);
        public static string PIRATE_WALK_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_PIRATE_WALK);

        public static string CANNON_SHOOT_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_SHOOT);
        public static string EXPLOSION_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_EXPLOSION);

        public static string COIN_ANIMATION => Path.Combine(FOLDER_ANIMATION, FILE_ANIMATION_COIN);

        #endregion

    }
}
