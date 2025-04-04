using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    public class PlayerPrefabInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerSpawnPoint _playerSpawnTransform;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerConfig).AsSingle();
            Container.BindInstance(_playerSpawnTransform).AsSingle();
            Container.BindInterfacesTo<PlayerFactory>().AsSingle().WithArguments(_playerConfig);
        }
    }
}