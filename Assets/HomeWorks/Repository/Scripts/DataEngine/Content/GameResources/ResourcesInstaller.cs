using Zenject;

namespace DataEngine
{
    public sealed class ResourcesInstaller : MonoInstaller<ResourcesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourceSaveLoader>().AsSingle().NonLazy();
        }
    }
}