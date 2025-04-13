using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class SaveLoaderMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var units = FindObjectsOfType<Unit>();
            Container.Bind<SaveLoader>().FromNew().AsSingle().WithArguments(units).NonLazy();
        }
    }
}