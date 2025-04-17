using System.Collections.Generic;
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
        void ISaveLoader.SaveGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            gameServices.ResourceService.SetResources(_resources);
            var resourceSaveData = new ResourcesSaveData()
            {
                Resources = gameServices.ResourceService.GetResources(),
            };
            gameRepository.SetData(resourceSaveData);
            Debug.Log("Saved game resources called");
            // gameServices.ResourceService.SetResources(resourceSaveData.Resources);
        }

        void ISaveLoader.LoadGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            if (gameRepository.TryGetData<ResourcesSaveData>(out var resourceSaveData))
            {
                var resources = resourceSaveData.Resources;
                gameServices.ResourceService.SetResources(resources);
                Debug.Log("Load game resources called"); 
            }
        }
    }

    public class ResourcesSaveData
    {
        public IEnumerable<Resource> Resources;
    }
}