using Zenject;

namespace DataEngine
{
    public class ManagersInstaller : MonoInstaller<ManagersInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveLoaderManager>().AsSingle().NonLazy();
        }
    }
}