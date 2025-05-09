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
    public static class RotationAPI
    {
        ///Keys
        public const int LookPoint = 8; // IReactiveVariable<Vector3>
        public const int RotationSpeed = 9; // IReactiveVariable<float>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<Vector3> GetLookPoint(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(LookPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetLookPoint(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(LookPoint, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddLookPoint(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(LookPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasLookPoint(this IEntity obj) => obj.HasValue(LookPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelLookPoint(this IEntity obj) => obj.DelValue(LookPoint);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLookPoint(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(LookPoint, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<float> GetRotationSpeed(this IEntity obj) => obj.GetValue<IReactiveVariable<float>>(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotationSpeed(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValue(RotationSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotationSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotationSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(RotationSpeed, value);
    }
}
