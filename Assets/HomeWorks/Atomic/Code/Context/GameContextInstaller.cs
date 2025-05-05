using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class GameContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private PlayerService _playerService;

        public override void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            context.AddPlayerService(_playerService);
            
            context.AddSystem(_playerInputController);
        }
    }

    [Serializable]
    public class PlayerInputController : IContextInit, IContextUpdate
    {
        [SerializeField] private SceneEntity _playerEntity;
        private MoveController _moveController;
        private PlayerService _playerService;
        private SceneEntity _playerEnt;

        public void Init(IContext context)
        {
            _moveController = context.GetMoveController();
            _playerService = context.GetPlayerService();
            _playerEnt = _playerService.PlayerEntity;
        }


        public void Update(IContext context, float deltaTime)
        {
            _playerEnt.GetMoveDirection().Value = _moveController.MoveDirection.Value;
            //_playerEntity.Entity.GetMoveDirection().Value = _moveController.MoveDirection.Value;
            _playerEntity.Entity.GetLookPoint().Value = _moveController.LookPoint.Value;
        }
    }
}