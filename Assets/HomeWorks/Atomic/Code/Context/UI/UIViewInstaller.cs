using System;
using Atomic.Contexts;
using UnityEngine;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class UIViewInstaller : IContextInstaller
    {
        [SerializeField] private UIView _uiView;
        public void Install(IContext context)
        {
            context.AddIUIViewModel(new UIViewModel(_uiView));
    
            context.AddSystem(new UIViewController());
        }
    }
}