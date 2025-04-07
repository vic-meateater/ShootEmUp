namespace Popup
{
    public interface IHeroCardPresenterFactory : IPresenterFactory
    {
        public HeroCardViewModel Create(HeroCardInfo config);
    }
}