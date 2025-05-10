using System;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class BulletsService
    {
        public SceneEntity Bullet {get; private set;}
        public BulletConfig BulletConfig;
        
        public void SetBulletEntity(SceneEntity bulletEntity)
        {
            Bullet = bulletEntity;
        }
    }
}