using UnityEngine;


namespace PiratesGame
{
    public sealed class RootStarter
    {

        #region Fields

        private PirateController _pirateController;
        private ResourcesManager _resourcesManager;

        private SceneObjectLinks _sceneObjectLinks;

        #endregion


        #region ClassLifeCycles

        public RootStarter(MonoBehaviourManager monoBehaviourManager)
        {
            _sceneObjectLinks = GameObject.FindObjectOfType<SceneObjectLinks>();
            _resourcesManager = new ResourcesManager();
            _pirateController = new PirateController(_resourcesManager, monoBehaviourManager);
            new CannonController(_resourcesManager, monoBehaviourManager, _pirateController.PirateTransform);
            new CoinController(GameObject.FindObjectsOfType<CoinView>(), _resourcesManager, monoBehaviourManager);
            new CameraController(monoBehaviourManager, _pirateController.PirateTransform, Camera.main);
            new SliderJointController(monoBehaviourManager, _sceneObjectLinks.SliderPlatform.GetComponent<SliderJointView>());
        }

        #endregion

    }
}
