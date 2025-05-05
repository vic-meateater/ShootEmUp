using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameCotextInstaller : SceneContextInstallerBase
    {
        [SerializeField] MoveController _moveController;
        [SerializeField] PlayerInputController _playerInputController;

        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            
            context.AddSystem(_playerInputController);
        }
    }

    [Serializable]
    public class PlayerInputController : IContextInit, IContextUpdate
    {
        [SerializeField] private SceneEntity _playerEntity;
        private MoveController _moveController;

        public void Init(IContext context)
        {
            _moveController = context.GetMoveController();
        }


        public void Update(IContext context, float deltaTime)
        {
            _playerEntity.Entity.GetMoveDirection().Value = _moveController.MoveDirection.Value;
        }
    }
}