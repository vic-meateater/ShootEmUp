using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ShootEmUp.HomeWorks.ECSGame
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PositionInitializer : IInitializer
    {
        public World World { get; set; }

        public void OnAwake()
        {
        }

        public void Dispose()
        {
        }
    }
}