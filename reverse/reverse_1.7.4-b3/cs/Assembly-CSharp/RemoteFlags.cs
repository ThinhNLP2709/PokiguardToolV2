/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class RemoteFlags // TypeDefIndex: 1803
{
	// Fields
	private static readonly Dictionary<string, bool> _flags; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnFlagsChanged; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E6AF0-0x00000001808E6B50 0x00000001808E6B50-0x00000001808E6BB0
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E6BB0-0x00000001808E6C10 0x00000001808E6C10-0x00000001808E6C70

	// Events
	public static event Action OnFlagsChanged {
		add; // 0x00000001808E6C70-0x00000001808E6DA0
		remove; // 0x00000001808E6DA0-0x00000001808E6ED0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__17 : IEnumerator<object> // TypeDefIndex: 1804
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private UnityWebRequest _req_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchAndApply_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808E7E90-0x00000001808E7FC0
		private bool MoveNext(); // 0x00000001808E7FC0-0x00000001808E8880
		private void __m__Finally1(); // 0x00000001808E8880-0x00000001808E88E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E88E0-0x00000001808E8920
	}

	// Constructors
	static RemoteFlags(); // 0x00000001808E7D00-0x00000001808E7E90

	// Methods
	public static bool IsOn(string key, bool defaultOn); // 0x00000001808E6ED0-0x00000001808E7030
	public static void LoadFromDisk(); // 0x00000001808E7030-0x00000001808E7200
	[IteratorStateMachine(typeof(_FetchAndApply_d__17))]
	public static IEnumerator FetchAndApply(); // 0x00000001808E7200-0x00000001808E7240
	private static bool ParseInto(string raw); // 0x00000001808E7240-0x00000001808E7A90
	private static void SafeRaiseChanged(); // 0x00000001808E7A90-0x00000001808E7C60
	private static string CachePath(); // 0x00000001808E7C60-0x00000001808E7D00
}

