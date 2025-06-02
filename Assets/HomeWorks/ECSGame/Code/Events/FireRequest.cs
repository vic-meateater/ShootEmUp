using Scellecs.Morpeh;

namespace ShootEmUp.Homeworks.ECSGame
{
    public struct FireRequest : IRequestData
    {
        public Entity Requester;
        public Entity Target;
        
    }

    public struct ArrowSpawnRequest : IRequestData
    {
        public Entity Requester;
    }
}