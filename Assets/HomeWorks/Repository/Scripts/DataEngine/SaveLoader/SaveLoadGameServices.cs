using GameEngine;

namespace DataEngine
{
    public class SaveLoadGameServices : ISaveLoadGameServices
    {
        public UnitManager UnitManager { get; }
        public ResourceService ResourceService { get; }

        public SaveLoadGameServices(UnitManager unitManager, ResourceService resourceService)
        {
            UnitManager = unitManager;
            ResourceService = resourceService;
        }
    }
}