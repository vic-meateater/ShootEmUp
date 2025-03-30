using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private UIView _uiView;
        [SerializeField] private WorldPositionPoint _worldSpawnTransform;
        [SerializeField] private LevelBounds _levelBounds;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameData).AsSingle();
            Container.BindInstance(_uiView).AsSingle();
            Container.BindInstance(_worldSpawnTransform).AsSingle();
            Container.BindInstance(_levelBounds).AsSingle();
            Container.BindInterfacesAndSelfTo<UpdateController>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<UIViewController>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletSystem>().FromNew().AsSingle().WithArguments(_gameData);
            Container.BindInterfacesAndSelfTo<GameCycle>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyManager>().FromNew().AsSingle();
            
        }
    }
}