using UnityEngine;
using UnityEngine.SceneManagement;


namespace PiratesGame
{
    public sealed class RootStarter
    {

        #region Fields

        private PirateController _pirateController;
        private ResourcesManager _resourcesManager;

        #endregion


        #region ClassLifeCycles

        public RootStarter(MonoBehaviourManager monoBehaviourManager, SceneObjectLinks sceneObjectLinks)
        {
            _resourcesManager = new ResourcesManager();
            _pirateController = new PirateController(_resourcesManager, monoBehaviourManager);

            new CameraController(monoBehaviourManager, _pirateController.PirateTransform, Camera.main);
            new LevelProgressController(_pirateController);
                
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                new CannonController(_resourcesManager, monoBehaviourManager, _pirateController.PirateTransform);
                new CoinController(sceneObjectLinks.Coins, _resourcesManager, monoBehaviourManager);
                new SliderJointController(monoBehaviourManager, sceneObjectLinks.SliderPlatform);
                new CheckPointChanger(sceneObjectLinks.SpikeBall, sceneObjectLinks.GroundPoints, monoBehaviourManager);
                new GhostController(sceneObjectLinks.AirPoints, sceneObjectLinks.Ghost, monoBehaviourManager);

                new QuestCoinTowerController(sceneObjectLinks.TowerView);
                new QuestLadderTreeController(sceneObjectLinks.LadderTreeView);
            }
        }

        #endregion

    }
}
