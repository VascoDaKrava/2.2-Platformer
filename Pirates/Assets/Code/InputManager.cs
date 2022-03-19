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
        /// Normalized direction
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetDirection()
        {
            Vector3 direction = new Vector3();
            direction.x = Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);
            direction.y = Input.GetAxis(InputKeysAndAxis.AXIS_VERTICAL);
            direction.z = 0.0f;

            return direction.normalized;
        }

        public static Vector3 GetDirectionX()
        {
            Vector3 direction = new Vector3();
            direction.x = Input.GetAxis(InputKeysAndAxis.AXIS_HORIZONTAL);
            direction.y = 0.0f;
            direction.z = 0.0f;

            return direction;
        }

        #endregion

    }
}
