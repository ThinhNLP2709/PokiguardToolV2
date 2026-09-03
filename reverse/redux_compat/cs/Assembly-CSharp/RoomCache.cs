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

public static class RoomCache // TypeDefIndex: 1158
{
	// Fields
	[CompilerGenerated]
	private static RoomBootstrapData _Data_k__BackingField; // 0x00
	private static float _lastFetch; // 0x08
	private static int _cachedPetId; // 0x0C
	private static string _cachedMode; // 0x10
	private const float TTL_SECONDS = 300f; // Metadata: 0x0064D3EF
	private const int REQUEST_TIMEOUT_SECONDS = 20; // Metadata: 0x0064D3F3
	private static float _lastFailTime; // 0x18
	private const float NEG_CACHE_SECONDS = 60f; // Metadata: 0x0064D3F4

	// Properties
	public static RoomBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804B96B0-0x00000001804B9700 0x00000001804B9740-0x00000001804B97B0
	public static bool UseWsBootstrap { get; set; } // 0x00000001804B9700-0x00000001804B9740 0x00000001804B97B0-0x00000001804B9800

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1159
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public RoomBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadViaWs_b__0(RoomBootstrapData data); // 0x00000001804C2D90-0x00000001804C2E10
		internal void _LoadViaWs_b__1(string reason); // 0x00000001804C2D70-0x00000001804C2D90
	}

	[CompilerGenerated]
	private sealed class _Load_d__17 : IEnumerator<object> // TypeDefIndex: 1160
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public bool force; // 0x28
		public int petId; // 0x2C
		public string mode; // 0x30
		public Action onSuccess; // 0x38
		private string _safeMode_5__2; // 0x40
		private UnityWebRequest _req_5__3; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BFC10-0x00000001804BFD00
		private bool MoveNext(); // 0x00000001804BEB40-0x00000001804BFBD0
		private void __m__Finally1(); // 0x00000001804BFD00-0x00000001804BFD50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BFBD0-0x00000001804BFC10
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__19 : IEnumerator<object> // TypeDefIndex: 1161
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int petId; // 0x20
		public string mode; // 0x28
		public Action<string> onError; // 0x30
		private __c__DisplayClass19_0 __8__1; // 0x38
		public Action onSuccess; // 0x40
		private Action<RoomBootstrapData> _onResp_5__2; // 0x48
		private Action<string> _onFail_5__3; // 0x50
		private float _deadline_5__4; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804C09E0-0x00000001804C0A30
		private bool MoveNext(); // 0x00000001804C02D0-0x00000001804C09A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C09A0-0x00000001804C09E0
	}

	// Constructors
	static RoomCache(); // 0x00000001804B9600-0x00000001804B96B0

	// Methods
	public static bool IsFresh(int petId, string mode); // 0x00000001804B9390-0x00000001804B9480
	public static void Invalidate(); // 0x00000001804B9330-0x00000001804B9390
	public static void Clear(); // 0x00000001804B9160-0x00000001804B9270
	[IteratorStateMachine(typeof(_Load_d__17))]
	public static IEnumerator Load(int petId, string mode, Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x0064D3EE */); // 0x00000001804B9540-0x00000001804B9600
	private static string Esc(string s); // 0x00000001804B9270-0x00000001804B9330
	[IteratorStateMachine(typeof(_LoadViaWs_d__19))]
	private static IEnumerator LoadViaWs(int petId, string mode, Action onSuccess, Action<string> onError); // 0x00000001804B9480-0x00000001804B9540
}

