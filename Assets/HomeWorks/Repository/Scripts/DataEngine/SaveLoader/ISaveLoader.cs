namespace DataEngine
{
    public interface ISaveLoader
    {

        void SaveGame(ISaveLoadGameServices gameServices);
        void LoadGame(ISaveLoadGameServices gameServices);
    }
}