using Scellecs.Morpeh;

namespace ShootEmUp.Homeworks.ECSGame
{
    public struct DeathEvent : IEventData
    {
        public Entity Entity;
    }
}