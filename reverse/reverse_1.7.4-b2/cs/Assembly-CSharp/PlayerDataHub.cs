/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PlayerDataHub : MonoBehaviour // TypeDefIndex: 1410
{
	// Fields
	[CompilerGenerated]
	private static PlayerDataHub _Instance_k__BackingField; // 0x00
	private const float DEBOUNCE_SECONDS = 0.35f; // Metadata: 0x0068CFED
	private const float COMMIT_WAIT_TIMEOUT = 4f; // Metadata: 0x0068CFF1
	private const float SCOPE_COOLDOWN_SECONDS = 1f; // Metadata: 0x0068CFF5
	private const PlayerDataScope COMMIT_DEPENDENT = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc; // Metadata: 0x0068CFF9
	private PlayerDataScope _dirty; // 0x20
	private bool _flushScheduled; // 0x24
	private bool _rewardCommitted; // 0x25
	private bool _awaitingCommit; // 0x26
	private Coroutine _postMatchRoutine; // 0x28
	private float _lastDispatchUser; // 0x30
	private float _lastDispatchChinhPhuc; // 0x34
	private float _lastDispatchEnergy; // 0x38
	[CompilerGenerated]
	private Action<PlayerDataScope> OnPlayerDataRefreshed; // 0x40

	// Properties
	public static PlayerDataHub Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C0D10-0x00000001805C0D50 0x00000001805C0E10-0x00000001805C0E70

	// Events
	public event Action<PlayerDataScope> OnPlayerDataRefreshed {
		add; // 0x00000001805C0C50-0x00000001805C0D10
		remove; // 0x00000001805C0D50-0x00000001805C0E10
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _DebouncedFlush_d__28 : IEnumerator<object> // TypeDefIndex: 1411
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DebouncedFlush_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805CFA20-0x00000001805CFAE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CFAE0-0x00000001805CFB20
	}

	[CompilerGenerated]
	private sealed class _PostMatchRoutine_d__29 : IEnumerator<object> // TypeDefIndex: 1412
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28
		private float _deadline_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostMatchRoutine_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805D40F0-0x00000001805D43E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D43E0-0x00000001805D4420
	}

	// Constructors
	public PlayerDataHub(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Bootstrap(); // 0x00000001805C0130-0x00000001805C0290
	public static PlayerDataHub EnsureInstance(); // 0x00000001805C0320-0x00000001805C0480
	private void Awake(); // 0x00000001805BFFF0-0x00000001805C0130
	private void OnDestroy(); // 0x00000001805C0920-0x00000001805C09F0
	public void MarkStale(PlayerDataScope scopes, string reason); // 0x00000001805C07C0-0x00000001805C0850
	public void RefreshStale(string reason); // 0x00000001805C0BA0-0x00000001805C0BE0
	public void ForceRefresh(PlayerDataScope scopes, string reason); // 0x00000001805C0770-0x00000001805C07C0
	public void RefreshAfterMatch(string reason); // 0x00000001805C0A80-0x00000001805C0BA0
	public void NotifyRewardCommitted(string matchId); // 0x00000001805C0850-0x00000001805C0920
	[IteratorStateMachine(typeof(_DebouncedFlush_d__28))]
	private IEnumerator DebouncedFlush(string reason); // 0x00000001805C0290-0x00000001805C0320
	[IteratorStateMachine(typeof(_PostMatchRoutine_d__29))]
	private IEnumerator PostMatchRoutine(string reason); // 0x00000001805C09F0-0x00000001805C0A80
	private void FlushNow(string reason, PlayerDataScope allowed = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc | PlayerDataScope.Room | PlayerDataScope.Energy | PlayerDataScope.All /* Metadata: 0x0068CFEC */); // 0x00000001805C0480-0x00000001805C0770
	private void RescheduleFlush(string reason); // 0x00000001805C0BE0-0x00000001805C0C50
}

