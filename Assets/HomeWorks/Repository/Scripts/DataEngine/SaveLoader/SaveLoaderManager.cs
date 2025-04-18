using Zenject;

namespace DataEngine
{
    public sealed class SaveLoaderManager
    {
        private ISaveLoader[] _saveLoaders;
        private ISaveLoadGameServices _gameServices;
        private IGameRepository _gameRepository;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, ISaveLoadGameServices gameServices, IGameRepository gameRepository)
        {
            _saveLoaders = saveLoaders;
            _gameServices = gameServices;
            _gameRepository = gameRepository;
        }

        public void SaveGame()
        {
            foreach (var saver in _saveLoaders)
            {
                saver.SaveGame(_gameServices, _gameRepository);
            }
            
            _gameRepository.SaveState();
        }

        public void LoadGame()
        {
            _gameRepository.LoadState();
            foreach (var loader in _saveLoaders)
            {
                loader.LoadGame(_gameServices, _gameRepository);
            }
        }
    }
}