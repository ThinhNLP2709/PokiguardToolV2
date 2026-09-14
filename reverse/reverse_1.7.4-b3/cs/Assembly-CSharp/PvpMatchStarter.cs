/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PvpMatchStarter : MonoBehaviour // TypeDefIndex: 558
{
	// Fields
	[CompilerGenerated]
	private static PvpMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private Coroutine _startCoroutine; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E8DC0-0x00000001803E8E00 0x00000001803E8E00-0x00000001803E8EA0
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E8EA0-0x00000001803E8EE0 0x00000001803E8EE0-0x00000001803E8F30

	// Nested types
	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__18 : IEnumerator<object> // TypeDefIndex: 559
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803EA4C0-0x00000001803EAB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EAB20-0x00000001803EAB60
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchPvp_d__16 : IEnumerator<object> // TypeDefIndex: 560
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchPvp_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803EAB60-0x00000001803EAF10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EAF10-0x00000001803EAF50
	}

	// Constructors
	public PvpMatchStarter(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803E8F30-0x00000001803E90C0
	private void Awake(); // 0x00000001803E90C0-0x00000001803E9500
	private void OnDestroy(); // 0x00000001803E9500-0x00000001803E9700
	private void Subscribe(); // 0x00000001803E9700-0x00000001803E98E0
	private void Unsubscribe(); // 0x00000001803E98E0-0x00000001803E9990
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803E9990-0x00000001803E9D40
	[IteratorStateMachine(typeof(_WsLoadMatchPvp_d__16))]
	private IEnumerator WsLoadMatchPvp(); // 0x00000001803E9D40-0x00000001803E9DE0
	private static void PrewarmRoomPetClips(); // 0x00000001803E9DE0-0x00000001803EA0B0
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__18))]
	private IEnumerator SnapshotWatchdog(); // 0x00000001803EA0B0-0x00000001803EA0F0
	private static bool SnapshotArrived(); // 0x00000001803EA0F0-0x00000001803EA4C0
}

