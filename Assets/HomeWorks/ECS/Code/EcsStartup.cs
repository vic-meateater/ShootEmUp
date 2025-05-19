using AB_Utility.FromSceneToEntityConverter;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    public sealed class EcsStartup : MonoBehaviour
    {
        [field: SerializeField] public GameData GameData { get; private set; }

        private EcsWorld _world;
        private IEcsSystems _systems;
        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new EntityManager();
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, GameData);
            _systems
                .Add(new ArmySpawnSystem())
                .Add(new TransformViewSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
        }

        private void Start()
        {
            _entityManager.Initialize(_world);
            _systems.ConvertScene();
            _systems.Inject(GameData, _entityManager);
            _systems.Init();
        }

        private void Update()
        {
            // process systems here.
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            // cleanup custom worlds here.

            // cleanup default world.
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}