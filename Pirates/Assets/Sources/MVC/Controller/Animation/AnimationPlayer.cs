using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class AnimationPlayer : IUpdatable
    {

        #region Fields

        private event Action _animationPlayFinishedEvent;

        private bool _isPlaying;
        private int _currentSpriteNumber;
        private float _timeBetweenSprites;
        private float _timeToNextSprite;
        private SpriteRenderer _spriteRenderer;
        private List<Sprite> _sprites;
        private MonoBehaviourManager _monoBehaviourManager;

        public bool IsLoop;

        #endregion


        #region Properties

        public event Action AnimationPlayFinished
        {
            add { _animationPlayFinishedEvent += value; }
            remove { _animationPlayFinishedEvent -= value; }
        }

        public List<Sprite> SpritesList
        {
            set
            {
                _sprites.Clear();
                _sprites = new List<Sprite>(value);
                _timeToNextSprite = _timeBetweenSprites;
                _currentSpriteNumber = 0;
            }
        }

        public bool Play
        {
            set
            {
                if (_isPlaying != value)
                {
                    _isPlaying = value;
                    if (_isPlaying)
                    {
                        _monoBehaviourManager.AddToUpdateList(this);
                        _timeToNextSprite = _timeBetweenSprites;
                        _currentSpriteNumber = 0;
                    }
                    else
                    {
                        _monoBehaviourManager.RemoveFromUpdateList(this);
                    }
                }
            }
        }

        #endregion


        #region ClassLifeCycles

        public AnimationPlayer(float animationDuration, SpriteRenderer spriteRenderer, List<Sprite> spritesList, MonoBehaviourManager monoBehaviourManager)
        {
            _timeBetweenSprites = animationDuration / spritesList.Count;
            _timeToNextSprite = _timeBetweenSprites;
            _spriteRenderer = spriteRenderer;
            _sprites = new List<Sprite>(spritesList);
            _monoBehaviourManager = monoBehaviourManager;
            _currentSpriteNumber = 0;
            IsLoop = true;
        }

        #endregion


        #region Methods

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
                    if (IsLoop)
                    {
                        _currentSpriteNumber = 0;
                    }
                    else
                    {
                        _currentSpriteNumber--;
                        _animationPlayFinishedEvent.Invoke();
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

        #endregion

    }
}
