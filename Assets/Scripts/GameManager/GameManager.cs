using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private GameObject _player; 
        [SerializeField] private BulletConfig _playerBulletConfig;
        [SerializeField] private GameObject _enemy; 
        [SerializeField] private BulletConfig _enemyBulletConfig;
        
        private PlayerController _playerController;
        private InputManager  _inputManager;
        private UpdateController _updateController;
        
        private void Start()
        {
            _playerController = new PlayerController(_player, _gameManager, _bulletSystem, _playerBulletConfig);
            _inputManager = new InputManager(_player);

            _updateController = new UpdateController();
            _updateController.AddFixedUpdateable(_inputManager);
            _updateController.AddUpdateable(_inputManager);
        }

        private void Update()
        {
           _updateController.Update();
        }

        private void FixedUpdate()
        {
            _updateController.FixedUpdate();
        }

        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}