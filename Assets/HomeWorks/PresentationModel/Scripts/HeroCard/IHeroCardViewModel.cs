using UnityEngine;

namespace Popup
{
    public interface IHeroCardViewModel: IViewModel
    {
        public ICharacterInfoViewModel CharacterInfoViewModel { get; }
        public ILevelViewModel LevelViewModel { get; }
        public IExperienceViewModel ExperienceViewModel { get; }
        public IStatsViewModel StatsViewModel { get; }
        public void LevelUp();
        public void AddExp(float exp);
        public void SetAvatar(Sprite avatar);
    }
}