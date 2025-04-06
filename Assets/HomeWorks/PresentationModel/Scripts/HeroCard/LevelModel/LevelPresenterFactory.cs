namespace Popup
{
    public sealed class LevelPresenterFactory : ILevelPresenterFactory
    {
        public LevelViewModel Create(HeroCardInfo heroCardInfo, ExperienceViewModel experienceViewModel)
        {
            return new LevelViewModel(heroCardInfo, experienceViewModel);
        }
    }
}