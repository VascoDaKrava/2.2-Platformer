using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private AnimationPlayer _animator;
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

            _pirateView = GameObject.Instantiate(_resourcesManager.Pirate).GetComponent<PirateView>();

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

            _animator.Play();

            //monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            //if (InputManager.isPause)
            //{
            //    _animator.Stop();
            //}

            //if (InputManager.isJump)
            //{
            //    _animator.SpritesList = _animations[AnimationTypes.Jump];
            //}
        }

        #endregion

    }
}
