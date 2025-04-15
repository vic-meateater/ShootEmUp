using Zenject;

namespace DataEngine
{
    public class SaveLoaderManager
    {
        private ISaveLoader[] _saveLoaders;
        private ISaveLoadGameServices _gameServices;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, ISaveLoadGameServices gameServices)
        {
            _saveLoaders = saveLoaders;
            _gameServices = gameServices;
        }

        public void SaveGame()
        {
            foreach (var saver in _saveLoaders)
            {
                saver.SaveGame(_gameServices);
            }
        }

        public void LoadGame()
        {
            foreach (var loader in _saveLoaders)
            {
                loader.LoadGame(_gameServices);
            }
        }
    }
}