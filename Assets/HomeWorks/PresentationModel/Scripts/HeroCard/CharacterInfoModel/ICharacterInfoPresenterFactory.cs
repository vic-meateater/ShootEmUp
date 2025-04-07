namespace Popup
{
    public interface ICharacterInfoPresenterFactory
    {
        CharacterInfoViewModel Create(HeroCardInfo config);
    }
}