using System.Collections.Generic;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public sealed class SceneHelper : MonoBehaviour
    {
        private SaveLoaderManager _saveLoaderManager;
        private SaveLoadGameServices _saveLoadGameServices;
        
        [Inject]
        private void Construct(SaveLoaderManager saveLoaderManager, SaveLoadGameServices saveLoadGameServices)
        {
            _saveLoaderManager = saveLoaderManager;
            _saveLoadGameServices = saveLoadGameServices;
        }

        [Button]
        public void InitSavableObjects()
        {
            var resources = FindObjectsOfType<Resource>();
            var units = FindObjectsOfType<Unit>();
            _saveLoadGameServices.ResourceService.SetResources(resources);
            _saveLoadGameServices.UnitManager.SetupUnits(units);
        }
        [Button]
        public void Save()
        {
            _saveLoaderManager.SaveGame();
        }

        [Button]
        public void Load()
        {
            _saveLoaderManager.LoadGame();
        }

    }
}
