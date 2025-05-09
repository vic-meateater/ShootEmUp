using System;
using Atomic.Contexts;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class PlayerInputInstaller : IContextInstaller
    {        
        [SerializeField] private MoveController _moveController;

        public void Install(IContext context)
        {
            context.AddMoveController(_moveController);
            context.AddSystem(new PlayerInputController());
        }
    }
}