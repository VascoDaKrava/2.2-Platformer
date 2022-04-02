using UnityEngine;


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

            new CannonController(_resourcesManager, monoBehaviourManager, _pirateController.PirateTransform);
            new CoinController(sceneObjectLinks.Coins, _resourcesManager, monoBehaviourManager);
            new CameraController(monoBehaviourManager, _pirateController.PirateTransform, Camera.main);
            new SliderJointController(monoBehaviourManager, sceneObjectLinks.SliderPlatform);
            new CheckPointChanger(sceneObjectLinks.SpikeBall, sceneObjectLinks.CheckPoint1, sceneObjectLinks.CheckPoint2, monoBehaviourManager);
            new GhostController(sceneObjectLinks.AirPoints, sceneObjectLinks.Ghost, monoBehaviourManager);
        }

        #endregion

    }
}
