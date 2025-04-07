using Zenject;

namespace Popup
{
    public sealed class StatModelInstaller : Installer<StatModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StatsModelPresenterFactory>().AsSingle().NonLazy();
        }
    }
}