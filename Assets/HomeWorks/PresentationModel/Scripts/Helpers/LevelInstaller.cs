using Zenject;

namespace Popup
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            LevelModelInstaller.Install(Container);
            HeroCardInstaller.Install(Container);
        }
    }
}
