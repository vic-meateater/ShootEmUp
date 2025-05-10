using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class WeaponEntityInstaller : SceneEntityInstaller
    {
        [SerializeField] private WeaponInstaller _weaponInstaller;
        [SerializeField] private DealDamageEventsInstaller _dealDamageEventsInstaller;
        public override void Install(IEntity entity)
        {
            _weaponInstaller.Install(entity);
            _dealDamageEventsInstaller.Install(entity);
        }
    }
    
    [Serializable]
    public class WeaponInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ReactiveInt _maxBullets;
        [SerializeField] private ReactiveFloat _reloadInterval;
        [SerializeField] private ReactiveFloat _shootCooldown;
        
        public void Install(IEntity entity)
        {
            entity.AddShootPoint(_shootPoint);
            entity.AddMaxBullets(_maxBullets);
            entity.AddRealoadInterval(_reloadInterval);
            entity.AddShootCoolDown(_shootCooldown);
            entity.AddReloadTimer(new ReactiveFloat(0f));
            entity.AddCurrentBullets(new ReactiveInt());
            
            entity.AddBehaviour(new WeaponShootBehaviour());
        }
    }
}