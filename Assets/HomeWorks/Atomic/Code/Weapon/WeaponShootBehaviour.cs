using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class WeaponShootBehaviour : IEntityInit, IEntityUpdate
    {
        private ReactiveInt _maxBullets;
        private ReactiveInt _currentBullets;
        private ReactiveFloat _reloadInterval;
        private ReactiveFloat _shootCooldown;
        private ReactiveFloat _reloadTimer;
        private float _lastShootTime;
        
        private IEvent _shootAction;
        private IEvent _shootEvent;
        
        public void Init(IEntity entity)
        {
            _shootAction = entity.GetDealDamageAction();
            _shootAction.Subscribe(OnDealDamageAction);
            _shootEvent = entity.GetDealDamageEvent();
            _maxBullets = entity.GetMaxBullets();
            _currentBullets = entity.GetCurrentBullets();
            _reloadInterval = entity.GetRealoadInterval();
            _shootCooldown = entity.GetShootCoolDown();
            _reloadTimer = entity.GetReloadTimer();
            
            _currentBullets.Value = _maxBullets.Value;
            _reloadTimer.Value = 0f;
            _lastShootTime = -_shootCooldown.Value;
        }

        private void OnDealDamageAction()
        {
            if (CanShoot())
            {
                _currentBullets.Value--;
                _lastShootTime = Time.time;
                _shootEvent?.Invoke();
                Debug.Log($"Dealing damage {_currentBullets.Value} left");
            }
            else
            {
                Debug.Log($"Can't deal damage {_currentBullets.Value} bullets. Cooldown: {_lastShootTime}");
            }
        }

        private bool CanShoot()
        {
            bool hasAmmo = _currentBullets.Value > 0;
            bool cooldownPassed = Time.time - _lastShootTime >= _shootCooldown.Value;
            return hasAmmo && cooldownPassed;
        }
        
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_currentBullets.Value >= _maxBullets.Value) 
            {
                _reloadTimer.Value = 0f;
                return;
            }

            _reloadTimer.Value += deltaTime;
        
            if (_reloadTimer.Value >= _reloadInterval.Value)
            {
                _currentBullets.Value = Mathf.Min(_currentBullets.Value + 1, _maxBullets.Value);
                _reloadTimer.Value = 0f;
                Debug.Log($"Ammo reloaded: {_currentBullets.Value}/{_maxBullets.Value}");
            }
        }
    }
}