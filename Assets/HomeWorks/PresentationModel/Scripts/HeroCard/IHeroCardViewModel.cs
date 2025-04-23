namespace Popup
{
    public interface IHeroCardViewModel: IViewModel
    {
        public ICharacterInfoViewModel CharacterInfoViewModel { get; }
        public ILevelViewModel LevelViewModel { get; }
        public IExperienceViewModel ExperienceViewModel { get; }
        public IStatsViewModel StatsViewModel { get; }
        public void LevelUp();
    }
}