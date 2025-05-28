using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    [CreateAssetMenu(fileName = "ArrowConfig", menuName = "ECSGame/ArrowConfig")]
    public class ArrowConfig : ScriptableObject
    {
        public EntityProvider Prefab;
    }
}
