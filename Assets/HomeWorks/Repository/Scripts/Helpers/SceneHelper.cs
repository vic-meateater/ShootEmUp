using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace DataEngine
{
    public class SceneHelper : MonoBehaviour
    {
        private SaveLoaderManager _saveLoaderManager;
        
        [Inject]
        private void Construct(SaveLoaderManager saveLoaderManager)
        {
            _saveLoaderManager = saveLoaderManager;
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
