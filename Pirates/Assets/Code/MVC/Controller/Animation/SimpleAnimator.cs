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

        public SimpleAnimator(List<Sprite> animation, float animationDuration, SpriteRenderer spriteRenderer, MonoBehaviourManager monoBehaviourManager)
        {
            animation.Add(null);

            _animationPlayer = new AnimationPlayer(animationDuration, spriteRenderer, animation, monoBehaviourManager);
            _animationPlayer.IsLoop = false;

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

        public void PlayOnce()
        {
            _animationPlayer.Play = true;
        }

        #endregion

    }
}
