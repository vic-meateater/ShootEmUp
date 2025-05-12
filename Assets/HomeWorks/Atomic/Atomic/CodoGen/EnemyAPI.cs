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
        public const int ParentPosition = 34; // ReactiveVector3


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVector3 GetParentPosition(this IEntity obj) => obj.GetValue<ReactiveVector3>(ParentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetParentPosition(this IEntity obj, out ReactiveVector3 value) => obj.TryGetValue(ParentPosition, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddParentPosition(this IEntity obj, ReactiveVector3 value) => obj.AddValue(ParentPosition, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasParentPosition(this IEntity obj) => obj.HasValue(ParentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelParentPosition(this IEntity obj) => obj.DelValue(ParentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetParentPosition(this IEntity obj, ReactiveVector3 value) => obj.SetValue(ParentPosition, value);
    }
}
