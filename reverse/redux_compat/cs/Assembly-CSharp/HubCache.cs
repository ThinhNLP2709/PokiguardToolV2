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

public static class HubCache // TypeDefIndex: 1154
{
	// Fields
	[CompilerGenerated]
	private static HubBootstrapData _Data_k__BackingField; // 0x00
	private static float _lastFetch; // 0x08
	private const float TTL_SECONDS = 60f; // Metadata: 0x0064D3E5
	private const int REQUEST_TIMEOUT_SECONDS = 20; // Metadata: 0x0064D3E9
	private static float _lastFailTime; // 0x0C
	private const float NEG_CACHE_SECONDS = 60f; // Metadata: 0x0064D3EA

	// Properties
	public static HubBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AF8B0-0x00000001804AF900 0x00000001804AFA00-0x00000001804AFA70
	public static bool IsFresh { get; } // 0x00000001804AF900-0x00000001804AF9C0 
	public static bool UseWsBootstrap { get; set; } // 0x00000001804AF9C0-0x00000001804AFA00 0x00000001804AFA70-0x00000001804AFAC0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1155
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public HubBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadViaWs_b__0(HubBootstrapData data); // 0x00000001804C2CF0-0x00000001804C2D70
		internal void _LoadViaWs_b__1(string reason); // 0x00000001804C2D70-0x00000001804C2D90
	}

	[CompilerGenerated]
	private sealed class _Load_d__16 : IEnumerator<object> // TypeDefIndex: 1156
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public bool force; // 0x28
		public Action onSuccess; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BEA10-0x00000001804BEAF0
		private bool MoveNext(); // 0x00000001804BDC20-0x00000001804BE9D0
		private void __m__Finally1(); // 0x00000001804BEAF0-0x00000001804BEB40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BE9D0-0x00000001804BEA10
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__18 : IEnumerator<object> // TypeDefIndex: 1157
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass18_0 __8__1; // 0x20
		public Action<string> onError; // 0x28
		public Action onSuccess; // 0x30
		private Action<HubBootstrapData> _onResp_5__2; // 0x38
		private Action<string> _onFail_5__3; // 0x40
		private float _deadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804C0280-0x00000001804C02D0
		private bool MoveNext(); // 0x00000001804BFD50-0x00000001804C0240
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C0240-0x00000001804C0280
	}

	// Constructors
	static HubCache(); // 0x00000001804AF860-0x00000001804AF8B0

	// Methods
	public static void Invalidate(); // 0x00000001804AF6D0-0x00000001804AF730
	public static void Clear(); // 0x00000001804AF550-0x00000001804AF610
	[IteratorStateMachine(typeof(_Load_d__16))]
	public static IEnumerator Load(Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x0064D3E4 */); // 0x00000001804AF7C0-0x00000001804AF860
	private static string Esc(string s); // 0x00000001804AF610-0x00000001804AF6D0
	[IteratorStateMachine(typeof(_LoadViaWs_d__18))]
	private static IEnumerator LoadViaWs(Action onSuccess, Action<string> onError); // 0x00000001804AF730-0x00000001804AF7C0
}

