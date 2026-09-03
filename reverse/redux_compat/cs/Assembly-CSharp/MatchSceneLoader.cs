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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class MatchSceneLoader // TypeDefIndex: 643
{
	// Fields
	public const string HUB_SCENE = "QuangTruong"; // Metadata: 0x0064C730
	private static bool _isLoading; // 0x00
	private static bool _isUnloading; // 0x01
	private const float SCENE_LOAD_TIMEOUT_SEC = 45f; // Metadata: 0x0064C73C
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
	internal static bool HubReloadExitInProgress { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C34F0-0x00000001803C3540 0x00000001803C3620-0x00000001803C3680
	public static bool IsBusy { get; } // 0x00000001803C3540-0x00000001803C35D0 
	public static bool IsHubRenderDisabled { get; } // 0x00000001803C35D0-0x00000001803C3620 

	// Nested types
	private sealed class PrefabEnterState // TypeDefIndex: 644
	{
		// Fields
		public bool done; // 0x10
		public bool prefabOk; // 0x11

		// Constructors
		public PrefabEnterState(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 645
	{
		// Fields
		private static Runner _instance; // 0x00

		// Properties
		public static Runner Instance { get; } // 0x00000001803CF6A0-0x00000001803CF7B0 

		// Constructors
		public Runner(); // 0x00000001802E7A70-0x00000001802E7BC0
	}

	[CompilerGenerated]
	private sealed class _AbortToHub_d__24 : IEnumerator<object> // TypeDefIndex: 646
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AbortToHub_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803CF7B0-0x00000001803CFB50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803CFB50-0x00000001803CFB90
	}

	[CompilerGenerated]
	private sealed class _LoadMatchAdditive_d__22 : IEnumerator<object> // TypeDefIndex: 647
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private PrefabEnterState _enterState_5__2; // 0x28
		private AsyncOperationHandle<SceneInstance> _handle_5__3; // 0x30
		private float _loadDeadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadMatchAdditive_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D2C20-0x00000001803D2CD0
		private bool MoveNext(); // 0x00000001803D1E00-0x00000001803D2BE0
		private void __m__Finally1(); // 0x00000001803D2CD0-0x00000001803D2D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D2BE0-0x00000001803D2C20
	}

	[CompilerGenerated]
	private sealed class _NotifyReturnAfterHubReload_d__27 : IEnumerator<object> // TypeDefIndex: 648
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private float _deadline_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _NotifyReturnAfterHubReload_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D2F40-0x00000001803D3410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D3410-0x00000001803D3450
	}

	[CompilerGenerated]
	private sealed class _PrefabEnterRoutine_d__21 : IEnumerator<object> // TypeDefIndex: 649
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		public PrefabEnterState state; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PrefabEnterRoutine_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D4040-0x00000001803D40C0
		private bool MoveNext(); // 0x00000001803D3A60-0x00000001803D4000
		private void __m__Finally1(); // 0x00000001803D40C0-0x00000001803D4130
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D4000-0x00000001803D4040
	}

	[CompilerGenerated]
	private sealed class _PrefabExitRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 650
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PrefabExitRoutine_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D4450-0x00000001803D44C0
		private bool MoveNext(); // 0x00000001803D4130-0x00000001803D4410
		private void __m__Finally1(); // 0x00000001803D44C0-0x00000001803D4860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D4410-0x00000001803D4450
	}

	[CompilerGenerated]
	private sealed class _UnloadHubRoutine_d__14 : IEnumerator<object> // TypeDefIndex: 651
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperation _op_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UnloadHubRoutine_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE030-0x00000001803BE060
		private bool MoveNext(); // 0x00000001803D50E0-0x00000001803D53B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D53B0-0x00000001803D53F0
	}

	[CompilerGenerated]
	private sealed class _UnloadMatch_d__25 : IEnumerator<object> // TypeDefIndex: 652
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string matchSceneName; // 0x20
		private AsyncOperationHandle<SceneInstance> _unloadHandle_5__2; // 0x28
		private AsyncOperation _op_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UnloadMatch_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D5E50-0x00000001803D5F00
		private bool MoveNext(); // 0x00000001803D53F0-0x00000001803D5E10
		private void __m__Finally1(); // 0x00000001803D5F00-0x00000001803D5F60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D5E10-0x00000001803D5E50
	}

	// Constructors
	static MatchSceneLoader(); // 0x00000001803C3100-0x00000001803C34F0

	// Methods
	public static string SceneAddressOf(string matchSceneName); // 0x00000001803C2C60-0x00000001803C2CB0
	private static MatchKind KindOf(string matchSceneName); // 0x00000001803C1A10-0x00000001803C1A60
	private static bool UsePrefabForEnter(string matchSceneName); // 0x00000001803C2F10-0x00000001803C2FF0
	private static bool UsePrefabForExit(string matchSceneName); // 0x00000001803C2FF0-0x00000001803C3100
	public static bool HubIsLoaded(); // 0x00000001803C17D0-0x00000001803C1860
	[IteratorStateMachine(typeof(_UnloadHubRoutine_d__14))]
	private static IEnumerator UnloadHubRoutine(); // 0x00000001803C2E50-0x00000001803C2EA0
	private static void PrepareHubReloadReturnFlags(string matchSceneName); // 0x00000001803C2A40-0x00000001803C2AD0
	private static void ResetWsRoomPropsAfterMatch(); // 0x00000001803C2AD0-0x00000001803C2C60
	public static bool IsMatchAdditiveLoaded(string matchSceneName); // 0x00000001803C1860-0x00000001803C1920
	[IteratorStateMachine(typeof(_PrefabEnterRoutine_d__21))]
	private static IEnumerator PrefabEnterRoutine(string matchSceneName, PrefabEnterState state); // 0x00000001803C2940-0x00000001803C29D0
	[IteratorStateMachine(typeof(_LoadMatchAdditive_d__22))]
	public static IEnumerator LoadMatchAdditive(string matchSceneName); // 0x00000001803C1A60-0x00000001803C1AD0
	private static void NotifyServerMatchLeaveIfNeeded(); // 0x00000001803C21E0-0x00000001803C2360
	[IteratorStateMachine(typeof(_AbortToHub_d__24))]
	private static IEnumerator AbortToHub(string matchSceneName, string reason); // 0x00000001803BF5C0-0x00000001803BF650
	[IteratorStateMachine(typeof(_UnloadMatch_d__25))]
	public static IEnumerator UnloadMatch(string matchSceneName); // 0x00000001803C2EA0-0x00000001803C2F10
	[IteratorStateMachine(typeof(_PrefabExitRoutine_d__26))]
	private static IEnumerator PrefabExitRoutine(string matchSceneName); // 0x00000001803C29D0-0x00000001803C2A40
	[IteratorStateMachine(typeof(_NotifyReturnAfterHubReload_d__27))]
	private static IEnumerator NotifyReturnAfterHubReload(string matchSceneName); // 0x00000001803C1C50-0x00000001803C1CC0
	private static void ClearTowerBattleFlag(); // 0x00000001803BF650-0x00000001803BF6C0
	private static void NotifyRoomRefreshOnReturn(string matchSceneName); // 0x00000001803C1CC0-0x00000001803C21E0
	public static void ForceReset(); // 0x00000001803C13B0-0x00000001803C1590
	public static void ForceRestoreHub(); // 0x00000001803C1590-0x00000001803C17D0
	public static void StartLoad(string matchSceneName); // 0x00000001803C2CB0-0x00000001803C2D80
	public static void StartUnload(string matchSceneName); // 0x00000001803C2D80-0x00000001803C2E50
	public static bool MuteHubAnimatorInMatch(Animator animator); // 0x00000001803C1AD0-0x00000001803C1C50
	private static void EnsureEventHook(); // 0x00000001803C12D0-0x00000001803C13B0
	private static void OnAnySceneUnloaded(Scene unloadedScene); // 0x00000001803C2360-0x00000001803C2940
	private static bool IsRenderKeptHubRoot(string rootName); // 0x00000001803C1920-0x00000001803C1A10
	private static void DisableHubInteraction(); // 0x00000001803BF6C0-0x00000001803C0670
	private static void EnableHubInteraction(); // 0x00000001803C0670-0x00000001803C12D0
}

