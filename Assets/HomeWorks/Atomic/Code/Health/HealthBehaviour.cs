using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class HealthBehaviour : IEntityInit, IEntityDispose
    {
        private IReactiveVariable<float> _currentHealth;
        private IEvent<float> _takeDamageAction;
        private IReactiveVariable<bool> _isDead;

        public void Init(IEntity entity)
        {
            _currentHealth = entity.GetCurrentHealth();
            _takeDamageAction = entity.GetTakeDamage();
            _takeDamageAction.Subscribe(OnTakeDamage);
            _isDead = entity.GetIsDead();
        }

        private void OnTakeDamage(float damage)
        {
            if (_currentHealth.Value - damage <= 0)
            {
                _isDead.Value = true;
                return;
            }

            _currentHealth.Value -= damage;
        }

        public void Dispose(IEntity entity)
        {
            _takeDamageAction.Unsubscribe(OnTakeDamage);
        }
    }
}