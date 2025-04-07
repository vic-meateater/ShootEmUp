using System;
using R3;

namespace Popup
{
    public sealed class StatsViewModel : IStatsViewModel, IDisposable
    {
        private const int MAGIC_STATS_NUMBER = 1;
        public ReadOnlyReactiveProperty<int> MoveSpeed => _moveSpeed;
        public ReadOnlyReactiveProperty<int> Stamina => _stamina;
        public ReadOnlyReactiveProperty<int> Dexterity => _dexterity;
        public ReadOnlyReactiveProperty<int> Intelligence => _intelligence;
        public ReadOnlyReactiveProperty<int> Damage => _damage;
        public ReadOnlyReactiveProperty<int> Regeneration => _regeneration;

        private readonly ReactiveProperty<int> _moveSpeed;
        private readonly ReactiveProperty<int> _stamina;
        private readonly ReactiveProperty<int> _dexterity;
        private readonly ReactiveProperty<int> _intelligence;
        private readonly ReactiveProperty<int> _damage;
        private readonly ReactiveProperty<int> _regeneration;
        
        private readonly HeroCardInfo _heroCardInfo;
        private readonly ILevelViewModel _levelViewModel;

        private DisposableBag _disposable;
        public StatsViewModel(HeroCardInfo heroCardInfo, ILevelViewModel levelViewModel)
        {
            _heroCardInfo = heroCardInfo;
            _levelViewModel = levelViewModel;
            
            _moveSpeed = new ReactiveProperty<int>(_heroCardInfo.MoveSpeed);
            _stamina = new ReactiveProperty<int>(_heroCardInfo.Stamina);
            _dexterity = new ReactiveProperty<int>(_heroCardInfo.Dexterity);
            _intelligence = new ReactiveProperty<int>(_heroCardInfo.Intelligence);
            _damage = new ReactiveProperty<int>(_heroCardInfo.Damage);
            _regeneration = new ReactiveProperty<int>(_heroCardInfo.Regeneration);

            _levelViewModel.Level.Subscribe(OnLevelChange).AddTo(ref _disposable);

        }

        public void AddMoveSpeed(int speed) => _moveSpeed.Value += speed;
        public void AddStamina(int stamina) => _stamina.Value += stamina;
        public void AddDexterity(int dexterity) => _dexterity.Value += dexterity;
        public void AddIntelligence(int inc) => _intelligence.Value += inc;
        public void AddDamage(int damage) => _damage.Value += damage;
        public void AddRegeneration(int regeneration) => _regeneration.Value += regeneration;

        private void OnLevelChange(int _)
        {
            AddMoveSpeed(MAGIC_STATS_NUMBER);
            AddStamina(MAGIC_STATS_NUMBER);
            AddDexterity(MAGIC_STATS_NUMBER);
            AddIntelligence(MAGIC_STATS_NUMBER);
            AddDamage(MAGIC_STATS_NUMBER);
            AddRegeneration(MAGIC_STATS_NUMBER);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}