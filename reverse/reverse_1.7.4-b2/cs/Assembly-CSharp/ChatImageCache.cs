/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ChatImageCache // TypeDefIndex: 436
{
	// Fields
	private const int LIMIT_THUMB = 24; // Metadata: 0x0068B28B
	private const int LIMIT_FULL = 2; // Metadata: 0x0068B28C
	private const int TIMEOUT_SEC = 20; // Metadata: 0x0068B28D
	private static readonly Dictionary<string, Texture2D> _thumbs; // 0x00
	private static readonly List<string> _thumbOrder; // 0x08
	private static readonly Dictionary<string, Texture2D> _fulls; // 0x10
	private static readonly List<string> _fullOrder; // 0x18
	private static readonly HashSet<string> _expired; // 0x20
	private static readonly Dictionary<string, List<Waiter>> _inFlight; // 0x28

	// Properties
	public static int CountThumb { get; } // 0x000000018036EB60-0x000000018036EBC0 
	public static int CountFull { get; } // 0x000000018036EB00-0x000000018036EB60 

	// Nested types
	private struct Waiter // TypeDefIndex: 437
	{
		// Fields
		public Action<Texture2D> OnDone; // 0x00
		public Action OnExpired; // 0x08
	}

	[CompilerGenerated]
	private sealed class _Download_d__14 : IEnumerator<object> // TypeDefIndex: 438
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string id; // 0x20
		public bool thumb; // 0x28
		public string key; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Download_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180374D30-0x0000000180374E10
		private bool MoveNext(); // 0x00000001803747F0-0x0000000180374CF0
		private void __m__Finally1(); // 0x0000000180374E10-0x0000000180374E60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180374CF0-0x0000000180374D30
	}

	// Constructors
	static ChatImageCache(); // 0x000000018036E8A0-0x000000018036EB00

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetOnPlay(); // 0x000000018036E380-0x000000018036E4C0
	public static bool IsValidId(string id); // 0x000000018036E2F0-0x000000018036E380
	public static bool IsKnownExpired(string id); // 0x000000018036E260-0x000000018036E2F0
	public static void Get(string id, bool thumb, Action<Texture2D> onDone, Action onExpired); // 0x000000018036DD20-0x000000018036E260
	[IteratorStateMachine(typeof(_Download_d__14))]
	private static IEnumerator Download(string id, bool thumb, string key); // 0x000000018036D9F0-0x000000018036DA90
	private static void Flush(string key, Texture2D tex, bool expired); // 0x000000018036DA90-0x000000018036DD20
	private static bool TryGetCached(string id, bool thumb, out Texture2D tex); // 0x000000018036E730-0x000000018036E8A0
	private static void Store(string id, bool thumb, Texture2D tex); // 0x000000018036E4C0-0x000000018036E730
}

