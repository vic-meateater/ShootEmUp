using Zenject;

namespace DataEngine
{
    public sealed class GameRepositoryInstaller : MonoInstaller<GameRepositoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle().NonLazy();
        }
    }
}