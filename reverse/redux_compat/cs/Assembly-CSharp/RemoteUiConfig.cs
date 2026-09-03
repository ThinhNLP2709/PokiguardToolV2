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

public static class RemoteUiConfig // TypeDefIndex: 1196
{
	// Fields
	private const string CACHE_FILE = "remote_ui.json"; // Metadata: 0x0064D495
	private const string PREF_ETAG = "RemoteUiEtag"; // Metadata: 0x0064D4A4
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0064D4B1
	private const int MAX_ENTRIES = 5000; // Metadata: 0x0064D4B2
	private static readonly Dictionary<string, string> _entries; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnConfigApplied; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804C5DC0-0x00000001804C5E10 0x00000001804C5F40-0x00000001804C5FA0
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804C5D70-0x00000001804C5DC0 0x00000001804C5EE0-0x00000001804C5F40

	// Events
	public static event Action OnConfigApplied {
		add; // 0x00000001804C5CA0-0x00000001804C5D70
		remove; // 0x00000001804C5E10-0x00000001804C5EE0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__18 : IEnumerator<object> // TypeDefIndex: 1197
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
		public _FetchAndApply_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D4060-0x00000001804D4140
		private bool MoveNext(); // 0x00000001804D3840-0x00000001804D4020
		private void __m__Finally1(); // 0x00000001804D4140-0x00000001804D4190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D4020-0x00000001804D4060
	}

	// Constructors
	static RemoteUiConfig(); // 0x00000001804C5B90-0x00000001804C5CA0

	// Methods
	public static bool TryGet(string uiKey, string prop, out string val); // 0x00000001804C5A30-0x00000001804C5B90
	public static void LoadFromDisk(); // 0x00000001804C4C80-0x00000001804C5220
	[IteratorStateMachine(typeof(_FetchAndApply_d__18))]
	public static IEnumerator FetchAndApply(); // 0x00000001804C4C30-0x00000001804C4C80
	private static bool ParseInto(string raw, out long version, out Dictionary<string, string> result); // 0x00000001804C5220-0x00000001804C57A0
	private static void SaveToDisk(string raw); // 0x00000001804C5960-0x00000001804C5A30
	private static string CachePath(); // 0x00000001804C4A80-0x00000001804C4B10
	private static void SafeRaiseApplied(); // 0x00000001804C57A0-0x00000001804C5960
	public static void ClearCache(); // 0x00000001804C4B10-0x00000001804C4C30
}

