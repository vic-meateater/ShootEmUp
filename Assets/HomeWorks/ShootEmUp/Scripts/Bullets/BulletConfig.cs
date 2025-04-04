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
        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public bool IsPlayer;
    }
}