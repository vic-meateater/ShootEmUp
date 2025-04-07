using Zenject;

namespace Popup
{
    public sealed class CharacterInfoModelInstaller : Installer<CharacterInfoModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterInfoPresenterFactory>().AsSingle().NonLazy();
        }
    }
}