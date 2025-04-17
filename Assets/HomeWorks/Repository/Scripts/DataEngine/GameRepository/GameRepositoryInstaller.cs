using Zenject;

namespace DataEngine
{
    public class GameRepositoryInstaller : MonoInstaller<GameRepositoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle().NonLazy();
        }
    }
}