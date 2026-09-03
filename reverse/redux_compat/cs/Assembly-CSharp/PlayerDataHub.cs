/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PlayerDataHub : MonoBehaviour // TypeDefIndex: 1185
{
	// Fields
	[CompilerGenerated]
	private static PlayerDataHub _Instance_k__BackingField; // 0x00
	private const float DEBOUNCE_SECONDS = 0.35f; // Metadata: 0x0064D425
	private const float COMMIT_WAIT_TIMEOUT = 4f; // Metadata: 0x0064D429
	private const float SCOPE_COOLDOWN_SECONDS = 1f; // Metadata: 0x0064D42D
	private const PlayerDataScope COMMIT_DEPENDENT = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc; // Metadata: 0x0064D431
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
	public static PlayerDataHub Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804B77E0-0x00000001804B7820 0x00000001804B78E0-0x00000001804B7940

	// Events
	public event Action<PlayerDataScope> OnPlayerDataRefreshed {
		add; // 0x00000001804B7720-0x00000001804B77E0
		remove; // 0x00000001804B7820-0x00000001804B78E0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _DebouncedFlush_d__28 : IEnumerator<object> // TypeDefIndex: 1186
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DebouncedFlush_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804BA980-0x00000001804BAA40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BAA40-0x00000001804BAA80
	}

	[CompilerGenerated]
	private sealed class _PostMatchRoutine_d__29 : IEnumerator<object> // TypeDefIndex: 1187
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PlayerDataHub __4__this; // 0x20
		public string reason; // 0x28
		private float _deadline_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostMatchRoutine_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804C0A30-0x00000001804C0CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C0CD0-0x00000001804C0D10
	}

	// Constructors
	public PlayerDataHub(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Bootstrap(); // 0x00000001804B69E0-0x00000001804B6B40
	public static PlayerDataHub EnsureInstance(); // 0x00000001804B6BD0-0x00000001804B6D30
	private void Awake(); // 0x00000001804B68A0-0x00000001804B69E0
	private void OnDestroy(); // 0x00000001804B7440-0x00000001804B7510
	public void MarkStale(PlayerDataScope scopes, string reason); // 0x00000001804B7280-0x00000001804B73B0
	public void RefreshStale(string reason); // 0x00000001804B7670-0x00000001804B76B0
	public void ForceRefresh(PlayerDataScope scopes, string reason); // 0x00000001804B7230-0x00000001804B7280
	public void RefreshAfterMatch(string reason); // 0x00000001804B75A0-0x00000001804B7670
	public void NotifyRewardCommitted(string matchId); // 0x00000001804B73B0-0x00000001804B7440
	[IteratorStateMachine(typeof(_DebouncedFlush_d__28))]
	private IEnumerator DebouncedFlush(string reason); // 0x00000001804B6B40-0x00000001804B6BD0
	[IteratorStateMachine(typeof(_PostMatchRoutine_d__29))]
	private IEnumerator PostMatchRoutine(string reason); // 0x00000001804B7510-0x00000001804B75A0
	private void FlushNow(string reason, PlayerDataScope allowed = PlayerDataScope.None | PlayerDataScope.User | PlayerDataScope.ChinhPhuc | PlayerDataScope.Room | PlayerDataScope.Energy | PlayerDataScope.All /* Metadata: 0x0064D424 */); // 0x00000001804B6D30-0x00000001804B7230
	private void RescheduleFlush(string reason); // 0x00000001804B76B0-0x00000001804B7720
}

