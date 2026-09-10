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

public static class RoomCache // TypeDefIndex: 1374
{
	// Fields
	[CompilerGenerated]
	private static RoomBootstrapData _Data_k__BackingField; // 0x00
	private static float _lastFetch; // 0x08
	private static int _cachedPetId; // 0x0C
	private static string _cachedMode; // 0x10
	private const float TTL_SECONDS = 300f; // Metadata: 0x0068CF4A
	private const int REQUEST_TIMEOUT_SECONDS = 20; // Metadata: 0x0068CF4E
	private static float _lastFailTime; // 0x18
	private const float NEG_CACHE_SECONDS = 60f; // Metadata: 0x0068CF4F

	// Properties
	public static RoomBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B51D0-0x00000001805B5220 0x00000001805B5260-0x00000001805B52D0
	public static bool UseWsBootstrap { get; set; } // 0x00000001805B5220-0x00000001805B5260 0x00000001805B52D0-0x00000001805B5320

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1375
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public RoomBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadViaWs_b__0(RoomBootstrapData data); // 0x00000001805BDFF0-0x00000001805BE070
		internal void _LoadViaWs_b__1(string reason); // 0x00000001805BE070-0x00000001805BE090
	}

	[CompilerGenerated]
	private sealed class _Load_d__17 : IEnumerator<object> // TypeDefIndex: 1376
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BADC0-0x00000001805BAEB0
		private bool MoveNext(); // 0x00000001805B9CF0-0x00000001805BAD80
		private void __m__Finally1(); // 0x00000001805BAEB0-0x00000001805BAF00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BAD80-0x00000001805BADC0
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__19 : IEnumerator<object> // TypeDefIndex: 1377
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BB8E0-0x00000001805BB930
		private bool MoveNext(); // 0x00000001805BB1D0-0x00000001805BB8A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BB8A0-0x00000001805BB8E0
	}

	// Constructors
	static RoomCache(); // 0x00000001805B5120-0x00000001805B51D0

	// Methods
	public static bool IsFresh(int petId, string mode); // 0x00000001805B4EB0-0x00000001805B4FA0
	public static void Invalidate(); // 0x00000001805B4E50-0x00000001805B4EB0
	public static void Clear(); // 0x00000001805B4C80-0x00000001805B4D90
	[IteratorStateMachine(typeof(_Load_d__17))]
	public static IEnumerator Load(int petId, string mode, Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x0068CF49 */); // 0x00000001805B5060-0x00000001805B5120
	private static string Esc(string s); // 0x00000001805B4D90-0x00000001805B4E50
	[IteratorStateMachine(typeof(_LoadViaWs_d__19))]
	private static IEnumerator LoadViaWs(int petId, string mode, Action onSuccess, Action<string> onError); // 0x00000001805B4FA0-0x00000001805B5060
}

