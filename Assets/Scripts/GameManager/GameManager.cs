using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IGameStopListener
    {
        [Inject] private GameCycle _gameCycle; 
        [Inject] private LevelBackground _levelBackground; 
        [Inject] private PlayerController _playerController;
        [Inject] private UIViewController _uiViewController;
        [Inject] private InputManager _inputManager;
        [Inject] private UpdateController _updateController;
        [Inject] private BulletSystem _bulletSystem;
        [Inject] private EnemyPool _enemyPool;
        [Inject] private EnemyManager _enemyManager;
        
        private void Start()
        {
            _gameCycle.AddListener(this);
            _gameCycle.AddListener(_playerController);
            _gameCycle.AddListener(_enemyManager);
            _gameCycle.AddListener(_bulletSystem);
            _gameCycle.AddListener(_levelBackground);

            _updateController.AddUpdateable(_enemyManager);
            _updateController.AddUpdateable(_inputManager);
            _updateController.AddUpdateable(_bulletSystem);
            _updateController.AddUpdateable(_levelBackground);
        }

        private void Update()
        {
           _updateController.OnUpdate();
        }

        private void FixedUpdate()
        {
            _updateController.OnFixedUpdate();
        }

        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        void IGameStopListener.OnStopGame()
        {
            FinishGame();
        }
    }
}