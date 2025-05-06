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
    }
}
