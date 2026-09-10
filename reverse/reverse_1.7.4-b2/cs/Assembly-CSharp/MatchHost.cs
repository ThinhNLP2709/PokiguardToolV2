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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchHost // TypeDefIndex: 833
{
	// Fields
	private const string RIG_ADDRESS_COOP = "Assets/Prefabs/Match/MatchRig.prefab"; // Metadata: 0x0068BD02
	private const string RIG_ADDRESS_PVP = "Assets/Prefabs/Match/MatchRigPvp.prefab"; // Metadata: 0x0068BD27
	private const float BUILD_WATCHDOG_SEC = 30f; // Metadata: 0x0068BD4F
	private const float BATTLE_SCENE_LOAD_TIMEOUT_SEC = 10f; // Metadata: 0x0068BD53
	private const float HUB_RELOAD_TIMEOUT_SEC = 30f; // Metadata: 0x0068BD57
	[CompilerGenerated]
	private static float _EnterProgress01_k__BackingField; // 0x00
	[CompilerGenerated]
	private static MatchState _State_k__BackingField; // 0x04
	[CompilerGenerated]
	private static MatchKind? _CurrentKind_k__BackingField; // 0x08
	[CompilerGenerated]
	private static GameObject _CurrentRig_k__BackingField; // 0x10
	[CompilerGenerated]
	private static bool _RigInBattleScene_k__BackingField; // 0x18
	[CompilerGenerated]
	private static string _LastLogicalSceneName_k__BackingField; // 0x20
	[CompilerGenerated]
	private static Camera _RigCamera_k__BackingField; // 0x28
	[CompilerGenerated]
	private static Action<MatchKind> OnEnter; // 0x30
	[CompilerGenerated]
	private static Action<MatchKind> OnExit; // 0x38
	private static readonly Dictionary<string, AsyncOperationHandle<GameObject>> _rigHandles; // 0x40
	private static readonly HashSet<string> _rigCacheCleared; // 0x48
	private static readonly HashSet<string> _rigMissingScript; // 0x50
	private const string MSG_NEED_UPDATE = "C\u1EA7n c\u1EADp nh\u1EADt phi\u00EAn b\u1EA3n m\u1EDBi \u0111\u1EC3 v\u00E0o tr\u1EADn."; // Metadata: 0x0068BD5B

	// Properties
	public static float EnterProgress01 { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D570-0x000000018049D5C0 0x000000018049DC40-0x000000018049DCA0
	public static MatchState State { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D940-0x000000018049D990 0x000000018049DDE0-0x000000018049DE40
	public static MatchKind? CurrentKind { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D4D0-0x000000018049D520 0x000000018049DB70-0x000000018049DBD0
	public static GameObject CurrentRig { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D520-0x000000018049D570 0x000000018049DBD0-0x000000018049DC40
	public static bool RigInBattleScene { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D8F0-0x000000018049D940 0x000000018049DD80-0x000000018049DDE0
	public static string LastLogicalSceneName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D850-0x000000018049D8A0 0x000000018049DCA0-0x000000018049DD10
	public static bool IsInMatch { get; } // 0x000000018049D6F0-0x000000018049D850 
	public static bool IsBusy { get; } // 0x000000018049D5C0-0x000000018049D6F0 
	public static Camera RigCamera { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018049D8A0-0x000000018049D8F0 0x000000018049DD10-0x000000018049DD80

	// Events
	public static event Action<MatchKind> OnEnter {
		add; // 0x000000018049D2F0-0x000000018049D3E0
		remove; // 0x000000018049D990-0x000000018049DA80
	}
	public static event Action<MatchKind> OnExit {
		add; // 0x000000018049D3E0-0x000000018049D4D0
		remove; // 0x000000018049DA80-0x000000018049DB70
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _EnsureRigReady_d__47 : IEnumerator<object> // TypeDefIndex: 834
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchKind kind; // 0x20
		private AsyncOperationHandle<GameObject> _handle_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureRigReady_d__47(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AA250-0x00000001804AA270
		private bool MoveNext(); // 0x00000001804AA0E0-0x00000001804AA210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AA210-0x00000001804AA250
	}

	[CompilerGenerated]
	private sealed class _Enter_d__56 : IEnumerator<object> // TypeDefIndex: 835
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchKind kind; // 0x20
		private string _address_5__2; // 0x28
		private float _t0_5__3; // 0x30
		private AsyncOperationHandle<GameObject> _handle_5__4; // 0x38
		private GameObject _prefab_5__5; // 0x50
		private bool _battleSceneReady_5__6; // 0x58
		private AsyncOperationHandle _clearOp_5__7; // 0x60
		private AsyncOperation _loadOp_5__8; // 0x78
		private float _deadline_5__9; // 0x80
		private bool _timedOut_5__10; // 0x84

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Enter_d__56(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804ABC10-0x00000001804ABC80
		private bool MoveNext(); // 0x00000001804AA270-0x00000001804ABBD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804ABBD0-0x00000001804ABC10
	}

	[CompilerGenerated]
	private sealed class _Exit_d__57 : IEnumerator<object> // TypeDefIndex: 836
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private MatchKind _kind_5__2; // 0x20
		private GameObject _rig_5__3; // 0x28
		private AsyncOperation _hubLoadOp_5__4; // 0x30
		private float _hubDeadline_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Exit_d__57(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x00000001804ABC80-0x00000001804AC7C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AC7C0-0x00000001804AC800
	}

	[CompilerGenerated]
	private sealed class _UnloadBattleSceneRoutine_d__58 : IEnumerator<object> // TypeDefIndex: 837
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
		public _UnloadBattleSceneRoutine_d__58(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
		private bool MoveNext(); // 0x00000001804AFCB0-0x00000001804AFF10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AFF10-0x00000001804AFF50
	}

	[CompilerGenerated]
	private sealed class _WatchdogGuard_d__60 : IEnumerator<object> // TypeDefIndex: 838
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _start_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogGuard_d__60(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804B0DF0-0x00000001804B1010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804B1010-0x00000001804B1050
	}

	// Constructors
	static MatchHost(); // 0x000000018049D1A0-0x000000018049D2F0

	// Methods
	public static bool SupportsPrefab(MatchKind kind); // 0x000000018049D080-0x000000018049D100
	private static string AddressOf(MatchKind kind); // 0x000000018049C1F0-0x000000018049C240
	public static void Prewarm(MatchKind kind); // 0x000000018049CDB0-0x000000018049CE40
	[IteratorStateMachine(typeof(_EnsureRigReady_d__47))]
	public static IEnumerator EnsureRigReady(MatchKind kind); // 0x000000018049C3A0-0x000000018049C400
	public static bool IsRigReady(MatchKind kind); // 0x000000018049CB10-0x000000018049CCA0
	private static AsyncOperationHandle<GameObject> StartRigLoad(string address); // 0x000000018049CE40-0x000000018049D080
	private static bool HasMissingScript(GameObject root); // 0x000000018049CA30-0x000000018049CB10
	private static bool LooksLikeBrokenBundle(Exception ex); // 0x000000018049CCA0-0x000000018049CDB0
	private static void DropRigHandle(string address); // 0x000000018049C240-0x000000018049C3A0
	[IteratorStateMachine(typeof(_Enter_d__56))]
	public static IEnumerator Enter(MatchKind kind); // 0x000000018049C400-0x000000018049C460
	[IteratorStateMachine(typeof(_Exit_d__57))]
	public static IEnumerator Exit(); // 0x000000018049C460-0x000000018049C4B0
	[IteratorStateMachine(typeof(_UnloadBattleSceneRoutine_d__58))]
	private static IEnumerator UnloadBattleSceneRoutine(); // 0x000000018049D100-0x000000018049D150
	public static void ForceReset(); // 0x000000018049C4B0-0x000000018049CA30
	[IteratorStateMachine(typeof(_WatchdogGuard_d__60))]
	public static IEnumerator WatchdogGuard(); // 0x000000018049D150-0x000000018049D1A0
}

