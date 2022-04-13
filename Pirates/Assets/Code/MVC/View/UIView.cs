using TMPro;
using UnityEngine;


namespace PiratesGame
{
    public sealed class UIView : MonoBehaviour
    {

        #region Fields

        [Space]
        [SerializeField]
        private TextMeshProUGUI _loseGame;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _winGame;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _coinsQuantity;

        [Space]
        [SerializeField]
        private Timer _timer;

        #endregion


        #region Properties

        public TextMeshProUGUI TMPLoseGame => _loseGame;
        public TextMeshProUGUI TMPWinGame => _winGame;
        public TextMeshProUGUI TMPCoinsQuantity => _coinsQuantity;
        public Timer Timer => _timer;

        #endregion

    }
}
