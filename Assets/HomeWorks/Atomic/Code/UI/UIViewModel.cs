using Atomic.Elements;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class UIViewModel : IUIViewModel
    {
        public IReactiveVariable<float> CurrentHealth { get; } = new ReactiveVariable<float>();
        public IReactiveVariable<bool> IsDead { get; } = new ReactiveVariable<bool>();
        public IReactiveVariable<int> MaxBullets { get; } = new ReactiveVariable<int>();
        public IReactiveVariable<int> CurrentBullets { get; } = new ReactiveVariable<int>();

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
        IReactiveVariable<int> MaxBullets { get; }
        IReactiveVariable<int> CurrentBullets { get; }
        
    }
}