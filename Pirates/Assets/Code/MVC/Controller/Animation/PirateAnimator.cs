using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateAnimator
    {

        #region Fields

        private float _idleAnimationDuration;
        private float _walkAnimationDuration;

        private AnimationPlayer _animationPlayer;
        private AnimationTypes _animationState;

        private Dictionary<AnimationTypes, List<Sprite>> _animations;

        #endregion


        #region Properties

        public AnimationTypes AnimationState
        {
            get { return _animationState; }
            set
            {
                if (_animationState != value && _animationPlayer.IsLoop)
                {
                    switch (value)
                    {
                        case AnimationTypes.None:
                            break;

                        case AnimationTypes.Attack:
                            break;

                        case AnimationTypes.Die:
                            break;

                        case AnimationTypes.Hurt:
                            break;

                        case AnimationTypes.Idle:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Idle];
                            _animationPlayer.AnimationDuration = _idleAnimationDuration;
                            _animationPlayer.IsLoop = true;
                            break;

                        case AnimationTypes.Jump:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Jump];
                            _animationPlayer.AnimationDuration = _idleAnimationDuration;
                            _animationPlayer.IsLoop = false;
                            break;

                        case AnimationTypes.Run:
                            break;

                        case AnimationTypes.Walk:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Walk];
                            _animationPlayer.AnimationDuration = _walkAnimationDuration;
                            _animationPlayer.IsLoop = true;
                            break;

                        default:
                            break;
                    }
                    _animationState = value;
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public PirateAnimator(
            ResourcesManager resources,
            float animationDurationIdle,
            float animationDurationWalk,
            SpriteRenderer spriteRenderer,
            MonoBehaviourManager monoBehaviourManager)
        {
            _animations = new Dictionary<AnimationTypes, List<Sprite>>();
            _animations.Add(AnimationTypes.Attack, resources.PirateAttackSprites);
            _animations.Add(AnimationTypes.Die, resources.PirateDieSprites);
            _animations.Add(AnimationTypes.Hurt, resources.PirateHurtSprites);
            _animations.Add(AnimationTypes.Idle, resources.PirateIdleSprites);
            _animations.Add(AnimationTypes.Jump, resources.PirateJumpSprites);
            _animations.Add(AnimationTypes.Run, resources.PirateRunSprites);
            _animations.Add(AnimationTypes.Walk, resources.PirateWalkSprites);

            _idleAnimationDuration = animationDurationIdle;
            _walkAnimationDuration = animationDurationWalk;

            _animationPlayer = new AnimationPlayer(_idleAnimationDuration, spriteRenderer, _animations[AnimationTypes.Idle], monoBehaviourManager);
            _animationPlayer.Play = true;

            _animationPlayer.AnimationPlayFinished += AnimationOnePlayFinishedEventHandler;

            _animationState = AnimationTypes.Idle;
        }

        ~PirateAnimator()
        {
            _animationPlayer.AnimationPlayFinished -= AnimationOnePlayFinishedEventHandler;
        }

        #endregion


        #region Methods

        private void AnimationOnePlayFinishedEventHandler()
        {
            _animationPlayer.IsLoop = true;
            AnimationState = AnimationTypes.Idle;
        }

        #endregion

    }
}
