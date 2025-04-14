using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class SaveLoader: ISaveLoader
    {
        private Unit[] _units;
        private Resource[] _resources;

        public SaveLoader(Unit[] units, Resource[] resources)
        {
            _units = units;
            _resources = resources;
        }
        public void SaveGame(UnitManager unitManager, ResourceService resourceService)
        {
            Debug.Log("save game called");
            unitManager.SetupUnits(_units);
            resourceService.SetResources(_resources);
        }
        
        public void LoadGame(UnitManager unitManager, ResourceService resourceService)
        {
            Debug.Log("load game called");
        }
    }
}
