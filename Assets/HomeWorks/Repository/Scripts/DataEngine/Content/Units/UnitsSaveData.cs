using System.Collections.Generic;

namespace DataEngine
{
    [System.Serializable]
    public sealed class UnitsSaveData
    {
        public HashSet<UnitsData> Units;
    }
    
    [System.Serializable]
    public struct UnitsData
    {
        public string UnitType;
        public int HitPoints;
        public float[] Position;
        public float[] Rotation;
    }
}