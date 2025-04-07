namespace Popup
{
    public interface IExperiencePresenterFactory: IPresenterFactory
    {
        public ExperienceViewModel Create(HeroCardInfo config);
    }
}