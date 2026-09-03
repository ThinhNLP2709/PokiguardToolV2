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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class MatchHost // TypeDefIndex: 637
{
	// Fields
	private const string RIG_ADDRESS_COOP = "Assets/Prefabs/Match/MatchRig.prefab"; // Metadata: 0x0064C6D7
	private const string RIG_ADDRESS_PVP = "Assets/Prefabs/Match/MatchRigPvp.prefab"; // Metadata: 0x0064C6FC
	private const float BUILD_WATCHDOG_SEC = 30f; // Metadata: 0x0064C724
	private const float BATTLE_SCENE_LOAD_TIMEOUT_SEC = 10f; // Metadata: 0x0064C728
	private const float HUB_RELOAD_TIMEOUT_SEC = 30f; // Metadata: 0x0064C72C
	[CompilerGenerated]
	private static MatchState _State_k__BackingField; // 0x00
	[CompilerGenerated]
	private static MatchKind? _CurrentKind_k__BackingField; // 0x04
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

	// Properties
	public static MatchState State { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBFA0-0x00000001803BBFF0 0x00000001803BC3E0-0x00000001803BC440
	public static MatchKind? CurrentKind { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBB80-0x00000001803BBBD0 0x00000001803BC1D0-0x00000001803BC230
	public static GameObject CurrentRig { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBBD0-0x00000001803BBC20 0x00000001803BC230-0x00000001803BC2A0
	public static bool RigInBattleScene { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBF50-0x00000001803BBFA0 0x00000001803BC380-0x00000001803BC3E0
	public static string LastLogicalSceneName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBEB0-0x00000001803BBF00 0x00000001803BC2A0-0x00000001803BC310
	public static bool IsInMatch { get; } // 0x00000001803BBD50-0x00000001803BBEB0 
	public static bool IsBusy { get; } // 0x00000001803BBC20-0x00000001803BBD50 
	public static Camera RigCamera { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BBF00-0x00000001803BBF50 0x00000001803BC310-0x00000001803BC380

	// Events
	public static event Action<MatchKind> OnEnter {
		add; // 0x00000001803BB9A0-0x00000001803BBA90
		remove; // 0x00000001803BBFF0-0x00000001803BC0E0
	}
	public static event Action<MatchKind> OnExit {
		add; // 0x00000001803BBA90-0x00000001803BBB80
		remove; // 0x00000001803BC0E0-0x00000001803BC1D0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _EnsureRigReady_d__43 : IEnumerator<object> // TypeDefIndex: 638
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchKind kind; // 0x20
		private AsyncOperationHandle<GameObject> _handle_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureRigReady_d__43(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BCF20-0x00000001803BCF40
		private bool MoveNext(); // 0x00000001803BCDB0-0x00000001803BCEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BCEE0-0x00000001803BCF20
	}

	[CompilerGenerated]
	private sealed class _Enter_d__47 : IEnumerator<object> // TypeDefIndex: 639
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
		private AsyncOperation _loadOp_5__7; // 0x60
		private float _deadline_5__8; // 0x68
		private bool _timedOut_5__9; // 0x6C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Enter_d__47(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D0EE0-0x00000001803D0F40
		private bool MoveNext(); // 0x00000001803CFE90-0x00000001803D0EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D0EA0-0x00000001803D0EE0
	}

	[CompilerGenerated]
	private sealed class _Exit_d__48 : IEnumerator<object> // TypeDefIndex: 640
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private MatchKind _kind_5__2; // 0x20
		private GameObject _rig_5__3; // 0x28
		private AsyncOperation _hubLoadOp_5__4; // 0x30
		private float _hubDeadline_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Exit_d__48(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
		private bool MoveNext(); // 0x00000001803D0F40-0x00000001803D1900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D1900-0x00000001803D1940
	}

	[CompilerGenerated]
	private sealed class _UnloadBattleSceneRoutine_d__49 : IEnumerator<object> // TypeDefIndex: 641
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
		public _UnloadBattleSceneRoutine_d__49(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE030-0x00000001803BE060
		private bool MoveNext(); // 0x00000001803D4E40-0x00000001803D50A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D50A0-0x00000001803D50E0
	}

	[CompilerGenerated]
	private sealed class _WatchdogGuard_d__51 : IEnumerator<object> // TypeDefIndex: 642
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _start_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogGuard_d__51(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D5F60-0x00000001803D6180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D6180-0x00000001803D61C0
	}

	// Constructors
	static MatchHost(); // 0x00000001803BB900-0x00000001803BB9A0

	// Methods
	public static bool SupportsPrefab(MatchKind kind); // 0x00000001803BB7E0-0x00000001803BB860
	private static string AddressOf(MatchKind kind); // 0x00000001803BAB40-0x00000001803BAB90
	public static void Prewarm(MatchKind kind); // 0x00000001803BB510-0x00000001803BB5A0
	[IteratorStateMachine(typeof(_EnsureRigReady_d__43))]
	public static IEnumerator EnsureRigReady(MatchKind kind); // 0x00000001803BACF0-0x00000001803BAD50
	public static bool IsRigReady(MatchKind kind); // 0x00000001803BB380-0x00000001803BB510
	private static AsyncOperationHandle<GameObject> StartRigLoad(string address); // 0x00000001803BB5A0-0x00000001803BB7E0
	private static void DropRigHandle(string address); // 0x00000001803BAB90-0x00000001803BACF0
	[IteratorStateMachine(typeof(_Enter_d__47))]
	public static IEnumerator Enter(MatchKind kind); // 0x00000001803BAD50-0x00000001803BADB0
	[IteratorStateMachine(typeof(_Exit_d__48))]
	public static IEnumerator Exit(); // 0x00000001803BADB0-0x00000001803BAE00
	[IteratorStateMachine(typeof(_UnloadBattleSceneRoutine_d__49))]
	private static IEnumerator UnloadBattleSceneRoutine(); // 0x00000001803BB860-0x00000001803BB8B0
	public static void ForceReset(); // 0x00000001803BAE00-0x00000001803BB380
	[IteratorStateMachine(typeof(_WatchdogGuard_d__51))]
	public static IEnumerator WatchdogGuard(); // 0x00000001803BB8B0-0x00000001803BB900
}

