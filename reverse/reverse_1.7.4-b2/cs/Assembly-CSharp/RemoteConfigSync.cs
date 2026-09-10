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

public class RemoteConfigSync : MonoBehaviour // TypeDefIndex: 1413
{
	// Fields
	private const float REFRESH_INTERVAL_SECONDS = 600f; // Metadata: 0x0068CFFA
	private static RemoteConfigSync _instance; // 0x00
	private static long _serverUiVersion; // 0x08
	private static long _serverFlagsVersion; // 0x10
	private static long _serverEventsVersion; // 0x18
	private static bool _kickedOff; // 0x20
	[CompilerGenerated]
	private static bool _FirstSyncDone_k__BackingField; // 0x21

	// Properties
	public static bool FirstSyncDone { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C1470-0x00000001805C14B0 0x00000001805C14B0-0x00000001805C14F0

	// Nested types
	[CompilerGenerated]
	private sealed class _RefreshLoop_d__16 : IEnumerator<object> // TypeDefIndex: 1414
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private WaitForSecondsRealtime _wait_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshLoop_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
		private bool MoveNext(); // 0x00000001805D4540-0x00000001805D4750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D4750-0x00000001805D4790
	}

	[CompilerGenerated]
	private sealed class _SyncChanged_d__14 : IEnumerator<object> // TypeDefIndex: 1415
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SyncChanged_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805D5460-0x00000001805D5860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D5860-0x00000001805D58A0
	}

	[CompilerGenerated]
	private sealed class _WaitFirstSync_d__15 : IEnumerator<object> // TypeDefIndex: 1416
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float maxSeconds; // 0x20
		private float _deadline_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitFirstSync_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805D5AF0-0x00000001805D5CC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D5CC0-0x00000001805D5D00
	}

	// Constructors
	public RemoteConfigSync(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void LoadAllFromDisk(); // 0x00000001805C1270-0x00000001805C1300
	public static void KickOff(AppBootstrapData data); // 0x00000001805C0F80-0x00000001805C1270
	private static void EnsureInstance(); // 0x00000001805C0E70-0x00000001805C0F80
	private void Start(); // 0x00000001805C1350-0x00000001805C13C0
	[IteratorStateMachine(typeof(_SyncChanged_d__14))]
	private IEnumerator SyncChanged(); // 0x00000001805C13C0-0x00000001805C1410
	[IteratorStateMachine(typeof(_WaitFirstSync_d__15))]
	public static IEnumerator WaitFirstSync(float maxSeconds); // 0x00000001805C1410-0x00000001805C1470
	[IteratorStateMachine(typeof(_RefreshLoop_d__16))]
	private IEnumerator RefreshLoop(); // 0x00000001805C1300-0x00000001805C1350
}

