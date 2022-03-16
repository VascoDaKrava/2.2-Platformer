using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class ResourcesManager
    {

        #region Properties

        public List<Sprite> PirateAttackSprites { get; private set; }
        public List<Sprite> PirateDieSprites { get; private set; }
        public List<Sprite> PirateHurtSprites { get; private set; }
        public List<Sprite> PirateIdleSprites { get; private set; }
        public List<Sprite> PirateJumpSprites { get; private set; }
        public List<Sprite> PirateRunSprites { get; private set; }
        public List<Sprite> PirateWalkSprites { get; private set; }

        public GameObject Pirate { get; private set; }

        public GameObject Cannon { get; private set; }
        public GameObject CannonBall { get; private set; }
        public List<Sprite> ShootSprites { get; private set; }
        public List<Sprite> ExplosionSprites { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourcesManager()
        {
            Pirate = Resources.Load<GameObject>(ResourcesPath.PIRATE);

            PirateAttackSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_ATTACK_ANIMATION).SpriteList);
            PirateDieSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_DIE_ANIMATION).SpriteList);
            PirateHurtSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_HURT_ANIMATION).SpriteList);
            PirateIdleSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_IDLE_ANIMATION).SpriteList);
            PirateJumpSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_JUMP_ANIMATION).SpriteList);
            PirateRunSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_RUN_ANIMATION).SpriteList);
            PirateWalkSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_WALK_ANIMATION).SpriteList);

            Cannon = Resources.Load<GameObject>(ResourcesPath.CANNON);
            CannonBall = Resources.Load<GameObject>(ResourcesPath.CANNON_BALL);

            ShootSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.CANNON_SHOOT_ANIMATION).SpriteList);
            ExplosionSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.EXPLOSION_ANIMATION).SpriteList);
        }

        #endregion

    }
}
