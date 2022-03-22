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

            foreach (GameObject coinView in coins)
            {
                new SimpleAnimator(
                    resourcesManager.CoinSprites,
                    CoinModel.RotationAnimationDuration,
                    true,
                    coinView.GetComponent<CoinView>().CoinSpriteRenderer,
                    _monoBehaviourManager).Play();
            }
        }

        #endregion

    }
}
