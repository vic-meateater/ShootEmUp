using GameEngine;

namespace DataEngine
{
    public interface ISaveLoadGameServices
    {
        UnitManager UnitManager { get; }
        ResourceService ResourceService { get; }
    }
}