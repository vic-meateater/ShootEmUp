using R3;

namespace Popup
{
    public interface ILevelViewModel : IViewModel
    {
        ReadOnlyReactiveProperty<int> Level { get; }
        ReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        public void AddLevel();
    }
}