using System.Collections.Generic;

namespace Popup
{
    public interface IStatsViewModel
    {
        public IReadOnlyDictionary<StatId, StatViewModel> Stats { get; }
    }
}