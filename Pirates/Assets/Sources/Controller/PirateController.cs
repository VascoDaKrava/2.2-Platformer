using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private AnimationPlayer _animator;
        private AnimationTypes _animationState;
        private PirateModel _pirateModel;
        private PirateView _pirateView;
        private ResourcesManager _resourcesManager;

        private Dictionary<AnimationTypes, List<Sprite>> _animations;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _resourcesManager = resourcesManager;

            _pirateModel = new PirateModel();

            _pirateView = GameObject.Instantiate(_resourcesManager.Pirate, new Vector3(0, -0.6f, 0), Quaternion.identity).GetComponent<PirateView>();

            _animations = new Dictionary<AnimationTypes, List<Sprite>>();
            _animations.Add(AnimationTypes.Attack, _resourcesManager.PirateAttackSprites);
            _animations.Add(AnimationTypes.Die, _resourcesManager.PirateDieSprites);
            _animations.Add(AnimationTypes.Hurt, _resourcesManager.PirateHurtSprites);
            _animations.Add(AnimationTypes.Idle, _resourcesManager.PirateIdleSprites);
            _animations.Add(AnimationTypes.Jump, _resourcesManager.PirateJumpSprites);
            _animations.Add(AnimationTypes.Run, _resourcesManager.PirateRunSprites);
            _animations.Add(AnimationTypes.Walk, _resourcesManager.PirateWalkSprites);

            _animator = new AnimationPlayer(
                _pirateModel.AnimationFrameInterval,
                _pirateView.SpriteRenderer,
                _animations[AnimationTypes.Idle],
                monoBehaviourManager);

            _animationState = AnimationTypes.Idle;

            _animator.IsPlay = true;

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region Methods

        private void LetMove()
        {
            if (InputManager.GetDirectionX() != Vector3.zero)
            {
                if (_animationState != AnimationTypes.Walk)
                {
                    _animationState = AnimationTypes.Walk;
                    _animator.SpritesList = _animations[AnimationTypes.Walk];
                    _animator.IsLoop = true;
                    _animator.IsPlay = true;
                }
                _pirateView.PirateTransform.position += InputManager.GetDirectionX() * _pirateModel.Speed * Time.deltaTime;
            }
            else
            {
                if (_animationState != AnimationTypes.Idle && _animationState != AnimationTypes.Jump)
                {
                    _animationState = AnimationTypes.Idle;
                    _animator.SpritesList = _animations[AnimationTypes.Idle];
                    _animator.IsLoop = true;
                    _animator.IsPlay = true;
                }
            }

            if (InputManager.isJump)
            {
                _animationState = AnimationTypes.Jump;
                _animator.SpritesList = _animations[AnimationTypes.Jump];
                _animator.IsLoop = false;
                _animator.IsPlay = true;
            }

            if (_animationState == AnimationTypes.Jump && !_animator.IsPlay)
            {
                _animationState = AnimationTypes.Idle;
                _animator.SpritesList = _animations[AnimationTypes.Idle];
                _animator.IsLoop = true;
                _animator.IsPlay = true;
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            LetMove();
        }

        #endregion

    }
}
