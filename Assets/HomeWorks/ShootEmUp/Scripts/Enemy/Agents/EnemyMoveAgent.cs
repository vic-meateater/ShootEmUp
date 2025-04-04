using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IFixedUpdate, IMoveAgent
    {
        [SerializeField] private MoveComponent _moveComponent;
        public bool IsReached => _isReached;
        
        private Vector2 _destination;
        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

        public void OnFixedUpdate()
        {
            MoveEnemy();
        }

        private void MoveEnemy()
        {
            if (_isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2) transform.position;
            if (vector.magnitude <= 0.25f)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }

    public interface IMoveAgent
    {
        public void SetDestination(Vector2 endPoint);
    }
}