using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    sealed class ArmySpawnSystem : IEcsInitSystem
    {
        private EcsWorldInject _world = default;
        private EcsSharedInject<GameData> _gameData;

        private EcsPoolInject<SpeedComponent> _speedPool;
        private EcsPoolInject<DirectionComponent> _directionPool;
        private EcsPoolInject<HealthComponent> _healthPool;
        private EcsPoolInject<UnitComponent> _unitPool;
        private EcsPoolInject<TeamComponent> _teamPool;

        public void Init(IEcsSystems systems)
        {
            SpawnArmy();
        }

        private void SpawnArmy()
        {
            for (int i = 0; i < 5; i++)
            {
                int row = i / 10;
                int col = i % 10;
                var startPosRed = _gameData.Value.RedArmyStartPosition;
                var startPosBlue = _gameData.Value.BlueArmyStartPosition;
                var spacing = _gameData.Value.UnitsSpacing;
                Vector3 positionRed = startPosRed + new Vector3(col * spacing, 0, row * spacing);
                Vector3 positionBlue = startPosBlue + new Vector3(col * spacing, 0, row * spacing);

                var redGO = Object.Instantiate(_gameData.Value.RedCube.UnitPrefab, positionRed, Quaternion.identity);
                CreateUnitEntity(redGO, Team.Red);
            }
        }

        private void CreateUnitEntity(GameObject go, Team team)
        {
            var entity = _world.Value.NewEntity();
            _speedPool.Value.Add(entity);
            _directionPool.Value.Add(entity);
            _healthPool.Value.Add(entity);
            _unitPool.Value.Add(entity);
            _teamPool.Value.Add(entity);
            ref var teamEntity = ref _teamPool.Value.Get(entity);
            teamEntity.Team = team;
        }
    }
}