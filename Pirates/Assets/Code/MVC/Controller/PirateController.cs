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
                if (!_model.IsFly)
                {
                    _animator.AnimationState = AnimationTypes.Jump;
                    DoJump();
                }
            }
            else
            {
                if (InputManager.GetDirectionX() != Vector3.zero)
                {
                    _animator.AnimationState = AnimationTypes.Walk;
                    _view.transform.position += InputManager.GetDirectionX() * _model.WalkSpeed * Time.deltaTime;
                    _view.SpriteRenderer.flipX = InputManager.GetDirectionX().x < 0 ? true : false;
                }
                else
                {
                    _animator.AnimationState = AnimationTypes.Idle;
                }
            }
        }

        private void DoJump()
        {
            _model.VerticalVelocity += _model.JumpPower;
            _model.IsFly = true;
        }

        private void DoFly()
        {
            if (_model.IsFly)
            {
                _view.transform.position += _model.VerticalVelocity * Vector3.up * Time.deltaTime;
                _model.VerticalVelocity -= _model.G * Time.deltaTime;

                if (_view.transform.position.y <= _model.GroundLevel)
                {
                    _model.IsFly = false;
                    _model.VerticalVelocity = 0.0f;
                    _view.transform.position = new Vector3(_view.transform.position.x, _model.GroundLevel, _view.transform.position.z);
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
