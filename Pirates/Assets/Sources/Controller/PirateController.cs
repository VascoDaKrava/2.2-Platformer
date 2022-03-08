using UnityEngine;


namespace PiratesGame
{
    public sealed class PirateController : IUpdatable
    {

        #region Fields

        private PirateView _pirateView;

        #endregion


        #region ClassLifeCycles

        public PirateController(ResourcesManager resourcesManager)
        {

            new PirateModel();

            _pirateView = GameObject.Instantiate(resourcesManager.Pirate).GetComponent<PirateView>();

        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
