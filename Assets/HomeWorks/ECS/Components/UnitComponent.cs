namespace ShootEmUp.HomeWorks.ECS
{
    struct UnitComponent
    {
        public int Team; // 0 - red, 1 - blue
        public int Health;
        public float AttackRange;
        public float AttackCooldown;
        public float CurrentCooldown;
    }
}