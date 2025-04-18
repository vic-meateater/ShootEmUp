using GameEngine;
using UnityEngine;

namespace DataEngine
{
    public sealed class UnitsSaveLoader: ISaveLoader
    {
        private Unit[] _units;
        
        public UnitsSaveLoader(Unit[] units)
        {
            _units = units;
        }

        void ISaveLoader.SaveGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            //gameServices.UnitManager.SetupUnits(_units);
            Debug.Log("Save game units called");
        }

        void ISaveLoader.LoadGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            Debug.Log("Load game units called");
        }
    }
    
    
}
