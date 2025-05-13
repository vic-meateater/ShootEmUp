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
    public static class TimerAPI
    {
        ///Keys
        public const int AtomicTimer = 36; // Timer


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timer GetAtomicTimer(this IEntity obj) => obj.GetValue<Timer>(AtomicTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAtomicTimer(this IEntity obj, out Timer value) => obj.TryGetValue(AtomicTimer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAtomicTimer(this IEntity obj, Timer value) => obj.AddValue(AtomicTimer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAtomicTimer(this IEntity obj) => obj.HasValue(AtomicTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAtomicTimer(this IEntity obj) => obj.DelValue(AtomicTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAtomicTimer(this IEntity obj, Timer value) => obj.SetValue(AtomicTimer, value);
    }
}
