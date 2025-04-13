using GameEngine;
using Zenject;

namespace DataEngine
{
    public sealed class SystemsInstaller : Installer<SystemsInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnitManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ResourceService>().FromNew().AsSingle().NonLazy();
            
        }
    }
}
