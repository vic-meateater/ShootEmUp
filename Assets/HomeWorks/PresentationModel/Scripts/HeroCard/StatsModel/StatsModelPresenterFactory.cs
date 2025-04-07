namespace Popup
{
    public sealed class StatsModelPresenterFactory : IStatsModelPresenterFactory
    {
        public StatsViewModel Create(HeroCardInfo heroCardInfo, ILevelViewModel levelViewModel)
        {
            return new StatsViewModel(heroCardInfo, levelViewModel);
        }
    }
}