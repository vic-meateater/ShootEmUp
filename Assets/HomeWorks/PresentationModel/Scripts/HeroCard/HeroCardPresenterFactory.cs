namespace Popup
{
    public sealed class HeroCardPresenterFactory : IHeroCardPresenterFactory
    {
        private readonly IExperiencePresenterFactory _experiencePresenterFactory;
        private readonly ILevelPresenterFactory _levelPresenterFactory;
        private readonly ICharacterInfoPresenterFactory _characterInfoPresenterFactory;

        public HeroCardPresenterFactory(
            IExperiencePresenterFactory experiencePresenterFactory,
            ILevelPresenterFactory levelPresenterFactory,
            ICharacterInfoPresenterFactory characterInfoPresenterFactory)
        {
            _experiencePresenterFactory = experiencePresenterFactory;
            _levelPresenterFactory = levelPresenterFactory;
            _characterInfoPresenterFactory = characterInfoPresenterFactory;
        }
        
        public HeroCardViewModel Create(HeroCardInfo heroCardInfo)
        {
            var experienceViewModel = _experiencePresenterFactory.Create(heroCardInfo);
            var levelViewModel = _levelPresenterFactory.Create(heroCardInfo, experienceViewModel);
            var characterInfoModel = _characterInfoPresenterFactory.Create(heroCardInfo);
            return new HeroCardViewModel(heroCardInfo, experienceViewModel, levelViewModel, characterInfoModel);
        }
    }
}