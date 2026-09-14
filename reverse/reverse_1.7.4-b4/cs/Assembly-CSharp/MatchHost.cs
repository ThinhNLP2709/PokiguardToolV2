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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchHost // TypeDefIndex: 1092
{
	// Fields
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

	// Properties
	public static float EnterProgress01 { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180674070-0x00000001806740D0 0x00000001806740D0-0x0000000180674140
	public static MatchState State { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180674140-0x00000001806741A0 0x00000001806741A0-0x0000000180674200
	public static MatchKind? CurrentKind { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180674200-0x0000000180674260 0x0000000180674260-0x00000001806742C0
	public static GameObject CurrentRig { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806742C0-0x0000000180674320 0x0000000180674320-0x00000001806743E0
	public static bool RigInBattleScene { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806743E0-0x0000000180674440 0x0000000180674440-0x00000001806744A0
	public static string LastLogicalSceneName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806744A0-0x0000000180674500 0x0000000180674500-0x00000001806745C0
	public static bool IsInMatch { get; } // 0x00000001806745C0-0x00000001806746F0 
	public static bool IsBusy { get; } // 0x00000001806746F0-0x00000001806747B0 
	public static Camera RigCamera { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806747B0-0x0000000180674810 0x0000000180674810-0x00000001806748D0

	// Events
	public static event Action<MatchKind> OnEnter {
		add; // 0x00000001806748D0-0x0000000180674A20
		remove; // 0x0000000180674A20-0x0000000180674B70
	}
	public static event Action<MatchKind> OnExit {
		add; // 0x0000000180674B70-0x0000000180674CC0
		remove; // 0x0000000180674CC0-0x0000000180674E10
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _EnsureRigReady_d__47 : IEnumerator<object> // TypeDefIndex: 1093
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchKind kind; // 0x20
		private AsyncOperationHandle<GameObject> _handle_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureRigReady_d__47(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180676AD0-0x0000000180676AF0
		private bool MoveNext(); // 0x0000000180676AF0-0x0000000180676CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180676CD0-0x0000000180676D10
	}

	[CompilerGenerated]
	private sealed class _Enter_d__56 : IEnumerator<object> // TypeDefIndex: 1094
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Enter_d__56(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180676D10-0x0000000180676E40
		private bool MoveNext(); // 0x0000000180676E40-0x0000000180678B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180678B50-0x0000000180678B90
	}

	[CompilerGenerated]
	private sealed class _Exit_d__57 : IEnumerator<object> // TypeDefIndex: 1095
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private MatchKind _kind_5__2; // 0x20
		private GameObject _rig_5__3; // 0x28
		private AsyncOperation _hubLoadOp_5__4; // 0x30
		private float _hubDeadline_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Exit_d__57(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
		private bool MoveNext(); // 0x0000000180678B90-0x0000000180679FE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180679FE0-0x000000018067A020
	}

	[CompilerGenerated]
	private sealed class _UnloadBattleSceneRoutine_d__58 : IEnumerator<object> // TypeDefIndex: 1096
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
		public _UnloadBattleSceneRoutine_d__58(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
		private bool MoveNext(); // 0x000000018067A020-0x000000018067A430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018067A430-0x000000018067A470
	}

	[CompilerGenerated]
	private sealed class _WatchdogGuard_d__60 : IEnumerator<object> // TypeDefIndex: 1097
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _start_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchdogGuard_d__60(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018067A470-0x000000018067A6D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018067A6D0-0x000000018067A710
	}

	// Constructors
	static MatchHost(); // 0x0000000180676880-0x0000000180676AD0

	// Methods
	public static bool SupportsPrefab(MatchKind kind); // 0x0000000180674E10-0x0000000180674EB0
	private static string AddressOf(MatchKind kind); // 0x0000000180674EB0-0x0000000180674F10
	public static void Prewarm(MatchKind kind); // 0x0000000180674F10-0x0000000180674FB0
	[IteratorStateMachine(typeof(_EnsureRigReady_d__47))]
	public static IEnumerator EnsureRigReady(MatchKind kind); // 0x0000000180674FB0-0x0000000180675000
	public static bool IsRigReady(MatchKind kind); // 0x0000000180675000-0x00000001806753A0
	private static AsyncOperationHandle<GameObject> StartRigLoad(string address); // 0x00000001806753A0-0x0000000180675620
	private static bool HasMissingScript(GameObject root); // 0x0000000180675620-0x00000001806757B0
	private static bool LooksLikeBrokenBundle(Exception ex); // 0x00000001806757B0-0x0000000180675F10
	private static void DropRigHandle(string address); // 0x0000000180675F10-0x00000001806760E0
	[IteratorStateMachine(typeof(_Enter_d__56))]
	public static IEnumerator Enter(MatchKind kind); // 0x00000001806760E0-0x0000000180676130
	[IteratorStateMachine(typeof(_Exit_d__57))]
	public static IEnumerator Exit(); // 0x0000000180676130-0x0000000180676170
	[IteratorStateMachine(typeof(_UnloadBattleSceneRoutine_d__58))]
	private static IEnumerator UnloadBattleSceneRoutine(); // 0x0000000180676170-0x00000001806761B0
	public static void ForceReset(); // 0x00000001806761B0-0x0000000180676840
	[IteratorStateMachine(typeof(_WatchdogGuard_d__60))]
	public static IEnumerator WatchdogGuard(); // 0x0000000180676840-0x0000000180676880
}

