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

public static class HubCache // TypeDefIndex: 1753
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
	public static HubBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808D0E40-0x00000001808D0EA0 0x00000001808D0EA0-0x00000001808D0F50
	public static bool HasBadges { get; } // 0x00000001808D12A0-0x00000001808D1380 
	public static bool IsFresh { get; } // 0x00000001808D1500-0x00000001808D1600 
	public static bool LoadPending { get; } // 0x00000001808D1660-0x00000001808D16C0 
	public static bool UseWsBootstrap { get; } // 0x00000001808D1780-0x00000001808D17D0 

	// Events
	public static event Action OnLoaded {
		add; // 0x00000001808D0F50-0x00000001808D1080
		remove; // 0x00000001808D1080-0x00000001808D11B0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1754
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public HubBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadViaWs_b__0(HubBootstrapData data); // 0x00000001808D1C40-0x00000001808D1D60
		internal void _LoadViaWs_b__1(string reason); // 0x00000001808D1D60-0x00000001808D1DC0
	}

	[CompilerGenerated]
	private sealed class _Load_d__28 : IEnumerator<object> // TypeDefIndex: 1755
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
		void IDisposable.Dispose(); // 0x00000001808D1DC0-0x00000001808D1EB0
		private bool MoveNext(); // 0x00000001808D1EB0-0x00000001808D2140
		private void __m__Finally1(); // 0x00000001808D2140-0x00000001808D21B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D21B0-0x00000001808D21F0
	}

	[CompilerGenerated]
	private sealed class _LoadCore_d__29 : IEnumerator<object> // TypeDefIndex: 1756
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
		void IDisposable.Dispose(); // 0x00000001808D21F0-0x00000001808D2320
		private bool MoveNext(); // 0x00000001808D2320-0x00000001808D3360
		private void __m__Finally1(); // 0x00000001808D3360-0x00000001808D33C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D33C0-0x00000001808D3400
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__31 : IEnumerator<object> // TypeDefIndex: 1757
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
		void IDisposable.Dispose(); // 0x00000001808D3400-0x00000001808D3510
		private bool MoveNext(); // 0x00000001808D3510-0x00000001808D4360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D4360-0x00000001808D43A0
	}

	// Constructors
	static HubCache(); // 0x00000001808D1BE0-0x00000001808D1C40

	// Methods
	private static void RaiseLoaded(); // 0x00000001808D11B0-0x00000001808D12A0
	public static bool TryGetBadges(out HubBadgesData badges); // 0x00000001808D1380-0x00000001808D1500
	public static void ExpectLoad(bool expect); // 0x00000001808D1600-0x00000001808D1660
	public static void Invalidate(); // 0x00000001808D16C0-0x00000001808D1720
	public static void Clear(); // 0x00000001808D1720-0x00000001808D1780
	[IteratorStateMachine(typeof(_Load_d__28))]
	public static IEnumerator Load(Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x005F1549 */); // 0x00000001808D17D0-0x00000001808D18E0
	[IteratorStateMachine(typeof(_LoadCore_d__29))]
	private static IEnumerator LoadCore(Action onSuccess, Action<string> onError, bool force); // 0x00000001808D18E0-0x00000001808D19F0
	private static string Esc(string s); // 0x00000001808D19F0-0x00000001808D1AD0
	[IteratorStateMachine(typeof(_LoadViaWs_d__31))]
	private static IEnumerator LoadViaWs(Action onSuccess, Action<string> onError); // 0x00000001808D1AD0-0x00000001808D1BE0
}

