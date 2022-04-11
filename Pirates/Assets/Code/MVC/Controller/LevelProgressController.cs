using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PiratesGame
{
    public sealed class LevelProgressController : IDisposable
    {

        #region Enum

        private enum TimerCaller
        {
            None = 0,
            Die = 1,
            Win = 2
        }

        #endregion


        #region Fields

        private float _delayBeforeNextStep = 3.0f;

        private int _coinsQuantity;
        private TimerCaller _timerCaller;

        private PirateController _player;
        private UIView _ui;

        #endregion


        #region CodeLifeCycles

        public LevelProgressController(PirateController player, UIView ui)
        {
            _player = player;
            _ui = ui;

            _ui.TMPWinGame.alpha = 0.0f;
            _ui.TMPLoseGame.alpha = 0.0f;

            _player.PirateCollectCoin += PirateCollectCoinHandler;
            _player.PirateDie += PirateDieHandler;
            _player.PirateWin += PirateWinHandler;
            _ui.Timer.TimerFinishedEvent += OnTimerFinish;
        }

        #endregion


        #region Methods

        private void PirateCollectCoinHandler()
        {
            _coinsQuantity++;
            _ui.TMPCoinsQuantity.text = $"{_coinsQuantity:D3}";
        }

        private void PirateDieHandler()
        {
            if (_timerCaller == TimerCaller.None)
            {
                Time.timeScale = 0.0f;
                _ui.Timer.StartTimer(_delayBeforeNextStep);
                _timerCaller = TimerCaller.Die;
                _ui.TMPLoseGame.alpha = 1.0f;
            }
        }

        private void PirateWinHandler()
        {
            if (_timerCaller == TimerCaller.None)
            {
                Time.timeScale = 0.0f;
                _ui.Timer.StartTimer(_delayBeforeNextStep);
                _timerCaller = TimerCaller.Win;
                _ui.TMPWinGame.alpha = 1.0f;
            }
        }

        private void OnTimerFinish()
        {
            Time.timeScale = 1.0f;
            switch (_timerCaller)
            {
                case TimerCaller.Die:
                    _timerCaller = TimerCaller.None;
                    _ui.TMPLoseGame.alpha = 0.0f;
                    break;

                case TimerCaller.Win:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                
                default:
                    break;
            }
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _player.PirateCollectCoin -= PirateCollectCoinHandler;
            _player.PirateDie -= PirateDieHandler;
            _player.PirateWin -= PirateWinHandler;
            _ui.Timer.TimerFinishedEvent -= OnTimerFinish;
        }

        #endregion

    }
}
