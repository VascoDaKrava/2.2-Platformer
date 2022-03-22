using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateAnimator
    {

        #region Fields

        private AnimationPlayer _animationPlayer;
        private AnimationTypes _animationState;

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
            get => _animationState;

            set
            {
                if (_animationState != value && _animationPlayer.IsLoop ||
                    value == AnimationTypes.Die)
                {
                    _animationPlayer.Play = true;
                    switch (value)
                    {
                        case AnimationTypes.None:
                            break;

                        case AnimationTypes.Attack:
                            break;

                        case AnimationTypes.Die:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Die];
                            _animationPlayer.AnimationDuration = _model.AnimationDurationDie;
                            _animationPlayer.IsLoop = false;
                            break;

                        case AnimationTypes.Hurt:
                            break;

                        case AnimationTypes.Idle:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Idle];
                            _animationPlayer.AnimationDuration = _model.AnimationDurationIdle;
                            _animationPlayer.IsLoop = true;
                            break;

                        case AnimationTypes.Jump:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Jump];
                            _animationPlayer.AnimationDuration = _model.AnimationDurationIdle;
                            _animationPlayer.IsLoop = false;
                            break;

                        case AnimationTypes.Run:
                            break;

                        case AnimationTypes.Walk:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Walk];
                            _animationPlayer.AnimationDuration = _model.AnimationDurationWalk;
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

            _animationPlayer = new AnimationPlayer(_model.AnimationDurationIdle, spriteRenderer, _animations[AnimationTypes.Idle], monoBehaviourManager);
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
            if (AnimationState == AnimationTypes.Die)
            {
                _animationPlayer.Play = false;
            }
            else
            {
                AnimationState = AnimationTypes.Idle;
            }
        }

        #endregion

    }
}
