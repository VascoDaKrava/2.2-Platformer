using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private AnimationController _animator;
        private PirateModel _pirateModel;
        private PirateView _pirateView;
        private ResourcesManager _resourcesManager;

        private Queue<List<Sprite>> _anima;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _resourcesManager = resourcesManager;

            _pirateModel = new PirateModel();

            _pirateView = GameObject.Instantiate(_resourcesManager.Pirate).GetComponent<PirateView>();

            monoBehaviourManager.AddToUpdateList(this);

            _animator = new AnimationController(
                _pirateModel.AnimationFrameInterval,
                _pirateView.SpriteRenderer,
                _resourcesManager.PirateIdleSprites,
                monoBehaviourManager);

            _animator.Play();

            _anima = new Queue<List<Sprite>>();
            _anima.Enqueue(_resourcesManager.PirateAttackSprites);
            _anima.Enqueue(_resourcesManager.PirateDieSprites);
            _anima.Enqueue(_resourcesManager.PirateHurtSprites);
            _anima.Enqueue(_resourcesManager.PirateIdleSprites);
            _anima.Enqueue(_resourcesManager.PirateJumpSprites);
            _anima.Enqueue(_resourcesManager.PirateRunSprites);
            _anima.Enqueue(_resourcesManager.PirateWalkSprites);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (InputManager.isPause)
            {
                _animator.Stop();
            }

            if (InputManager.isJump)
            {
                _animator.SpritesList = _anima.Dequeue();
            }
        }

        #endregion

    }
}
