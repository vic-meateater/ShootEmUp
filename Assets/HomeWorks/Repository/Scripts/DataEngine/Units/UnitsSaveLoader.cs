using System;
using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class UnitsSaveLoader: ISaveLoader
    {
        private Unit[] _units;
        
        public UnitsSaveLoader(Unit[] units)
        {
            _units = units;
        }

        public void SaveGame(ISaveLoadGameServices gameServices)
        {
            gameServices.UnitManager.SetupUnits(_units);
            Debug.Log("Save game units called");
        }

        public void LoadGame(ISaveLoadGameServices gameServices)
        {
            Debug.Log("Load game units called");
        }
    }
}
