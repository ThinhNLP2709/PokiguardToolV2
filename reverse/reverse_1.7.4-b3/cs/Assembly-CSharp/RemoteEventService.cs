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

public static class RemoteEventService // TypeDefIndex: 1801
{
	// Fields
	private static readonly List<RemoteEventItem> _events; // 0x00
	private static long _serverTimeOffsetMs; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E45A0-0x00000001808E4600 0x00000001808E4600-0x00000001808E4660

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__14 : IEnumerator<object> // TypeDefIndex: 1802
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
		public _FetchAndApply_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808E5EA0-0x00000001808E5FD0
		private bool MoveNext(); // 0x00000001808E5FD0-0x00000001808E6A50
		private void __m__Finally1(); // 0x00000001808E6A50-0x00000001808E6AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E6AB0-0x00000001808E6AF0
	}

	// Constructors
	static RemoteEventService(); // 0x00000001808E5D60-0x00000001808E5EA0

	// Methods
	public static void LoadFromDisk(); // 0x00000001808E4660-0x00000001808E4750
	[IteratorStateMachine(typeof(_FetchAndApply_d__14))]
	public static IEnumerator FetchAndApply(); // 0x00000001808E4750-0x00000001808E4790
	private static void ApplyServerTimeHeader(UnityWebRequest req); // 0x00000001808E4790-0x00000001808E4930
	private static bool ParseInto(string raw); // 0x00000001808E4930-0x00000001808E51F0
	public static RemoteEventItem PickAutoShow(); // 0x00000001808E51F0-0x00000001808E53E0
	public static void MarkShownToday(RemoteEventItem e); // 0x00000001808E53E0-0x00000001808E54C0
	public static bool IsAllowedUrl(string url); // 0x00000001808E54C0-0x00000001808E5910
	public static void SeedServerTime(long serverTimeMs); // 0x00000001808E5910-0x00000001808E5980
	public static long NowServerMs(); // 0x00000001808E5980-0x00000001808E59E0
	private static long NowLocalMs(); // 0x00000001808E59E0-0x00000001808E5AE0
	private static string TodayStamp(); // 0x00000001808E5AE0-0x00000001808E5CC0
	private static string CachePath(); // 0x00000001808E5CC0-0x00000001808E5D60
}

