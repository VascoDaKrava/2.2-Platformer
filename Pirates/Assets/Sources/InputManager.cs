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

        #endregion


        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetDirection()
        {
            Vector2 direction = new Vector2();
            direction.x = Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);
            direction.y = Input.GetAxis(InputKeysAndAxis.AXIS_VERTICAL);

            return direction.normalized;
        }

        #endregion

    }
}
