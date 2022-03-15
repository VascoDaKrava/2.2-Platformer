using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private PirateAnimator _animator;
        private PirateModel _model;
        private PirateView _view;

        #endregion


        #region Properties

        public Transform PirateTransform => _view.transform;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _model = new PirateModel();
            _view = GameObject.Instantiate(resourcesManager.Pirate, _model.StartPosition, Quaternion.identity).GetComponent<PirateView>();

            _animator = new PirateAnimator(
                resourcesManager,
                _model.AnimationFrameInterval,
                _view.SpriteRenderer,
                monoBehaviourManager
                );

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region Methods

        private void LetMove()
        {
            if (InputManager.isJump)
            {
                _animator.AnimationState = AnimationTypes.Jump;
            }
            else
            {
                if (InputManager.GetDirectionX() != Vector3.zero)
                {
                    _animator.AnimationState = AnimationTypes.Walk;
                    _view.PirateTransform.position += InputManager.GetDirectionX() * _model.Speed * Time.deltaTime;
                    _view.SpriteRenderer.flipX = InputManager.GetDirectionX().x < 0 ? true : false;
                }
                else
                {
                    _animator.AnimationState = AnimationTypes.Idle;
                }
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
