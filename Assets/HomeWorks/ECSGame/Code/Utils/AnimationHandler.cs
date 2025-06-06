using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using ShootEmUp.Homeworks.ECSGame;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private EntityProvider _entityProvider;
        private World _world;
        private Entity _entity;
        private Request<ArrowSpawnRequest> _arrowSpawnRequest;
        private Stash<ReadyToClean> _readyToCleanStash;

        private void Awake()
        {
            _world = _entityProvider.Entity.GetWorld();
            _arrowSpawnRequest = _world.GetRequest<ArrowSpawnRequest>();
            _readyToCleanStash = _world.GetStash<ReadyToClean>();
        }

        public void OnDamageFrame(string attackType)
        {
            if (attackType == "Range")
            {
                if (_entityProvider.isActiveAndEnabled)
                {
                    _entity = _entityProvider.Entity;
                    Debug.Log($"Range Attack started {_entity.Id}");
                    _arrowSpawnRequest.Publish(new ArrowSpawnRequest { Requester = _entity }, allowNextFrame: true);
                }
            }
        }

        public void OnDeathFrame()
        {
            if (_entityProvider.isActiveAndEnabled)
            {
                _entity = _entityProvider.Entity;
                Debug.Log($"{_entity.Id} Умерло, надо бы подчистить");
                _readyToCleanStash.Add(_entity);
            }
        }
    }
}