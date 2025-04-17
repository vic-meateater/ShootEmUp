using Zenject;

namespace DataEngine
{
    public class ResourcesInstaller : MonoInstaller<ResourcesInstaller>
    {
        public override void InstallBindings()
        {
            var resources = FindObjectsOfType<GameEngine.Resource>();
            Container.BindInterfacesAndSelfTo<ResourceSaveLoader>().AsSingle().WithArguments(resources).NonLazy();
        }
    }
}