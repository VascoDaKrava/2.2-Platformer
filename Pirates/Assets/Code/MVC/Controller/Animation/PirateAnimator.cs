using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateAnimator
    {

        #region Fields

        private AnimationPlayer _animationPlayer;
        private AnimationType _currentAnimationState;

        private PirateModel _model;

        private Dictionary<AnimationType, List<Sprite>> _animations;

        #endregion


        #region Properties

        public event Action AnimationPlayFinished
        {
            add
            {
                _animationPlayer.AnimationPlayFinished += value;
            }

            remove
            {
                _animationPlayer.AnimationPlayFinished -= value;
            }
        }

        public AnimationType AnimationState
        {
            get => _currentAnimationState;

            set
            {
                if (value != _currentAnimationState)
                {
                    switch (value)
                    {
                        case AnimationType.None:
                            break;

                        case AnimationType.Attack:
                            break;

                        case AnimationType.Die:
                            _animationPlayer.ChangeAnimation(_animations[AnimationType.Die], _model.AnimationDurationDie, false);
                            break;

                        case AnimationType.Hurt:
                            break;

                        case AnimationType.Idle:
                            _animationPlayer.ChangeAnimation(_animations[AnimationType.Idle], _model.AnimationDurationIdle, true);
                            break;

                        case AnimationType.Jump:
                            _animationPlayer.ChangeAnimation(_animations[AnimationType.Jump], _model.AnimationDurationDie, false);
                            break;

                        case AnimationType.Run:
                            break;

                        case AnimationType.Walk:
                            _animationPlayer.ChangeAnimation(_animations[AnimationType.Walk], _model.AnimationDurationWalk, true);
                            break;

                        default:
                            break;
                    }
                    _currentAnimationState = value;
                    _animationPlayer.Play = true;
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public PirateAnimator(
            ResourcesManager resources,
            PirateModel model,
            SpriteRenderer spriteRenderer,
            MonoBehaviourManager monoBehaviourManager)
        {
            _animations = new Dictionary<AnimationType, List<Sprite>>();
            _animations.Add(AnimationType.Attack, resources.PirateAttackSprites);
            _animations.Add(AnimationType.Die, resources.PirateDieSprites);
            _animations.Add(AnimationType.Hurt, resources.PirateHurtSprites);
            _animations.Add(AnimationType.Idle, resources.PirateIdleSprites);
            _animations.Add(AnimationType.Jump, resources.PirateJumpSprites);
            _animations.Add(AnimationType.Run, resources.PirateRunSprites);
            _animations.Add(AnimationType.Walk, resources.PirateWalkSprites);

            _model = model;

            _animationPlayer = new AnimationPlayer(spriteRenderer, monoBehaviourManager);

            AnimationState = AnimationType.Idle;
        }

        #endregion

    }
}
