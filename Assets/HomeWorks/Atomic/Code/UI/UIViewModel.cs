using Atomic.Elements;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIViewModel : IUIViewModel
    {
        public IReactiveVariable<float> CurrentHealth { get; } = new ReactiveVariable<float>();
        public IReactiveVariable<bool> IsDead { get; } = new ReactiveVariable<bool>();
        
        private readonly UIView _view;
        
        public UIViewModel(UIView view)
        {
            _view = view;
            _view.Init(this);
        }
    }

    public interface IUIViewModel
    {
        IReactiveVariable<float> CurrentHealth { get; }
        IReactiveVariable<bool> IsDead { get; }
    }
}