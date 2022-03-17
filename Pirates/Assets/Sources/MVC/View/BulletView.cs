using UnityEngine;


namespace PiratesGame
{
    public sealed class BulletView : MonoBehaviour
    {

        #region Properties

        public SpriteRenderer SpriteRenderer { get; private set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            foreach (Transform item in gameObject.GetComponentsInChildren<Transform>())
            {
                if (item.name == Names.EXPLOSION_RENDERER)
                {
                    SpriteRenderer = item.GetComponent<SpriteRenderer>();
                }
            }
        }

        #endregion

    }
}
