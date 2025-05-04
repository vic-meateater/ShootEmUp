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
    public static class BulletAPI
    {
        ///Keys
        public const int BulletPrefab = 11; // GameObject
        public const int BulletSpawnPoint = 12; // Transform
        public const int WeaponEntity = 17; // SceneEntity


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameObject GetBulletPrefab(this IEntity obj) => obj.GetValue<GameObject>(BulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetBulletPrefab(this IEntity obj, out GameObject value) => obj.TryGetValue(BulletPrefab, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddBulletPrefab(this IEntity obj, GameObject value) => obj.AddValue(BulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBulletPrefab(this IEntity obj) => obj.HasValue(BulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelBulletPrefab(this IEntity obj) => obj.DelValue(BulletPrefab);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBulletPrefab(this IEntity obj, GameObject value) => obj.SetValue(BulletPrefab, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetBulletSpawnPoint(this IEntity obj) => obj.GetValue<Transform>(BulletSpawnPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetBulletSpawnPoint(this IEntity obj, out Transform value) => obj.TryGetValue(BulletSpawnPoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddBulletSpawnPoint(this IEntity obj, Transform value) => obj.AddValue(BulletSpawnPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBulletSpawnPoint(this IEntity obj) => obj.HasValue(BulletSpawnPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelBulletSpawnPoint(this IEntity obj) => obj.DelValue(BulletSpawnPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBulletSpawnPoint(this IEntity obj, Transform value) => obj.SetValue(BulletSpawnPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntity GetWeaponEntity(this IEntity obj) => obj.GetValue<SceneEntity>(WeaponEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWeaponEntity(this IEntity obj, out SceneEntity value) => obj.TryGetValue(WeaponEntity, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWeaponEntity(this IEntity obj, SceneEntity value) => obj.AddValue(WeaponEntity, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWeaponEntity(this IEntity obj) => obj.HasValue(WeaponEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWeaponEntity(this IEntity obj) => obj.DelValue(WeaponEntity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWeaponEntity(this IEntity obj, SceneEntity value) => obj.SetValue(WeaponEntity, value);
    }
}
