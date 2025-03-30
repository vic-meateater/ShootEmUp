using UnityEngine;

namespace ShootEmUp
{
    public class Player : MonoBehaviour, IPlayer
    {
        private float _speed;
        private int _health;
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }

    public interface IPlayer
    {
    }
}
