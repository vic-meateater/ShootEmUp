namespace Popup
{
    public interface ILevelPresenterFactory : IPresenterFactory
    {
        public LevelViewModel Create(HeroCardInfo config, ExperienceViewModel experienceViewModel);
    }
}