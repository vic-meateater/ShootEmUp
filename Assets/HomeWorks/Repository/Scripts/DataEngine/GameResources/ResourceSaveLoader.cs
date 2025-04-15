using GameEngine;
using UnityEngine;

namespace DataEngine
{
    public class ResourceSaveLoader: ISaveLoader
    {
        private Resource[] _resources;

        public ResourceSaveLoader(Resource[] resources)
        {
            _resources = resources;
        }
        public void SaveGame(ISaveLoadGameServices gameServices)
        {
            gameServices.ResourceService.SetResources(_resources);
            Debug.Log("Saved game resources called");
        }

        public void LoadGame(ISaveLoadGameServices gameServices)
        {
            Debug.Log("Load game resources called");
        }
    }
}