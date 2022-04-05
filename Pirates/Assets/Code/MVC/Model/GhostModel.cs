using UnityEngine;


namespace PiratesGame
{
    public sealed class GhostModel
    {

        #region Fields

        private bool _isCatchPlayer = false;

        private readonly Color _normalColor = Color.white;
        private readonly Color _dangerColor = Color.red;
        private Color _color;

        #endregion


        #region Properties

        public bool IsCatchPlayer
        {
            get => _isCatchPlayer;
            
            set
            {
                _isCatchPlayer = value;
                if (value)
                {
                    _color = _dangerColor;
                }
                else
                {
                    _color = _normalColor;
                }
            }
        }

        public Color Color => _color;

        #endregion

    }
}
