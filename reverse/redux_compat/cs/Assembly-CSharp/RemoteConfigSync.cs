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

public class RemoteConfigSync : MonoBehaviour // TypeDefIndex: 1188
{
	// Fields
	private const float REFRESH_INTERVAL_SECONDS = 600f; // Metadata: 0x0064D432
	private static RemoteConfigSync _instance; // 0x00
	private static long _serverUiVersion; // 0x08
	private static long _serverFlagsVersion; // 0x10
	private static long _serverEventsVersion; // 0x18
	private static bool _kickedOff; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _RefreshLoop_d__11 : IEnumerator<object> // TypeDefIndex: 1189
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private WaitForSecondsRealtime _wait_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshLoop_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE030-0x00000001803BE060
		private bool MoveNext(); // 0x00000001804C1540-0x00000001804C1750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C1750-0x00000001804C1790
	}

	[CompilerGenerated]
	private sealed class _SyncChanged_d__10 : IEnumerator<object> // TypeDefIndex: 1190
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SyncChanged_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804C28E0-0x00000001804C2CB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C2CB0-0x00000001804C2CF0
	}

	// Constructors
	public RemoteConfigSync(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static void LoadAllFromDisk(); // 0x00000001804B7D10-0x00000001804B7DA0
	public static void KickOff(AppBootstrapData data); // 0x00000001804B7A50-0x00000001804B7D10
	private static void EnsureInstance(); // 0x00000001804B7940-0x00000001804B7A50
	private void Start(); // 0x00000001804B7DF0-0x00000001804B7E60
	[IteratorStateMachine(typeof(_SyncChanged_d__10))]
	private IEnumerator SyncChanged(); // 0x00000001804B7E60-0x00000001804B7EB0
	[IteratorStateMachine(typeof(_RefreshLoop_d__11))]
	private IEnumerator RefreshLoop(); // 0x00000001804B7DA0-0x00000001804B7DF0
}

