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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class TowerPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 1343
{
	// Fields
	public const string PANEL_KEY = "PanelTower"; // Metadata: 0x005EF9CC
	public const string PREF_JUST_CLEARED = "TowerJustCleared"; // Metadata: 0x005EF9D7
	private const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x005EF9E8
	public const int FLOOR_SLOTS = 5; // Metadata: 0x005EF9EE
	public const int FLOOR_ANIM_MAX = 5; // Metadata: 0x005EF9EF
	private const float FLOOR_ANIM_STAGGER = 0.08f; // Metadata: 0x005EF9F0
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
	public bool IsBusy { get; } // 0x000000018075BF50-0x000000018075BF60 
	private static bool Live { get; } // 0x000000018075BF60-0x000000018075BFE0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 1344
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public int requested; // 0x18

		// Constructors
		public __c__DisplayClass103_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowBoss_b__0(AnimationClip[] clips); // 0x000000018076C4B0-0x000000018076C910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1345
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickTop_b__0(float y); // 0x000000018076C910-0x000000018076CA40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 1346
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CloseTop_b__0(float y); // 0x000000018076CA40-0x000000018076CB70
		internal void _CloseTop_b__1(); // 0x000000018076CB70-0x000000018076CCD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 1347
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public TowerResetPackage pkg; // 0x18

		// Constructors
		public __c__DisplayClass115_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClaimResetPackage_b__0(); // 0x000000018076CCD0-0x000000018076CE00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass125_0 // TypeDefIndex: 1348
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
		internal void _StartTowerBattle_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal void _StartTowerBattle_b__1(string r); // 0x0000000180308BB0-0x0000000180308C10
		internal void _StartTowerBattle_b__2(ChatMessageDTO _); // 0x00000001805955D0-0x00000001805955E0
		internal void _StartTowerBattle_b__3(ChatMessageDTO m); // 0x00000001805955E0-0x0000000180595650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass132_0 // TypeDefIndex: 1349
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass132_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__0(float y); // 0x000000018076CE00-0x000000018076CF10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 1350
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFloorListFx_b__0(float x); // 0x000000018076CF10-0x000000018076D020
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass136_0 // TypeDefIndex: 1351
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass136_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFloorClearedFx_b__0(float a); // 0x000000018076D020-0x000000018076D1A0
		internal void _PlayFloorClearedFx_b__1(); // 0x000000018076D1A0-0x000000018076D2F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass137_0 // TypeDefIndex: 1352
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass137_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakePowerBox_b__0(float k); // 0x000000018076D2F0-0x000000018076D440
		internal void _ShakePowerBox_b__1(); // 0x000000018076D440-0x000000018076D550
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 1353
	{
		// Fields
		public AnimationClip[] got; // 0x10
		public bool ready; // 0x18

		// Constructors
		public __c__DisplayClass99_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadFloorAnimators_b__0(AnimationClip[] clips); // 0x000000018076D550-0x000000018076D5B0
	}

	[CompilerGenerated]
	private sealed class _FillTop_d__110 : IEnumerator<object> // TypeDefIndex: 1354
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
		private bool MoveNext(); // 0x000000018076D5B0-0x000000018076DCB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076DCB0-0x000000018076DCF0
	}

	[CompilerGenerated]
	private sealed class _LoadFloorAnimators_d__99 : IEnumerator<object> // TypeDefIndex: 1355
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
		void IDisposable.Dispose(); // 0x000000018076DCF0-0x000000018076DE50
		private bool MoveNext(); // 0x000000018076DE50-0x000000018076E650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076E650-0x000000018076E690
	}

	[CompilerGenerated]
	private sealed class _LoadInfo_d__90 : IEnumerator<object> // TypeDefIndex: 1356
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018076E690-0x000000018076E990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076E990-0x000000018076E9D0
	}

	[CompilerGenerated]
	private sealed class _PostBuyPower_d__119 : IEnumerator<object> // TypeDefIndex: 1357
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018076E9D0-0x000000018076EE10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076EE10-0x000000018076EE50
	}

	[CompilerGenerated]
	private sealed class _PostResetClaim_d__116 : IEnumerator<object> // TypeDefIndex: 1358
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018076EE50-0x000000018076F2B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076F2B0-0x000000018076F2F0
	}

	[CompilerGenerated]
	private sealed class _PowerTimerLoop_d__128 : IEnumerator<object> // TypeDefIndex: 1359
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
		private bool MoveNext(); // 0x000000018076F2F0-0x000000018076F680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076F680-0x000000018076F6C0
	}

	[CompilerGenerated]
	private sealed class _ResetTimerLoop_d__127 : IEnumerator<object> // TypeDefIndex: 1360
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
		private bool MoveNext(); // 0x000000018076F6C0-0x000000018076FA20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018076FA20-0x000000018076FA60
	}

	[CompilerGenerated]
	private sealed class _StartTowerBattle_d__125 : IEnumerator<object> // TypeDefIndex: 1361
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
		void IDisposable.Dispose(); // 0x0000000180596670-0x0000000180596870
		private bool MoveNext(); // 0x000000018076FA60-0x0000000180770E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180770E40-0x0000000180770E80
	}

	// Constructors
	public TowerPanelController(); // 0x000000018076C1A0-0x000000018076C3C0

	// Methods
	private void RenderGifts(Transform container, TowerGiftBundle gift, float cell); // 0x000000018075BFE0-0x000000018075C130
	private void RenderEntries(Transform container, List<RewardDisplayHelper.Entry> entries, float cell); // 0x000000018075C130-0x000000018075C470
	private static void Notice(string msg, float sec); // 0x000000018075C470-0x000000018075C540
	private void Awake(); // 0x000000018075C540-0x000000018075C550
	public void OpenPanel(); // 0x000000018075C550-0x000000018075C7E0
	private void OnDisable(); // 0x000000018075C7E0-0x000000018075CA10
	private void EnsureWired(); // 0x000000018075CA10-0x000000018075E240
	private void OnClickPet(); // 0x000000018075E240-0x000000018075E3B0
	private void HandlePetChosen(int petId); // 0x000000018075E3B0-0x000000018075E470
	private void RefreshPetBox(); // 0x000000018075E470-0x000000018075EC90
	private void CollectFloorItems(Transform root); // 0x000000018075EC90-0x000000018075F260
	private static void Wire(Button b, UnityAction action); // 0x000000018075F260-0x000000018075F370
	public void ClosePanel(); // 0x000000018075F370-0x000000018075F5A0
	private void HideSubViews(); // 0x000000018075F5A0-0x000000018075FA80
	private void SetPlaceholders(); // 0x000000018075FA80-0x00000001807606B0
	private void SetStartInteractable(bool on); // 0x00000001807606B0-0x0000000180760890
	private void SetLoading(bool on); // 0x0000000180760890-0x0000000180760D70
	[IteratorStateMachine(typeof(_LoadInfo_d__90))]
	private IEnumerator LoadInfo(); // 0x0000000180760D70-0x0000000180760E10
	private void OnInfo(TowerInfoData d); // 0x0000000180760E10-0x0000000180760F00
	private void OnInfoErr(string err); // 0x0000000180760F00-0x0000000180761030
	private void ShowLoadError(string msg); // 0x0000000180761030-0x0000000180761770
	public void Render(TowerInfoData info); // 0x0000000180761770-0x00000001807625C0
	private void RenderRewards(TowerFloorInfo f, bool atMax); // 0x00000001807625C0-0x0000000180762D90
	private void RenderPower(TowerInfoData info); // 0x0000000180762D90-0x00000001807634C0
	private void RenderFloorList(TowerInfoData info, bool atMax); // 0x00000001807634C0-0x0000000180763B70
	[IteratorStateMachine(typeof(_LoadFloorAnimators_d__99))]
	private IEnumerator LoadFloorAnimators(); // 0x0000000180763B70-0x0000000180763C10
	private void StopFloorAnimLoader(); // 0x0000000180763C10-0x0000000180763C90
	private void ReleaseFloorAnims(); // 0x0000000180763C90-0x0000000180763E20
	private void RenderResetTimer(TowerInfoData info); // 0x0000000180763E20-0x00000001807641B0
	private void ShowBoss(int petId); // 0x00000001807641B0-0x00000001807647F0
	private void ApplyBossStaticIcon(int petId); // 0x00000001807647F0-0x0000000180764D40
	private void ReleaseBoss(); // 0x0000000180764D40-0x0000000180765160
	public void ShowGiftFloor(RectTransform anchor, TowerFloorInfo data); // 0x0000000180765160-0x0000000180765610
	private void PlaceTooltipNear(RectTransform anchor); // 0x0000000180765610-0x0000000180765B80
	public void HideGiftFloor(); // 0x0000000180765B80-0x0000000180765DE0
	private void RenderTop(TowerInfoData info); // 0x0000000180765DE0-0x0000000180766090
	[IteratorStateMachine(typeof(_FillTop_d__110))]
	private IEnumerator FillTop(TowerInfoData info); // 0x0000000180766090-0x00000001807661A0
	private TowerTopItem EnsureTopRow(int index); // 0x00000001807661A0-0x0000000180766620
	public void OnClickTop(); // 0x0000000180766620-0x0000000180766B90
	public void CloseTop(); // 0x0000000180766B90-0x0000000180766FC0
	private void ShowResetPopup(TowerResetOffer offer); // 0x0000000180766FC0-0x0000000180767180
	private void OnClaimResetPackage(string packageType); // 0x0000000180767180-0x0000000180767500
	[IteratorStateMachine(typeof(_PostResetClaim_d__116))]
	private IEnumerator PostResetClaim(TowerResetPackage pkg); // 0x0000000180767500-0x0000000180767610
	private void OnResetClaimOk(TowerResetClaimData d); // 0x0000000180767610-0x0000000180767A10
	public void OnClickBuyPower(); // 0x0000000180767A10-0x0000000180767DA0
	[IteratorStateMachine(typeof(_PostBuyPower_d__119))]
	private IEnumerator PostBuyPower(); // 0x0000000180767DA0-0x0000000180767E40
	private void OnBuyPowerOk(TowerBuyPowerData d); // 0x0000000180767E40-0x0000000180768070
	private void OnActionErr(string err); // 0x0000000180768070-0x0000000180768100
	private void ShowConfirm(string message, Action onYes); // 0x0000000180768100-0x0000000180768500
	private void HideConfirm(); // 0x0000000180768500-0x00000001807686A0
	public void OnClickStart(); // 0x00000001807686A0-0x0000000180768A90
	[IteratorStateMachine(typeof(_StartTowerBattle_d__125))]
	private IEnumerator StartTowerBattle(); // 0x0000000180768A90-0x0000000180768B30
	private void FailStart(string msg); // 0x0000000180768B30-0x0000000180768C00
	[IteratorStateMachine(typeof(_ResetTimerLoop_d__127))]
	private IEnumerator ResetTimerLoop(long seconds); // 0x0000000180768C00-0x0000000180768CC0
	[IteratorStateMachine(typeof(_PowerTimerLoop_d__128))]
	private IEnumerator PowerTimerLoop(int seconds); // 0x0000000180768CC0-0x0000000180768D70
	private void StopTimers(); // 0x0000000180768D70-0x0000000180768E20
	private void StopTimer(ref Coroutine co); // 0x0000000180768E20-0x0000000180768E90
	private void Track(int id); // 0x0000000180768E90-0x0000000180768F40
	private void PlayOpenFx(); // 0x0000000180768F40-0x0000000180769760
	private void PlayFloorListFx(); // 0x0000000180769760-0x0000000180769C50
	private void PlayBossPopIn(); // 0x0000000180769C50-0x0000000180769F40
	private void PlayBossBreath(); // 0x0000000180769F40-0x000000018076A1F0
	private void PlayFloorClearedFx(); // 0x000000018076A1F0-0x000000018076A920
	private void ShakePowerBox(); // 0x000000018076A920-0x000000018076ACF0
	private void PlayPowerGainFx(); // 0x000000018076ACF0-0x000000018076AF90
	private void PlayPressFx(Button b); // 0x000000018076AF90-0x000000018076B240
	private void CancelFx(); // 0x000000018076B240-0x000000018076BE30
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018076BE30-0x000000018076C090
	private static GameObject FindGo(Transform root, string nodeName); // 0x000000018076C090-0x000000018076C1A0
	[CompilerGenerated]
	private void _EnsureWired_b__79_0(); // 0x000000018076C3C0-0x000000018076C400
	[CompilerGenerated]
	private void _OnClickBuyPower_b__118_0(); // 0x000000018076C400-0x000000018076C4B0
}

