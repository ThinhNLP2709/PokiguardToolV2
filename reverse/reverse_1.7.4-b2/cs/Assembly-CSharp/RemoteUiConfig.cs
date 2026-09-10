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

public static class RemoteUiConfig // TypeDefIndex: 1422
{
	// Fields
	private const string CACHE_FILE = "remote_ui.json"; // Metadata: 0x0068D05D
	private const string PREF_ETAG = "RemoteUiEtag"; // Metadata: 0x0068D06C
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0068D079
	private const int MAX_ENTRIES = 5000; // Metadata: 0x0068D07A
	private static readonly Dictionary<string, string> _entries; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnConfigApplied; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C4B70-0x00000001805C4BC0 0x00000001805C4CF0-0x00000001805C4D50
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C4B20-0x00000001805C4B70 0x00000001805C4C90-0x00000001805C4CF0

	// Events
	public static event Action OnConfigApplied {
		add; // 0x00000001805C4A50-0x00000001805C4B20
		remove; // 0x00000001805C4BC0-0x00000001805C4C90
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__18 : IEnumerator<object> // TypeDefIndex: 1423
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
		public _FetchAndApply_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D1A80-0x00000001805D1B60
		private bool MoveNext(); // 0x00000001805D11F0-0x00000001805D1A40
		private void __m__Finally1(); // 0x00000001805D1B60-0x00000001805D1BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D1A40-0x00000001805D1A80
	}

	// Constructors
	static RemoteUiConfig(); // 0x00000001805C4940-0x00000001805C4A50

	// Methods
	public static bool TryGet(string uiKey, string prop, out string val); // 0x00000001805C47E0-0x00000001805C4940
	public static void LoadFromDisk(); // 0x00000001805C3A30-0x00000001805C3FD0
	[IteratorStateMachine(typeof(_FetchAndApply_d__18))]
	public static IEnumerator FetchAndApply(); // 0x00000001805C39E0-0x00000001805C3A30
	private static bool ParseInto(string raw, out long version, out Dictionary<string, string> result); // 0x00000001805C3FD0-0x00000001805C4550
	private static void SaveToDisk(string raw); // 0x00000001805C4710-0x00000001805C47E0
	private static string CachePath(); // 0x00000001805C3830-0x00000001805C38C0
	private static void SafeRaiseApplied(); // 0x00000001805C4550-0x00000001805C4710
	public static void ClearCache(); // 0x00000001805C38C0-0x00000001805C39E0
}

