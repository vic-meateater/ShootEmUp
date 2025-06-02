using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using ShootEmUp.Homeworks.ECSGame;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    [Serializable]
    public class StartUpECS : MonoBehaviour
    {
        [SerializeField] private SystemsGroup _systemsGroup;
        [SerializeField] private ArrowConfig _arrowConfig;
        
        private World _world;
        private FireRequestSystem _fireRequestSystem;

        private void Awake()
        {
            _world = World.Default;
            _fireRequestSystem = new FireRequestSystem();
            _fireRequestSystem.Initialize(_arrowConfig);
            
            var initSystems = _world.CreateSystemsGroup();
            initSystems.AddInitializer(new PositionInitializer());
            _world.AddSystemsGroup(order: 0, initSystems);
        }

        private void Start()
        {
            var updateSystems = _world.CreateSystemsGroup();
            updateSystems.AddSystem(new MovementSystem());
            updateSystems.AddSystem(new HealthSystem());
            updateSystems.AddSystem(new EnemyDetectionSystem());
            updateSystems.AddSystem(_fireRequestSystem);
            updateSystems.AddSystem(new ArrowSpawnSystem());
            _world.AddSystemsGroup(order: 1, updateSystems);

            //var fixedSystems = _world.CreateSystemsGroup();
            //fixedSystems.AddSystem(...);
            //_world.AddSystemsGroup(order: 2, fixedSystems);
            
            var lateSystems = _world.CreateSystemsGroup();
            lateSystems.AddSystem(new TransformViewSynchronizerSystem());
            lateSystems.AddSystem(new MoveAnimatorLateSystem());
            lateSystems.AddSystem(new AttackAnimatorLateSystem());
            _world.AddSystemsGroup(order: 3, lateSystems);
        }
    }
}