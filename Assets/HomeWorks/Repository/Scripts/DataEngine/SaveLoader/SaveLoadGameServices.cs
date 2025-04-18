using GameEngine;

namespace DataEngine
{
    public sealed class SaveLoadGameServices : ISaveLoadGameServices
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