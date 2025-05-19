using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    sealed class ArmySpawnSystem : IEcsInitSystem
    {
        private EcsWorldInject _world = default;
        private EcsSharedInject<GameData> _gameData;

        // private EcsPoolInject<SpeedComponent> _speedPool;
        // private EcsPoolInject<DirectionComponent> _directionPool;
        // private EcsPoolInject<HealthComponent> _healthPool;
        // private EcsPoolInject<UnitComponent> _unitPool;
        // private EcsPoolInject<TeamComponent> _teamPool;

        private readonly EcsCustomInject<EntityManager> _entityManager;
        private EcsFilterInject<Inc<TeamComponent>> _teamFilterInject;

        public void Init(IEcsSystems systems)
        {
            SpawnArmy();
        }

        private void SpawnArmy()
        {
            var startPosRed = _gameData.Value.RedParent.transform.position;
            var startPosBlue = _gameData.Value.BlueParent.transform.position;
            var spacing = _gameData.Value.UnitsSpacing;
            
            var redEntity = _gameData.Value.RedCube.UnitPrefab;
            var redParent = _gameData.Value.RedParent.transform;
            
            var blueEntity = _gameData.Value.BlueCube.UnitPrefab;
            var blueParent = _gameData.Value.BlueParent.transform;
            
            
            for (int i = 0; i < 100; i++)
            {
                int row = i / 10;
                int col = i % 10;

                Vector3 positionRed = startPosRed + new Vector3(col * spacing, 0, row * spacing);
                Vector3 positionBlue = startPosBlue + new Vector3(col * spacing, 0, row * spacing);
                
                _entityManager.Value.Create(redEntity, positionRed, Quaternion.identity, redParent);
                _entityManager.Value.Create(blueEntity, positionBlue, Quaternion.identity, blueParent);
            }
        }
    }
}