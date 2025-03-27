using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "ShootEmUp/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        public PhysicsLayer PhysicsLayer;
        public Color BulletColor;
        
        public int Damage;
        public float Speed;
    }
}