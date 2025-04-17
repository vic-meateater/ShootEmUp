namespace DataEngine
{
    public interface ISaveLoader
    {

        void SaveGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository);
        void LoadGame(ISaveLoadGameServices gameServices, IGameRepository gameRepository);
    }
}