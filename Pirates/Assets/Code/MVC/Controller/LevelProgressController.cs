using System;
using UnityEngine.SceneManagement;


namespace PiratesGame
{
    public sealed class LevelProgressController : IDisposable
    {

        #region MyRegion

        private PirateController _player;

        #endregion


        #region CodeLifeCycles

        public LevelProgressController(PirateController player)
        {
            _player = player;

            _player.PirateCollectCoin += PirateCollectCoinHandler;
            _player.PirateDie += PirateDieHandler;
            _player.PirateWin += PirateWinHandler;
        }

        #endregion


        #region Methods

        private void PirateCollectCoinHandler()
        {

        }

        private void PirateDieHandler()
        {

        }

        private void PirateWinHandler()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _player.PirateCollectCoin -= PirateCollectCoinHandler;
            _player.PirateDie -= PirateDieHandler;
            _player.PirateWin -= PirateWinHandler;
        }

        #endregion

    }
}
