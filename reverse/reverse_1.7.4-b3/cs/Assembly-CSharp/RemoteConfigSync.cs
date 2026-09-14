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

public class RemoteConfigSync : MonoBehaviour // TypeDefIndex: 1795
{
	// Fields
	private const float REFRESH_INTERVAL_SECONDS = 600f; // Metadata: 0x005F01E4
	private static RemoteConfigSync _instance; // 0x00
	private static long _serverUiVersion; // 0x08
	private static long _serverFlagsVersion; // 0x10
	private static long _serverEventsVersion; // 0x18
	private static bool _kickedOff; // 0x20
	private static bool _bootOwned; // 0x21
	[CompilerGenerated]
	private static bool _FirstSyncDone_k__BackingField; // 0x22

	// Properties
	public static bool FirstSyncDone { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E3050-0x00000001808E3090 0x00000001808E3090-0x00000001808E30E0

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAllDirect_d__13 : IEnumerator<object> // TypeDefIndex: 1796
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808E3810-0x00000001808E3B60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E3B60-0x00000001808E3BA0
	}

	[CompilerGenerated]
	private sealed class _RefreshLoop_d__19 : IEnumerator<object> // TypeDefIndex: 1797
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
		void IDisposable.Dispose(); // 0x00000001805EE460-0x00000001805EE4D0
		private bool MoveNext(); // 0x00000001808E3BA0-0x00000001808E3E60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E3E60-0x00000001808E3EA0
	}

	[CompilerGenerated]
	private sealed class _SyncChanged_d__17 : IEnumerator<object> // TypeDefIndex: 1798
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808E3EA0-0x00000001808E4320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E4320-0x00000001808E4360
	}

	[CompilerGenerated]
	private sealed class _WaitFirstSync_d__18 : IEnumerator<object> // TypeDefIndex: 1799
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808E4360-0x00000001808E4560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E4560-0x00000001808E45A0
	}

	// Constructors
	public RemoteConfigSync(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void LoadAllFromDisk(); // 0x00000001808E30E0-0x00000001808E31B0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void SelfSyncWhenBootSkipped(); // 0x00000001808E31B0-0x00000001808E3280
	[IteratorStateMachine(typeof(_FetchAllDirect_d__13))]
	private IEnumerator FetchAllDirect(); // 0x00000001808E3280-0x00000001808E32C0
	public static void KickOff(AppBootstrapData data); // 0x00000001808E32C0-0x00000001808E34E0
	private static void EnsureInstance(); // 0x00000001808E34E0-0x00000001808E36D0
	private void Start(); // 0x00000001808E36D0-0x00000001808E3730
	[IteratorStateMachine(typeof(_SyncChanged_d__17))]
	private IEnumerator SyncChanged(); // 0x00000001808E3730-0x00000001808E3770
	[IteratorStateMachine(typeof(_WaitFirstSync_d__18))]
	public static IEnumerator WaitFirstSync(float maxSeconds); // 0x00000001808E3770-0x00000001808E37D0
	[IteratorStateMachine(typeof(_RefreshLoop_d__19))]
	private IEnumerator RefreshLoop(); // 0x00000001808E37D0-0x00000001808E3810
}

