using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ZombieGame/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab {get; private set;}
        [field: SerializeField] public int PoolSize {get; private set;}
    }
}