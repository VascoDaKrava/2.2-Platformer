using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public class SimpleAnimator : IDisposable
    {

        #region Fields

        private AnimationPlayer _animationPlayer;

        #endregion


        #region CodeLifeCycles

        public SimpleAnimator(List<Sprite> animation, float animationDuration, bool isLoop, SpriteRenderer spriteRenderer, MonoBehaviourManager monoBehaviourManager)
        {
            _animationPlayer = new AnimationPlayer(spriteRenderer, monoBehaviourManager);
            _animationPlayer.ChangeAnimation(animation, animationDuration, isLoop);

            _animationPlayer.AnimationPlayFinished += AnimationOnePlayFinishedEventHandler;
        }

        #endregion


        #region Methods

        public void Play()
        {
            _animationPlayer.Play = true;
        }

        private void AnimationOnePlayFinishedEventHandler()
        {
            _animationPlayer.Play = false;
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _animationPlayer.AnimationPlayFinished -= AnimationOnePlayFinishedEventHandler;
        }

        #endregion

    }
}
