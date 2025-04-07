namespace Popup
{
    public sealed class HeroCardPresenterFactory : IHeroCardPresenterFactory
    {
        private readonly IExperiencePresenterFactory _experiencePresenterFactory;
        private readonly ILevelPresenterFactory _levelPresenterFactory;
        private readonly ICharacterInfoPresenterFactory _characterInfoPresenterFactory;
        private readonly IStatsModelPresenterFactory _statsModelPresenterFactory;
        
        public HeroCardPresenterFactory(
            IExperiencePresenterFactory experiencePresenterFactory,
            ILevelPresenterFactory levelPresenterFactory,
            ICharacterInfoPresenterFactory characterInfoPresenterFactory,
            IStatsModelPresenterFactory statsModelPresenterFactory)
        {
            _experiencePresenterFactory = experiencePresenterFactory;
            _levelPresenterFactory = levelPresenterFactory;
            _characterInfoPresenterFactory = characterInfoPresenterFactory;
            _statsModelPresenterFactory = statsModelPresenterFactory;
        }
        
        public HeroCardViewModel Create(HeroCardInfo heroCardInfo)
        {
            var experienceViewModel = _experiencePresenterFactory.Create(heroCardInfo);
            var levelViewModel = _levelPresenterFactory.Create(heroCardInfo, experienceViewModel);
            var characterInfoModel = _characterInfoPresenterFactory.Create(heroCardInfo);
            var statsModel = _statsModelPresenterFactory.Create(heroCardInfo, levelViewModel);
            return new HeroCardViewModel(heroCardInfo, experienceViewModel, levelViewModel, characterInfoModel, statsModel);
        }
    }
}