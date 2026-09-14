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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class TowerPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 1345
{
	// Fields
	public const string PANEL_KEY = "PanelTower"; // Metadata: 0x005F0D99
	public const string PREF_JUST_CLEARED = "TowerJustCleared"; // Metadata: 0x005F0DA4
	private const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x005F0DB5
	public const int FLOOR_SLOTS = 5; // Metadata: 0x005F0DBB
	public const int FLOOR_ANIM_MAX = 5; // Metadata: 0x005F0DBC
	private const float FLOOR_ANIM_STAGGER = 0.08f; // Metadata: 0x005F0DBD
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
	[Header("Pet ra tr\u1EADn (02/09/2026)")]
	[SerializeField]
	private GameObject petBox; // 0xC0
	[SerializeField]
	private Button btnPet; // 0xC8
	[SerializeField]
	private Image imgPetIcon; // 0xD0
	[SerializeField]
	private Image imgPetElement; // 0xD8
	[SerializeField]
	private UnityEngine.UI.Text txtPetLv; // 0xE0
	[SerializeField]
	private TowerPetPicker petPicker; // 0xE8
	[Header("M\u1ED1c r\u01B0\u01A1ng (c\u1ED9t tr\u00E1i)")]
	[SerializeField]
	private GameObject infoFloor; // 0xF0
	[SerializeField]
	private TowerFloorItem[] floorItems; // 0xF8
	[SerializeField]
	private Button maskGiftFloor; // 0x100
	[SerializeField]
	private GameObject rewardFloor; // 0x108
	[SerializeField]
	private Transform rewardFloorContainer; // 0x110
	[Header("L\u00E0m m\u1EDBi m\u00F9a")]
	[SerializeField]
	private GameObject infoReset; // 0x118
	[SerializeField]
	private UnityEngine.UI.Text txtResetTime; // 0x120
	[SerializeField]
	private TowerResetPopup resetPopup; // 0x128
	[Header("N\u0103ng l\u01B0\u1EE3ng th\u00E1p")]
	[SerializeField]
	private GameObject powerBox; // 0x130
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x138
	[SerializeField]
	private UnityEngine.UI.Text txtNextPower; // 0x140
	[SerializeField]
	private Button btnBuyPower; // 0x148
	[Header("B\u1EA3ng x\u1EBFp h\u1EA1ng")]
	[SerializeField]
	private Button btnTop; // 0x150
	[SerializeField]
	private GameObject topLayout; // 0x158
	[SerializeField]
	private RectTransform topMain; // 0x160
	[SerializeField]
	private Button topMask; // 0x168
	[SerializeField]
	private ScrollRect topScroll; // 0x170
	[SerializeField]
	private RectTransform topContent; // 0x178
	[SerializeField]
	private UnityEngine.UI.Text txtTopTitle; // 0x180
	[SerializeField]
	private GameObject topItemPrefab; // 0x188
	[Header("H\u1ED9p x\u00E1c nh\u1EADn (C\u00F3 / Hu\u1EF7)")]
	[SerializeField]
	private GameObject confirmDim; // 0x190
	[SerializeField]
	private UnityEngine.UI.Text txtConfirm; // 0x198
	[SerializeField]
	private Button btnConfirmYes; // 0x1A0
	[SerializeField]
	private Button btnConfirmNo; // 0x1A8
	private readonly List<TowerTopItem> _topPool; // 0x1B0
	private readonly List<int> _tweens; // 0x1B8
	private TowerInfoData _info; // 0x1C0
	private int _userId; // 0x1C8
	private bool _wired; // 0x1CC
	private bool _busy; // 0x1CD
	private bool _topOpen; // 0x1CE
	private int _bossPetShown; // 0x1D0
	private CanvasGroup _frameGroup; // 0x1D8
	private Coroutine _resetTimerCo; // 0x1E0
	private Coroutine _powerTimerCo; // 0x1E8
	private Coroutine _topFillCo; // 0x1F0
	private Action _confirmYes; // 0x1F8
	private Coroutine _floorAnimCo; // 0x200

	// Properties
	public bool IsBusy { get; } // 0x000000018075DE20-0x000000018075DE30 
	private static bool Live { get; } // 0x000000018075DE30-0x000000018075DEB0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 1346
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public int requested; // 0x18

		// Constructors
		public __c__DisplayClass103_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowBoss_b__0(AnimationClip[] clips); // 0x000000018076E380-0x000000018076E7E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1347
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickTop_b__0(float y); // 0x000000018076E7E0-0x000000018076E910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 1348
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseTop_b__0(float y); // 0x000000018076E910-0x000000018076EA40
		internal void _CloseTop_b__1(); // 0x000000018076EA40-0x000000018076EBA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 1349
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public TowerResetPackage pkg; // 0x18

		// Constructors
		public __c__DisplayClass115_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClaimResetPackage_b__0(); // 0x000000018076EBA0-0x000000018076ECD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass125_0 // TypeDefIndex: 1350
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18
		public bool started; // 0x20
		public bool startFailed; // 0x21
		public string startReason; // 0x28

		// Constructors
		public __c__DisplayClass125_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartTowerBattle_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
		internal void _StartTowerBattle_b__1(string r); // 0x0000000180308BE0-0x0000000180308C40
		internal void _StartTowerBattle_b__2(ChatMessageDTO _); // 0x0000000180596F30-0x0000000180596F40
		internal void _StartTowerBattle_b__3(ChatMessageDTO m); // 0x0000000180596F40-0x0000000180596FB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass132_0 // TypeDefIndex: 1351
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass132_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__0(float y); // 0x000000018076ECD0-0x000000018076EDE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 1352
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFloorListFx_b__0(float x); // 0x000000018076EDE0-0x000000018076EEF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass136_0 // TypeDefIndex: 1353
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass136_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFloorClearedFx_b__0(float a); // 0x000000018076EEF0-0x000000018076F070
		internal void _PlayFloorClearedFx_b__1(); // 0x000000018076F070-0x000000018076F1C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass137_0 // TypeDefIndex: 1354
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass137_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakePowerBox_b__0(float k); // 0x000000018076F1C0-0x000000018076F310
		internal void _ShakePowerBox_b__1(); // 0x000000018076F310-0x000000018076F420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 1355
	{
		// Fields
		public AnimationClip[] got; // 0x10
		public bool ready; // 0x18

		// Constructors
		public __c__DisplayClass99_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadFloorAnimators_b__0(AnimationClip[] clips); // 0x000000018076F420-0x000000018076F480
	}

	[CompilerGenerated]
	private sealed class _FillTop_d__110 : IEnumerator<object> // TypeDefIndex: 1356
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FillTop_d__110(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018076F480-0x000000018076FB80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076FB80-0x000000018076FBC0
	}

	[CompilerGenerated]
	private sealed class _LoadFloorAnimators_d__99 : IEnumerator<object> // TypeDefIndex: 1357
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass99_0 __8__1; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private Dictionary<int, AnimationClip[]> _done_5__3; // 0x38
		private int _animated_5__4; // 0x40
		private int _i_5__5; // 0x44
		private TowerFloorItem _item_5__6; // 0x48
		private int _petId_5__7; // 0x50
		private float _deadline_5__8; // 0x54

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadFloorAnimators_d__99(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018076FBC0-0x000000018076FD20
		private bool MoveNext(); // 0x000000018076FD20-0x0000000180770520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180770520-0x0000000180770560
	}

	[CompilerGenerated]
	private sealed class _LoadInfo_d__90 : IEnumerator<object> // TypeDefIndex: 1358
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadInfo_d__90(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180770560-0x0000000180770890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180770890-0x00000001807708D0
	}

	[CompilerGenerated]
	private sealed class _PostBuyPower_d__119 : IEnumerator<object> // TypeDefIndex: 1359
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostBuyPower_d__119(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807708D0-0x0000000180770D40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180770D40-0x0000000180770D80
	}

	[CompilerGenerated]
	private sealed class _PostResetClaim_d__116 : IEnumerator<object> // TypeDefIndex: 1360
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		public TowerResetPackage pkg; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostResetClaim_d__116(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180770D80-0x0000000180771200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180771200-0x0000000180771240
	}

	[CompilerGenerated]
	private sealed class _PowerTimerLoop_d__128 : IEnumerator<object> // TypeDefIndex: 1361
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private int _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PowerTimerLoop_d__128(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180771240-0x00000001807715D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807715D0-0x0000000180771610
	}

	[CompilerGenerated]
	private sealed class _ResetTimerLoop_d__127 : IEnumerator<object> // TypeDefIndex: 1362
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResetTimerLoop_d__127(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180771610-0x0000000180771970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180771970-0x00000001807719B0
	}

	[CompilerGenerated]
	private sealed class _StartTowerBattle_d__125 : IEnumerator<object> // TypeDefIndex: 1363
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass125_0 __8__1; // 0x28
		private float _tWs_5__2; // 0x30
		private TowerBattleBridge _bridge_5__3; // 0x38
		private Action _onReady_5__4; // 0x40
		private Action<string> _onFailed_5__5; // 0x48
		private float _t_5__6; // 0x50
		private Action<ChatMessageDTO> _onStarting_5__7; // 0x58
		private Action<ChatMessageDTO> _onStartFailed_5__8; // 0x60
		private float _tStart_5__9; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _StartTowerBattle_d__125(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180597FD0-0x00000001805981D0
		private bool MoveNext(); // 0x00000001807719B0-0x0000000180772D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180772D90-0x0000000180772DD0
	}

	// Constructors
	public TowerPanelController(); // 0x000000018076E070-0x000000018076E290

	// Methods
	private void RenderGifts(Transform container, TowerGiftBundle gift, float cell); // 0x000000018075DEB0-0x000000018075E000
	private void RenderEntries(Transform container, List<RewardDisplayHelper.Entry> entries, float cell); // 0x000000018075E000-0x000000018075E340
	private static void Notice(string msg, float sec); // 0x000000018075E340-0x000000018075E410
	private void Awake(); // 0x000000018075E410-0x000000018075E420
	public void OpenPanel(); // 0x000000018075E420-0x000000018075E6B0
	private void OnDisable(); // 0x000000018075E6B0-0x000000018075E8E0
	private void EnsureWired(); // 0x000000018075E8E0-0x0000000180760110
	private void OnClickPet(); // 0x0000000180760110-0x0000000180760280
	private void HandlePetChosen(int petId); // 0x0000000180760280-0x0000000180760340
	private void RefreshPetBox(); // 0x0000000180760340-0x0000000180760B60
	private void CollectFloorItems(Transform root); // 0x0000000180760B60-0x0000000180761130
	private static void Wire(Button b, UnityAction action); // 0x0000000180761130-0x0000000180761240
	public void ClosePanel(); // 0x0000000180761240-0x0000000180761470
	private void HideSubViews(); // 0x0000000180761470-0x0000000180761950
	private void SetPlaceholders(); // 0x0000000180761950-0x0000000180762580
	private void SetStartInteractable(bool on); // 0x0000000180762580-0x0000000180762760
	private void SetLoading(bool on); // 0x0000000180762760-0x0000000180762C40
	[IteratorStateMachine(typeof(_LoadInfo_d__90))]
	private IEnumerator LoadInfo(); // 0x0000000180762C40-0x0000000180762CE0
	private void OnInfo(TowerInfoData d); // 0x0000000180762CE0-0x0000000180762DD0
	private void OnInfoErr(string err); // 0x0000000180762DD0-0x0000000180762F00
	private void ShowLoadError(string msg); // 0x0000000180762F00-0x0000000180763640
	public void Render(TowerInfoData info); // 0x0000000180763640-0x0000000180764490
	private void RenderRewards(TowerFloorInfo f, bool atMax); // 0x0000000180764490-0x0000000180764C60
	private void RenderPower(TowerInfoData info); // 0x0000000180764C60-0x0000000180765390
	private void RenderFloorList(TowerInfoData info, bool atMax); // 0x0000000180765390-0x0000000180765A40
	[IteratorStateMachine(typeof(_LoadFloorAnimators_d__99))]
	private IEnumerator LoadFloorAnimators(); // 0x0000000180765A40-0x0000000180765AE0
	private void StopFloorAnimLoader(); // 0x0000000180765AE0-0x0000000180765B60
	private void ReleaseFloorAnims(); // 0x0000000180765B60-0x0000000180765CF0
	private void RenderResetTimer(TowerInfoData info); // 0x0000000180765CF0-0x0000000180766080
	private void ShowBoss(int petId); // 0x0000000180766080-0x00000001807666C0
	private void ApplyBossStaticIcon(int petId); // 0x00000001807666C0-0x0000000180766C10
	private void ReleaseBoss(); // 0x0000000180766C10-0x0000000180767030
	public void ShowGiftFloor(RectTransform anchor, TowerFloorInfo data); // 0x0000000180767030-0x00000001807674E0
	private void PlaceTooltipNear(RectTransform anchor); // 0x00000001807674E0-0x0000000180767A50
	public void HideGiftFloor(); // 0x0000000180767A50-0x0000000180767CB0
	private void RenderTop(TowerInfoData info); // 0x0000000180767CB0-0x0000000180767F60
	[IteratorStateMachine(typeof(_FillTop_d__110))]
	private IEnumerator FillTop(TowerInfoData info); // 0x0000000180767F60-0x0000000180768070
	private TowerTopItem EnsureTopRow(int index); // 0x0000000180768070-0x00000001807684F0
	public void OnClickTop(); // 0x00000001807684F0-0x0000000180768A60
	public void CloseTop(); // 0x0000000180768A60-0x0000000180768E90
	private void ShowResetPopup(TowerResetOffer offer); // 0x0000000180768E90-0x0000000180769050
	private void OnClaimResetPackage(string packageType); // 0x0000000180769050-0x00000001807693D0
	[IteratorStateMachine(typeof(_PostResetClaim_d__116))]
	private IEnumerator PostResetClaim(TowerResetPackage pkg); // 0x00000001807693D0-0x00000001807694E0
	private void OnResetClaimOk(TowerResetClaimData d); // 0x00000001807694E0-0x00000001807698E0
	public void OnClickBuyPower(); // 0x00000001807698E0-0x0000000180769C70
	[IteratorStateMachine(typeof(_PostBuyPower_d__119))]
	private IEnumerator PostBuyPower(); // 0x0000000180769C70-0x0000000180769D10
	private void OnBuyPowerOk(TowerBuyPowerData d); // 0x0000000180769D10-0x0000000180769F40
	private void OnActionErr(string err); // 0x0000000180769F40-0x0000000180769FD0
	private void ShowConfirm(string message, Action onYes); // 0x0000000180769FD0-0x000000018076A3D0
	private void HideConfirm(); // 0x000000018076A3D0-0x000000018076A570
	public void OnClickStart(); // 0x000000018076A570-0x000000018076A960
	[IteratorStateMachine(typeof(_StartTowerBattle_d__125))]
	private IEnumerator StartTowerBattle(); // 0x000000018076A960-0x000000018076AA00
	private void FailStart(string msg); // 0x000000018076AA00-0x000000018076AAD0
	[IteratorStateMachine(typeof(_ResetTimerLoop_d__127))]
	private IEnumerator ResetTimerLoop(long seconds); // 0x000000018076AAD0-0x000000018076AB90
	[IteratorStateMachine(typeof(_PowerTimerLoop_d__128))]
	private IEnumerator PowerTimerLoop(int seconds); // 0x000000018076AB90-0x000000018076AC40
	private void StopTimers(); // 0x000000018076AC40-0x000000018076ACF0
	private void StopTimer(ref Coroutine co); // 0x000000018076ACF0-0x000000018076AD60
	private void Track(int id); // 0x000000018076AD60-0x000000018076AE10
	private void PlayOpenFx(); // 0x000000018076AE10-0x000000018076B630
	private void PlayFloorListFx(); // 0x000000018076B630-0x000000018076BB20
	private void PlayBossPopIn(); // 0x000000018076BB20-0x000000018076BE10
	private void PlayBossBreath(); // 0x000000018076BE10-0x000000018076C0C0
	private void PlayFloorClearedFx(); // 0x000000018076C0C0-0x000000018076C7F0
	private void ShakePowerBox(); // 0x000000018076C7F0-0x000000018076CBC0
	private void PlayPowerGainFx(); // 0x000000018076CBC0-0x000000018076CE60
	private void PlayPressFx(Button b); // 0x000000018076CE60-0x000000018076D110
	private void CancelFx(); // 0x000000018076D110-0x000000018076DD00
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018076DD00-0x000000018076DF60
	private static GameObject FindGo(Transform root, string nodeName); // 0x000000018076DF60-0x000000018076E070
	[CompilerGenerated]
	private void _EnsureWired_b__79_0(); // 0x000000018076E290-0x000000018076E2D0
	[CompilerGenerated]
	private void _OnClickBuyPower_b__118_0(); // 0x000000018076E2D0-0x000000018076E380
}

