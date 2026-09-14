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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ChatImageCache // TypeDefIndex: 490
{
	// Fields
	private static readonly Dictionary<string, Texture2D> _thumbs; // 0x00
	private static readonly List<string> _thumbOrder; // 0x08
	private static readonly Dictionary<string, Texture2D> _fulls; // 0x10
	private static readonly List<string> _fullOrder; // 0x18
	private static readonly HashSet<string> _expired; // 0x20
	private static readonly Dictionary<string, List<Waiter>> _inFlight; // 0x28

	// Nested types
	private struct Waiter // TypeDefIndex: 491
	{
		// Fields
		public Action<Texture2D> OnDone; // 0x00
		public Action OnExpired; // 0x08
	}

	[CompilerGenerated]
	private sealed class _Download_d__14 : IEnumerator<object> // TypeDefIndex: 492
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string id; // 0x20
		public bool thumb; // 0x28
		public string key; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Download_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803973D0-0x0000000180397500
		private bool MoveNext(); // 0x0000000180397500-0x0000000180397CF0
		private void __m__Finally1(); // 0x0000000180397CF0-0x0000000180397D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180397D50-0x0000000180397D90
	}

	// Constructors
	static ChatImageCache(); // 0x0000000180396D50-0x00000001803973D0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetOnPlay(); // 0x00000001803958E0-0x0000000180395A70
	public static bool IsValidId(string id); // 0x0000000180395A70-0x0000000180395AF0
	public static bool IsKnownExpired(string id); // 0x0000000180395AF0-0x0000000180395B90
	public static void Get(string id, bool thumb, Action<Texture2D> onDone, Action onExpired); // 0x0000000180395B90-0x00000001803962D0
	[IteratorStateMachine(typeof(_Download_d__14))]
	private static IEnumerator Download(string id, bool thumb, string key); // 0x00000001803962D0-0x00000001803963E0
	private static void Flush(string key, Texture2D tex, bool expired); // 0x00000001803963E0-0x0000000180396780
	private static bool TryGetCached(string id, bool thumb, out Texture2D tex); // 0x0000000180396780-0x00000001803969C0
	private static void Store(string id, bool thumb, Texture2D tex); // 0x00000001803969C0-0x0000000180396D50
}

