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
    public static class WeaponAPI
    {
        ///Keys
        public const int ShootPoint = 16; // Transform
        public const int WeaponSlot = 18; // Transform
        public const int MaxBullets = 22; // ReactiveInt
        public const int CurrentBullets = 23; // ReactiveInt
        public const int RealoadInterval = 24; // ReactiveFloat
        public const int ShootCoolDown = 25; // ReactiveFloat
        public const int ReloadTimer = 26; // ReactiveFloat
        public const int BulletSpeed = 27; // ReactiveFloat
        public const int DamageMultiplier = 30; // ReactiveFloat
        public const int CanShoot = 35; // AndExpression


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetMaxBullets(this IEntity obj) => obj.GetValue<ReactiveInt>(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxBullets(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(MaxBullets, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxBullets(this IEntity obj, ReactiveInt value) => obj.AddValue(MaxBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxBullets(this IEntity obj) => obj.HasValue(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxBullets(this IEntity obj) => obj.DelValue(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxBullets(this IEntity obj, ReactiveInt value) => obj.SetValue(MaxBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetCurrentBullets(this IEntity obj) => obj.GetValue<ReactiveInt>(CurrentBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCurrentBullets(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(CurrentBullets, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCurrentBullets(this IEntity obj, ReactiveInt value) => obj.AddValue(CurrentBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCurrentBullets(this IEntity obj) => obj.HasValue(CurrentBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCurrentBullets(this IEntity obj) => obj.DelValue(CurrentBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCurrentBullets(this IEntity obj, ReactiveInt value) => obj.SetValue(CurrentBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetRealoadInterval(this IEntity obj) => obj.GetValue<ReactiveFloat>(RealoadInterval);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRealoadInterval(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(RealoadInterval, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRealoadInterval(this IEntity obj, ReactiveFloat value) => obj.AddValue(RealoadInterval, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRealoadInterval(this IEntity obj) => obj.HasValue(RealoadInterval);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRealoadInterval(this IEntity obj) => obj.DelValue(RealoadInterval);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRealoadInterval(this IEntity obj, ReactiveFloat value) => obj.SetValue(RealoadInterval, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetShootCoolDown(this IEntity obj) => obj.GetValue<ReactiveFloat>(ShootCoolDown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootCoolDown(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(ShootCoolDown, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootCoolDown(this IEntity obj, ReactiveFloat value) => obj.AddValue(ShootCoolDown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootCoolDown(this IEntity obj) => obj.HasValue(ShootCoolDown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootCoolDown(this IEntity obj) => obj.DelValue(ShootCoolDown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootCoolDown(this IEntity obj, ReactiveFloat value) => obj.SetValue(ShootCoolDown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetReloadTimer(this IEntity obj) => obj.GetValue<ReactiveFloat>(ReloadTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetReloadTimer(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(ReloadTimer, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddReloadTimer(this IEntity obj, ReactiveFloat value) => obj.AddValue(ReloadTimer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasReloadTimer(this IEntity obj) => obj.HasValue(ReloadTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelReloadTimer(this IEntity obj) => obj.DelValue(ReloadTimer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetReloadTimer(this IEntity obj, ReactiveFloat value) => obj.SetValue(ReloadTimer, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetBulletSpeed(this IEntity obj) => obj.GetValue<ReactiveFloat>(BulletSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetBulletSpeed(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(BulletSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddBulletSpeed(this IEntity obj, ReactiveFloat value) => obj.AddValue(BulletSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBulletSpeed(this IEntity obj) => obj.HasValue(BulletSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelBulletSpeed(this IEntity obj) => obj.DelValue(BulletSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBulletSpeed(this IEntity obj, ReactiveFloat value) => obj.SetValue(BulletSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveFloat GetDamageMultiplier(this IEntity obj) => obj.GetValue<ReactiveFloat>(DamageMultiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageMultiplier(this IEntity obj, out ReactiveFloat value) => obj.TryGetValue(DamageMultiplier, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageMultiplier(this IEntity obj, ReactiveFloat value) => obj.AddValue(DamageMultiplier, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageMultiplier(this IEntity obj) => obj.HasValue(DamageMultiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageMultiplier(this IEntity obj) => obj.DelValue(DamageMultiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageMultiplier(this IEntity obj, ReactiveFloat value) => obj.SetValue(DamageMultiplier, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanShoot(this IEntity obj) => obj.GetValue<AndExpression>(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanShoot(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanShoot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanShoot(this IEntity obj, AndExpression value) => obj.AddValue(CanShoot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanShoot(this IEntity obj) => obj.HasValue(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanShoot(this IEntity obj) => obj.DelValue(CanShoot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanShoot(this IEntity obj, AndExpression value) => obj.SetValue(CanShoot, value);
    }
}
