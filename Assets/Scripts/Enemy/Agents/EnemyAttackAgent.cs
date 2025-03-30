using System;
using UnityEngine;

namespace ShootEmUp
{
    public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);
    public sealed class EnemyAttackAgent : MonoBehaviour, IFixedUpdate, IAttackAgent
    {
        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        private GameObject _target;
        private float _currentTime;
        
        
        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        void IFixedUpdate.OnFixedUpdate()
        {
            if (PrepareFiring()) return;

            FireCountdown();
        }

        private bool PrepareFiring()
        {
            if (!_moveAgent.IsReached)
            {
                return true;
            }

            if (_target == null || !_target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return true;
            }

            return false;
        }

        private void FireCountdown()
        {
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.GetPosition();
            var vector = (Vector2) _target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }

    public interface IAttackAgent
    {
        public event FireHandler OnFire;
        void SetTarget(GameObject target);
    }
}