using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MoveComponent : MonoBehaviour, IMovable, ISpeedChangeable
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private float _speed;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }

    public interface ISpeedChangeable
    {
        public void SetSpeed(float speed);
    }

    public interface IMovable
    {
        public void MoveByRigidbodyVelocity(Vector2 vector);
    }
}