using UnityEngine;


namespace PiratesGame
{
    public sealed class ResourcesManager
    {

        #region Properties

        public GameObject Pirate { get; private set; }

        #endregion


        #region ClassLifeCycles

        public ResourcesManager()
        {
            Pirate = Resources.Load<GameObject>(ResourcesPath.PIRATE);
        }

        #endregion

    }
}
