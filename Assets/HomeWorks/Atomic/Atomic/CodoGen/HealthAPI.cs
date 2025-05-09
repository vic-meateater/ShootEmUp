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
    public static class HealthAPI
    {
        ///Keys
        public const int MaxHealth = 1; // float
        public const int CurrentHealth = 2; // IReactiveVariable<float>
        public const int IsDead = 3; // IReactiveVariable<bool>
        public const int TakeDamage = 4; // IEvent<float>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMaxHealth(this IEntity obj) => obj.GetValue<float>(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxHealth(this IEntity obj, out float value) => obj.TryGetValue(MaxHealth, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxHealth(this IEntity obj, float value) => obj.AddValue(MaxHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxHealth(this IEntity obj) => obj.HasValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxHealth(this IEntity obj) => obj.DelValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxHealth(this IEntity obj, float value) => obj.SetValue(MaxHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<float> GetCurrentHealth(this IEntity obj) => obj.GetValue<IReactiveVariable<float>>(CurrentHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCurrentHealth(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValue(CurrentHealth, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCurrentHealth(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(CurrentHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCurrentHealth(this IEntity obj) => obj.HasValue(CurrentHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCurrentHealth(this IEntity obj) => obj.DelValue(CurrentHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCurrentHealth(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(CurrentHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReactiveVariable<bool> GetIsDead(this IEntity obj) => obj.GetValue<IReactiveVariable<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out IReactiveVariable<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, IReactiveVariable<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, IReactiveVariable<bool> value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent<float> GetTakeDamage(this IEntity obj) => obj.GetValue<IEvent<float>>(TakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamage(this IEntity obj, out IEvent<float> value) => obj.TryGetValue(TakeDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamage(this IEntity obj, IEvent<float> value) => obj.AddValue(TakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamage(this IEntity obj) => obj.HasValue(TakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamage(this IEntity obj) => obj.DelValue(TakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamage(this IEntity obj, IEvent<float> value) => obj.SetValue(TakeDamage, value);
    }
}
