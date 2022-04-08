using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable, IDisposable
    {

        #region Fields

        private int _framesLeftBeforeCheck;

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

        #endregion


        #region Methods

        private void CheckMove()
        {
            _calculateVelocityX = 0.0f;

            if (_framesLeftBeforeCheck > 0)
            {
                _framesLeftBeforeCheck--;
            }
            else
            {
                _model.isGrounded = _contactChecker.BottomContact;
            }

            if (InputManager.isJump)
            {
                if (_model.isGrounded)
                {
                    _animator.AnimationState = AnimationType.Jump;
                    DoJump();
                    _framesLeftBeforeCheck = _model.FrameSkipForJumpCheck;
                    _model.isGrounded = false;
                }
            }
            else
            {
                if (Mathf.Abs(InputManager.DirectionX) > 0.0f)
                {
                    _calculateVelocityX = InputManager.DirectionX * _model.WalkSpeed;

                    _view.PlayerSpriteRenderer.flipX = InputManager.DirectionX < 0 ? true : false;

                    if (_model.isGrounded)
                    {
                        _animator.AnimationState = AnimationType.Walk;
                    }

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
                        _animator.AnimationState = AnimationType.Idle;
                    }
                }
            }
        }

        private void DoMove()
        {
            if (_view.ExtraVelocity != Vector2.zero)
            {
                _view.PlayerRigidbody.velocity = new Vector2(_calculateVelocityX + _view.ExtraVelocity.x, _view.ExtraVelocity.y);
            }
            else
            {
                if (!Mathf.Approximately(_calculateVelocityX, 0.0f))
                {
                    _view.PlayerRigidbody.velocity = new Vector2(_calculateVelocityX, _view.PlayerRigidbody.velocity.y);
                }
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
            _animator.AnimationState = AnimationType.Die;
            _animator.AnimationPlayFinished += AnimationOnePlayFinishedEventHandler;
        }

        private void DoRestart()
        {
            _animator.AnimationPlayFinished -= AnimationOnePlayFinishedEventHandler;
            _model.isMotorStop = false;
            _view.PlayerRigidbody.velocity = Vector2.zero;
            _view.transform.position = _model.StartPosition;
            _animator.AnimationState = AnimationType.Idle;
            _view.OnTriggerEvent += OnTriggerEventHandler;
        }

        private void OnTriggerEventHandler(GameObject triggerObject)
        {
            switch (triggerObject.tag)
            {
                case TagsAndLayers.TAG_COIN:
                    Debug.Log("Coin collected");
                    triggerObject.SetActive(false);
                    break;

                case TagsAndLayers.TAG_DANGER:
                    Debug.Log("Death become..");
                    DoDie();
                    break;

                case TagsAndLayers.TAG_WIN:
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


        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdateFixed);

            _view.OnTriggerEvent -= OnTriggerEventHandler;
            _view.Timer.TimerFinishedEvent -= DoRestart;
        }

        #endregion

    }
}
