using R3;
using UnityEngine;

namespace Popup
{
    public interface IHeroCardViewModel: IViewModel
    {
        public ReadOnlyReactiveProperty<string> Title { get; }
        public ReadOnlyReactiveProperty<Sprite> Avatar { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        public ReadOnlyReactiveProperty<string> Description { get; }
        public ReadOnlyReactiveProperty<float> Experience { get; }
        public ReadOnlyReactiveProperty<int> MoveSpeed { get; }
        public ReadOnlyReactiveProperty<int> Stamina { get; }
        public ReadOnlyReactiveProperty<int> Dexterity { get; }
        public ReadOnlyReactiveProperty<int> Intelligence { get; }
        public ReadOnlyReactiveProperty<int> Damage { get; }
        public ReadOnlyReactiveProperty<int> Regeneration { get; }
        public ReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        public float MaxExperience { get; }
        public void LevelUp();
    }
}