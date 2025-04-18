using Zenject;

namespace DataEngine
{
    public sealed class ResourcesInstaller : MonoInstaller<ResourcesInstaller>
    {
        public override void InstallBindings()
        {
            var resources = FindObjectsOfType<GameEngine.Resource>();
            Container.BindInterfacesAndSelfTo<ResourceSaveLoader>().AsSingle().WithArguments(resources).NonLazy();
        }
    }
}