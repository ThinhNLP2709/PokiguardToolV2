/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchSceneLoader // TypeDefIndex: 839
{
	// Fields
	public const string HUB_SCENE = "QuangTruong"; // Metadata: 0x0068BD94
	private static bool _isLoading; // 0x00
	private static bool _isUnloading; // 0x01
	private const float SCENE_LOAD_TIMEOUT_SEC = 45f; // Metadata: 0x0068BDA0
	private static readonly Dictionary<string, AsyncOperationHandle<SceneInstance>> _sceneHandles; // 0x08
	[CompilerGenerated]
	private static bool _HubReloadExitInProgress_k__BackingField; // 0x10
	private static readonly List<Canvas> _disabledCanvases; // 0x18
	private static readonly List<Renderer> _disabledRenderers; // 0x20
	private static readonly List<Camera> _disabledCameras; // 0x28
	private static readonly List<Camera> _disabledCameraComponents; // 0x30
	private static readonly List<AudioListener> _disabledAudioListeners; // 0x38
	private static readonly List<GraphicRaycaster> _disabledRaycasters; // 0x40
	private static readonly List<Animator> _disabledAnimators; // 0x48
	private static bool _hubInteractionDisabled; // 0x50
	private static bool _eventHookInstalled; // 0x51
	private static readonly string[] HUB_ROOTS_KEEP_RENDER; // 0x58

	// Properties
	internal static bool HubReloadExitInProgress { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804A1E10-0x00000001804A1E60 0x00000001804A2050-0x00000001804A20B0
	public static bool IsBusy { get; } // 0x00000001804A1E60-0x00000001804A2000 
	public static bool IsHubRenderDisabled { get; } // 0x00000001804A2000-0x00000001804A2050 

	// Nested types
	private sealed class PrefabEnterState // TypeDefIndex: 840
	{
		// Fields
		public bool done; // 0x10
		public bool prefabOk; // 0x11

		// Constructors
		public PrefabEnterState(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 841
	{
		// Fields
		private static Runner _instance; // 0x00

		// Properties
		public static Runner Instance { get; } // 0x00000001804A9170-0x00000001804A9280 

		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0
	}

	[CompilerGenerated]
	private sealed class _AbortToHub_d__24 : IEnumerator<object> // TypeDefIndex: 842
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AbortToHub_d__24(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804A9810-0x00000001804A9BD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A9BD0-0x00000001804A9C10
	}

	[CompilerGenerated]
	private sealed class _LoadMatchAdditive_d__22 : IEnumerator<object> // TypeDefIndex: 843
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private PrefabEnterState _enterState_5__2; // 0x28
		private AsyncOperationHandle<SceneInstance> _handle_5__3; // 0x30
		private float _loadDeadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadMatchAdditive_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AD960-0x00000001804ADA10
		private bool MoveNext(); // 0x00000001804ACAD0-0x00000001804AD920
		private void __m__Finally1(); // 0x00000001804ADA10-0x00000001804ADA70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AD920-0x00000001804AD960
	}

	[CompilerGenerated]
	private sealed class _NotifyReturnAfterHubReload_d__27 : IEnumerator<object> // TypeDefIndex: 844
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _NotifyReturnAfterHubReload_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804AE190-0x00000001804AE660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AE660-0x00000001804AE6A0
	}

	[CompilerGenerated]
	private sealed class _PrefabEnterRoutine_d__21 : IEnumerator<object> // TypeDefIndex: 845
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public PrefabEnterState state; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PrefabEnterRoutine_d__21(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AED30-0x00000001804AEDB0
		private bool MoveNext(); // 0x00000001804AE6A0-0x00000001804AECF0
		private void __m__Finally1(); // 0x00000001804AEDB0-0x00000001804AEE20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AECF0-0x00000001804AED30
	}

	[CompilerGenerated]
	private sealed class _PrefabExitRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 846
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PrefabExitRoutine_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AF160-0x00000001804AF1D0
		private bool MoveNext(); // 0x00000001804AEE20-0x00000001804AF120
		private void __m__Finally1(); // 0x00000001804AF1D0-0x00000001804AF5E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AF120-0x00000001804AF160
	}

	[CompilerGenerated]
	private sealed class _UnloadHubRoutine_d__14 : IEnumerator<object> // TypeDefIndex: 847
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperation _op_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UnloadHubRoutine_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
		private bool MoveNext(); // 0x00000001804AFF50-0x00000001804B0220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804B0220-0x00000001804B0260
	}

	[CompilerGenerated]
	private sealed class _UnloadMatch_d__25 : IEnumerator<object> // TypeDefIndex: 848
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private AsyncOperationHandle<SceneInstance> _unloadHandle_5__2; // 0x28
		private AsyncOperation _op_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UnloadMatch_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804B0CE0-0x00000001804B0D90
		private bool MoveNext(); // 0x00000001804B0260-0x00000001804B0CA0
		private void __m__Finally1(); // 0x00000001804B0D90-0x00000001804B0DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804B0CA0-0x00000001804B0CE0
	}

	// Constructors
	static MatchSceneLoader(); // 0x00000001804A1A20-0x00000001804A1E10

	// Methods
	public static string SceneAddressOf(string matchSceneName); // 0x00000001804A1510-0x00000001804A1560
	private static MatchKind KindOf(string matchSceneName); // 0x00000001804A0290-0x00000001804A02E0
	private static bool UsePrefabForEnter(string matchSceneName); // 0x00000001804A17C0-0x00000001804A1910
	private static bool UsePrefabForExit(string matchSceneName); // 0x00000001804A1910-0x00000001804A1A20
	public static bool HubIsLoaded(); // 0x00000001804A0050-0x00000001804A00E0
	[IteratorStateMachine(typeof(_UnloadHubRoutine_d__14))]
	private static IEnumerator UnloadHubRoutine(); // 0x00000001804A1700-0x00000001804A1750
	private static void PrepareHubReloadReturnFlags(string matchSceneName); // 0x00000001804A12F0-0x00000001804A1380
	private static void ResetWsRoomPropsAfterMatch(); // 0x00000001804A1380-0x00000001804A1510
	public static bool IsMatchAdditiveLoaded(string matchSceneName); // 0x00000001804A00E0-0x00000001804A01A0
	[IteratorStateMachine(typeof(_PrefabEnterRoutine_d__21))]
	private static IEnumerator PrefabEnterRoutine(string matchSceneName, PrefabEnterState state); // 0x00000001804A11F0-0x00000001804A1280
	[IteratorStateMachine(typeof(_LoadMatchAdditive_d__22))]
	public static IEnumerator LoadMatchAdditive(string matchSceneName); // 0x00000001804A02E0-0x00000001804A0350
	private static void NotifyServerMatchLeaveIfNeeded(); // 0x00000001804A0A60-0x00000001804A0BE0
	[IteratorStateMachine(typeof(_AbortToHub_d__24))]
	private static IEnumerator AbortToHub(string matchSceneName, string reason); // 0x000000018049DE40-0x000000018049DED0
	[IteratorStateMachine(typeof(_UnloadMatch_d__25))]
	public static IEnumerator UnloadMatch(string matchSceneName); // 0x00000001804A1750-0x00000001804A17C0
	[IteratorStateMachine(typeof(_PrefabExitRoutine_d__26))]
	private static IEnumerator PrefabExitRoutine(string matchSceneName); // 0x00000001804A1280-0x00000001804A12F0
	[IteratorStateMachine(typeof(_NotifyReturnAfterHubReload_d__27))]
	private static IEnumerator NotifyReturnAfterHubReload(string matchSceneName); // 0x00000001804A04D0-0x00000001804A0540
	private static void ClearTowerBattleFlag(); // 0x000000018049DED0-0x000000018049DF40
	private static void NotifyRoomRefreshOnReturn(string matchSceneName); // 0x00000001804A0540-0x00000001804A0A60
	public static void ForceReset(); // 0x000000018049FC30-0x000000018049FE10
	public static void ForceRestoreHub(); // 0x000000018049FE10-0x00000001804A0050
	public static void StartLoad(string matchSceneName); // 0x00000001804A1560-0x00000001804A1630
	public static void StartUnload(string matchSceneName); // 0x00000001804A1630-0x00000001804A1700
	public static bool MuteHubAnimatorInMatch(Animator animator); // 0x00000001804A0350-0x00000001804A04D0
	private static void EnsureEventHook(); // 0x000000018049FB50-0x000000018049FC30
	private static void OnAnySceneUnloaded(Scene unloadedScene); // 0x00000001804A0BE0-0x00000001804A11F0
	private static bool IsRenderKeptHubRoot(string rootName); // 0x00000001804A01A0-0x00000001804A0290
	private static void DisableHubInteraction(); // 0x000000018049DF40-0x000000018049EEF0
	private static void EnableHubInteraction(); // 0x000000018049EEF0-0x000000018049FB50
}

