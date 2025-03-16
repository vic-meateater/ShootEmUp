using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        public Vector2 GetPosition() => _firePoint.position;
        public Quaternion GetRotation() => _firePoint.rotation;
    }
}