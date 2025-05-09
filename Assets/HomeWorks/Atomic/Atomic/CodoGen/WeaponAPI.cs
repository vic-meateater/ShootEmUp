/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using Atomic.Extensions;

namespace Atomic.Entities
{
    public static class WeaponAPI
    {
        ///Keys
        public const int ShootPoint = 16; // Transform
        public const int WeaponSlot = 18; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetShootPoint(this IEntity obj) => obj.GetValue<Transform>(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootPoint(this IEntity obj, out Transform value) => obj.TryGetValue(ShootPoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootPoint(this IEntity obj, Transform value) => obj.AddValue(ShootPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootPoint(this IEntity obj) => obj.HasValue(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootPoint(this IEntity obj) => obj.DelValue(ShootPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootPoint(this IEntity obj, Transform value) => obj.SetValue(ShootPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetWeaponSlot(this IEntity obj) => obj.GetValue<Transform>(WeaponSlot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeaponSlot(this IEntity obj, out Transform value) => obj.TryGetValue(WeaponSlot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeaponSlot(this IEntity obj, Transform value) => obj.AddValue(WeaponSlot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeaponSlot(this IEntity obj) => obj.HasValue(WeaponSlot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeaponSlot(this IEntity obj) => obj.DelValue(WeaponSlot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeaponSlot(this IEntity obj, Transform value) => obj.SetValue(WeaponSlot, value);
    }
}
