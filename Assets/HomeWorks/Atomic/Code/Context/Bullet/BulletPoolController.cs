using System.Collections.Generic;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class BulletPoolController : IContextInit
    {
        private BulletsService _bulletsService;
        private WeaponService _weaponService;
        private GameObjectSpawner _spawner;
        private Transform _parent;
        private Transform _shootPoint;
        private ReactiveFloat _bulletSpeed;
        private int _poolSize;
        private Queue<GameObject> _bulletsPool = new Queue<GameObject>();

        public void Init(IContext context)
        {
            _bulletsService = context.GetGameServices().BulletsService;
            _weaponService = context.GetGameServices().WeaponService;
            _spawner = context.GetGameObjectSpawner();
            _parent = context.GetBulletsPool();
            
            _shootPoint = _weaponService.Weapon.GetShootPoint(); 
            _bulletSpeed = _weaponService.Weapon.GetBulletSpeed();
            _poolSize = _bulletsService.BulletConfig.PoolSize;
            
            _bulletsService.ShootEvent += SpawnBullet;
            
            PoolInit();
        }

        private void PoolInit()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var bulletGO = _spawner.SpawnGameObject(
                    _bulletsService.BulletConfig.Prefab,
                    _parent,
                    _parent);
                bulletGO.SetActive(false);
                _bulletsPool.Enqueue(bulletGO);
            }
        }

        private void SpawnBullet()
        {
#if UNITY_EDITOR
            if (_bulletsPool.Count == 0)
            {
                Debug.LogWarning("No bullets in pool!");
                return;
            }
#endif
            var bullet = _bulletsPool.Dequeue();
            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = _shootPoint.rotation;

            if (bullet.TryGetComponent(out IEntity bulletEntity))
            {

                bulletEntity.GetMoveDirection().Value = _shootPoint.forward;
                bulletEntity.GetMoveSpeed().Value = _bulletSpeed.Value;
                bulletEntity.GetBaseDamage().Value *= _weaponService.Weapon.GetDamageMultiplier().Value;
            }

            bullet.SetActive(true);
            
            if(bulletEntity.TryGetDealDamageEvent(out IEvent damageEvent))
                damageEvent.OnEvent += () => ReturnBulletToPool(bulletEntity);

        }

        private void ReturnBulletToPool(IEntity bulletEntity)
        {
            Debug.Log("Returning bullet to pool");
            var bullet = (bulletEntity as MonoBehaviour)?.gameObject;
            if (bullet)
            {
                bullet.SetActive(false);
                bullet.transform.position = _parent.position;
                _bulletsPool.Enqueue(bullet);
            }
        }
    }
}