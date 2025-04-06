namespace Popup
{
    public sealed class HeroCardPresenterFactory : IHeroCardPresenterFactory
    {
        private readonly IExperiencePresenterFactory _experiencePresenterFactory;
        private readonly ILevelPresenterFactory _levelPresenterFactory;

        public HeroCardPresenterFactory(
            IExperiencePresenterFactory experiencePresenterFactory,
            ILevelPresenterFactory levelPresenterFactory)
        {
            _experiencePresenterFactory = experiencePresenterFactory;
            _levelPresenterFactory = levelPresenterFactory;
        }
        
        public HeroCardViewModel Create(HeroCardInfo heroCardInfo)
        {
            var experienceViewModel = _experiencePresenterFactory.Create(heroCardInfo);
            var levelViewModel = _levelPresenterFactory.Create(heroCardInfo, experienceViewModel);
            return new HeroCardViewModel(heroCardInfo, experienceViewModel, levelViewModel);
        }
    }
}