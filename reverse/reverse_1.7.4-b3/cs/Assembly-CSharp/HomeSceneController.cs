/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class HomeSceneController : MonoBehaviour // TypeDefIndex: 981
{
	// Fields
	private const float BADGE_POLL_SEC = 60f; // Metadata: 0x005EF1CC
	private const float FOCUS_REFRESH_MIN_GAP = 30f; // Metadata: 0x005EF1D0
	private const int NEWBIE_LEVEL = 5; // Metadata: 0x005EF1D4
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
	public static int UserLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805EC6A0-0x00000001805EC6E0 0x00000001805EC6E0-0x00000001805EC730

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 982
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__26_1; // 0x08
		public static Action<string> __9__29_1; // 0x10
		public static Action<string> __9__29_3; // 0x18

		// Constructors
		static __c(); // 0x00000001805EE0A0-0x00000001805EE140
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadUserRoutine_b__26_1(string err); // 0x00000001805EE140-0x00000001805EE1C0
		internal void _RefreshBadges_b__29_1(string err); // 0x000000018028A320-0x000000018028A330
		internal void _RefreshBadges_b__29_3(string err); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 983
	{
		// Fields
		public UserDTO user; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadUserRoutine_b__0(UserDTO u); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 984
	{
		// Fields
		public GiftCountResponse resp; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshBadges_b__0(GiftCountResponse r); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_1 // TypeDefIndex: 985
	{
		// Fields
		public ManagerThongBao.ThongBaoResponse data; // 0x10

		// Constructors
		public __c__DisplayClass29_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshBadges_b__2(ManagerThongBao.ThongBaoResponse r); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class _BadgePollLoop_d__28 : IEnumerator<object> // TypeDefIndex: 986
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeSceneController __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BadgePollLoop_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001805EE1C0-0x00000001805EE420
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EE420-0x00000001805EE460
	}

	[CompilerGenerated]
	private sealed class _LoadUserRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 987
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass26_0 __8__1; // 0x20
		public HomeSceneController __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserRoutine_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EE460-0x00000001805EE4D0
		private bool MoveNext(); // 0x00000001805EE4D0-0x00000001805EEA50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EEA50-0x00000001805EEA90
	}

	[CompilerGenerated]
	private sealed class _RefreshBadges_d__29 : IEnumerator<object> // TypeDefIndex: 988
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshBadges_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
		private bool MoveNext(); // 0x00000001805EEB50-0x00000001805EF2D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EF2D0-0x00000001805EF310
	}

	// Constructors
	public HomeSceneController(); // 0x00000001805EDFA0-0x00000001805EE0A0

	// Methods
	private void Awake(); // 0x00000001805EC730-0x00000001805EC7F0
	private void Start(); // 0x00000001805EC7F0-0x00000001805ECA10
	private void OnDestroy(); // 0x00000001805ECA10-0x00000001805ECA50
	private void OnApplicationFocus(bool focus); // 0x00000001805ECA50-0x00000001805ECAF0
	private void CollectViews(); // 0x00000001805ECAF0-0x00000001805ECB70
	[IteratorStateMachine(typeof(_LoadUserRoutine_d__26))]
	private IEnumerator LoadUserRoutine(); // 0x00000001805ECB70-0x00000001805ECC10
	private void ApplyLevelToAll(); // 0x00000001805ECC10-0x00000001805ECDB0
	[IteratorStateMachine(typeof(_BadgePollLoop_d__28))]
	private IEnumerator BadgePollLoop(); // 0x00000001805ECDB0-0x00000001805ECE50
	[IteratorStateMachine(typeof(_RefreshBadges_d__29))]
	private IEnumerator RefreshBadges(); // 0x00000001805ECE50-0x00000001805ECEF0
	private bool HasSource(HomeNotifySource src); // 0x00000001805ECEF0-0x00000001805ED090
	private void SetBadge(HomeNotifySource src, int count); // 0x00000001805ED090-0x00000001805ED250
	private void PlayEnterAnimation(); // 0x00000001805ED250-0x00000001805ED9F0
	private void MaybeShowHand(); // 0x00000001805ED9F0-0x00000001805EDDC0
	public HomeModuleView FindView(string moduleId); // 0x00000001805EDDC0-0x00000001805EDFA0
}

