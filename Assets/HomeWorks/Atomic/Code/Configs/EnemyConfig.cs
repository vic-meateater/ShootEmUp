using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ZombieGame/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab {get; private set;}
        [field: SerializeField] public int PoolSize {get; private set;}
        [field: SerializeField] public float RespawnInterval {get; private set;}
    }
}