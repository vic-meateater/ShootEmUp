using System;
using System.Collections.Generic;
using R3;
using TMPro;
using UnityEngine;

namespace Popup
{
    public class StatsView : MonoBehaviour, IDisposable
    {
        [Header("Stats")]
        [SerializeField] private TMP_Text _moveSpeed;
        [SerializeField] private TMP_Text _stamina;
        [SerializeField] private TMP_Text _dexterity;
        [SerializeField] private TMP_Text _intelligence;
        [SerializeField] private TMP_Text _damage;
        [SerializeField] private TMP_Text _regeneration;
        
        private readonly Dictionary<StatId, TMP_Text> _statsDictionary = new();
        private IStatsViewModel _statsViewModel;
        private DisposableBag _disposables;
        
        public void Init(IStatsViewModel statsViewModel)
        {
            _statsViewModel = statsViewModel;

            FillStatsDictionary();
            Subscribes();
        }

        private void FillStatsDictionary()
        {
            _statsDictionary.Clear();
            _statsDictionary[StatId.MoveSpeed] = _moveSpeed;
            _statsDictionary[StatId.Stamina] = _stamina;
            _statsDictionary[StatId.Dexterity] = _dexterity;
            _statsDictionary[StatId.Intelligence] = _intelligence;
            _statsDictionary[StatId.Damage] = _damage;
            _statsDictionary[StatId.Regeneration] = _regeneration;
        }

        private void Subscribes()
        {
            foreach (var kvp in _statsDictionary)
            {
                var statKey = kvp.Key;
                var statText = kvp.Value;

                if (_statsViewModel.Stats.TryGetValue(statKey, out var stat))
                {
                    stat.Value.Subscribe(value => statText.text = value.ToString())
                        .AddTo(ref _disposables);
                }
                else
                {
                    Debug.LogWarning($"StatsView: StatId {statKey} not found in ViewModel.");
                }
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}