using UnityEngine;


namespace PiratesGame
{
    public static class InputManager
    {

        #region Properties

        public static bool isPrimaryFire => Input.GetButton(InputKeysAndAxis.KEY_PRIMARY_FIRE);

        public static bool isSecondaryFire => Input.GetButtonDown(InputKeysAndAxis.KEY_SECONDARY_FIRE);

        public static bool isPause => Input.GetButtonDown(InputKeysAndAxis.KEY_PAUSE);
        public static bool isJump => Input.GetButtonDown(InputKeysAndAxis.KEY_JUMP);
        public static float DirectionX => Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);

        #endregion

    }
}
