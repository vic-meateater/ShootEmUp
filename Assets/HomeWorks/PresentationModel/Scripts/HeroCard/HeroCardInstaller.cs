using Zenject;

namespace Popup
{
    public sealed class HeroCardInstaller : Installer<HeroCardInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HeroCardPresenterFactory>().AsSingle().NonLazy();
        }
    }
}
