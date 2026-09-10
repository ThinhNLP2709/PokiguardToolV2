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

public static class HubCache // TypeDefIndex: 1369
{
	// Fields
	[CompilerGenerated]
	private static HubBootstrapData _Data_k__BackingField; // 0x00
	[CompilerGenerated]
	private static Action OnLoaded; // 0x08
	private static float _lastFetch; // 0x10
	private const float TTL_SECONDS = 60f; // Metadata: 0x0068CF40
	private const int REQUEST_TIMEOUT_SECONDS = 20; // Metadata: 0x0068CF44
	private static float _lastFailTime; // 0x14
	private const float NEG_CACHE_SECONDS = 60f; // Metadata: 0x0068CF45
	private static bool _expectLoad; // 0x18
	private static bool _loading; // 0x19

	// Properties
	public static HubBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805ABA00-0x00000001805ABA50 0x00000001805ABDD0-0x00000001805ABE40
	public static bool HasBadges { get; } // 0x00000001805ABA50-0x00000001805ABBA0 
	public static bool IsFresh { get; } // 0x00000001805ABBA0-0x00000001805ABC60 
	public static bool LoadPending { get; } // 0x00000001805ABC60-0x00000001805ABCC0 
	public static bool UseWsBootstrap { get; set; } // 0x00000001805ABCC0-0x00000001805ABD00 0x00000001805ABE40-0x00000001805ABE90

	// Events
	public static event Action OnLoaded {
		add; // 0x00000001805AB930-0x00000001805ABA00
		remove; // 0x00000001805ABD00-0x00000001805ABDD0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1370
	{
		// Fields
		public bool done; // 0x10
		public bool success; // 0x11
		public HubBootstrapData responseData; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadViaWs_b__0(HubBootstrapData data); // 0x00000001805BE280-0x00000001805BE300
		internal void _LoadViaWs_b__1(string reason); // 0x00000001805BE070-0x00000001805BE090
	}

	[CompilerGenerated]
	private sealed class _Load_d__28 : IEnumerator<object> // TypeDefIndex: 1371
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action onSuccess; // 0x20
		public Action<string> onError; // 0x28
		public bool force; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Load_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BB0F0-0x00000001805BB170
		private bool MoveNext(); // 0x00000001805BAF00-0x00000001805BB0B0
		private void __m__Finally1(); // 0x00000001805BB170-0x00000001805BB1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BB0B0-0x00000001805BB0F0
	}

	[CompilerGenerated]
	private sealed class _LoadCore_d__29 : IEnumerator<object> // TypeDefIndex: 1372
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public bool force; // 0x28
		public Action onSuccess; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadCore_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B94B0-0x00000001805B9590
		private bool MoveNext(); // 0x00000001805B8760-0x00000001805B9470
		private void __m__Finally1(); // 0x00000001805B9590-0x00000001805B95E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B9470-0x00000001805B94B0
	}

	[CompilerGenerated]
	private sealed class _LoadViaWs_d__31 : IEnumerator<object> // TypeDefIndex: 1373
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadViaWs_d__31(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BBE70-0x00000001805BBEC0
		private bool MoveNext(); // 0x00000001805BB930-0x00000001805BBE30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BBE30-0x00000001805BBE70
	}

	// Constructors
	static HubCache(); // 0x00000001805AB8E0-0x00000001805AB930

	// Methods
	private static void RaiseLoaded(); // 0x00000001805AB610-0x00000001805AB6F0
	public static bool TryGetBadges(out HubBadgesData badges); // 0x00000001805AB6F0-0x00000001805AB8E0
	public static void ExpectLoad(bool expect); // 0x00000001805AB380-0x00000001805AB3E0
	public static void Invalidate(); // 0x00000001805AB3E0-0x00000001805AB440
	public static void Clear(); // 0x00000001805AB200-0x00000001805AB2C0
	[IteratorStateMachine(typeof(_Load_d__28))]
	public static IEnumerator Load(Action onSuccess = null, Action<string> onError = null, bool force = false /* Metadata: 0x0068CF3F */); // 0x00000001805AB570-0x00000001805AB610
	[IteratorStateMachine(typeof(_LoadCore_d__29))]
	private static IEnumerator LoadCore(Action onSuccess, Action<string> onError, bool force); // 0x00000001805AB440-0x00000001805AB4E0
	private static string Esc(string s); // 0x00000001805AB2C0-0x00000001805AB380
	[IteratorStateMachine(typeof(_LoadViaWs_d__31))]
	private static IEnumerator LoadViaWs(Action onSuccess, Action<string> onError); // 0x00000001805AB4E0-0x00000001805AB570
}

