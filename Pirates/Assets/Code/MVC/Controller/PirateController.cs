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
            _view = GameObject.Instantiate(resourcesManager.Pirate, _model.StartPosition, Quaternion.identity);

            _animator = new PirateAnimator(
                resourcesManager,
                _model.AnimationDuration,
                _view.PlayerSpriteRenderer,
                monoBehaviourManager
                );

            monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdateFixed);
        }

        #endregion


        #region Methods

        private void LetMove()
        {
            if (InputManager.isJump)
            {
                if (!_model.IsFly)
                {
                    _animator.AnimationState = AnimationTypes.Jump;
                    DoJump();
                }
            }
            else
            {
                if (!Mathf.Approximately(InputManager.DirectionX, 0.0f))
                {
                    _animator.AnimationState = AnimationTypes.Walk;
                    _view.PlayerRigidbody.velocity = new Vector2(InputManager.DirectionX * _model.WalkSpeed, _view.PlayerRigidbody.velocity.y);
                    _view.PlayerSpriteRenderer.flipX = InputManager.DirectionX < 0 ? true : false;
                }
                else
                {
                    _animator.AnimationState = AnimationTypes.Idle;
                }
            }
        }

        private void DoJump()
        {
            _view.PlayerRigidbody.AddForce(Vector2.up * _model.JumpForce);
            _model.IsFly = true;
        }

        private void DoFly()
        {
            if (_model.IsFly)
            {
                if (_view.transform.position.y <= _model.GroundLevel)
                {
                    _model.IsFly = false;
                }
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            LetMove();
            DoFly();
        }

        #endregion

    }
}
