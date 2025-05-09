using System;
using Atomic.Entities;
using UnityEngine.Serialization;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class PlayerService
    {
        public SceneEntity Player { get; private set; }
        public PlayerConfig PlayerConfig;
        
        public void SetPlayerEntity(SceneEntity playerEntity)
        {
            Player = playerEntity;
        }
    }
}