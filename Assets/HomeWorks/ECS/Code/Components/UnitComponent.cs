namespace ShootEmUp.HomeWorks.ECS
{
    struct UnitComponent
    {
        public Team Team;
        public int Health;
        public float AttackRange;
        public float AttackCooldown;
        public float CurrentCooldown;
    }
}

public enum Team
{
    Red,
    Blue
}