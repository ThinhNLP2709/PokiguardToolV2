/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RemoteFlags // TypeDefIndex: 1420
{
	// Fields
	private const string CACHE_FILE = "remote_flags.json"; // Metadata: 0x0068D03A
	private const string PREF_ETAG = "RemoteFlagsEtag"; // Metadata: 0x0068D04C
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0068D05C
	private static readonly Dictionary<string, bool> _flags; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnFlagsChanged; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C3650-0x00000001805C36A0 0x00000001805C37D0-0x00000001805C3830
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C3600-0x00000001805C3650 0x00000001805C3770-0x00000001805C37D0

	// Events
	public static event Action OnFlagsChanged {
		add; // 0x00000001805C3530-0x00000001805C3600
		remove; // 0x00000001805C36A0-0x00000001805C3770
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__17 : IEnumerator<object> // TypeDefIndex: 1421
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchAndApply_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D10C0-0x00000001805D11A0
		private bool MoveNext(); // 0x00000001805D0A50-0x00000001805D1080
		private void __m__Finally1(); // 0x00000001805D11A0-0x00000001805D11F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D1080-0x00000001805D10C0
	}

	// Constructors
	static RemoteFlags(); // 0x00000001805C3420-0x00000001805C3530

	// Methods
	public static bool IsOn(string key, bool defaultOn); // 0x00000001805C2880-0x00000001805C2990
	public static void LoadFromDisk(); // 0x00000001805C2990-0x00000001805C2B00
	[IteratorStateMachine(typeof(_FetchAndApply_d__17))]
	public static IEnumerator FetchAndApply(); // 0x00000001805C2830-0x00000001805C2880
	private static bool ParseInto(string raw); // 0x00000001805C2B00-0x00000001805C3260
	private static void SafeRaiseChanged(); // 0x00000001805C3260-0x00000001805C3420
	private static string CachePath(); // 0x00000001805C27A0-0x00000001805C2830
}

