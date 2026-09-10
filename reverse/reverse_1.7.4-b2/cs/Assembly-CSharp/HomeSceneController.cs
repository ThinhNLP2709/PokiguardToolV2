/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class HomeSceneController : MonoBehaviour // TypeDefIndex: 814
{
	// Fields
	private const float BADGE_POLL_SEC = 60f; // Metadata: 0x0068BCA6
	private const float FOCUS_REFRESH_MIN_GAP = 30f; // Metadata: 0x0068BCAA
	private const int NEWBIE_LEVEL = 5; // Metadata: 0x0068BCAE
	[CompilerGenerated]
	private static int _UserLevel_k__BackingField; // 0x00
	[Header("C\u1EA5u h\u00ECnh")]
	public HomeModuleConfig config; // 0x20
	[Header("Tham chi\u1EBFu trong scene")]
	[Tooltip("Thanh t\u00E0i nguy\u00EAn tr\u00EAn c\u00F9ng. V2 \'faithful\' KH\u00D4NG d\u1EF1ng thanh n\u00E0y (TopUI c\u1EE7a b\u1EA3n g\u1ED1c r\u1ED7ng, n\u1ED9i dung n\u1EB1m \u1EDF bundle kh\u00F4ng c\u00F3 trong APK) \u21D2 \u0111\u1EC3 tr\u1ED1ng l\u00E0 b\u00ECnh th\u01B0\u1EDDng.")]
	public HomeTopBar topBar; // 0x28
	[Tooltip("\u00D4 \u0111\u1EA1i di\u1EC7n g\u00F3c tr\u00E1i tr\u00EAn (node UserAvatar c\u1EE7a b\u1EA3n g\u1ED1c).")]
	public HomeAvatarView avatar; // 0x30
	public HomeAudio audioController; // 0x38
	public HomeFeatureRouter router; // 0x40
	public HomeHorizontalScroller scroller; // 0x48
	public HomeEventStrip eventStrip; // 0x50
	public HomeHandFocus handFocus; // 0x58
	[Tooltip("Node cha c\u1EE7a c\u00E1c to\u00E0 nh\u00E0 \u2014 d\u00F9ng cho hi\u1EC7u \u1EE9ng pop-in so le.")]
	public RectTransform buildingsRoot; // 0x60
	[Tooltip("\u1EA2nh n\u1EC1n \u2014 fade v\u00E0o l\u00FAc m\u1EDF m\u00E0n.")]
	public CanvasGroup backgroundGroup; // 0x68
	private readonly List<HomeModuleView> _views; // 0x70
	private Coroutine _badgeLoop; // 0x78
	private float _lastFocusRefresh; // 0x80
	private bool _userLoaded; // 0x84

	// Properties
	public static int UserLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180498FE0-0x0000000180499020 0x0000000180499020-0x0000000180499060

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 815
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__26_1; // 0x08
		public static Action<string> __9__29_1; // 0x10
		public static Action<string> __9__29_3; // 0x18

		// Constructors
		static __c(); // 0x00000001804AFC40-0x00000001804AFCB0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadUserRoutine_b__26_1(string err); // 0x00000001804AFBD0-0x00000001804AFC40
		internal void _RefreshBadges_b__29_1(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
		internal void _RefreshBadges_b__29_3(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 816
	{
		// Fields
		public UserDTO user; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadUserRoutine_b__0(UserDTO u); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 817
	{
		// Fields
		public GiftCountResponse resp; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshBadges_b__0(GiftCountResponse r); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_1 // TypeDefIndex: 818
	{
		// Fields
		public ManagerThongBao.ThongBaoResponse data; // 0x10

		// Constructors
		public __c__DisplayClass29_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshBadges_b__2(ManagerThongBao.ThongBaoResponse r); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class _BadgePollLoop_d__28 : IEnumerator<object> // TypeDefIndex: 819
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeSceneController __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BadgePollLoop_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001804A9C10-0x00000001804A9D60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A9D60-0x00000001804A9DA0
	}

	[CompilerGenerated]
	private sealed class _LoadUserRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 820
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass26_0 __8__1; // 0x20
		public HomeSceneController __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserRoutine_d__26(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
		private bool MoveNext(); // 0x00000001804ADA70-0x00000001804AE120
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AE120-0x00000001804AE160
	}

	[CompilerGenerated]
	private sealed class _RefreshBadges_d__29 : IEnumerator<object> // TypeDefIndex: 821
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeSceneController __4__this; // 0x20
		private __c__DisplayClass29_0 __8__1; // 0x28
		private __c__DisplayClass29_1 __8__2; // 0x30
		private int _userId_5__2; // 0x38
		private bool _needNotice_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshBadges_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x00000001804AF5E0-0x00000001804AFB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AFB90-0x00000001804AFBD0
	}

	// Constructors
	public HomeSceneController(); // 0x0000000180498F50-0x0000000180498FE0

	// Methods
	private void Awake(); // 0x0000000180498100-0x00000001804981B0
	private void Start(); // 0x0000000180498DF0-0x0000000180498F50
	private void OnDestroy(); // 0x0000000180498820-0x00000001804988E0
	private void OnApplicationFocus(bool focus); // 0x00000001804987C0-0x0000000180498820
	private void CollectViews(); // 0x0000000180498220-0x0000000180498290
	[IteratorStateMachine(typeof(_LoadUserRoutine_d__26))]
	private IEnumerator LoadUserRoutine(); // 0x00000001804984B0-0x0000000180498520
	private void ApplyLevelToAll(); // 0x0000000180498000-0x0000000180498100
	[IteratorStateMachine(typeof(_BadgePollLoop_d__28))]
	private IEnumerator BadgePollLoop(); // 0x00000001804981B0-0x0000000180498220
	[IteratorStateMachine(typeof(_RefreshBadges_d__29))]
	private IEnumerator RefreshBadges(); // 0x0000000180498C60-0x0000000180498CD0
	private bool HasSource(HomeNotifySource src); // 0x00000001804983B0-0x00000001804984B0
	private void SetBadge(HomeNotifySource src, int count); // 0x0000000180498CD0-0x0000000180498DF0
	private void PlayEnterAnimation(); // 0x00000001804988E0-0x0000000180498C60
	private void MaybeShowHand(); // 0x0000000180498520-0x00000001804987C0
	public HomeModuleView FindView(string moduleId); // 0x0000000180498290-0x00000001804983B0
}

