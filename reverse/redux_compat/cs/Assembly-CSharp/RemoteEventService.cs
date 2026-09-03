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

public static class RemoteEventService // TypeDefIndex: 1192
{
	// Fields
	private const string CACHE_FILE = "remote_events.json"; // Metadata: 0x0064D436
	private const string PREF_ETAG = "RemoteEventsEtag"; // Metadata: 0x0064D449
	private const string PREF_SHOWN_PREFIX = "evShown_"; // Metadata: 0x0064D45A
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0064D463
	private const string HEADER_SERVER_TIME = "X-Server-Time"; // Metadata: 0x0064D464
	private static readonly List<RemoteEventItem> _events; // 0x00
	private static long _serverTimeOffsetMs; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804B90B0-0x00000001804B9100 0x00000001804B9100-0x00000001804B9160
	public static IReadOnlyList<RemoteEventItem> Events { get; } // 0x00000001804B9060-0x00000001804B90B0 

	// Nested types
	[CompilerGenerated]
	private sealed class _FetchAndApply_d__14 : IEnumerator<object> // TypeDefIndex: 1193
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
		public _FetchAndApply_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BC590-0x00000001804BC670
		private bool MoveNext(); // 0x00000001804BBE50-0x00000001804BC550
		private void __m__Finally1(); // 0x00000001804BC670-0x00000001804BC6C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BC550-0x00000001804BC590
	}

	// Constructors
	static RemoteEventService(); // 0x00000001804B8FD0-0x00000001804B9060

	// Methods
	public static void LoadFromDisk(); // 0x00000001804B8210-0x00000001804B82F0
	[IteratorStateMachine(typeof(_FetchAndApply_d__14))]
	public static IEnumerator FetchAndApply(); // 0x00000001804B8030-0x00000001804B8080
	private static void ApplyServerTimeHeader(UnityWebRequest req); // 0x00000001804B7EB0-0x00000001804B7FA0
	private static bool ParseInto(string raw); // 0x00000001804B84D0-0x00000001804B8C80
	public static RemoteEventItem PickAutoShow(); // 0x00000001804B8C80-0x00000001804B8E00
	public static void MarkShownToday(RemoteEventItem e); // 0x00000001804B82F0-0x00000001804B8390
	public static bool IsAllowedUrl(string url); // 0x00000001804B8080-0x00000001804B8210
	public static void SeedServerTime(long serverTimeMs); // 0x00000001804B8E00-0x00000001804B8E70
	public static long NowServerMs(); // 0x00000001804B8470-0x00000001804B84D0
	private static long NowLocalMs(); // 0x00000001804B8390-0x00000001804B8470
	private static string TodayStamp(); // 0x00000001804B8E70-0x00000001804B8FD0
	private static string CachePath(); // 0x00000001804B7FA0-0x00000001804B8030
}

