using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IUpdateable
    {
        private float _horizontalDirection;
        
        public void Update()
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