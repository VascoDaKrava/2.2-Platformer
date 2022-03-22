using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public class SimpleAnimator
    {

        #region Fields

        private AnimationPlayer _animationPlayer;

        #endregion


        #region CodeLifeCycles

        public SimpleAnimator(List<Sprite> animation, float animationDuration, bool isLoop, SpriteRenderer spriteRenderer, MonoBehaviourManager monoBehaviourManager)
        {
            if (!isLoop)
            {
                animation.Add(null);
            }

            _animationPlayer = new AnimationPlayer(animationDuration, spriteRenderer, animation, monoBehaviourManager);
            _animationPlayer.IsLoop = isLoop;

            _animationPlayer.AnimationPlayFinished += AnimationOnePlayFinishedEventHandler;
        }

        ~SimpleAnimator()
        {
            _animationPlayer.AnimationPlayFinished -= AnimationOnePlayFinishedEventHandler;
        }

        #endregion


        #region Methods

        private void AnimationOnePlayFinishedEventHandler()
        {
            _animationPlayer.Play = false;
        }

        public void Play()
        {
            _animationPlayer.Play = true;
        }

        #endregion

    }
}
