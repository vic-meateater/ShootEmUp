using System.Collections.Generic;
using GameEngine;
using UnityEngine;

namespace DataEngine
{
    public sealed class UnitsSaveLoader: ISaveLoader
    {
        private readonly Dictionary<string, Unit> _unitPrefabs;
        
        public UnitsSaveLoader(Dictionary<string, Unit> unitPrefabs)
        {
            _unitPrefabs = unitPrefabs;
        }

        void ISaveLoader.SaveGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            var units = gameServices.UnitManager.GetAllUnits();
            var saveData = new UnitsSaveData
            {
                Units = new HashSet<UnitsData>()
            };

            foreach (Unit unit in units)
            {
                saveData.Units.Add(new UnitsData
                {
                    UnitType = unit.Type,
                    HitPoints = unit.HitPoints,
                    Position = Converter.Vector3ToArray(unit.Position),
                    Rotation = Converter.Vector3ToArray(unit.Rotation),
                });
            }
            gameRepository.SetData(saveData);
            Debug.Log($"Save game units called\nSaved {saveData.Units.Count} units");
        }

        void ISaveLoader.LoadGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            if (!gameRepository.TryGetData<UnitsSaveData>(out var saveData)) 
                return;
            
            var existingUnits = new List<Unit>(gameServices.UnitManager.GetAllUnits());
            foreach (Unit unit in existingUnits)
            {
                gameServices.UnitManager.DestroyUnit(unit);
            }
            
            foreach (var record in saveData.Units)
            {
                if (_unitPrefabs.TryGetValue(record.UnitType, out Unit prefab))
                {
                    var unit = gameServices.UnitManager.SpawnUnit(
                        prefab,
                        Converter.ArrayToVector3(record.Position),
                        Quaternion.Euler(Converter.ArrayToVector3(record.Rotation))
                    );
                    
                    unit.HitPoints = record.HitPoints;
                }
                else
                {
                    Debug.LogWarning($"Unit prefab not found for type: {record.UnitType}");
                }
            }
            Debug.Log($"Load game units called.\nLoaded {saveData.Units.Count} units");
        }
    }
}
