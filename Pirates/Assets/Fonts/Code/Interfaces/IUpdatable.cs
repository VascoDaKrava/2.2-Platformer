namespace PiratesGame
{
    public interface IUpdatable
    {

        #region Methods

        /// <summary>
        /// Contains methods for runnig in Update()
        /// </summary>
        void LetUpdate();

        /// <summary>
        /// Contains methods for runnig in FixedUpdate()
        /// </summary>
        void LetFixedUpdate();

        #endregion

    }
}
