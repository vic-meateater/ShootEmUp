using Zenject;

namespace Popup
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ExperienceModelInstaller.Install(Container);
            LevelModelInstaller.Install(Container);
            CharacterInfoModelInstaller.Install(Container);
            HeroCardInstaller.Install(Container);
        }
    }
}
