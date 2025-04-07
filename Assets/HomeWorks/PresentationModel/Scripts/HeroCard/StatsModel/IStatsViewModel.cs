using R3;

namespace Popup
{
    public interface IStatsViewModel
    {
        ReadOnlyReactiveProperty<int> MoveSpeed { get; }
        ReadOnlyReactiveProperty<int> Stamina { get; }
        ReadOnlyReactiveProperty<int> Dexterity { get; }
        ReadOnlyReactiveProperty<int> Intelligence { get; }
        ReadOnlyReactiveProperty<int> Damage { get; }
        ReadOnlyReactiveProperty<int> Regeneration { get; }

        void AddMoveSpeed(int value);
        void AddStamina(int value);
        void AddDexterity(int value);
        void AddIntelligence(int value);
        void AddDamage(int value);
        void AddRegeneration(int value);
    }
}