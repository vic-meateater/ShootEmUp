using Zenject;

namespace DataEngine
{
    public class LevelInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            SystemsInstaller.Install(Container);
        }
    }
}
