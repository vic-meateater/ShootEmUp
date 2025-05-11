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
    public static class DealDamageAPI
    {
        ///Keys
        public const int DealDamageReqest = 13; // IEvent
        public const int DealDamageAction = 14; // IEvent
        public const int DealDamageEvent = 15; // IEvent
        public const int CharacterDie = 28; // IEvent


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent GetDealDamageReqest(this IEntity obj) => obj.GetValue<IEvent>(DealDamageReqest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDealDamageReqest(this IEntity obj, out IEvent value) => obj.TryGetValue(DealDamageReqest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDealDamageReqest(this IEntity obj, IEvent value) => obj.AddValue(DealDamageReqest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDealDamageReqest(this IEntity obj) => obj.HasValue(DealDamageReqest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDealDamageReqest(this IEntity obj) => obj.DelValue(DealDamageReqest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDealDamageReqest(this IEntity obj, IEvent value) => obj.SetValue(DealDamageReqest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent GetDealDamageAction(this IEntity obj) => obj.GetValue<IEvent>(DealDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDealDamageAction(this IEntity obj, out IEvent value) => obj.TryGetValue(DealDamageAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDealDamageAction(this IEntity obj, IEvent value) => obj.AddValue(DealDamageAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDealDamageAction(this IEntity obj) => obj.HasValue(DealDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDealDamageAction(this IEntity obj) => obj.DelValue(DealDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDealDamageAction(this IEntity obj, IEvent value) => obj.SetValue(DealDamageAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent GetDealDamageEvent(this IEntity obj) => obj.GetValue<IEvent>(DealDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDealDamageEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(DealDamageEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDealDamageEvent(this IEntity obj, IEvent value) => obj.AddValue(DealDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDealDamageEvent(this IEntity obj) => obj.HasValue(DealDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDealDamageEvent(this IEntity obj) => obj.DelValue(DealDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDealDamageEvent(this IEntity obj, IEvent value) => obj.SetValue(DealDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEvent GetCharacterDie(this IEntity obj) => obj.GetValue<IEvent>(CharacterDie);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCharacterDie(this IEntity obj, out IEvent value) => obj.TryGetValue(CharacterDie, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCharacterDie(this IEntity obj, IEvent value) => obj.AddValue(CharacterDie, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCharacterDie(this IEntity obj) => obj.HasValue(CharacterDie);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCharacterDie(this IEntity obj) => obj.DelValue(CharacterDie);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCharacterDie(this IEntity obj, IEvent value) => obj.SetValue(CharacterDie, value);
    }
}
