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

public static class RemoteEventService // TypeDefIndex: 1803
{
	// Fields
	private static readonly List<RemoteEventItem> _events; // 0x00
	private static long _serverTimeOffsetMs; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E74D0-0x00000001808E7530 0x00000001808E7530-0x00000001808E7590

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__14 : IEnumerator<object> // TypeDefIndex: 1804
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
		void IDisposable.Dispose(); // 0x00000001808E8DD0-0x00000001808E8F00
		private bool MoveNext(); // 0x00000001808E8F00-0x00000001808E9980
		private void __m__Finally1(); // 0x00000001808E9980-0x00000001808E99E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E99E0-0x00000001808E9A20
	}

	// Constructors
	static RemoteEventService(); // 0x00000001808E8C90-0x00000001808E8DD0

	// Methods
	public static void LoadFromDisk(); // 0x00000001808E7590-0x00000001808E7680
	[IteratorStateMachine(typeof(_FetchAndApply_d__14))]
	public static IEnumerator FetchAndApply(); // 0x00000001808E7680-0x00000001808E76C0
	private static void ApplyServerTimeHeader(UnityWebRequest req); // 0x00000001808E76C0-0x00000001808E7860
	private static bool ParseInto(string raw); // 0x00000001808E7860-0x00000001808E8120
	public static RemoteEventItem PickAutoShow(); // 0x00000001808E8120-0x00000001808E8310
	public static void MarkShownToday(RemoteEventItem e); // 0x00000001808E8310-0x00000001808E83F0
	public static bool IsAllowedUrl(string url); // 0x00000001808E83F0-0x00000001808E8840
	public static void SeedServerTime(long serverTimeMs); // 0x00000001808E8840-0x00000001808E88B0
	public static long NowServerMs(); // 0x00000001808E88B0-0x00000001808E8910
	private static long NowLocalMs(); // 0x00000001808E8910-0x00000001808E8A10
	private static string TodayStamp(); // 0x00000001808E8A10-0x00000001808E8BF0
	private static string CachePath(); // 0x00000001808E8BF0-0x00000001808E8C90
}

