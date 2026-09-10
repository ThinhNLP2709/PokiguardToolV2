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

public static class RemoteEventService // TypeDefIndex: 1418
{
	// Fields
	private const string CACHE_FILE = "remote_events.json"; // Metadata: 0x0068CFFE
	private const string PREF_ETAG = "RemoteEventsEtag"; // Metadata: 0x0068D011
	private const string PREF_SHOWN_PREFIX = "evShown_"; // Metadata: 0x0068D022
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0068D02B
	private const string HEADER_SERVER_TIME = "X-Server-Time"; // Metadata: 0x0068D02C
	private static readonly List<RemoteEventItem> _events; // 0x00
	private static long _serverTimeOffsetMs; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C26F0-0x00000001805C2740 0x00000001805C2740-0x00000001805C27A0
	public static IReadOnlyList<RemoteEventItem> Events { get; } // 0x00000001805C26A0-0x00000001805C26F0 

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__14 : IEnumerator<object> // TypeDefIndex: 1419
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
		public _FetchAndApply_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D0920-0x00000001805D0A00
		private bool MoveNext(); // 0x00000001805D0180-0x00000001805D08E0
		private void __m__Finally1(); // 0x00000001805D0A00-0x00000001805D0A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D08E0-0x00000001805D0920
	}

	// Constructors
	static RemoteEventService(); // 0x00000001805C2610-0x00000001805C26A0

	// Methods
	public static void LoadFromDisk(); // 0x00000001805C1850-0x00000001805C1930
	[IteratorStateMachine(typeof(_FetchAndApply_d__14))]
	public static IEnumerator FetchAndApply(); // 0x00000001805C1670-0x00000001805C16C0
	private static void ApplyServerTimeHeader(UnityWebRequest req); // 0x00000001805C14F0-0x00000001805C15E0
	private static bool ParseInto(string raw); // 0x00000001805C1B10-0x00000001805C22C0
	public static RemoteEventItem PickAutoShow(); // 0x00000001805C22C0-0x00000001805C2440
	public static void MarkShownToday(RemoteEventItem e); // 0x00000001805C1930-0x00000001805C19D0
	public static bool IsAllowedUrl(string url); // 0x00000001805C16C0-0x00000001805C1850
	public static void SeedServerTime(long serverTimeMs); // 0x00000001805C2440-0x00000001805C24B0
	public static long NowServerMs(); // 0x00000001805C1AB0-0x00000001805C1B10
	private static long NowLocalMs(); // 0x00000001805C19D0-0x00000001805C1AB0
	private static string TodayStamp(); // 0x00000001805C24B0-0x00000001805C2610
	private static string CachePath(); // 0x00000001805C15E0-0x00000001805C1670
}

