using Scellecs.Morpeh;

namespace ShootEmUp.Homeworks.ECSGame
{
    public struct DamageRequest : IRequestData
    {
        public Entity Requester;
        public Entity Target;
    }
}