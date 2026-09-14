/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RemoteUiConfig // TypeDefIndex: 1807
{
	// Fields
	private static readonly Dictionary<string, string> _entries; // 0x00
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _Loaded_k__BackingField; // 0x10
	[CompilerGenerated]
	private static Action OnConfigApplied; // 0x18

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808EB850-0x00000001808EB8B0 0x00000001808EB8B0-0x00000001808EB910
	public static bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808EB910-0x00000001808EB970 0x00000001808EB970-0x00000001808EB9D0

	// Events
	public static event Action OnConfigApplied {
		add; // 0x00000001808EB9D0-0x00000001808EBB00
		remove; // 0x00000001808EBB00-0x00000001808EBC30
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__18 : IEnumerator<object> // TypeDefIndex: 1808
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
		public _FetchAndApply_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808ED0B0-0x00000001808ED1E0
		private bool MoveNext(); // 0x00000001808ED1E0-0x00000001808EDCF0
		private void __m__Finally1(); // 0x00000001808EDCF0-0x00000001808EDD50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808EDD50-0x00000001808EDD90
	}

	// Constructors
	static RemoteUiConfig(); // 0x00000001808ECF20-0x00000001808ED0B0

	// Methods
	public static bool TryGet(string uiKey, string prop, out string val); // 0x00000001808EBC30-0x00000001808EBD90
	public static void LoadFromDisk(); // 0x00000001808EBD90-0x00000001808EC4D0
	[IteratorStateMachine(typeof(_FetchAndApply_d__18))]
	public static IEnumerator FetchAndApply(); // 0x00000001808EC4D0-0x00000001808EC510
	private static bool ParseInto(string raw, out long version, out Dictionary<string, string> result); // 0x00000001808EC510-0x00000001808ECBD0
	private static void SaveToDisk(string raw); // 0x00000001808ECBD0-0x00000001808ECCB0
	private static string CachePath(); // 0x00000001808ECCB0-0x00000001808ECD50
	private static void SafeRaiseApplied(); // 0x00000001808ECD50-0x00000001808ECF20
}

