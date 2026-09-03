/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class TowerPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 783
{
	// Fields
	public const string PANEL_KEY = "PanelTower"; // Metadata: 0x0064C910
	public const string PREF_JUST_CLEARED = "TowerJustCleared"; // Metadata: 0x0064C91B
	private const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x0064C92C
	public const int FLOOR_SLOTS = 5; // Metadata: 0x0064C932
	public const int FLOOR_ANIM_MAX = 5; // Metadata: 0x0064C933
	private const float FLOOR_ANIM_STAGGER = 0.08f; // Metadata: 0x0064C934
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x30
	[SerializeField]
	private RawImage bgTower; // 0x38
	[Header("\u1EA2i hi\u1EC7n t\u1EA1i")]
	[SerializeField]
	private GameObject floorBox; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtFloor; // 0x48
	[SerializeField]
	private GameObject maxFloor; // 0x50
	[Header("Boss t\u1EA7ng")]
	[SerializeField]
	private RectTransform bossAnchor; // 0x58
	[SerializeField]
	private Animator bossAnimator; // 0x60
	[SerializeField]
	private Image bossImage; // 0x68
	[SerializeField]
	private Image glowFloor; // 0x70
	[Header("Kh\u1ED1i qu\u00E0")]
	[SerializeField]
	private GameObject rewardOne; // 0x78
	[SerializeField]
	private Transform rewardOneContainer; // 0x80
	[SerializeField]
	private GameObject rewardTwo; // 0x88
	[SerializeField]
	private Transform rewardTwoVictory; // 0x90
	[SerializeField]
	private Transform rewardTwoPass; // 0x98
	[SerializeField]
	private GameObject receivedSpecial; // 0xA0
	[Header("B\u1EAFt \u0111\u1EA7u")]
	[SerializeField]
	private Button btnStart; // 0xA8
	[SerializeField]
	private UnityEngine.UI.Text txtStart; // 0xB0
	[SerializeField]
	private GameObject decoStart; // 0xB8
	[Header("M\u1ED1c r\u01B0\u01A1ng (c\u1ED9t tr\u00E1i)")]
	[SerializeField]
	private GameObject infoFloor; // 0xC0
	[SerializeField]
	private TowerFloorItem[] floorItems; // 0xC8
	[SerializeField]
	private Button maskGiftFloor; // 0xD0
	[SerializeField]
	private GameObject rewardFloor; // 0xD8
	[SerializeField]
	private Transform rewardFloorContainer; // 0xE0
	[Header("L\u00E0m m\u1EDBi m\u00F9a")]
	[SerializeField]
	private GameObject infoReset; // 0xE8
	[SerializeField]
	private UnityEngine.UI.Text txtResetTime; // 0xF0
	[SerializeField]
	private TowerResetPopup resetPopup; // 0xF8
	[Header("N\u0103ng l\u01B0\u1EE3ng th\u00E1p")]
	[SerializeField]
	private GameObject powerBox; // 0x100
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x108
	[SerializeField]
	private UnityEngine.UI.Text txtNextPower; // 0x110
	[SerializeField]
	private Button btnBuyPower; // 0x118
	[Header("B\u1EA3ng x\u1EBFp h\u1EA1ng")]
	[SerializeField]
	private Button btnTop; // 0x120
	[SerializeField]
	private GameObject topLayout; // 0x128
	[SerializeField]
	private RectTransform topMain; // 0x130
	[SerializeField]
	private Button topMask; // 0x138
	[SerializeField]
	private ScrollRect topScroll; // 0x140
	[SerializeField]
	private RectTransform topContent; // 0x148
	[SerializeField]
	private UnityEngine.UI.Text txtTopTitle; // 0x150
	[SerializeField]
	private GameObject topItemPrefab; // 0x158
	[Header("H\u1ED9p x\u00E1c nh\u1EADn (C\u00F3 / Hu\u1EF7)")]
	[SerializeField]
	private GameObject confirmDim; // 0x160
	[SerializeField]
	private UnityEngine.UI.Text txtConfirm; // 0x168
	[SerializeField]
	private Button btnConfirmYes; // 0x170
	[SerializeField]
	private Button btnConfirmNo; // 0x178
	private readonly List<TowerTopItem> _topPool; // 0x180
	private readonly List<int> _tweens; // 0x188
	private TowerInfoData _info; // 0x190
	private int _userId; // 0x198
	private bool _wired; // 0x19C
	private bool _busy; // 0x19D
	private bool _topOpen; // 0x19E
	private int _bossPetShown; // 0x1A0
	private CanvasGroup _frameGroup; // 0x1A8
	private Coroutine _resetTimerCo; // 0x1B0
	private Coroutine _powerTimerCo; // 0x1B8
	private Coroutine _topFillCo; // 0x1C0
	private Action _confirmYes; // 0x1C8
	private Coroutine _floorAnimCo; // 0x1D0

	// Properties
	public bool IsBusy { get; } // 0x0000000180408700-0x0000000180408710 
	private static bool Live { get; } // 0x0000000180408710-0x0000000180408750 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 784
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass103_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnClickTop_b__0(float y); // 0x0000000180439750-0x0000000180439800
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass104_0 // TypeDefIndex: 785
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass104_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CloseTop_b__0(float y); // 0x0000000180439800-0x00000001804398B0
		internal void _CloseTop_b__1(); // 0x00000001804398B0-0x0000000180439950
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass106_0 // TypeDefIndex: 786
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public TowerResetPackage pkg; // 0x18

		// Constructors
		public __c__DisplayClass106_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnClaimResetPackage_b__0(); // 0x0000000180439950-0x0000000180439990
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass116_0 // TypeDefIndex: 787
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18
		public bool started; // 0x20
		public bool startFailed; // 0x21
		public string startReason; // 0x28

		// Constructors
		public __c__DisplayClass116_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _StartTowerBattle_b__0(); // 0x000000018030F220-0x000000018030F230
		internal void _StartTowerBattle_b__1(string r); // 0x0000000180439990-0x00000001804399B0
		internal void _StartTowerBattle_b__2(ChatMessageDTO _); // 0x00000001804399B0-0x00000001804399C0
		internal void _StartTowerBattle_b__3(ChatMessageDTO m); // 0x00000001804399C0-0x00000001804399F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass123_0 // TypeDefIndex: 788
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass123_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayOpenFx_b__0(float y); // 0x00000001804399F0-0x0000000180439A80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass124_0 // TypeDefIndex: 789
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass124_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayFloorListFx_b__0(float x); // 0x0000000180439A80-0x0000000180439B10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass127_0 // TypeDefIndex: 790
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass127_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayFloorClearedFx_b__0(float a); // 0x0000000180439B10-0x0000000180439C00
		internal void _PlayFloorClearedFx_b__1(); // 0x0000000180439C00-0x0000000180439C90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass128_0 // TypeDefIndex: 791
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass128_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShakePowerBox_b__0(float k); // 0x0000000180439C90-0x0000000180439D60
		internal void _ShakePowerBox_b__1(); // 0x0000000180439D60-0x0000000180439DF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 792
	{
		// Fields
		public AnimationClip[] got; // 0x10
		public bool ready; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadFloorAnimators_b__0(AnimationClip[] clips); // 0x0000000180439DF0-0x0000000180439E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass94_0 // TypeDefIndex: 793
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public int requested; // 0x18

		// Constructors
		public __c__DisplayClass94_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShowBoss_b__0(AnimationClip[] clips); // 0x0000000180439E10-0x000000018043A120
	}

	[CompilerGenerated]
	private sealed class _FillTop_d__101 : IEnumerator<object> // TypeDefIndex: 794
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerInfoData info; // 0x20
		public TowerPanelController __4__this; // 0x28
		private List<TowerTopRow> _rows_5__2; // 0x30
		private int _n_5__3; // 0x38
		private int _i_5__4; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FillTop_d__101(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x0000000180436DF0-0x0000000180437200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180437200-0x0000000180437240
	}

	[CompilerGenerated]
	private sealed class _LoadFloorAnimators_d__90 : IEnumerator<object> // TypeDefIndex: 795
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass90_0 __8__1; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private Dictionary<int, AnimationClip[]> _done_5__3; // 0x38
		private int _animated_5__4; // 0x40
		private int _i_5__5; // 0x44
		private TowerFloorItem _item_5__6; // 0x48
		private int _petId_5__7; // 0x50
		private float _deadline_5__8; // 0x54

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadFloorAnimators_d__90(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804378E0-0x0000000180437940
		private bool MoveNext(); // 0x00000001804373D0-0x00000001804378A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804378A0-0x00000001804378E0
	}

	[CompilerGenerated]
	private sealed class _LoadInfo_d__81 : IEnumerator<object> // TypeDefIndex: 796
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadInfo_d__81(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180437940-0x0000000180437B00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180437B00-0x0000000180437B40
	}

	[CompilerGenerated]
	private sealed class _PostBuyPower_d__110 : IEnumerator<object> // TypeDefIndex: 797
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostBuyPower_d__110(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180437B40-0x0000000180437E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180437E40-0x0000000180437E80
	}

	[CompilerGenerated]
	private sealed class _PostResetClaim_d__107 : IEnumerator<object> // TypeDefIndex: 798
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		public TowerResetPackage pkg; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostResetClaim_d__107(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180437E80-0x0000000180438180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180438180-0x00000001804381C0
	}

	[CompilerGenerated]
	private sealed class _PowerTimerLoop_d__119 : IEnumerator<object> // TypeDefIndex: 799
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private int _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PowerTimerLoop_d__119(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001804381C0-0x0000000180438400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180438400-0x0000000180438440
	}

	[CompilerGenerated]
	private sealed class _ResetTimerLoop_d__118 : IEnumerator<object> // TypeDefIndex: 800
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResetTimerLoop_d__118(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x0000000180438440-0x0000000180438650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180438650-0x0000000180438690
	}

	[CompilerGenerated]
	private sealed class _StartTowerBattle_d__116 : IEnumerator<object> // TypeDefIndex: 801
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass116_0 __8__1; // 0x28
		private float _tWs_5__2; // 0x30
		private TowerBattleBridge _bridge_5__3; // 0x38
		private Action _onReady_5__4; // 0x40
		private Action<string> _onFailed_5__5; // 0x48
		private float _t_5__6; // 0x50
		private Action<ChatMessageDTO> _onStarting_5__7; // 0x58
		private Action<ChatMessageDTO> _onStartFailed_5__8; // 0x60
		private float _tStart_5__9; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _StartTowerBattle_d__116(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180439560-0x00000001804395E0
		private bool MoveNext(); // 0x0000000180438A30-0x0000000180439520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180439520-0x0000000180439560
	}

	// Constructors
	public TowerPanelController(); // 0x0000000180408600-0x0000000180408700

	// Methods
	private void RenderGifts(Transform container, TowerGiftBundle gift, float cell); // 0x00000001804056F0-0x0000000180405790
	private void RenderEntries(Transform container, List<RewardDisplayHelper.Entry> entries, float cell); // 0x0000000180405260-0x0000000180405380
	private static void Notice(string msg, float sec); // 0x0000000180401DB0-0x0000000180401EA0
	private void Awake(); // 0x00000001803FF610-0x00000001803FF620
	public void OpenPanel(); // 0x0000000180403140-0x0000000180403400
	private void OnDisable(); // 0x0000000180402B70-0x0000000180402D00
	private void EnsureWired(); // 0x0000000180400380-0x0000000180401740
	private void CollectFloorItems(Transform root); // 0x00000001803FFE20-0x0000000180400170
	private static void Wire(Button b, UnityAction action); // 0x0000000180408560-0x0000000180408600
	public void ClosePanel(); // 0x00000001803FF970-0x00000001803FFB80
	private void HideSubViews(); // 0x0000000180401B90-0x0000000180401CD0
	private void SetPlaceholders(); // 0x0000000180406C90-0x00000001804073B0
	private void SetStartInteractable(bool on); // 0x00000001804073B0-0x0000000180407490
	private void SetLoading(bool on); // 0x0000000180406B00-0x0000000180406C90
	[IteratorStateMachine(typeof(_LoadInfo_d__81))]
	private IEnumerator LoadInfo(); // 0x0000000180401D40-0x0000000180401DB0
	private void OnInfo(TowerInfoData d); // 0x0000000180402E00-0x0000000180402EE0
	private void OnInfoErr(string err); // 0x0000000180402D00-0x0000000180402E00
	private void ShowLoadError(string msg); // 0x0000000180407DF0-0x0000000180408120
	public void Render(TowerInfoData info); // 0x0000000180406330-0x0000000180406A80
	private void RenderRewards(TowerFloorInfo f, bool atMax); // 0x0000000180405E60-0x0000000180406150
	private void RenderPower(TowerInfoData info); // 0x0000000180405790-0x0000000180405C60
	private void RenderFloorList(TowerInfoData info, bool atMax); // 0x0000000180405380-0x00000001804056F0
	[IteratorStateMachine(typeof(_LoadFloorAnimators_d__90))]
	private IEnumerator LoadFloorAnimators(); // 0x0000000180401CD0-0x0000000180401D40
	private void StopFloorAnimLoader(); // 0x00000001804082B0-0x0000000180408300
	private void ReleaseFloorAnims(); // 0x0000000180405110-0x0000000180405260
	private void RenderResetTimer(TowerInfoData info); // 0x0000000180405C60-0x0000000180405E60
	private void ShowBoss(int petId); // 0x0000000180407750-0x0000000180407A20
	private void ApplyBossStaticIcon(int petId); // 0x00000001803FF450-0x00000001803FF610
	private void ReleaseBoss(); // 0x0000000180404FB0-0x0000000180405110
	public void ShowGiftFloor(RectTransform anchor, TowerFloorInfo data); // 0x0000000180407BB0-0x0000000180407DF0
	private void PlaceTooltipNear(RectTransform anchor); // 0x0000000180403400-0x0000000180403690
	public void HideGiftFloor(); // 0x0000000180401AD0-0x0000000180401B90
	private void RenderTop(TowerInfoData info); // 0x0000000180406150-0x0000000180406330
	[IteratorStateMachine(typeof(_FillTop_d__101))]
	private IEnumerator FillTop(TowerInfoData info); // 0x0000000180401800-0x0000000180401890
	private TowerTopItem EnsureTopRow(int index); // 0x0000000180400170-0x0000000180400380
	public void OnClickTop(); // 0x0000000180402850-0x0000000180402B70
	public void CloseTop(); // 0x00000001803FFB80-0x00000001803FFE20
	private void ShowResetPopup(TowerResetOffer offer); // 0x0000000180408120-0x0000000180408240
	private void OnClaimResetPackage(string packageType); // 0x00000001804020E0-0x0000000180402350
	[IteratorStateMachine(typeof(_PostResetClaim_d__107))]
	private IEnumerator PostResetClaim(TowerResetPackage pkg); // 0x0000000180404EA0-0x0000000180404F30
	private void OnResetClaimOk(TowerResetClaimData d); // 0x0000000180402EE0-0x0000000180403140
	public void OnClickBuyPower(); // 0x0000000180402350-0x00000001804026D0
	[IteratorStateMachine(typeof(_PostBuyPower_d__110))]
	private IEnumerator PostBuyPower(); // 0x0000000180404E30-0x0000000180404EA0
	private void OnBuyPowerOk(TowerBuyPowerData d); // 0x0000000180401F80-0x00000001804020E0
	private void OnActionErr(string err); // 0x0000000180401EA0-0x0000000180401F80
	private void ShowConfirm(string message, Action onYes); // 0x0000000180407A20-0x0000000180407BB0
	private void HideConfirm(); // 0x0000000180401A30-0x0000000180401AD0
	public void OnClickStart(); // 0x00000001804026D0-0x0000000180402850
	[IteratorStateMachine(typeof(_StartTowerBattle_d__116))]
	private IEnumerator StartTowerBattle(); // 0x0000000180408240-0x00000001804082B0
	private void FailStart(string msg); // 0x0000000180401740-0x0000000180401800
	[IteratorStateMachine(typeof(_ResetTimerLoop_d__118))]
	private IEnumerator ResetTimerLoop(long seconds); // 0x0000000180406A80-0x0000000180406B00
	[IteratorStateMachine(typeof(_PowerTimerLoop_d__119))]
	private IEnumerator PowerTimerLoop(int seconds); // 0x0000000180404F30-0x0000000180404FB0
	private void StopTimers(); // 0x0000000180408340-0x0000000180408400
	private void StopTimer(ref Coroutine co); // 0x0000000180408300-0x0000000180408340
	private void Track(int id); // 0x0000000180408400-0x00000001804084A0
	private void PlayOpenFx(); // 0x0000000180404480-0x0000000180404A30
	private void PlayFloorListFx(); // 0x0000000180404040-0x0000000180404480
	private void PlayBossPopIn(); // 0x0000000180403890-0x0000000180403AC0
	private void PlayBossBreath(); // 0x0000000180403690-0x0000000180403890
	private void PlayFloorClearedFx(); // 0x0000000180403AC0-0x0000000180404040
	private void ShakePowerBox(); // 0x0000000180407490-0x0000000180407750
	private void PlayPowerGainFx(); // 0x0000000180404A30-0x0000000180404C30
	private void PlayPressFx(Button b); // 0x0000000180404C30-0x0000000180404E30
	private void CancelFx(); // 0x00000001803FF620-0x00000001803FF970
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x0000000180401890-0x00000001804019A0
	private static GameObject FindGo(Transform root, string nodeName); // 0x00000001804019A0-0x0000000180401A30
	[CompilerGenerated]
	private void _EnsureWired_b__73_0(); // 0x00000001804084A0-0x00000001804084E0
	[CompilerGenerated]
	private void _OnClickBuyPower_b__109_0(); // 0x00000001804084E0-0x0000000180408560
}

