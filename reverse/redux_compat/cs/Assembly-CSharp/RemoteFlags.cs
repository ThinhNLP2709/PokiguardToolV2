/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RemoteFlags // TypeDefIndex: 1194
{
	// Fields
	private const string CACHE_FILE = "remote_flags.json"; // Metadata: 0x0064D472
	private const string PREF_ETAG = "RemoteFlagsEtag"; // Metadata: 0x0064D484
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0064D494
	private static readonly Dictionary<string, bool> _flags; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnFlagsChanged; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804C48A0-0x00000001804C48F0 0x00000001804C4A20-0x00000001804C4A80
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804C4850-0x00000001804C48A0 0x00000001804C49C0-0x00000001804C4A20

	// Events
	public static event Action OnFlagsChanged {
		add; // 0x00000001804C4780-0x00000001804C4850
		remove; // 0x00000001804C48F0-0x00000001804C49C0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__17 : IEnumerator<object> // TypeDefIndex: 1195
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchAndApply_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D3710-0x00000001804D37F0
		private bool MoveNext(); // 0x00000001804D30D0-0x00000001804D36D0
		private void __m__Finally1(); // 0x00000001804D37F0-0x00000001804D3840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D36D0-0x00000001804D3710
	}

	// Constructors
	static RemoteFlags(); // 0x00000001804C4670-0x00000001804C4780

	// Methods
	public static bool IsOn(string key, bool defaultOn); // 0x00000001804C3AD0-0x00000001804C3BE0
	public static void LoadFromDisk(); // 0x00000001804C3BE0-0x00000001804C3D50
	[IteratorStateMachine(typeof(_FetchAndApply_d__17))]
	public static IEnumerator FetchAndApply(); // 0x00000001804C3A80-0x00000001804C3AD0
	private static bool ParseInto(string raw); // 0x00000001804C3D50-0x00000001804C44B0
	private static void SafeRaiseChanged(); // 0x00000001804C44B0-0x00000001804C4670
	private static string CachePath(); // 0x00000001804C39F0-0x00000001804C3A80
}

