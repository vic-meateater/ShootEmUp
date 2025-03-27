using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IUpdate
    {
        private float _horizontalDirection;
        
        void IUpdate.OnUpdate()
        {
            PlayerInput();
        }

        private void PlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                EventManager.Instance.OnFire();
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _horizontalDirection = 1;
            }
            else
            {
                _horizontalDirection = 0;
            }
            EventManager.Instance.OnPlayerInputChanged(_horizontalDirection);
        }
    }
}