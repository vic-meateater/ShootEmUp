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
		public const int PlayerService = 2; // PlayerService
		public const int IUIViewModel = 3; // IUIViewModel
		public const int PlayerConfig = 4; // PlayerConfig
		public const int PlayerSpawner = 5; // PlayerSpawner


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
		public static PlayerService GetPlayerService(this IContext obj) => obj.ResolveValue<PlayerService>(PlayerService);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerService(this IContext obj, out PlayerService value) => obj.TryResolveValue(PlayerService, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerService(this IContext obj, PlayerService value) => obj.AddValue(PlayerService, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerService(this IContext obj) => obj.DelValue(PlayerService);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerService(this IContext obj, PlayerService value) => obj.SetValue(PlayerService, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerService(this IContext obj) => obj.HasValue(PlayerService);

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
		public static PlayerConfig GetPlayerConfig(this IContext obj) => obj.ResolveValue<PlayerConfig>(PlayerConfig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerConfig(this IContext obj, out PlayerConfig value) => obj.TryResolveValue(PlayerConfig, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerConfig(this IContext obj, PlayerConfig value) => obj.AddValue(PlayerConfig, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerConfig(this IContext obj) => obj.DelValue(PlayerConfig);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerConfig(this IContext obj, PlayerConfig value) => obj.SetValue(PlayerConfig, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerConfig(this IContext obj) => obj.HasValue(PlayerConfig);

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
    }
}
