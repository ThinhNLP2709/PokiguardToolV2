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

public class PvpMatchStarter : MonoBehaviour // TypeDefIndex: 505
{
	// Fields
	[CompilerGenerated]
	private static PvpMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private Coroutine _startCoroutine; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803A8D00-0x00000001803A8D40 0x00000001803A8D80-0x00000001803A8DE0
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803A8D40-0x00000001803A8D80 0x00000001803A8DE0-0x00000001803A8E20

	// Nested types
	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__18 : IEnumerator<object> // TypeDefIndex: 506
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803C2CD0-0x00000001803C3070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C3070-0x00000001803C30B0
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchPvp_d__16 : IEnumerator<object> // TypeDefIndex: 507
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchPvp_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803C30B0-0x00000001803C3360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C3360-0x00000001803C33A0
	}

	// Constructors
	public PvpMatchStarter(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803A7D70-0x00000001803A7E60
	private void Awake(); // 0x00000001803A7E60-0x00000001803A80C0
	private void OnDestroy(); // 0x00000001803A83A0-0x00000001803A84F0
	private void Subscribe(); // 0x00000001803A8AB0-0x00000001803A8BF0
	private void Unsubscribe(); // 0x00000001803A8BF0-0x00000001803A8C90
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803A80C0-0x00000001803A83A0
	[IteratorStateMachine(typeof(_WsLoadMatchPvp_d__16))]
	private IEnumerator WsLoadMatchPvp(); // 0x00000001803A8C90-0x00000001803A8D00
	private static void PrewarmRoomPetClips(); // 0x00000001803A84F0-0x00000001803A8740
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__18))]
	private IEnumerator SnapshotWatchdog(); // 0x00000001803A8A60-0x00000001803A8AB0
	private static bool SnapshotArrived(); // 0x00000001803A8740-0x00000001803A8A60
}

