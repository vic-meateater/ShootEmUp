using System;
using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class BulletPoolInstaller : IContextInstaller
    {
        public void Install(IContext context)
        {
            context.AddSystem(new BulletPoolController());
        }
    }

    public class BulletPoolController : IContextInit
    {
        private BulletsService _bulletsService;
        private WeaponService _weaponService;
        private GameObjectSpawner _spawner;
        private List<IEntity> _bulletsPool = new List<IEntity>();
        private Transform _parent;
        private Transform _shootPoint;
        private int _poolSize;

        public void Init(IContext context)
        {
            _bulletsService = context.GetGameServices().BulletsService;
            _weaponService = context.GetGameServices().WeaponService;
            _shootPoint = _weaponService.Weapon.GetShootPoint(); 
            _spawner = context.GetGameObjectSpawner();
            _bulletsService.ShootEvent += SpawnBullet;
            _parent = context.GetBulletsPool();
            _poolSize = _bulletsService.BulletConfig.PoolSize;
            
            PoolInit();
        }

        private void PoolInit()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var bulletGO = _spawner.SpawnGameObject(
                    _bulletsService.BulletConfig.Prefab,
                    _shootPoint,
                    _parent);
                bulletGO.SetActive(false);
                var bulletEntity = bulletGO.GetComponent<IEntity>();
                _bulletsPool.Add(bulletEntity);
            }
        }

        private void SpawnBullet()
        {
            
        }
    }
}