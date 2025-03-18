using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EventManager
    {
        private static readonly Lazy<EventManager> _instance = new Lazy<EventManager>(() => new EventManager());
        public static EventManager Instance => _instance.Value;
        private EventManager() { }
        public event Action OnFire;
        public event Action<GameObject> OnEnemyReachedDestination;

        public void Fire()
        {
            OnFire?.Invoke();
        }
        public void EnemyReachedDestination(GameObject enemy)
        {
            OnEnemyReachedDestination?.Invoke(enemy);
        }
    }
}