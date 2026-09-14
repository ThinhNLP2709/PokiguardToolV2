/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PlayerDataHub : MonoBehaviour // TypeDefIndex: 1794
{
	// Fields
	[CompilerGenerated]
	private static PlayerDataHub _Instance_k__BackingField; // 0x00
	private const float DEBOUNCE_SECONDS = 0.35f; // Metadata: 0x005F15A8
	private const float COMMIT_WAIT_TIMEOUT = 4f; // Metadata: 0x005F15AC
	private const float SCOPE_COOLDOWN_SECONDS = 1f; // Metadata: 0x005F15B0
	private const PlayerDataScope COMMIT_DEPENDENT = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc; // Metadata: 0x005F15B4
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
	public static PlayerDataHub Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E4630-0x00000001808E4670 0x00000001808E4670-0x00000001808E4710

	// Events
	public event Action<PlayerDataScope> OnPlayerDataRefreshed {
		add; // 0x00000001808E4710-0x00000001808E4830
		remove; // 0x00000001808E4830-0x00000001808E4950
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _DebouncedFlush_d__28 : IEnumerator<object> // TypeDefIndex: 1795
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DebouncedFlush_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808E59E0-0x00000001808E5AD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E5AD0-0x00000001808E5B10
	}

	[CompilerGenerated]
	private sealed class _PostMatchRoutine_d__29 : IEnumerator<object> // TypeDefIndex: 1796
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28
		private float _deadline_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostMatchRoutine_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808E5B10-0x00000001808E5F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E5F40-0x00000001808E5F80
	}

	// Constructors
	public PlayerDataHub(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Bootstrap(); // 0x00000001808E4950-0x00000001808E4960
	public static PlayerDataHub EnsureInstance(); // 0x00000001808E4960-0x00000001808E4B20
	private void Awake(); // 0x00000001808E4B20-0x00000001808E4D90
	private void OnDestroy(); // 0x00000001808E4D90-0x00000001808E4EF0
	public void MarkStale(PlayerDataScope scopes, string reason); // 0x00000001808E4EF0-0x00000001808E4F90
	public void RefreshStale(string reason); // 0x00000001808E4F90-0x00000001808E4FD0
	public void ForceRefresh(PlayerDataScope scopes, string reason); // 0x00000001808E4FD0-0x00000001808E5020
	public void RefreshAfterMatch(string reason); // 0x00000001808E5020-0x00000001808E5210
	public void NotifyRewardCommitted(string matchId); // 0x00000001808E5210-0x00000001808E5300
	[IteratorStateMachine(typeof(_DebouncedFlush_d__28))]
	private IEnumerator DebouncedFlush(string reason); // 0x00000001808E5300-0x00000001808E5410
	[IteratorStateMachine(typeof(_PostMatchRoutine_d__29))]
	private IEnumerator PostMatchRoutine(string reason); // 0x00000001808E5410-0x00000001808E5520
	private void FlushNow(string reason, PlayerDataScope allowed = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc | PlayerDataScope.Room | PlayerDataScope.Energy | PlayerDataScope.All /* Metadata: 0x005F15A7 */); // 0x00000001808E5520-0x00000001808E5960
	private void RescheduleFlush(string reason); // 0x00000001808E5960-0x00000001808E59E0
}

