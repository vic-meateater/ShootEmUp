using Zenject;

namespace Popup
{
    public class ExperienceModelInstaller : Installer<ExperienceModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ExperiencePresenterFactory>().AsSingle().NonLazy();
        }
    }
}