using System;

namespace ShootEmUp.HomeWorks.ECS
{
    [Serializable]
    struct UnitComponent
    {
        public float AttackRange;
        public float AttackCooldown;
        public float CurrentCooldown;
    }
}

