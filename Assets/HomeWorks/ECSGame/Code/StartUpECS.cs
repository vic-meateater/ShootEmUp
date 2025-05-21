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
            //var initSystems = _world.CreateSystemsGroup();
            //initSystems.AddSystem(...);
            //_world.AddSystemsGroup(order: 0, initSystems);
        }

        private void Start()
        {
            var updateSystems = _world.CreateSystemsGroup();
            updateSystems.AddSystem(new HealthSystem());

            //var fixedSystems = _world.CreateSystemsGroup();
            //fixedSystems.AddSystem(...);
            
            //var lateSystems = _world.CreateSystemsGroup();
            //lateSystems.AddSystem(...);

            _world.AddSystemsGroup(order: 1, updateSystems);
            //_world.AddSystemsGroup(order: 2, fixedSystems);
            //_world.AddSystemsGroup(order: 3, lateSystems);
        }
    }
}