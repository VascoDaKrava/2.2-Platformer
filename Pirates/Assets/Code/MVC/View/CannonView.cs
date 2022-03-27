using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonView : MonoBehaviour
    {

        #region Fields

        [SerializeField]
        private SpriteRenderer _bulletStartRenderer;

        [SerializeField]
        private Transform _bulletStartTransform;

        [SerializeField]
        private Transform _burrelTransform;

        #endregion


        #region Properties

        public SpriteRenderer BulletStartRenderer => _bulletStartRenderer;
        public Transform BulletStartTransform => _bulletStartTransform;
        public Transform BurrelTransform => _burrelTransform;

        #endregion

    }
}
