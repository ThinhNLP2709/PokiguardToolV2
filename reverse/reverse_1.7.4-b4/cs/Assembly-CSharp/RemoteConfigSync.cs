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

public class RemoteConfigSync : MonoBehaviour // TypeDefIndex: 1797
{
	// Fields
	private const float REFRESH_INTERVAL_SECONDS = 600f; // Metadata: 0x005F15B5
	private static RemoteConfigSync _instance; // 0x00
	private static long _serverUiVersion; // 0x08
	private static long _serverFlagsVersion; // 0x10
	private static long _serverEventsVersion; // 0x18
	private static bool _kickedOff; // 0x20
	private static bool _bootOwned; // 0x21
	[CompilerGenerated]
	private static bool _FirstSyncDone_k__BackingField; // 0x22

	// Properties
	public static bool FirstSyncDone { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E5F80-0x00000001808E5FC0 0x00000001808E5FC0-0x00000001808E6010

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAllDirect_d__13 : IEnumerator<object> // TypeDefIndex: 1798
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchAllDirect_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808E6740-0x00000001808E6A90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E6A90-0x00000001808E6AD0
	}

	[CompilerGenerated]
	private sealed class _RefreshLoop_d__19 : IEnumerator<object> // TypeDefIndex: 1799
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private WaitForSecondsRealtime _wait_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshLoop_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
		private bool MoveNext(); // 0x00000001808E6AD0-0x00000001808E6D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E6D90-0x00000001808E6DD0
	}

	[CompilerGenerated]
	private sealed class _SyncChanged_d__17 : IEnumerator<object> // TypeDefIndex: 1800
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SyncChanged_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808E6DD0-0x00000001808E7250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E7250-0x00000001808E7290
	}

	[CompilerGenerated]
	private sealed class _WaitFirstSync_d__18 : IEnumerator<object> // TypeDefIndex: 1801
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float maxSeconds; // 0x20
		private float _deadline_5__2; // 0x24

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitFirstSync_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808E7290-0x00000001808E7490
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E7490-0x00000001808E74D0
	}

	// Constructors
	public RemoteConfigSync(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void LoadAllFromDisk(); // 0x00000001808E6010-0x00000001808E60E0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void SelfSyncWhenBootSkipped(); // 0x00000001808E60E0-0x00000001808E61B0
	[IteratorStateMachine(typeof(_FetchAllDirect_d__13))]
	private IEnumerator FetchAllDirect(); // 0x00000001808E61B0-0x00000001808E61F0
	public static void KickOff(AppBootstrapData data); // 0x00000001808E61F0-0x00000001808E6410
	private static void EnsureInstance(); // 0x00000001808E6410-0x00000001808E6600
	private void Start(); // 0x00000001808E6600-0x00000001808E6660
	[IteratorStateMachine(typeof(_SyncChanged_d__17))]
	private IEnumerator SyncChanged(); // 0x00000001808E6660-0x00000001808E66A0
	[IteratorStateMachine(typeof(_WaitFirstSync_d__18))]
	public static IEnumerator WaitFirstSync(float maxSeconds); // 0x00000001808E66A0-0x00000001808E6700
	[IteratorStateMachine(typeof(_RefreshLoop_d__19))]
	private IEnumerator RefreshLoop(); // 0x00000001808E6700-0x00000001808E6740
}

