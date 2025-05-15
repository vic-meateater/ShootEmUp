using Leopotam.EcsLite;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    sealed class ArmySpawnSystem : IEcsInitSystem
    {
        private GameData _gameData;
        private EcsWorld _world;

        public void Init(IEcsSystems systems)
        {
            _gameData = systems.GetShared<GameData>();
            _world = systems.GetWorld();
            
            SpawnArmy();
        }

        private void SpawnArmy()
        {
            for (int i = 0; i < 100; i++)
            {
                int row = i / 10;
                int col = i % 10;
                var startPosRed = _gameData.RedArmyStartPosition;
                var startPosBlue = _gameData.BlueArmyStartPosition;
                var spacing = _gameData.UnitsSpacing;
                Vector3 positionRed = startPosRed + new Vector3(col * spacing, 0, row * spacing);
                Vector3 positionBlue = startPosBlue + new Vector3(col * spacing, 0, row * spacing);

                var redGO = Object.Instantiate(_gameData.RedCube.UnitPrefab, positionRed, Quaternion.identity);
                CreateUnitEntity(redGO, Team.Red);
            }
        }

        private void CreateUnitEntity(GameObject go, Team team)
        {
            var entity = _world.NewEntity(); 
            var poolUnit = _world.GetPool<UnitComponent>();
            var poolMoveable = _world.GetPool<MovableComponent>();

        }
    }
}