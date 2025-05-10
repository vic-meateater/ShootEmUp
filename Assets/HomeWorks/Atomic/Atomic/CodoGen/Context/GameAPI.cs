/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;

namespace ShootEmUp.HomeWorks.Atomic
{
	public static class GameAPI
	{
		///Keys
		public const int MoveController = 1; // MoveController
		public const int IUIViewModel = 3; // IUIViewModel
		public const int PlayerSpawner = 5; // PlayerSpawner
		public const int GameServices = 6; // GameServices
		public const int GameObjectSpawner = 2; // GameObjectSpawner
		public const int BulletsPool = 4; // Transform


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MoveController GetMoveController(this IContext obj) => obj.ResolveValue<MoveController>(MoveController);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveController(this IContext obj, out MoveController value) => obj.TryResolveValue(MoveController, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveController(this IContext obj, MoveController value) => obj.AddValue(MoveController, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveController(this IContext obj) => obj.DelValue(MoveController);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveController(this IContext obj, MoveController value) => obj.SetValue(MoveController, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveController(this IContext obj) => obj.HasValue(MoveController);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IUIViewModel GetIUIViewModel(this IContext obj) => obj.ResolveValue<IUIViewModel>(IUIViewModel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIUIViewModel(this IContext obj, out IUIViewModel value) => obj.TryResolveValue(IUIViewModel, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddIUIViewModel(this IContext obj, IUIViewModel value) => obj.AddValue(IUIViewModel, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIUIViewModel(this IContext obj) => obj.DelValue(IUIViewModel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIUIViewModel(this IContext obj, IUIViewModel value) => obj.SetValue(IUIViewModel, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIUIViewModel(this IContext obj) => obj.HasValue(IUIViewModel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PlayerSpawner GetPlayerSpawner(this IContext obj) => obj.ResolveValue<PlayerSpawner>(PlayerSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerSpawner(this IContext obj, out PlayerSpawner value) => obj.TryResolveValue(PlayerSpawner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerSpawner(this IContext obj, PlayerSpawner value) => obj.AddValue(PlayerSpawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerSpawner(this IContext obj) => obj.DelValue(PlayerSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerSpawner(this IContext obj, PlayerSpawner value) => obj.SetValue(PlayerSpawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerSpawner(this IContext obj) => obj.HasValue(PlayerSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameServices GetGameServices(this IContext obj) => obj.ResolveValue<GameServices>(GameServices);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameServices(this IContext obj, out GameServices value) => obj.TryResolveValue(GameServices, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameServices(this IContext obj, GameServices value) => obj.AddValue(GameServices, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameServices(this IContext obj) => obj.DelValue(GameServices);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameServices(this IContext obj, GameServices value) => obj.SetValue(GameServices, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameServices(this IContext obj) => obj.HasValue(GameServices);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObjectSpawner GetGameObjectSpawner(this IContext obj) => obj.ResolveValue<GameObjectSpawner>(GameObjectSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameObjectSpawner(this IContext obj, out GameObjectSpawner value) => obj.TryResolveValue(GameObjectSpawner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameObjectSpawner(this IContext obj, GameObjectSpawner value) => obj.AddValue(GameObjectSpawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameObjectSpawner(this IContext obj) => obj.DelValue(GameObjectSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameObjectSpawner(this IContext obj, GameObjectSpawner value) => obj.SetValue(GameObjectSpawner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameObjectSpawner(this IContext obj) => obj.HasValue(GameObjectSpawner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetBulletsPool(this IContext obj) => obj.ResolveValue<Transform>(BulletsPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletsPool(this IContext obj, out Transform value) => obj.TryResolveValue(BulletsPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletsPool(this IContext obj, Transform value) => obj.AddValue(BulletsPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletsPool(this IContext obj) => obj.DelValue(BulletsPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletsPool(this IContext obj, Transform value) => obj.SetValue(BulletsPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletsPool(this IContext obj) => obj.HasValue(BulletsPool);
    }
}
