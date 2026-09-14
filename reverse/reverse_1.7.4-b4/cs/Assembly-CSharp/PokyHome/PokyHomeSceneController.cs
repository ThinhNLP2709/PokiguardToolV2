/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeSceneController : MonoBehaviour // TypeDefIndex: 2662
	{
		// Fields
		private const float BADGE_POLL_SEC = 60f; // Metadata: 0x005F2713
		private const float USER_CACHE_SEC = 60f; // Metadata: 0x005F2717
		private const float FOCUS_REFRESH_MIN_GAP = 30f; // Metadata: 0x005F271B
		[CompilerGenerated]
		private static int _UserLevel_k__BackingField; // 0x00
		private static UserDTO _cachedUser; // 0x08
		private static float _cachedAt; // 0x10
		[Header("C\u1EA5u h\u00ECnh")]
		public PokyHomeModuleConfig config; // 0x20
		[Header("Tham chi\u1EBFu trong scene")]
		public PokyHomeLockState lockState; // 0x28
		public PokyHomeFeatureRouter router; // 0x30
		public PokyHomeNextModule nextModule; // 0x38
		public PokyHomeInfoUserBar infoBar; // 0x40
		public PokyHomeAvatar avatar; // 0x48
		public PokyHomeGiftTime giftTime; // 0x50
		public PokyHomeEventStrip eventStrip; // 0x58
		public PokyHomeIdleRecommend idleRecommend; // 0x60
		public PokyHomeLastChat lastChat; // 0x68
		public HomeAudio audioController; // 0x70
		public HomeHorizontalScroller scroller; // 0x78
		[Tooltip("C\u00E1c nh\u00F3m UI (Bottom / LeftUI / RightUI) \u2014 pop-in nh\u1EB9 l\u00FAc v\u00E0o m\u00E0n. \u26A0 KH\u00D4NG \u0111\u01B0a Canvas g\u1ED1c v\u00E0o \u0111\u00E2y: localScale c\u1EE7a n\u00F3 do CanvasScaler l\u00E1i, tween v\u00E0o l\u00E0 gi\u00E0nh nhau v\u00E0 UI nh\u1EA3y c\u1EE1.")]
		public RectTransform[] uiGroups; // 0x80
		private Coroutine _badgeLoop; // 0x88
		private float _lastFocusRefresh; // 0x90
		private bool _userLoaded; // 0x94
	
		// Properties
		public static int UserLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C386A0-0x0000000180C38700 0x0000000180C38700-0x0000000180C38760
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2663
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__29_1; // 0x08
			public static Action<string> __9__33_1; // 0x10
			public static Action<string> __9__33_3; // 0x18
	
			// Constructors
			static __c(); // 0x0000000180C39870-0x0000000180C39910
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadUserRoutine_b__29_1(string err); // 0x0000000180C39910-0x0000000180C39990
			internal void _RefreshBadges_b__33_1(string err); // 0x000000018028A320-0x000000018028A330
			internal void _RefreshBadges_b__33_3(string err); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 2664
		{
			// Fields
			public UserDTO user; // 0x10
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadUserRoutine_b__0(UserDTO u); // 0x00000001802D8AB0-0x00000001802D8B10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass33_0 // TypeDefIndex: 2665
		{
			// Fields
			public GiftCountResponse resp; // 0x10
	
			// Constructors
			public __c__DisplayClass33_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _RefreshBadges_b__0(GiftCountResponse r); // 0x00000001802D8AB0-0x00000001802D8B10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass33_1 // TypeDefIndex: 2666
		{
			// Fields
			public ManagerThongBao.ThongBaoResponse data; // 0x10
	
			// Constructors
			public __c__DisplayClass33_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _RefreshBadges_b__2(ManagerThongBao.ThongBaoResponse r); // 0x00000001802D8AB0-0x00000001802D8B10
		}
	
		[CompilerGenerated]
		private sealed class _BadgePollLoop_d__32 : IEnumerator<object> // TypeDefIndex: 2667
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHomeSceneController __4__this; // 0x20
			private WaitForSecondsRealtime _wait_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _BadgePollLoop_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180C39990-0x0000000180C39BF0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C39BF0-0x0000000180C39C30
		}
	
		[CompilerGenerated]
		private sealed class _LoadUserRoutine_d__29 : IEnumerator<object> // TypeDefIndex: 2668
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			private __c__DisplayClass29_0 __8__1; // 0x20
			public PokyHomeSceneController __4__this; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadUserRoutine_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
			private bool MoveNext(); // 0x0000000180C39C30-0x0000000180C3A8E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C3A8E0-0x0000000180C3A920
		}
	
		[CompilerGenerated]
		private sealed class _RefreshBadges_d__33 : IEnumerator<object> // TypeDefIndex: 2669
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyHomeSceneController __4__this; // 0x20
			private __c__DisplayClass33_0 __8__1; // 0x28
			private __c__DisplayClass33_1 __8__2; // 0x30
			private int _userId_5__2; // 0x38
			private bool _needNotice_5__3; // 0x3C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _RefreshBadges_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
			private bool MoveNext(); // 0x0000000180C3A920-0x0000000180C3B4F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C3B4F0-0x0000000180C3B530
		}
	
		// Constructors
		public PokyHomeSceneController(); // 0x0000000180C397D0-0x0000000180C39820
		static PokyHomeSceneController(); // 0x0000000180C39820-0x0000000180C39870
	
		// Methods
		private void Awake(); // 0x0000000180C38760-0x0000000180C388E0
		private void Start(); // 0x0000000180C388E0-0x0000000180C38B30
		private void OnDestroy(); // 0x0000000180C38B30-0x0000000180C38C10
		private void OnApplicationFocus(bool focus); // 0x0000000180C38C10-0x0000000180C38CB0
		[IteratorStateMachine(typeof(_LoadUserRoutine_d__29))]
		private IEnumerator LoadUserRoutine(); // 0x0000000180C38CB0-0x0000000180C38D50
		private void ApplyUser(UserDTO user); // 0x0000000180C38D50-0x0000000180C39070
		public void DebugSetLevel(int level); // 0x0000000180C39070-0x0000000180C39270
		[IteratorStateMachine(typeof(_BadgePollLoop_d__32))]
		private IEnumerator BadgePollLoop(); // 0x0000000180C39270-0x0000000180C39310
		[IteratorStateMachine(typeof(_RefreshBadges_d__33))]
		private IEnumerator RefreshBadges(); // 0x0000000180C39310-0x0000000180C393B0
		private void PlayEnterAnimation(); // 0x0000000180C393B0-0x0000000180C397D0
	}
}
