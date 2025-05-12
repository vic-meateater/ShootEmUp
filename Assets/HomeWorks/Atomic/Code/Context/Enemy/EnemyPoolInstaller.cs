using System;
using Atomic.Contexts;

namespace ShootEmUp.HomeWorks.Atomic.Enemy
{
    [Serializable]
    public class EnemyPoolInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new EnemyPoolController());
        }
    }
}