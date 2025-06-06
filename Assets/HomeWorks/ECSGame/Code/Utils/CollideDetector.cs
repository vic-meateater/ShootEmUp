using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using ShootEmUp.Homeworks.ECSGame;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    public class CollideDetector : MonoBehaviour
    {
        private World _world;
        private Request<DamageRequest> _damageRequest;


        private void Awake()
        {
            _world = World.Default;
            _damageRequest = _world.GetRequest<DamageRequest>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EntityProvider>(out var targetProvider))
            {
                Entity target = targetProvider.Entity;
                if (gameObject.TryGetComponent<EntityProvider>(out var provider))
                {
                    Entity requester = provider.Entity;
                    _damageRequest.Publish(new DamageRequest {Requester = requester, Target = target},
                        allowNextFrame: true);
                }
            }
        }
    }
}