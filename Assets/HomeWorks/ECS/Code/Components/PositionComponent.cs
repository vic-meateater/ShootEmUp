using System;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECS
{
    [Serializable]
    public struct PositionComponent
    {
        public Vector3 Position; 
    }

    [Serializable]
    public struct TransformViewComponent
    {
        public Transform Transform;
    }
}