using Zenject;

namespace DataEngine
{
    public sealed class ManagersInstaller : MonoInstaller<ManagersInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveLoaderManager>().AsSingle().NonLazy();
        }
    }
}