using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IFixedUpdateable, IUpdateable
    {
        private readonly GameObject _player;
        private readonly PlayerController _playerController;
        private EventManager _eventManager;
        private float _horizontalDirection;
        

        public InputManager(GameObject player, PlayerController playerController, EventManager eventManager)
        {
            _player = player;
            _playerController = playerController;
            _eventManager = eventManager;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _eventManager.Fire();
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