namespace PiratesGame
{
    public sealed class CoinController
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;

        #endregion


        #region CodeLifeCycles

        public CoinController(CoinView[] coins, ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {
            _monoBehaviourManager = monoBehaviourManager;

            foreach (CoinView coinView in coins)
            {
                new SimpleAnimator(
                resourcesManager.CoinSprites,
                CoinModel.RotationAnimationDuration,
                true,
                coinView.CoinSpriteRenderer,
                _monoBehaviourManager).Play();
            }
        }

        #endregion

    }
}
