using R3;
using UnityEngine;

namespace Popup
{
    public interface IHeroCardViewModel: IViewModel
    {
        public string Title { get; }
        public Sprite Avatar { get; }
        public ReadOnlyReactiveProperty<int> Level { get; }
        public string Description { get; }
        public ReadOnlyReactiveProperty<float> Experience { get; }
        public int MoveSpeed { get; }
        public int Stamina { get; }
        public int Dexterity { get; }
        public int Intelligence { get; }
        public int Damage { get; }
        public int Regeneration { get; }
        
        public ReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        public void LevelUp();
    }
}