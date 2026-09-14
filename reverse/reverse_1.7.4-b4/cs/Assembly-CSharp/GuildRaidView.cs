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
public class GuildRaidView : MonoBehaviour // TypeDefIndex: 902
{
	// Fields
	public const float RAID_W = 953f; // Metadata: 0x005F00AA
	public const float RAID_H = 556f; // Metadata: 0x005F00AE
	private const float PANEL_SCALE = 1.28f; // Metadata: 0x005F00B2
	private const float CONTENT_HALF_H = 283f; // Metadata: 0x005F00B6
	private const float CONTENT_HALF_W = 478f; // Metadata: 0x005F00BA
	private const float TITLE_Y = 228f; // Metadata: 0x005F00BE
	private static readonly Vector2 TITLE_POS; // 0x00
	private static readonly Vector2 TITLE_SIZE; // 0x08
	private static readonly Vector2 STAGE_POS; // 0x10
	private static readonly Vector2 STAGE_SIZE; // 0x18
	private static readonly Vector2 RANK_POS; // 0x20
	private static readonly Vector2 RANK_SIZE; // 0x28
	private static readonly Vector2 STRIP_POS; // 0x30
	private static readonly Vector2 STRIP_SIZE; // 0x38
	private static readonly Vector2 LOADOUT_POS; // 0x40
	private static readonly Vector2 LOADOUT_SIZE; // 0x48
	private static readonly Vector2 BAR_POS; // 0x50
	private static readonly Vector2 BAR_SIZE; // 0x58
	public const float STAGE_PET_BOX = 150f; // Metadata: 0x005F00C2
	private static readonly Color C_TITLE; // 0x60
	private static readonly Color C_HILITE; // 0x70
	private static readonly Color C_LABEL; // 0x80
	private static readonly Color C_VALUE; // 0x90
	private static readonly Color C_DANGER; // 0xA0
	private static readonly Color C_MUTED; // 0xB0
	private static readonly Color C_HP_FILL; // 0xC0
	private static readonly Color C_BTN_ON; // 0xD0
	private static readonly Color C_BTN_BUY; // 0xE0
	private static readonly Color C_BTN_OFF; // 0xF0
	private static readonly Color C_PANEL_DIM; // 0x100
	private const string TICKET_ICON = "Image/item/9010"; // Metadata: 0x005F00C6
	private static readonly Color DOT_ON; // 0x110
	private static readonly Color DOT_OFF; // 0x120
	private const int ATTEMPT_DOTS = 5; // Metadata: 0x005F00D6
	public const string PREF_AUTO_FIGHT = "GuildRaidAutoFight"; // Metadata: 0x005F00D7
	private GuildPanelController _owner; // 0x20
	private GuildRaidData _data; // 0x28
	private RaidState _state; // 0x30
	private bool _built; // 0x34
	private bool _starting; // 0x35
	private Coroutine _tickCo; // 0x38
	private Coroutine _pollCo; // 0x40
	private readonly List<int> _tweens; // 0x48
	private readonly List<GuildRaidRankRow> _rowPool; // 0x50
	private long _serverTimeMs; // 0x58
	private float _serverSyncAt; // 0x60
	private int _petShown; // 0x64
	private Animator _petAnim; // 0x68
	private Image _petImg; // 0x70
	private PetImageFit _petFit; // 0x78
	private RectTransform _raidRoot; // 0x80
	private UnityEngine.UI.Text _txtTitle; // 0x88
	private UnityEngine.UI.Text _txtBossName; // 0x90
	private UnityEngine.UI.Text _txtChip; // 0x98
	private UnityEngine.UI.Text _txtHp; // 0xA0
	private UnityEngine.UI.Text _txtFighting; // 0xA8
	private UnityEngine.UI.Text _txtBossLevel; // 0xB0
	private UnityEngine.UI.Text _txtBossStar; // 0xB8
	private Image _imgHpFill; // 0xC0
	private Image _imgElement; // 0xC8
	private Image _imgNameCard; // 0xD0
	private Image _imgChipBg; // 0xD8
	private Image _imgPedestal; // 0xE0
	private Image _imgFlash; // 0xE8
	private UnityEngine.UI.Text _txtRankTitle; // 0xF0
	private UnityEngine.UI.Text _txtRankSub; // 0xF8
	private UnityEngine.UI.Text _txtRankEmpty; // 0x100
	private UnityEngine.UI.Text _txtRewardHint; // 0x108
	private UnityEngine.UI.Text _txtAttemptsLabel; // 0x110
	private UnityEngine.UI.Text _txtAttempts; // 0x118
	private UnityEngine.UI.Text _txtTicket; // 0x120
	private UnityEngine.UI.Text _txtNotice; // 0x128
	private Image _imgTicket; // 0x130
	private readonly Image[] _dots; // 0x138
	private Image _imgRewardPet; // 0x140
	private Image _imgRewardCoin; // 0x148
	private Image _imgRewardGold; // 0x150
	private UnityEngine.UI.Text _txtRewardPetLbl; // 0x158
	private UnityEngine.UI.Text _txtRewardCoin; // 0x160
	private UnityEngine.UI.Text _txtRewardGold; // 0x168
	private Button _btnStrip; // 0x170
	private Sprite _artMainGreen; // 0x178
	private Sprite _artMainBlue; // 0x180
	private Sprite _artMainGrey; // 0x188
	private Button _btnFight; // 0x190
	private Button _btnSecondary; // 0x198
	private Button _btnSchedule; // 0x1A0
	private Button _btnReward; // 0x1A8
	private Button _btnClose; // 0x1B0
	private Button _btnHelp; // 0x1B8
	private UnityEngine.UI.Text _txtFight; // 0x1C0
	private UnityEngine.UI.Text _txtSecondary; // 0x1C8
	private RectTransform _rankContent; // 0x1D0
	private RectTransform _rankViewport; // 0x1D8
	private RectTransform _meRowHost; // 0x1E0
	private GuildRaidRankRow _meRow; // 0x1E8
	private Transform _petSlot; // 0x1F0
	private Transform _stage; // 0x1F8
	private UnityEngine.UI.Text _fontSample; // 0x200
	private RectTransform _loadoutRow; // 0x208
	private UnityEngine.UI.Text _txtLoadoutLabel; // 0x210
	private UnityEngine.UI.Text _txtDeckCount; // 0x218
	private Button _btnPetSlot; // 0x220
	private Button _btnLoadout; // 0x228
	private Image _imgPetSlot; // 0x230
	private readonly Button[] _cardSlotBtns; // 0x238
	private readonly Image[] _imgCardSlots; // 0x240
	private GuildRaidLoadoutPopup _loadoutPopup; // 0x248
	private bool _mainIsBuy; // 0x250
	private static bool _openToastShown; // 0x130
	private static bool _killFxShown; // 0x131
	private GuildRaidSchedulePopup _schedulePopup; // 0x258
	private GuildRaidRewardPopup _rewardPopup; // 0x260
	private bool _openFxPlayed; // 0x268
	private Coroutine _rescaleCo; // 0x270
	private int _pulseId; // 0x278
	private int _blinkId; // 0x27C
	private static readonly Vector2 BTN_CLOSE_SIZE; // 0x134
	private static readonly Vector2 BTN_HELP_SIZE; // 0x13C
	private const float BTN_HELP_LONG = 52f; // Metadata: 0x005F00EA
	private static readonly Vector2 BTN_PLUS_SIZE; // 0x144
	private const float BTN_PLUS_LONG = 44f; // Metadata: 0x005F00EE
	private static readonly Vector2 BTN_CHIP_SIZE; // 0x14C
	private static readonly Vector2 BTN_MAIN_SIZE; // 0x154
	private static readonly Vector2 P_NAMECARD; // 0x15C
	private static readonly Vector2 S_NAMECARD; // 0x164
	private static readonly Vector2 P_PEDESTAL; // 0x16C
	private static readonly Vector2 S_PEDESTAL; // 0x174
	private static readonly Vector2 P_PET; // 0x17C
	private static readonly Vector2 P_CHIP; // 0x184
	private static readonly Vector2 S_CHIPBG; // 0x18C
	private static readonly Vector2 S_CHIPTXT; // 0x194
	private static readonly Vector2 P_HP; // 0x19C
	private static readonly Vector2 S_HP; // 0x1A4
	private static readonly Vector2 P_HPSUB; // 0x1AC
	private static readonly Vector2 S_HPSUB; // 0x1B4
	private static readonly Vector2 P_LO_LABEL; // 0x1BC
	private static readonly Vector2 S_LO_LABEL; // 0x1C4
	private static readonly Vector2 P_LO_PET; // 0x1CC
	private static readonly Vector2 S_LO_PET; // 0x1D4
	private static readonly Vector2 S_LO_CARD; // 0x1DC
	private const float LO_CARD_X0 = -180f; // Metadata: 0x005F00F2
	private const float LO_CARD_STEP = 62f; // Metadata: 0x005F00F6
	private static readonly Vector2 P_LO_COUNT; // 0x1E4
	private static readonly Vector2 S_LO_COUNT; // 0x1EC
	private static readonly Vector2 P_LO_BTN; // 0x1F4
	private static float _lastGoodScale; // 0x1FC

	// Properties
	private static bool Live { get; } // 0x0000000180582790-0x0000000180582810 
	private bool HasBoss { get; } // 0x0000000180583B70-0x0000000180583B90 

	// Nested types
	private enum RaidState // TypeDefIndex: 903
	{
		LEGACY_OFF = 0,
		NO_GUILD = 1,
		LOCKED_LEVEL = 2,
		NO_SCHEDULE = 3,
		UPCOMING = 4,
		LIVE = 5,
		KILLED = 6,
		ESCAPED = 7
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 904
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__126_0; // 0x08
		public static Action<string> __9__153_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180596B90-0x0000000180596C30
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__126_0(string err); // 0x0000000180596C30-0x0000000180596CA0
		internal void _OpenRewards_b__153_1(string err); // 0x0000000180596CA0-0x0000000180596D10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 905
	{
		// Fields
		public float ratio; // 0x10
		public Color want; // 0x14
		public Image target; // 0x28
		public float from; // 0x30
		public Color fromCol; // 0x34

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderStage_b__0(float v); // 0x0000000180596D10-0x0000000180596F30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 906
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18
		public bool started; // 0x20
		public bool startFailed; // 0x21
		public string startReason; // 0x28

		// Constructors
		public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _StartBattleRoutine_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
		internal void _StartBattleRoutine_b__1(string r); // 0x0000000180308BE0-0x0000000180308C40
		internal void _StartBattleRoutine_b__2(ChatMessageDTO _); // 0x0000000180596F30-0x0000000180596F40
		internal void _StartBattleRoutine_b__3(ChatMessageDTO m); // 0x0000000180596F40-0x0000000180596FB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass153_0 // TypeDefIndex: 907
	{
		// Fields
		public GuildRaidView __4__this; // 0x10
		public int bossPet; // 0x18

		// Constructors
		public __c__DisplayClass153_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenRewards_b__0(GuildRaidRewardsData d); // 0x0000000180596FB0-0x00000001805970E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 908
	{
		// Fields
		public RectTransform srt; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__2(float v); // 0x00000001805970E0-0x0000000180597230
		internal void _PlayOpenFx_b__3(); // 0x0000000180597230-0x0000000180597340
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_1 // TypeDefIndex: 909
	{
		// Fields
		public Image flash; // 0x10

		// Constructors
		public __c__DisplayClass164_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__0(float v); // 0x0000000180597340-0x00000001805974C0
		internal void _PlayOpenFx_b__1(); // 0x00000001805974C0-0x0000000180597610
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass165_0 // TypeDefIndex: 910
	{
		// Fields
		public RectTransform prt; // 0x10
		public Image self; // 0x18
		public float startX; // 0x20
		public float drift; // 0x24

		// Constructors
		public __c__DisplayClass165_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayConfetti_b__0(float v); // 0x0000000180597610-0x00000001805978B0
		internal void _PlayConfetti_b__1(); // 0x00000001805978B0-0x0000000180597A00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass170_0 // TypeDefIndex: 911
	{
		// Fields
		public UnityEngine.UI.Text t; // 0x10

		// Constructors
		public __c__DisplayClass170_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetChipBlink_b__0(float a); // 0x0000000180597A00-0x0000000180597B80
	}

	[CompilerGenerated]
	private sealed class _PollLoop_d__144 : IEnumerator<object> // TypeDefIndex: 912
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRaidView __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PollLoop_d__144(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180597B80-0x0000000180597D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180597D50-0x0000000180597D90
	}

	[CompilerGenerated]
	private sealed class _RescaleRoutine_d__122 : IEnumerator<object> // TypeDefIndex: 913
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRaidView __4__this; // 0x20
		private int _i_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RescaleRoutine_d__122(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180597D90-0x0000000180597F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180597F90-0x0000000180597FD0
	}

	[CompilerGenerated]
	private sealed class _StartBattleRoutine_d__149 : IEnumerator<object> // TypeDefIndex: 914
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRaidView __4__this; // 0x20
		private __c__DisplayClass149_0 __8__1; // 0x28
		private float _tWs_5__2; // 0x30
		private GuildRaidBridge _bridge_5__3; // 0x38
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
		public _StartBattleRoutine_d__149(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180597FD0-0x00000001805981D0
		private bool MoveNext(); // 0x00000001805981D0-0x0000000180599710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180599710-0x0000000180599750
	}

	[CompilerGenerated]
	private sealed class _TickLoop_d__143 : IEnumerator<object> // TypeDefIndex: 915
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRaidView __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TickLoop_d__143(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180599750-0x00000001805998C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805998C0-0x0000000180599900
	}

	// Constructors
	public GuildRaidView(); // 0x0000000180596210-0x0000000180596510
	static GuildRaidView(); // 0x0000000180596510-0x0000000180596B90

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180582810-0x0000000180582870
	public void Open(); // 0x0000000180582870-0x0000000180582B40
	private void ShowOpenToastOnce(GuildRaidData d); // 0x0000000180582B40-0x0000000180582DA0
	private void ScheduleRescale(); // 0x0000000180582DA0-0x0000000180582F20
	[IteratorStateMachine(typeof(_RescaleRoutine_d__122))]
	private IEnumerator RescaleRoutine(); // 0x0000000180582F20-0x0000000180582FC0
	public void Close(); // 0x0000000180582FC0-0x00000001805830E0
	private void OnDisable(); // 0x00000001805830E0-0x0000000180583110
	private void BackToHall(); // 0x0000000180583110-0x0000000180583210
	public void Reload(); // 0x0000000180583210-0x00000001805835C0
	private void Render(GuildRaidData d); // 0x00000001805835C0-0x00000001805838F0
	private static RaidState ResolveState(GuildRaidData d); // 0x00000001805838F0-0x0000000180583B30
	private static int AttemptsLeft(GuildRaidData d); // 0x0000000180583B30-0x0000000180583B70
	private void ApplyState(); // 0x0000000180583B90-0x0000000180584B90
	private void RenderStage(GuildRaidData d); // 0x0000000180584B90-0x0000000180585970
	private static string HpSubLine(GuildRaidData d, long hpCur, long hpMax); // 0x0000000180585970-0x0000000180585BC0
	private void ApplyPetFloor(); // 0x0000000180585BC0-0x0000000180585CD0
	private void RenderRank(GuildRaidData d); // 0x0000000180585CD0-0x0000000180586800
	private static string MyName(GuildRaidData d); // 0x0000000180586800-0x0000000180586A70
	private static float MyPct(GuildRaidData d); // 0x0000000180586A70-0x0000000180586BA0
	private void RenderRewardStrip(GuildRaidData d); // 0x0000000180586BA0-0x0000000180587540
	private void RenderActionBar(GuildRaidData d); // 0x0000000180587540-0x0000000180587D20
	private void StartLoops(); // 0x0000000180587D20-0x0000000180587F70
	private void StopLoops(); // 0x0000000180587F70-0x00000001805880E0
	[IteratorStateMachine(typeof(_TickLoop_d__143))]
	private IEnumerator TickLoop(); // 0x00000001805880E0-0x0000000180588180
	[IteratorStateMachine(typeof(_PollLoop_d__144))]
	private IEnumerator PollLoop(); // 0x0000000180588180-0x0000000180588220
	private long NowServerMs(); // 0x0000000180588220-0x0000000180588290
	private void TickClock(); // 0x0000000180588290-0x0000000180588B60
	private void OnClickFight(); // 0x0000000180588B60-0x0000000180588EE0
	public void StartBattle(); // 0x0000000180588EE0-0x0000000180588FE0
	[IteratorStateMachine(typeof(_StartBattleRoutine_d__149))]
	private IEnumerator StartBattleRoutine(); // 0x0000000180588FE0-0x0000000180589080
	private void FailStart(string msg); // 0x0000000180589080-0x0000000180589150
	private void SetFightInteractable(bool on); // 0x0000000180589150-0x00000001805892F0
	private void OpenSchedule(); // 0x00000001805892F0-0x0000000180589670
	private void OpenRewards(); // 0x0000000180589670-0x0000000180589B80
	private void ClosePopups(); // 0x0000000180589B80-0x0000000180589F80
	private GuildRaidLoadoutPopup EnsureLoadoutPopup(); // 0x0000000180589F80-0x000000018058A1F0
	private void OpenPetPicker(); // 0x000000018058A1F0-0x000000018058A340
	private void OpenCardPicker(); // 0x000000018058A340-0x000000018058A490
	private void RenderLoadout(); // 0x000000018058A490-0x000000018058AAF0
	private static void SetSlotPlus(Button slot, bool empty); // 0x000000018058AAF0-0x000000018058ACF0
	private void OnClickSecondary(); // 0x000000018058ACF0-0x000000018058ADF0
	private void ShowHelp(); // 0x000000018058ADF0-0x000000018058B010
	private void Track(int id); // 0x000000018058B010-0x000000018058B0B0
	private void CancelFx(); // 0x000000018058B0B0-0x000000018058BB50
	private void PlayOpenFx(); // 0x000000018058BB50-0x000000018058C400
	private void PlayConfetti(); // 0x000000018058C400-0x000000018058CE20
	private void StartPulse(); // 0x000000018058CE20-0x000000018058D070
	private void StopPulse(); // 0x000000018058D070-0x000000018058D280
	private void SetChipBlink(bool on); // 0x000000018058D280-0x000000018058D5F0
	private void ReleasePet(); // 0x000000018058D5F0-0x000000018058D670
	private void EnsureBuilt(); // 0x000000018058D670-0x000000018058DE50
	private void SkinBackdrop(); // 0x000000018058DE50-0x000000018058E190
	private void HideLegacy(string nodeName); // 0x000000018058E190-0x000000018058E3A0
	private static RectTransform EnsureNode(Transform parent, string name); // 0x000000018058E3A0-0x000000018058E750
	private void BuildTitleBar(Font font); // 0x000000018058E750-0x000000018058F1E0
	private void BuildStage(Font font); // 0x000000018058F1E0-0x0000000180590D00
	private void BuildRankPanel(Font font); // 0x0000000180590D00-0x0000000180591B20
	private void BuildRewardStrip(Font font); // 0x0000000180591B20-0x0000000180592B00
	private void BuildLoadoutBar(Font font); // 0x0000000180592B00-0x0000000180593700
	private Button BuildLoadoutSlot(Transform parent, string name, Font font, Vector2 pos, Vector2 size, UnityAction onTap, out Image icon); // 0x0000000180593700-0x0000000180593B60
	private void BuildActionBar(Font font); // 0x0000000180593B60-0x0000000180594C00
	private GuildRaidRankRow EnsureRow(int index); // 0x0000000180594C00-0x0000000180595050
	private void ApplyPanelScale(); // 0x0000000180595050-0x0000000180595600
	private static float AvailableHalfWidth(Transform host); // 0x0000000180595600-0x00000001805959E0
	private static float AvailableHalfHeight(Transform host, out string source); // 0x00000001805959E0-0x0000000180596210
}

