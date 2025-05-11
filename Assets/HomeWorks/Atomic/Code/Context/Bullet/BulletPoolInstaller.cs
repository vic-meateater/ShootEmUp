using System;
using Atomic.Contexts;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class BulletPoolInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new BulletPoolController());
        }
    }
}