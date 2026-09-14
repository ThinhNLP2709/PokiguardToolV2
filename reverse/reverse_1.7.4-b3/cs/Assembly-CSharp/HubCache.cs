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

public static class HubCache // TypeDefIndex: 1751
{
	// Fields
	[CompilerGenerated]
	private static HubBootstrapData _Data_k__BackingField; // 0x00
	[CompilerGenerated]
	private static Action OnLoaded; // 0x08
	private static float _lastFetch; // 0x10
	private static float _lastFailTime; // 0x14
	private static bool _expectLoad; // 0x18
	private static bool _loading; // 0x19

	// Properties
	public static HubBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808CDF40-0x00000001808CDFA0 0x00000001808CDFA0-0x00000001808CE050
	public static bool HasBadges { get; } // 0x00000001808CE3A0-0x00000001808CE480 
	public static bool IsFresh { get; } // 0x00000001808CE600-0x00000001808CE700 
	public static bool LoadPending { get; } // 0x00000001808CE760-0x00000001808CE7C0 
	public static bool UseWsBootstrap { get; } // 0x00000001808CE880-0x00000001808CE8D0 

	// Events
	public static event Action OnLoaded {
		add; // 0x00000001808CE050-0x00000001808CE180
		remove; // 0x00000001808CE180-0x00000001808CE2B0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1752
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public HubBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadViaWs_b__0(HubBootstrapData data); // 0x00000001808CED40-0x00000001808CEE60
		internal void _LoadViaWs_b__1(string reason); // 0x00000001808CEE60-0x00000001808CEEC0
	}

	[CompilerGenerated]
	private sealed class _Load_d__28 : IEnumerator<object> // TypeDefIndex: 1753
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action onSuccess; // 0x20
		public Action<string> onError; // 0x28
		public bool force; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808CEEC0-0x00000001808CEFB0
		private bool MoveNext(); // 0x00000001808CEFB0-0x00000001808CF240
		private void __m__Finally1(); // 0x00000001808CF240-0x00000001808CF2B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CF2B0-0x00000001808CF2F0
	}

	[CompilerGenerated]
	private sealed class _LoadCore_d__29 : IEnumerator<object> // TypeDefIndex: 1754
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public bool force; // 0x28
		public Action onSuccess; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadCore_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808CF2F0-0x00000001808CF420
		private bool MoveNext(); // 0x00000001808CF420-0x00000001808D0460
		private void __m__Finally1(); // 0x00000001808D0460-0x00000001808D04C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D04C0-0x00000001808D0500
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__31 : IEnumerator<object> // TypeDefIndex: 1755
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass31_0 __8__1; // 0x20
		public Action<string> onError; // 0x28
		public Action onSuccess; // 0x30
		private Action<HubBootstrapData> _onResp_5__2; // 0x38
		private Action<string> _onFail_5__3; // 0x40
		private float _deadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__31(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808D0500-0x00000001808D0610
		private bool MoveNext(); // 0x00000001808D0610-0x00000001808D1460
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D1460-0x00000001808D14A0
	}

	// Constructors
	static HubCache(); // 0x00000001808CECE0-0x00000001808CED40

	// Methods
	private static void RaiseLoaded(); // 0x00000001808CE2B0-0x00000001808CE3A0
	public static bool TryGetBadges(out HubBadgesData badges); // 0x00000001808CE480-0x00000001808CE600
	public static void ExpectLoad(bool expect); // 0x00000001808CE700-0x00000001808CE760
	public static void Invalidate(); // 0x00000001808CE7C0-0x00000001808CE820
	public static void Clear(); // 0x00000001808CE820-0x00000001808CE880
	[IteratorStateMachine(typeof(_Load_d__28))]
	public static IEnumerator Load(Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x005F0178 */); // 0x00000001808CE8D0-0x00000001808CE9E0
	[IteratorStateMachine(typeof(_LoadCore_d__29))]
	private static IEnumerator LoadCore(Action onSuccess, Action<string> onError, bool force); // 0x00000001808CE9E0-0x00000001808CEAF0
	private static string Esc(string s); // 0x00000001808CEAF0-0x00000001808CEBD0
	[IteratorStateMachine(typeof(_LoadViaWs_d__31))]
	private static IEnumerator LoadViaWs(Action onSuccess, Action<string> onError); // 0x00000001808CEBD0-0x00000001808CECE0
}

