using Zenject;

namespace DataEngine
{
    public sealed class UnitsInstaller : MonoInstaller<UnitsInstaller>
    {
        public override void InstallBindings()
        {
            var units = FindObjectsOfType<GameEngine.Unit>();
            Container.BindInterfacesAndSelfTo<UnitsSaveLoader>().AsSingle().WithArguments(units).NonLazy();
        }
    }
}