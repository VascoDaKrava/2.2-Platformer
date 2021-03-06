using System;
using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonController : IUpdatable, IDisposable
    {

        #region Fields

        private BulletPool _bulletPool;
        private CannonModel _model;
        private CannonView _view;
        private MonoBehaviourManager _monoBehaviourManager;
        private SimpleAnimator _animator;
        private Transform _pirateTransform;

        #endregion


        #region CodeLifeCicles

        public CannonController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager, Transform pirateTransform)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _pirateTransform = pirateTransform;

            _model = new CannonModel();
            _view = GameObject.Instantiate(resourcesManager.Cannon, _model.StartPosition, Quaternion.identity);

            _bulletPool = new BulletPool(_model.BulletsInPool, _monoBehaviourManager, resourcesManager, _view.BulletStartTransform);

            _animator = new SimpleAnimator(resourcesManager.ShootSprites, _model.ShootAnimationDuration, false, _view.BulletStartRenderer, _monoBehaviourManager);

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region Methods

        private void Aiming()
        {
            _view.BurrelTransform.rotation =
                Quaternion.AngleAxis(
                    (_pirateTransform.position.y > _view.BurrelTransform.position.y ? -1 : 1) *
                    Mathf.Clamp(Vector3.Angle(Vector3.left, _pirateTransform.position - _view.BurrelTransform.position), 0.0f, _model.MaxBurrelAngle),
                    Vector3.forward
                    );
        }

        private void Shoot()
        {
            if (_model.TimeToNextShoot > 0.0f)
            {
                _model.TimeToNextShoot -= Time.deltaTime;
            }
            else
            {
                _model.ResetTime();
                _bulletPool.PopFromPool();
                _animator.Play();
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            Aiming();
            Shoot();
        }

        public void LetFixedUpdate() { }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }

        #endregion

    }
}
