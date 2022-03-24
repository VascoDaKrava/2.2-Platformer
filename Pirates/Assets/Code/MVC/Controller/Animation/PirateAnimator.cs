using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateAnimator
    {

        #region Fields

        private AnimationPlayer _animationPlayer;
        private AnimationTypes _currentAnimationState;

        private PirateModel _model;

        private Dictionary<AnimationTypes, List<Sprite>> _animations;

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

        public AnimationTypes AnimationState
        {
            get => _currentAnimationState;

            set
            {
                if (value != _currentAnimationState)
                {
                    switch (value)
                    {
                        case AnimationTypes.None:
                            break;

                        case AnimationTypes.Attack:
                            break;

                        case AnimationTypes.Die:
                            _animationPlayer.ChangeAnimation(_animations[AnimationTypes.Die], _model.AnimationDurationDie, false);
                            break;

                        case AnimationTypes.Hurt:
                            break;

                        case AnimationTypes.Idle:
                            _animationPlayer.ChangeAnimation(_animations[AnimationTypes.Idle], _model.AnimationDurationIdle, true);
                            break;

                        case AnimationTypes.Jump:
                            _animationPlayer.ChangeAnimation(_animations[AnimationTypes.Jump], _model.AnimationDurationDie, false);
                            break;

                        case AnimationTypes.Run:
                            break;

                        case AnimationTypes.Walk:
                            _animationPlayer.ChangeAnimation(_animations[AnimationTypes.Walk], _model.AnimationDurationWalk, true);
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
            _animations = new Dictionary<AnimationTypes, List<Sprite>>();
            _animations.Add(AnimationTypes.Attack, resources.PirateAttackSprites);
            _animations.Add(AnimationTypes.Die, resources.PirateDieSprites);
            _animations.Add(AnimationTypes.Hurt, resources.PirateHurtSprites);
            _animations.Add(AnimationTypes.Idle, resources.PirateIdleSprites);
            _animations.Add(AnimationTypes.Jump, resources.PirateJumpSprites);
            _animations.Add(AnimationTypes.Run, resources.PirateRunSprites);
            _animations.Add(AnimationTypes.Walk, resources.PirateWalkSprites);

            _model = model;

            _animationPlayer = new AnimationPlayer(spriteRenderer, monoBehaviourManager);

            AnimationState = AnimationTypes.Idle;
        }

        #endregion

    }
}
