using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public sealed class UnitsInstaller : MonoInstaller<UnitsInstaller>
    {
        [SerializeField] private UnitsConfig _unitsConfig;
        public override void InstallBindings()
        {
            var units = FindObjectsOfType<GameEngine.Unit>();
            var prefabsDictionary = _unitsConfig.ToDictionary();
            Container.Bind<Dictionary<string, GameEngine.Unit>>()
                .FromInstance(prefabsDictionary)
                .AsSingle()
                .WhenInjectedInto<UnitsSaveLoader>();
            Container.BindInterfacesAndSelfTo<UnitsSaveLoader>().AsSingle().WithArguments(units, prefabsDictionary).NonLazy();
        }
    }
}