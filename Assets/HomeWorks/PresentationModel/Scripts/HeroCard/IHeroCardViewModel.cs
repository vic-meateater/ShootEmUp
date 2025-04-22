using System.Collections.Generic;
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
        public ReadOnlyReactiveProperty<bool> CanLevelUp { get; }
        public IReadOnlyDictionary<StatId, StatViewModel> Stats { get; }
        public string ExperienceToLvlUp { get; }
        public void LevelUp();
    }
}