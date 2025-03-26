using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IGameStopListener
    {
        [Header("Game")]
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private LevelBackground _levelBackground;
        [SerializeField] private GameData _gameData;
        
        [Header("Bullet")]
        [SerializeField] private Transform _bulletPoolContainerTransform;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _bulletInitialCount;
        
        [Header("Player")]
        [SerializeField] private GameObject _player; 
        [SerializeField] private BulletConfig _playerBulletConfig;
        [SerializeField] private Transform _playerSpawnTransform;
        
        [Header("Enemies")]
        [SerializeField] private GameObject _enemyPrefab; 
        [SerializeField] private BulletConfig _enemyBulletConfig;
        [SerializeField] private Transform _enemyPoolContainerTransform;
        [SerializeField] private EnemyPositions _enemyPositions;

       
        [Header("UI")]
        [SerializeField] private UIView _uiView;
        
        private GameCycle _gameCycle; 
        private PlayerController _playerController;
        private UIViewController _uiViewController;
        private InputManager  _inputManager;
        private UpdateController _updateController;
        private BulletSystem _bulletSystem;
        private EnemyPool _enemyPool;
        private EnemyManager _enemyManager;
        
        private void Start()
        {
            _gameData.WorldTransform = _worldTransform;
            _gameData.EnemyPoolContainerTransform = _enemyPoolContainerTransform;
            _gameData.EnemyPositions = _enemyPositions;
            _gameData.EnemyPrefab = _enemyPrefab;
            _gameData.LevelBounds = _levelBounds;
            _gameData.BulletPoolContainerTransform = _bulletPoolContainerTransform;
            _gameData.BulletPrefab = _bulletPrefab;
            _gameData.BulletInitialCount = _bulletInitialCount;
            
            _gameCycle = new GameCycle();
            _updateController = new UpdateController();
            _uiViewController = new UIViewController(_uiView);
            _inputManager = new InputManager();
            _bulletSystem = new BulletSystem(_gameData);
            _playerController = new PlayerController(_player, 
                                                    _gameManager, 
                                                    _bulletSystem, 
                                                    _playerBulletConfig, 
                                                    _playerSpawnTransform, 
                                                    _gameData);

            _enemyPool = new EnemyPool(_gameData);
            _enemyManager = new EnemyManager(_enemyPool, _gameData, _bulletSystem, _updateController);
            
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