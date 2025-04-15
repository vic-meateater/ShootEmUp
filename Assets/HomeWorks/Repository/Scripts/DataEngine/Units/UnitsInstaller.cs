using Zenject;

namespace DataEngine
{
    public class UnitsInstaller : MonoInstaller<UnitsInstaller>
    {
        public override void InstallBindings()
        {
            var units = FindObjectsOfType<GameEngine.Unit>();
            Container.BindInterfacesAndSelfTo<UnitsSaveLoader>().AsSingle().WithArguments(units).NonLazy();
        }
    }
}