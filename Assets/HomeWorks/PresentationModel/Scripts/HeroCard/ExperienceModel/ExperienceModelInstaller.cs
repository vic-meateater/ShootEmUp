using Zenject;

namespace Popup
{
    public sealed class ExperienceModelInstaller : Installer<ExperienceModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ExperiencePresenterFactory>().AsSingle().NonLazy();
        }
    }
}