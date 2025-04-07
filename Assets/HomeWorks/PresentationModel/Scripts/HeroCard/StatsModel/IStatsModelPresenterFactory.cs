namespace Popup
{
    public interface IStatsModelPresenterFactory: IPresenterFactory
    {
        StatsViewModel Create(HeroCardInfo heroCardInfo, ILevelViewModel levelViewModel);
    }
}