using System.Collections.Generic;
using System.Linq;
using GameEngine;
using UnityEngine;

namespace DataEngine
{
    public sealed class ResourceSaveLoader: ISaveLoader
    {
        private Resource[] _resources;

        public ResourceSaveLoader(Resource[] resources)
        {
            _resources = resources;
        }
        void ISaveLoader.SaveGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            var resources = gameServices.ResourceService.GetResources();
            var saveData = new ResourcesSaveData
            {
                Resources = resources.Select(r => new ResourceData
                {
                    ID = r.ID,
                    Amount = r.Amount,
                    Position = Converter.Vector3ToArray(r.transform.position),
                })
            };
            gameRepository.SetData(saveData);
            Debug.Log($"Saved game resources called.\nSaved: {saveData.Resources.Count()} resources");
        }

        void ISaveLoader.LoadGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            if (gameRepository.TryGetData<ResourcesSaveData>(out var saveData))
            {
                
                var saveDataDict = new Dictionary<string, ResourceData>();
                foreach (var data in saveData.Resources)
                {
                    saveDataDict[data.ID] = data;
                }
                
                var updatedResources = GetUpdatedResources(
                    gameServices.ResourceService.GetResources(), saveDataDict);
                
                gameServices.ResourceService.SetResources(updatedResources);
                Debug.Log($"Load game resources called.\nLoaded: {updatedResources.Count()} resources");
            }
        }
        
        private IEnumerable<Resource> GetUpdatedResources(
            IEnumerable<Resource> existing, Dictionary<string, ResourceData> saveDict)
        {
            foreach (Resource resource in existing)
            {
                if (saveDict.TryGetValue(resource.ID, out var data))
                {
                    resource.Amount = data.Amount;
                    resource.transform.position = Converter.ArrayToVector3(data.Position);
                    yield return resource;
                }
            }
        }
        
        // private float[] Vector3ToArray(Vector3 vector)
        // {
        //     return new float[] { vector.x, vector.y, vector.z };
        // }
        //
        // private Vector3 ArrayToVector3(float[] array)
        // {
        //     if (array == null || array.Length != 3)
        //         return Vector3.zero;
        //     
        //     return new Vector3(array[0], array[1], array[2]);
        // }
    }
}