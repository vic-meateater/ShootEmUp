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
        private World _world;

        private void Awake()
        {
            _world = World.Default;
            var initSystems = _world.CreateSystemsGroup();
            initSystems.AddInitializer(new PositionInitializer());
            _world.AddSystemsGroup(order: 0, initSystems);
        }

        private void Start()
        {
            var updateSystems = _world.CreateSystemsGroup();
            updateSystems.AddSystem(new MovementSystem());
            updateSystems.AddSystem(new HealthSystem());
            _world.AddSystemsGroup(order: 1, updateSystems);

            //var fixedSystems = _world.CreateSystemsGroup();
            //fixedSystems.AddSystem(...);
            //_world.AddSystemsGroup(order: 2, fixedSystems);
            
            var lateSystems = _world.CreateSystemsGroup();
            lateSystems.AddSystem(new TransformViewSynchronizerSystem());
            lateSystems.AddSystem(new AnimatorLateSystem());
            _world.AddSystemsGroup(order: 3, lateSystems);
        }
    }
}