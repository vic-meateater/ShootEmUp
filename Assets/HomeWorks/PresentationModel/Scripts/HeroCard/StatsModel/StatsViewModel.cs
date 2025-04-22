using System;
using System.Collections.Generic;
using R3;

namespace Popup
{
    public sealed class StatsViewModel : IStatsViewModel, IDisposable
    {
        private const int MAGIC_STATS_NUMBER = 1;
        public IReadOnlyDictionary<StatId, StatViewModel> Stats => _stats;

        private readonly Dictionary<StatId, StatViewModel> _stats;
        
        private readonly HeroCardInfo _heroCardInfo;
        private readonly ILevelViewModel _levelViewModel;

        private DisposableBag _disposable;
        public StatsViewModel(HeroCardInfo heroCardInfo, ILevelViewModel levelViewModel)
        {
            _heroCardInfo = heroCardInfo;
            _levelViewModel = levelViewModel;
            
            _stats = new Dictionary<StatId, StatViewModel>
            {
                { StatId.MoveSpeed,     new StatViewModel(StatId.MoveSpeed, _heroCardInfo.MoveSpeed) },
                { StatId.Stamina,       new StatViewModel(StatId.Stamina, _heroCardInfo.Stamina) },
                { StatId.Dexterity,     new StatViewModel(StatId.Dexterity, _heroCardInfo.Dexterity) },
                { StatId.Intelligence,  new StatViewModel(StatId.Intelligence, _heroCardInfo.Intelligence) },
                { StatId.Damage,        new StatViewModel(StatId.Damage, _heroCardInfo.Damage) },
                { StatId.Regeneration,  new StatViewModel(StatId.Regeneration, _heroCardInfo.Regeneration) },
            };

            _levelViewModel.Level.Subscribe(_ => OnLevelChange(MAGIC_STATS_NUMBER)).AddTo(ref _disposable);
        }

        private void OnLevelChange(int value)
        {
            foreach (var stat in _stats.Values)
            {
                stat.Add(value);
            }
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
public enum StatId
{
    MoveSpeed,
    Stamina,
    Dexterity,
    Intelligence,
    Damage,
    Regeneration
}