using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;

        private PirateAnimator _animator;
        private PirateModel _model;
        private PirateView _view;

        private RigidbodyContactChecker _contactChecker;

        private float _calculateVelocityX;

        #endregion


        #region Properties

        public Transform PirateTransform => _view.PlayerRigidbody.transform;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _monoBehaviourManager = monoBehaviourManager;

            _model = new PirateModel();
            _view = GameObject.Instantiate(resourcesManager.Pirate, _model.StartPosition, Quaternion.identity);

            _contactChecker = new RigidbodyContactChecker(_view.PlayerRigidbody, _monoBehaviourManager);

            _animator = new PirateAnimator(
                resourcesManager,
                _model.AnimationDuration,
                _view.PlayerSpriteRenderer,
                _monoBehaviourManager
                );

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdateFixed);
        }

        ~PirateController()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdateFixed);
        }

        #endregion


        #region Methods

        private void CheckMove()
        {
            _model.isGrounded = _contactChecker.BottomContact;

            if (InputManager.isJump)
            {
                if (_model.isGrounded)
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
                    _calculateVelocityX = InputManager.DirectionX * _model.WalkSpeed;
                    _view.PlayerSpriteRenderer.flipX = InputManager.DirectionX < 0 ? true : false;

                    if (_calculateVelocityX < 0.0f && _contactChecker.LeftContact ||
                        _calculateVelocityX > 0.0f && _contactChecker.RightContact)
                    {
                        _calculateVelocityX = 0.0f;
                    }
                }
                else
                {
                    _animator.AnimationState = AnimationTypes.Idle;
                }
            }
        }

        private void DoMove()
        {
            if (!Mathf.Approximately(_calculateVelocityX, 0.0f))
            {
                _view.PlayerRigidbody.velocity = new Vector2(_calculateVelocityX, _view.PlayerRigidbody.velocity.y);
            }
        }

        private void DoJump()
        {
            _view.PlayerRigidbody.AddForce(Vector2.up * _model.JumpForce);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            CheckMove();
        }

        public void LetFixedUpdate()
        {
            DoMove();
        }

        #endregion

    }
}
