using System.Collections.Generic;
using UnityEngine;

namespace DataEngine
{
    [CreateAssetMenu(fileName = "UnitsConfig", menuName = "Repository/UnitsConfig")]
    public sealed class UnitsConfig : ScriptableObject
    {
        public List<GameEngine.Unit> Prefabs;
    
        public Dictionary<string, GameEngine.Unit> ToDictionary()
        {
            var dict = new Dictionary<string, GameEngine.Unit>();
            foreach (var prefab in Prefabs)
            {
                dict[prefab.Type] = prefab;
            }
            return dict;
        }
    }
}
