using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IFixedUpdateable, IUpdateable
    {
        private readonly GameObject _player;
        private float _horizontalDirection;
        

        public InputManager(GameObject player)
        {
            _player = player;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EventManager.Instance.Fire();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _horizontalDirection = 1;
            }
            else
            {
                _horizontalDirection = 0;
            }
        }
        
        public void FixedUpdate()
        {
            _player.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}