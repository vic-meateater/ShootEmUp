using GameEngine;
using Zenject;

namespace DataEngine
{
    public interface ISaveLoader
    {
        void SaveGame(UnitManager unitManager, ResourceService resourceService);
        void LoadGame(UnitManager unitManager, ResourceService resourceService);
    }
}