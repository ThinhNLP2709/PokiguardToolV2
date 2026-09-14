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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchSceneLoader // TypeDefIndex: 1098
{
	// Fields
	private static bool _isLoading; // 0x00
	private static bool _isUnloading; // 0x01
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
	internal static bool HubReloadExitInProgress { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018067AC60-0x000000018067ACC0 0x000000018067ACC0-0x000000018067AD20
	public static bool IsBusy { get; } // 0x000000018067B140-0x000000018067B1D0 
	public static bool IsHubRenderDisabled { get; } // 0x000000018067CA50-0x000000018067CAB0 

	// Nested types
	private sealed class PrefabEnterState // TypeDefIndex: 1099
	{
		// Fields
		public bool done; // 0x10
		public bool prefabOk; // 0x11

		// Constructors
		public PrefabEnterState(); // 0x000000018028A320-0x000000018028A330
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 1100
	{
		// Fields
		private static Runner _instance; // 0x00

		// Properties
		public static Runner Instance { get; } // 0x0000000180680E80-0x0000000180681070 

		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[CompilerGenerated]
	private sealed class _AbortToHub_d__24 : IEnumerator<object> // TypeDefIndex: 1101
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AbortToHub_d__24(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180681070-0x00000001806816F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806816F0-0x0000000180681730
	}

	[CompilerGenerated]
	private sealed class _LoadMatchAdditive_d__22 : IEnumerator<object> // TypeDefIndex: 1102
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private PrefabEnterState _enterState_5__2; // 0x28
		private AsyncOperationHandle<SceneInstance> _handle_5__3; // 0x30
		private float _loadDeadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadMatchAdditive_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180681730-0x0000000180681880
		private bool MoveNext(); // 0x0000000180681880-0x00000001806827C0
		private void __m__Finally1(); // 0x00000001806827C0-0x0000000180682830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180682830-0x0000000180682870
	}

	[CompilerGenerated]
	private sealed class _NotifyReturnAfterHubReload_d__27 : IEnumerator<object> // TypeDefIndex: 1103
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _NotifyReturnAfterHubReload_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180682870-0x00000001806830A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806830A0-0x00000001806830E0
	}

	[CompilerGenerated]
	private sealed class _PrefabEnterRoutine_d__21 : IEnumerator<object> // TypeDefIndex: 1104
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public PrefabEnterState state; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PrefabEnterRoutine_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806830E0-0x0000000180683150
		private bool MoveNext(); // 0x0000000180683150-0x0000000180683AE0
		private void __m__Finally1(); // 0x0000000180683AE0-0x0000000180683B60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180683B60-0x0000000180683BA0
	}

	[CompilerGenerated]
	private sealed class _PrefabExitRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 1105
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PrefabExitRoutine_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180683BA0-0x0000000180683C10
		private bool MoveNext(); // 0x0000000180683C10-0x00000001806840C0
		private void __m__Finally1(); // 0x00000001806840C0-0x0000000180684920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180684920-0x0000000180684960
	}

	[CompilerGenerated]
	private sealed class _UnloadHubRoutine_d__14 : IEnumerator<object> // TypeDefIndex: 1106
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperation _op_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UnloadHubRoutine_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
		private bool MoveNext(); // 0x0000000180684960-0x0000000180684D70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180684D70-0x0000000180684DB0
	}

	[CompilerGenerated]
	private sealed class _UnloadMatch_d__25 : IEnumerator<object> // TypeDefIndex: 1107
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private AsyncOperationHandle<SceneInstance> _unloadHandle_5__2; // 0x28
		private AsyncOperation _op_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UnloadMatch_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180684DB0-0x0000000180684F00
		private bool MoveNext(); // 0x0000000180684F00-0x0000000180685EA0
		private void __m__Finally1(); // 0x0000000180685EA0-0x0000000180685F10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180685F10-0x0000000180685F50
	}

	// Constructors
	static MatchSceneLoader(); // 0x0000000180680060-0x00000001806808F0

	// Methods
	public static string SceneAddressOf(string matchSceneName); // 0x000000018067A710-0x000000018067A770
	private static MatchKind KindOf(string matchSceneName); // 0x000000018067A770-0x000000018067A800
	private static bool UsePrefabForEnter(string matchSceneName); // 0x000000018067A800-0x000000018067AA50
	private static bool UsePrefabForExit(string matchSceneName); // 0x000000018067AA50-0x000000018067AB60
	public static bool HubIsLoaded(); // 0x000000018067AB60-0x000000018067AC60
	[IteratorStateMachine(typeof(_UnloadHubRoutine_d__14))]
	private static IEnumerator UnloadHubRoutine(); // 0x000000018067AD20-0x000000018067AD60
	private static void PrepareHubReloadReturnFlags(string matchSceneName); // 0x000000018067AD60-0x000000018067AE60
	private static void ResetWsRoomPropsAfterMatch(); // 0x000000018067AE60-0x000000018067B010
	public static bool IsMatchAdditiveLoaded(string matchSceneName); // 0x000000018067B010-0x000000018067B140
	[IteratorStateMachine(typeof(_PrefabEnterRoutine_d__21))]
	private static IEnumerator PrefabEnterRoutine(string matchSceneName, PrefabEnterState state); // 0x000000018067B1D0-0x000000018067B2E0
	[IteratorStateMachine(typeof(_LoadMatchAdditive_d__22))]
	public static IEnumerator LoadMatchAdditive(string matchSceneName); // 0x000000018067B2E0-0x000000018067B380
	private static void NotifyServerMatchLeaveIfNeeded(); // 0x000000018067B380-0x000000018067B5A0
	[IteratorStateMachine(typeof(_AbortToHub_d__24))]
	private static IEnumerator AbortToHub(string matchSceneName, string reason); // 0x000000018067B5A0-0x000000018067B6B0
	[IteratorStateMachine(typeof(_UnloadMatch_d__25))]
	public static IEnumerator UnloadMatch(string matchSceneName); // 0x000000018067B6B0-0x000000018067B750
	[IteratorStateMachine(typeof(_PrefabExitRoutine_d__26))]
	private static IEnumerator PrefabExitRoutine(string matchSceneName); // 0x000000018067B750-0x000000018067B7F0
	[IteratorStateMachine(typeof(_NotifyReturnAfterHubReload_d__27))]
	private static IEnumerator NotifyReturnAfterHubReload(string matchSceneName); // 0x000000018067B7F0-0x000000018067B890
	private static void ClearTowerBattleFlag(); // 0x000000018067B890-0x000000018067B950
	private static void ClearGuildRaidReturnFlag(); // 0x000000018067B950-0x000000018067BA40
	private static void NotifyRoomRefreshOnReturn(string matchSceneName); // 0x000000018067BA40-0x000000018067C570
	public static void ForceReset(); // 0x000000018067C570-0x000000018067C730
	public static void ForceRestoreHub(); // 0x000000018067C730-0x000000018067C950
	public static void StartLoad(string matchSceneName); // 0x000000018067C950-0x000000018067C9D0
	public static void StartUnload(string matchSceneName); // 0x000000018067C9D0-0x000000018067CA50
	public static bool MuteHubAnimatorInMatch(Animator animator); // 0x000000018067CAB0-0x000000018067CDD0
	private static void EnsureEventHook(); // 0x000000018067CDD0-0x000000018067CEC0
	private static void OnAnySceneUnloaded(Scene unloadedScene); // 0x000000018067CEC0-0x000000018067D730
	private static bool IsRenderKeptHubRoot(string rootName); // 0x000000018067D730-0x000000018067D860
	private static void DisableHubInteraction(); // 0x000000018067D860-0x000000018067EC60
	private static void EnableHubInteraction(); // 0x000000018067EC60-0x0000000180680060
}

