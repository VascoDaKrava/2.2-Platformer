using UnityEngine;


namespace PiratesGame
{
    public sealed class CannonView : MonoBehaviour
    {

        #region Properties

        public SpriteRenderer BulletStartRenderer { get; private set; }
        public Transform BulletStartTransform { get; private set; }
        public Transform BurrelTransform { get; private set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            foreach (Transform item in gameObject.GetComponentsInChildren<Transform>())
            {
                switch (item.name)
                {
                    case Names.BULLET_START_POSITION:
                        BulletStartTransform = item;
                        BulletStartRenderer = item.GetComponent<SpriteRenderer>();
                        break;

                    case Names.BURREL:
                        BurrelTransform = item;
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion

    }
}
