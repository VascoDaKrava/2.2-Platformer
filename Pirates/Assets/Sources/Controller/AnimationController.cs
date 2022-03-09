using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class AnimationController : IUpdatable
    {

        #region Fields

        private int _currentSpriteNumber;
        private float _timeBetweenSprites;
        private float _timeToNextSprite;
        private SpriteRenderer _spriteRenderer;
        private List<Sprite> _sprites;
        private MonoBehaviourManager _monoBehaviourManager;

        #endregion


        #region Properties

        public List<Sprite> SpritesList
        {
            set
            {
                _sprites.Clear();
                _sprites = new List<Sprite>(value);
                _timeToNextSprite = _timeBetweenSprites;
            }
        }

        #endregion


        #region ClassLifeCycles

        public AnimationController(float timeBetweenSprites, SpriteRenderer spriteRenderer, List<Sprite> spritesList, MonoBehaviourManager monoBehaviourManager)
        {
            _timeBetweenSprites = timeBetweenSprites;
            _timeToNextSprite = _timeBetweenSprites;
            _spriteRenderer = spriteRenderer;
            _sprites = new List<Sprite>(spritesList);
            _monoBehaviourManager = monoBehaviourManager;
            _currentSpriteNumber = 0;
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
                    _currentSpriteNumber = 0;
                }

                _spriteRenderer.sprite = _sprites[_currentSpriteNumber];
            }
        }

        public void Play()
        {
            _monoBehaviourManager.AddToUpdateList(this);
        }

        public void Stop()
        {
            _monoBehaviourManager.RemoveFromUpdateList(this);
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
