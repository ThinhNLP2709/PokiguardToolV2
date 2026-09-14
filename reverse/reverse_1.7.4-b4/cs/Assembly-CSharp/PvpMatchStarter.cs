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

public class PvpMatchStarter : MonoBehaviour // TypeDefIndex: 559
{
	// Fields
	[CompilerGenerated]
	private static PvpMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private Coroutine _startCoroutine; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E9B00-0x00000001803E9B40 0x00000001803E9B40-0x00000001803E9BE0
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E9BE0-0x00000001803E9C20 0x00000001803E9C20-0x00000001803E9C70

	// Nested types
	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__18 : IEnumerator<object> // TypeDefIndex: 560
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803EB200-0x00000001803EB860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EB860-0x00000001803EB8A0
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchPvp_d__16 : IEnumerator<object> // TypeDefIndex: 561
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803EB8A0-0x00000001803EBC50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EBC50-0x00000001803EBC90
	}

	// Constructors
	public PvpMatchStarter(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803E9C70-0x00000001803E9E00
	private void Awake(); // 0x00000001803E9E00-0x00000001803EA240
	private void OnDestroy(); // 0x00000001803EA240-0x00000001803EA440
	private void Subscribe(); // 0x00000001803EA440-0x00000001803EA620
	private void Unsubscribe(); // 0x00000001803EA620-0x00000001803EA6D0
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803EA6D0-0x00000001803EAA80
	[IteratorStateMachine(typeof(_WsLoadMatchPvp_d__16))]
	private IEnumerator WsLoadMatchPvp(); // 0x00000001803EAA80-0x00000001803EAB20
	private static void PrewarmRoomPetClips(); // 0x00000001803EAB20-0x00000001803EADF0
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__18))]
	private IEnumerator SnapshotWatchdog(); // 0x00000001803EADF0-0x00000001803EAE30
	private static bool SnapshotArrived(); // 0x00000001803EAE30-0x00000001803EB200
}

