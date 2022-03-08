using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private PirateView _pirateView;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager, MonoBehaviourManager monoBehaviourManager)
        {

            new PirateModel();

            _pirateView = GameObject.Instantiate(resourcesManager.Pirate).GetComponent<PirateView>();

            monoBehaviourManager.AddToUpdateList(this);
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            //throw new System.NotImplementedException();
        }

        #endregion

    }
}
