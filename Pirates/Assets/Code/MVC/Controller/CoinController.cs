using UnityEngine;


namespace PiratesGame
{
    public sealed class CoinController
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;

        #endregion


        #region CodeLifeCycles

        public CoinController(GameObject[] coins, ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _monoBehaviourManager = monoBehaviourManager;

            foreach (GameObject coinGameObject in coins)
            {
                if (coinGameObject.TryGetComponent<CoinView> (out CoinView coinView))
                {
                    new SimpleAnimator(
                    resourcesManager.CoinSprites,
                    CoinModel.RotationAnimationDuration,
                    true,
                    coinView.CoinSpriteRenderer,
                    _monoBehaviourManager).Play();
                }
            }
        }

        #endregion

    }
}
