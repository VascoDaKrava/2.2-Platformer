using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private PirateAnimator _animator;
        private PirateModel _pirateModel;
        private PirateView _pirateView;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _pirateModel = new PirateModel();

            _pirateView = GameObject.Instantiate(resourcesManager.Pirate, new Vector3(0, _pirateModel.GroundLevel, 0), Quaternion.identity).GetComponent<PirateView>();

            _animator = new PirateAnimator(
                resourcesManager,
                _pirateModel.AnimationFrameInterval,
                _pirateView.SpriteRenderer,
                monoBehaviourManager
                );

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region Methods

        private void LetMove()
        {
            if (InputManager.GetDirectionX() != Vector3.zero)
            {
                _animator.AnimationState = AnimationTypes.Walk;
                _pirateView.PirateTransform.position += InputManager.GetDirectionX() * _pirateModel.Speed * Time.deltaTime;
            }
            else
            {
                    _animator.AnimationState = AnimationTypes.Idle;
            }

            if (InputManager.isJump)
            {
                _animator.AnimationState = AnimationTypes.Jump;
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
