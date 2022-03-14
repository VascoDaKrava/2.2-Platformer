using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class AnimationPlayer : IUpdatable
    {

        #region Fields

        private bool _isPlay;
        private int _currentSpriteNumber;
        private float _timeBetweenSprites;
        private float _timeToNextSprite;
        private SpriteRenderer _spriteRenderer;
        private List<Sprite> _sprites;
        private MonoBehaviourManager _monoBehaviourManager;

        public bool IsLoop;

        #endregion


        #region Properties

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

        public bool IsPlay
        {
            get
            {
                return _isPlay;
            }
            set
            {
                if (_isPlay != value)
                {
                    _isPlay = value;
                    if (_isPlay)
                    {
                        _monoBehaviourManager.AddToUpdateList(this);
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

        public AnimationPlayer(float timeBetweenSprites, SpriteRenderer spriteRenderer, List<Sprite> spritesList, MonoBehaviourManager monoBehaviourManager)
        {
            _timeBetweenSprites = timeBetweenSprites;
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
            if (_timeToNextSprite > 0)
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
                        IsPlay = false;
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
