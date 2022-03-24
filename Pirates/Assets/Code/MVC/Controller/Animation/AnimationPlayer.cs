using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class AnimationPlayer : IUpdatable
    {

        #region Fields


        private event Action _animationPlayFinishedEvent;

        private bool _isLoop;
        private bool _isNeedToPlay;
        private int _currentSpriteNumber;
        private float _timeBetweenSprites;
        private float _timeToNextSprite;
        private List<Sprite> _sprites;
        private MonoBehaviourManager _monoBehaviourManager;
        private SpriteRenderer _spriteRenderer;

        #endregion


        #region Properties

        public event Action AnimationPlayFinished
        {
            add { _animationPlayFinishedEvent += value; }
            remove { _animationPlayFinishedEvent -= value; }
        }

        public bool Play
        {
            set
            {
                if (_sprites == null || _sprites?.Count == 0)
                {
                    throw new Exception("List<Sprite> is empty! Use method ChangeAnimation before.");
                }

                if (_isNeedToPlay != value)
                {
                    _isNeedToPlay = value;
                    if (_isNeedToPlay)
                    {
                        _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
                        _timeToNextSprite = _timeBetweenSprites;
                        _currentSpriteNumber = 0;
                    }
                    else
                    {
                        _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
                    }
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public AnimationPlayer(SpriteRenderer spriteRenderer, MonoBehaviourManager monoBehaviourManager)
        {
            _spriteRenderer = spriteRenderer;
            _monoBehaviourManager = monoBehaviourManager;
        }

        #endregion


        #region Methods

        public void ChangeAnimation(List<Sprite> spritesList, float animationDuration, bool isLoop)
        {
            _sprites?.Clear();
            _sprites = new List<Sprite>(spritesList);
            _currentSpriteNumber = 0;

            _timeBetweenSprites = animationDuration / _sprites.Count;
            _timeToNextSprite = _timeBetweenSprites;

            _isLoop = isLoop;
        }

        private void PlayAnimation()
        {
            if (_timeToNextSprite > 0.0f)
            {
                _timeToNextSprite -= Time.deltaTime;
            }
            else
            {
                _timeToNextSprite = _timeBetweenSprites;
                _currentSpriteNumber++;

                if (_currentSpriteNumber == _sprites.Count)
                {
                    if (_isLoop)
                    {
                        _currentSpriteNumber = 0;
                    }
                    else
                    {
                        _currentSpriteNumber--;
                        Play = false;
                        _animationPlayFinishedEvent?.Invoke();
                    }
                }

                _spriteRenderer.sprite = _sprites[_currentSpriteNumber];
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            PlayAnimation();
        }

        public void LetFixedUpdate() { }

        #endregion

    }
}
