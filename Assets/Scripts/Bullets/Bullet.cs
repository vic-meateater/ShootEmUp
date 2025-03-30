using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [Inject] private BulletPool _bulletPool;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public bool IsPlayer => _isPlayer;
        public int Damage => _damage;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        
        private bool _isPlayer;
        private int _damage;

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.linearVelocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
        
        public void SetIsPlayer(bool isPlayer)
        {
            _isPlayer = isPlayer;
        }
        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void SetPool(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
        
        public void Die()
        {
            _bulletPool.Despawn(this);
        }
    }
}