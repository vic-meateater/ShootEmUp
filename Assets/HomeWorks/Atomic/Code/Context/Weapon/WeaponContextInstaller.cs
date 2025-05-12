using System;
using Atomic.Contexts;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class WeaponContextInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new WeaponSpawnerController());
            context.AddSystem(new WeaponController());
        }
    }
}