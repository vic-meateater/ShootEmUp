using System;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class Helper : MonoBehaviour
    {
        private SaveLoader _saveLoader;
        private UnitManager _unitManager;
        private ResourceService _resourceService;

        [Inject]
        private void Construct(SaveLoader saveLoader, UnitManager unitManager, ResourceService resourceService)
        {
            _saveLoader = saveLoader;
            _unitManager = unitManager;
            _resourceService = resourceService;
        }

        [Button]
        public void Save()
        {
            _saveLoader.SaveGame(_unitManager, _resourceService);
        }
    }
}
