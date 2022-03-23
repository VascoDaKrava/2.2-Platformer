using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private float _calculateVelocityX;

        private MonoBehaviourManager _monoBehaviourManager;

        private PirateAnimator _animator;
        private PirateModel _model;
        private PirateView _view;

        private RigidbodyContactChecker _contactChecker;

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
                _model,
                _view.PlayerSpriteRenderer,
                _monoBehaviourManager
                );

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdateFixed);

            _view.OnTriggerEvent += OnTriggerEventHandler;
            _view.Timer.TimerFinishedEvent += DoRestart;
        }

        ~PirateController()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdateFixed);

            _view.OnTriggerEvent -= OnTriggerEventHandler;
            _view.Timer.TimerFinishedEvent -= DoRestart;
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
                    if (_model.isGrounded)
                    {
                        _animator.AnimationState = AnimationTypes.Walk;
                    }

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
                    if (_model.isGrounded)
                    {
                        _animator.AnimationState = AnimationTypes.Idle;
                    }
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

        private void DoDie()
        {
            _view.OnTriggerEvent -= OnTriggerEventHandler;
            _model.isMotorStop = true;
            _calculateVelocityX = 0.0f;
            _view.PlayerRigidbody.velocity = Vector2.zero;
            _animator.AnimationState = AnimationTypes.Die;
            _animator.AnimationPlayFinished += AnimationOnePlayFinishedEventHandler;
        }

        private void DoRestart()
        {
            _animator.AnimationPlayFinished -= AnimationOnePlayFinishedEventHandler;
            _view.transform.position = _model.StartPosition;
            _model.isMotorStop = false;
            _view.PlayerRigidbody.velocity = Vector2.zero;
            _animator.AnimationState = AnimationTypes.Idle;
            _view.OnTriggerEvent += OnTriggerEventHandler;
        }

        private void OnTriggerEventHandler(GameObject triggerObject)
        {
            switch (triggerObject.tag)
            {
                case TagsAndLayers.TagCoin:
                    Debug.Log("Coin collected");
                    triggerObject.SetActive(false);
                    break;

                case TagsAndLayers.TagDanger:
                    Debug.Log("Death become..");
                    DoDie();
                    break;

                case TagsAndLayers.TagWin:
                    Debug.Log("WIN");
                    break;

                default:
                    break;
            }
        }

        private void AnimationOnePlayFinishedEventHandler()
        {
            _view.Timer.StartTimer(_model.TimeToReset);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            if (!_model.isMotorStop)
            {
                CheckMove();
            }
        }

        public void LetFixedUpdate()
        {
            DoMove();
        }

        #endregion

    }
}
