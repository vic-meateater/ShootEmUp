using System;

namespace ShootEmUp.HomeWorks.ECS
{
    [Serializable]
    public struct TeamComponent
    {
        public Team Team;
    }
    
    public enum Team
    {
        Red,
        Blue
    }
}

