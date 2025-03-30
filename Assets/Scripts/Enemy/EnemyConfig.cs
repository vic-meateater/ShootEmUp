using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "EnemyConfig",
        menuName = "ShootEmUp/New EnemyConfig"
    )]
    public class EnemyConfig : ScriptableObject
    {
        public Enemy EnemyPrefab;
        public int HealthPoints;
        public float Speed;
    }
}