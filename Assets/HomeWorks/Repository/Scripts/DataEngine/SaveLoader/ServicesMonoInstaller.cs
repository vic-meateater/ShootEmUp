using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class MonoInstaller : MonoInstaller
    {
        [SerializeField] private UnitManager _unitManager;
        [SerializeField] private ResourceService _resourceService;
        
        public override void InstallBindings()
        {
            var units = FindObjectsOfType<Unit>();
            var resources = FindObjectsOfType<Resource>();
            
            Container.Bind<SaveLoader>().FromNew().AsSingle().WithArguments(units, resources).NonLazy();
            Container.Bind<UnitManager>().FromInstance(_unitManager).AsSingle().NonLazy();
            Container.Bind<ResourceService>().FromInstance(_resourceService).AsSingle().NonLazy();
        }
    }
}