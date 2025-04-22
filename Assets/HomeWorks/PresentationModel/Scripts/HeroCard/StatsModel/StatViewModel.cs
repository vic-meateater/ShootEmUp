using R3;

namespace Popup
{
    public sealed class StatViewModel
    {
        public StatId Id { get; }
        public ReadOnlyReactiveProperty<int> Value => _value;

        private readonly ReactiveProperty<int> _value;

        public StatViewModel(StatId id, int initialValue)
        {
            Id = id;
            _value = new ReactiveProperty<int>(initialValue);
        }

        public void Add(int amount) => _value.Value += amount;
    }
}