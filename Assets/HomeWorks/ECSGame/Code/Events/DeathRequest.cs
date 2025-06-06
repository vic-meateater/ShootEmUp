using Scellecs.Morpeh;

namespace ShootEmUp.Homeworks.ECSGame
{
    public struct DeathRequest : IRequestData
    {
        public Entity Requester;
        public Entity Target;
    }
}