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

public static class RoomCache // TypeDefIndex: 1758
{
	// Fields
	[CompilerGenerated]
	private static RoomBootstrapData _Data_k__BackingField; // 0x00
	private static float _lastFetch; // 0x08
	private static int _cachedPetId; // 0x0C
	private static string _cachedMode; // 0x10
	private static float _lastFailTime; // 0x18

	// Properties
	public static RoomBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808D43A0-0x00000001808D4400 0x00000001808D4400-0x00000001808D44B0
	public static bool UseWsBootstrap { get; } // 0x00000001808D4730-0x00000001808D4780 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1759
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public RoomBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadViaWs_b__0(RoomBootstrapData data); // 0x00000001808D4C50-0x00000001808D4D70
		internal void _LoadViaWs_b__1(string reason); // 0x00000001808D1D60-0x00000001808D1DC0
	}

	[CompilerGenerated]
	private sealed class _Load_d__17 : IEnumerator<object> // TypeDefIndex: 1760
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808D4D70-0x00000001808D4F20
		private bool MoveNext(); // 0x00000001808D4F20-0x00000001808D6270
		private void __m__Finally1(); // 0x00000001808D6270-0x00000001808D62D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D62D0-0x00000001808D6310
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__19 : IEnumerator<object> // TypeDefIndex: 1761
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808D6310-0x00000001808D6420
		private bool MoveNext(); // 0x00000001808D6420-0x00000001808D6E60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D6E60-0x00000001808D6EA0
	}

	// Constructors
	static RoomCache(); // 0x00000001808D4B60-0x00000001808D4C50

	// Methods
	public static bool IsFresh(int petId, string mode); // 0x00000001808D44B0-0x00000001808D45D0
	public static void Invalidate(); // 0x00000001808D45D0-0x00000001808D4630
	public static void Clear(); // 0x00000001808D4630-0x00000001808D4730
	[IteratorStateMachine(typeof(_Load_d__17))]
	public static IEnumerator Load(int petId, string mode, Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x005F154A */); // 0x00000001808D4780-0x00000001808D4900
	private static string Esc(string s); // 0x00000001808D4900-0x00000001808D49E0
	[IteratorStateMachine(typeof(_LoadViaWs_d__19))]
	private static IEnumerator LoadViaWs(int petId, string mode, Action onSuccess, Action<string> onError); // 0x00000001808D49E0-0x00000001808D4B60
}

