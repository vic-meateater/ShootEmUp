using Zenject;

namespace Popup
{
    public sealed class LevelModelInstaller : Installer<LevelModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelPresenterFactory>().AsSingle().NonLazy();
        }
    }
}