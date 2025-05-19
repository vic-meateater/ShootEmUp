using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    public class CubeInstaller : EntityInstaller
    {
        [SerializeField] private Team _team;
        protected override void Install(Entity entity)
        {
            entity.AddData(new DirectionComponent());
            entity.AddData(new HealthComponent());
            entity.AddData(new SpeedComponent());
            entity.AddData(new TeamComponent {Team = Team.Red});
            entity.AddData(new UnitComponent());
            entity.AddData(new DestroyedTagComponent());
            entity.AddData(new TransformViewComponent {Transform = transform});
            entity.AddData(new PositionComponent {Position = transform.position});
            
        }

        protected override void Dispose(Entity entity)
        {
            //throw new System.NotImplementedException();
        }
    }
}
