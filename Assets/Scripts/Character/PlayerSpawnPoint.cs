using UnityEngine;

namespace ShootEmUp
{
    public class PlayerSpawnPoint: MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}