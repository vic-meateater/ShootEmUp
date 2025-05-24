using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Serialization;

namespace ShootEmUp.Homeworks.ECSGame
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct TeamComponent : IComponent
    {
        public Team Team;
    }
}

public enum Team
{
    Red,
    Blue
}