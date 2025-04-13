using GameEngine;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class SaveLoader: ISaveLoader
    {
        private Unit[] _units;

        public SaveLoader(Unit[] units)
        {
            _units = units;
        }
        public void SaveGame(UnitManager unitManager, ResourceService resourceService)
        {
            Debug.Log("save game called");
            unitManager.SetupUnits(_units);
        }

        public void LoadGame(UnitManager unitManager, ResourceService resourceService)
        {
            //throw new System.NotImplementedException();
        }
    }
}
