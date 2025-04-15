using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class ServicesMonoInstaller : MonoInstaller
    {
        [SerializeField] private UnitManager _unitManager;
        [SerializeField] private ResourceService _resourceService;
        
        public override void InstallBindings()
        {
            Container.Bind<UnitManager>().FromInstance(_unitManager).AsSingle().NonLazy();
            Container.Bind<ResourceService>().FromInstance(_resourceService).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<SaveLoadGameServices>()
                .AsSingle()
                .WithArguments(_unitManager, _resourceService)
                .NonLazy();
        }
    }
}