using Zenject;
namespace Popup
{
    public sealed class ExperiencePresenterFactory : IExperiencePresenterFactory
    {
        public ExperienceViewModel Create(HeroCardInfo heroCardInfo)
        {
            return new ExperienceViewModel(heroCardInfo);
        }
    }
}