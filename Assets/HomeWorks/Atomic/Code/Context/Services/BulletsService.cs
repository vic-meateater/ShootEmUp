using System;
using Atomic.Elements;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class BulletsService
    {
        public SceneEntity Bullet {get; private set;}
        public BulletConfig BulletConfig;

        public event Action ShootEvent;
        
        public void SetBulletEntity(SceneEntity bulletEntity)
        {
            Bullet = bulletEntity;
        }
        
        public void OnShootEvent() => ShootEvent?.Invoke();
    }
}