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
    public static class EnemyAPI
    {
        ///Keys
        public const int SpawnedEvent = 32; // IEvent<IEntity>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent<IEntity> GetSpawnedEvent(this IEntity obj) => obj.GetValue<IEvent<IEntity>>(SpawnedEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSpawnedEvent(this IEntity obj, out IEvent<IEntity> value) => obj.TryGetValue(SpawnedEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSpawnedEvent(this IEntity obj, IEvent<IEntity> value) => obj.AddValue(SpawnedEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSpawnedEvent(this IEntity obj) => obj.HasValue(SpawnedEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSpawnedEvent(this IEntity obj) => obj.DelValue(SpawnedEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSpawnedEvent(this IEntity obj, IEvent<IEntity> value) => obj.SetValue(SpawnedEvent, value);
    }
}
