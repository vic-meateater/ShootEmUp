using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour, IHealth, IDamageable
    {
        public event Action<GameObject> HPEmpty;

        private int _currentHitPoints;

        public bool IsHitPointsExists()
        {
            return _currentHitPoints > 0;
        }

        public int GetHitPoints() => _currentHitPoints;

        public void TakeDamage(int damage)
        {
            _currentHitPoints -= damage;
            if (_currentHitPoints <= 0)
            {
                HPEmpty?.Invoke(gameObject);
            }
        }

        public void SetHealth(int health)
        {
            _currentHitPoints = health;
        }
    }

    public interface IHealth
    {
        public event Action<GameObject> HPEmpty;
        public void SetHealth(int health);
    }
}