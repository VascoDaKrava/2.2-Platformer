using System;
using Pathfinding;
using UnityEngine;


namespace PiratesGame
{
    public sealed class GhostView : MonoBehaviour
    {

        #region Fields

        public Action<Collider2D> OnTriggerEnter;
        public Action<Collider2D> OnTriggerExit;

        [SerializeField]
        private AIPath _path;

        [SerializeField]
        private AIDestinationSetter _destinationSetter;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        #endregion


        #region Properties

        public AIPath Path => _path;
        public AIDestinationSetter DestinationSetter => _destinationSetter;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEnter?.Invoke(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            OnTriggerExit?.Invoke(collision);
        }

        #endregion

    }
}
