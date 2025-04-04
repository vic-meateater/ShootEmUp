using UnityEngine;

namespace ShootEmUp
{
    public class WorldPositionPoint: MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}