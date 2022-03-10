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

        #endregion


        #region ClassLifeCycles

        public ResourcesManager()
        {
            Pirate = Resources.Load<GameObject>(ResourcesPath.PIRATE);

            PirateAttackSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_ATTACK).SpriteList);
            PirateDieSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_DIE).SpriteList);
            PirateHurtSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_HURT).SpriteList);
            PirateIdleSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_IDLE).SpriteList);
            PirateJumpSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_JUMP).SpriteList);
            PirateRunSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_RUN).SpriteList);
            PirateWalkSprites = new List<Sprite>(Resources.Load<AnimationsSO>(ResourcesPath.PIRATE_WALK).SpriteList);
        }

        #endregion

    }
}
