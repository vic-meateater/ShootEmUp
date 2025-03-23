using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IGameStopListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private GameObject _player; 
        [SerializeField] private BulletConfig _playerBulletConfig;
        [SerializeField] private GameObject _enemy; 
        [SerializeField] private BulletConfig _enemyBulletConfig;
        [SerializeField] private UIView _uiView;
        
        private GameCycle _gameCycle; 
        private PlayerController _playerController;
        private UIViewController _uiViewController;
        private InputManager  _inputManager;
        private UpdateController _updateController;
        
        private void Start()
        {
            _gameCycle = new GameCycle();
            _playerController = new PlayerController(_player, _gameManager, _bulletSystem, _playerBulletConfig);
            _inputManager = new InputManager();
            _uiViewController = new UIViewController(_uiView);
            
            _gameCycle.AddListener(this);
            _gameCycle.AddListener(_playerController);

            _updateController = new UpdateController();
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

        void IGameStopListener.OnStopGame()
        {
            FinishGame();
        }
    }
}