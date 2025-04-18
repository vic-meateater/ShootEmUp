using System;
using System.Collections.Generic;

namespace DataEngine
{
    [Serializable]
    public sealed class ResourcesSaveData
    {
        public IEnumerable<ResourceData> Resources;
    }
    
    [Serializable]
    public struct ResourceData 
    {
        public string ID;
        public int Amount;
        public float[] Position;
        
    }
}