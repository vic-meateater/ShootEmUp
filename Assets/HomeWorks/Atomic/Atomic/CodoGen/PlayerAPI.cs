/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Atomic.Extensions;

namespace ShootEmUp.HomeWorks.Atomic
{
    public static class PlayerAPI
    {
        ///Keys
        public const int Kills = 37; // ReactiveInt


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetKills(this IEntity obj) => obj.GetValue<ReactiveInt>(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetKills(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Kills, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddKills(this IEntity obj, ReactiveInt value) => obj.AddValue(Kills, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasKills(this IEntity obj) => obj.HasValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelKills(this IEntity obj) => obj.DelValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetKills(this IEntity obj, ReactiveInt value) => obj.SetValue(Kills, value);
    }
}
