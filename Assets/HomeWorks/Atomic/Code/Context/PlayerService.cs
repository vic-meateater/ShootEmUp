using System;
using Atomic.Entities;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class PlayerService
    {
        public SceneEntity PlayerEntity;

        public void SetPlayerEntity(SceneEntity playerEntity)
        {
            PlayerEntity = playerEntity;
        }
    }
}