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
    public static class MoveAPI
    {
        ///Keys
        public const int MoveDirection = 5; // IReactiveVariable<Vector3>
        public const int MoveSpeed = 6; // IReactiveVariable<float>
        public const int Rigidbody = 7; // Rigidbody
        public const int Transform = 10; // Transform


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<IReactiveVariable<float>>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rigidbody GetRigidbody(this IEntity obj) => obj.GetValue<Rigidbody>(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRigidbody(this IEntity obj, out Rigidbody value) => obj.TryGetValue(Rigidbody, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRigidbody(this IEntity obj, Rigidbody value) => obj.AddValue(Rigidbody, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRigidbody(this IEntity obj) => obj.HasValue(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRigidbody(this IEntity obj) => obj.DelValue(Rigidbody);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRigidbody(this IEntity obj, Rigidbody value) => obj.SetValue(Rigidbody, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);
    }
}
