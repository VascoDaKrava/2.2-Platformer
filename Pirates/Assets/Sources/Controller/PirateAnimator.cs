using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateAnimator
    {

        #region Fields

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
                if (_animationState != value)
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
                            //if (_animationState != AnimationTypes.Jump)
                            //{
                                _animationPlayer.SpritesList = _animations[AnimationTypes.Idle];
                                _animationPlayer.IsLoop = true;
                                _animationPlayer.IsPlay = true;
                            //}
                            break;

                        case AnimationTypes.Jump:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Jump];
                            _animationPlayer.IsLoop = false;
                            _animationPlayer.IsPlay = true;
                            break;

                        case AnimationTypes.Run:
                            break;

                        case AnimationTypes.Walk:
                            _animationPlayer.SpritesList = _animations[AnimationTypes.Walk];
                            _animationPlayer.IsLoop = true;
                            _animationPlayer.IsPlay = true;
                            break;

                        default:
                            break;
                    }
                    _animationState = value;
                }
                else
                {
                    if (_animationState == AnimationTypes.Jump)
                    {
                        if (!_animationPlayer.IsPlay)
                        {
                            _animationState = AnimationTypes.Idle;
                            AnimationState = AnimationTypes.Idle;
                        }
                    }
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public PirateAnimator(ResourcesManager resources, float animationFrameInterval, SpriteRenderer spriteRenderer, MonoBehaviourManager monoBehaviourManager)
        {
            _animations = new Dictionary<AnimationTypes, List<Sprite>>();
            _animations.Add(AnimationTypes.Attack, resources.PirateAttackSprites);
            _animations.Add(AnimationTypes.Die, resources.PirateDieSprites);
            _animations.Add(AnimationTypes.Hurt, resources.PirateHurtSprites);
            _animations.Add(AnimationTypes.Idle, resources.PirateIdleSprites);
            _animations.Add(AnimationTypes.Jump, resources.PirateJumpSprites);
            _animations.Add(AnimationTypes.Run, resources.PirateRunSprites);
            _animations.Add(AnimationTypes.Walk, resources.PirateWalkSprites);

            _animationPlayer = new AnimationPlayer(animationFrameInterval, spriteRenderer, _animations[AnimationTypes.Idle], monoBehaviourManager);

            _animationState = AnimationTypes.Idle;

            _animationPlayer.IsPlay = true;
        }

        #endregion

    }
}
