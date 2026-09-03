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

public class PvpMatchStarter : MonoBehaviour // TypeDefIndex: 436
{
	// Fields
	[CompilerGenerated]
	private static PvpMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private Coroutine _startCoroutine; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018034A0B0-0x000000018034A0F0 0x000000018034A130-0x000000018034A190
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018034A0F0-0x000000018034A130 0x000000018034A190-0x000000018034A1D0

	// Nested types
	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__18 : IEnumerator<object> // TypeDefIndex: 437
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018035B8A0-0x000000018035BDB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035BDB0-0x000000018035BDF0
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchPvp_d__16 : IEnumerator<object> // TypeDefIndex: 438
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchPvp_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018035C1E0-0x000000018035C450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035C450-0x000000018035C490
	}

	// Constructors
	public PvpMatchStarter(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x0000000180349440-0x0000000180349530
	private void Awake(); // 0x0000000180349530-0x0000000180349790
	private void OnDestroy(); // 0x0000000180349A70-0x0000000180349BC0
	private void Subscribe(); // 0x0000000180349E60-0x0000000180349FA0
	private void Unsubscribe(); // 0x0000000180349FA0-0x000000018034A040
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x0000000180349790-0x0000000180349A70
	[IteratorStateMachine(typeof(_WsLoadMatchPvp_d__16))]
	private IEnumerator WsLoadMatchPvp(); // 0x000000018034A040-0x000000018034A0B0
	private static void PrewarmRoomPetClips(); // 0x0000000180349BC0-0x0000000180349E10
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__18))]
	private IEnumerator SnapshotWatchdog(); // 0x0000000180349E10-0x0000000180349E60
}

