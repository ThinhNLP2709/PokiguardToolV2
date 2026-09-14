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
public class GuildRaidView : MonoBehaviour // TypeDefIndex: 900
{
	// Fields
	public const float RAID_W = 953f; // Metadata: 0x005EECDC
	public const float RAID_H = 556f; // Metadata: 0x005EECE0
	private const float PANEL_SCALE = 1.28f; // Metadata: 0x005EECE4
	private const float CONTENT_HALF_H = 283f; // Metadata: 0x005EECE8
	private const float CONTENT_HALF_W = 478f; // Metadata: 0x005EECEC
	private const float TITLE_Y = 228f; // Metadata: 0x005EECF0
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
	public const float STAGE_PET_BOX = 150f; // Metadata: 0x005EECF4
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
	private const string TICKET_ICON = "Image/item/9010"; // Metadata: 0x005EECF8
	private static readonly Color DOT_ON; // 0x110
	private static readonly Color DOT_OFF; // 0x120
	private const int ATTEMPT_DOTS = 5; // Metadata: 0x005EED08
	public const string PREF_AUTO_FIGHT = "GuildRaidAutoFight"; // Metadata: 0x005EED09
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
	private const float BTN_HELP_LONG = 52f; // Metadata: 0x005EED1C
	private static readonly Vector2 BTN_PLUS_SIZE; // 0x144
	private const float BTN_PLUS_LONG = 44f; // Metadata: 0x005EED20
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
	private const float LO_CARD_X0 = -180f; // Metadata: 0x005EED24
	private const float LO_CARD_STEP = 62f; // Metadata: 0x005EED28
	private static readonly Vector2 P_LO_COUNT; // 0x1E4
	private static readonly Vector2 S_LO_COUNT; // 0x1EC
	private static readonly Vector2 P_LO_BTN; // 0x1F4
	private static float _lastGoodScale; // 0x1FC

	// Properties
	private static bool Live { get; } // 0x0000000180580E30-0x0000000180580EB0 
	private bool HasBoss { get; } // 0x0000000180582210-0x0000000180582230 

	// Nested types
	private enum RaidState // TypeDefIndex: 901
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
	private sealed class __c // TypeDefIndex: 902
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__126_0; // 0x08
		public static Action<string> __9__153_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180595230-0x00000001805952D0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__126_0(string err); // 0x00000001805952D0-0x0000000180595340
		internal void _OpenRewards_b__153_1(string err); // 0x0000000180595340-0x00000001805953B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 903
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
		internal void _RenderStage_b__0(float v); // 0x00000001805953B0-0x00000001805955D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 904
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
		internal void _StartBattleRoutine_b__0(); // 0x0000000180308BA0-0x0000000180308BB0
		internal void _StartBattleRoutine_b__1(string r); // 0x0000000180308BB0-0x0000000180308C10
		internal void _StartBattleRoutine_b__2(ChatMessageDTO _); // 0x00000001805955D0-0x00000001805955E0
		internal void _StartBattleRoutine_b__3(ChatMessageDTO m); // 0x00000001805955E0-0x0000000180595650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass153_0 // TypeDefIndex: 905
	{
		// Fields
		public GuildRaidView __4__this; // 0x10
		public int bossPet; // 0x18

		// Constructors
		public __c__DisplayClass153_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenRewards_b__0(GuildRaidRewardsData d); // 0x0000000180595650-0x0000000180595780
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 906
	{
		// Fields
		public RectTransform srt; // 0x10
		public Vector2 home; // 0x18

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__2(float v); // 0x0000000180595780-0x00000001805958D0
		internal void _PlayOpenFx_b__3(); // 0x00000001805958D0-0x00000001805959E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_1 // TypeDefIndex: 907
	{
		// Fields
		public Image flash; // 0x10

		// Constructors
		public __c__DisplayClass164_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayOpenFx_b__0(float v); // 0x00000001805959E0-0x0000000180595B60
		internal void _PlayOpenFx_b__1(); // 0x0000000180595B60-0x0000000180595CB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass165_0 // TypeDefIndex: 908
	{
		// Fields
		public RectTransform prt; // 0x10
		public Image self; // 0x18
		public float startX; // 0x20
		public float drift; // 0x24

		// Constructors
		public __c__DisplayClass165_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayConfetti_b__0(float v); // 0x0000000180595CB0-0x0000000180595F50
		internal void _PlayConfetti_b__1(); // 0x0000000180595F50-0x00000001805960A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass170_0 // TypeDefIndex: 909
	{
		// Fields
		public UnityEngine.UI.Text t; // 0x10

		// Constructors
		public __c__DisplayClass170_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetChipBlink_b__0(float a); // 0x00000001805960A0-0x0000000180596220
	}

	[CompilerGenerated]
	private sealed class _PollLoop_d__144 : IEnumerator<object> // TypeDefIndex: 910
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
		private bool MoveNext(); // 0x0000000180596220-0x00000001805963F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805963F0-0x0000000180596430
	}

	[CompilerGenerated]
	private sealed class _RescaleRoutine_d__122 : IEnumerator<object> // TypeDefIndex: 911
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180596430-0x0000000180596630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180596630-0x0000000180596670
	}

	[CompilerGenerated]
	private sealed class _StartBattleRoutine_d__149 : IEnumerator<object> // TypeDefIndex: 912
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
		void IDisposable.Dispose(); // 0x0000000180596670-0x0000000180596870
		private bool MoveNext(); // 0x0000000180596870-0x0000000180597DB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180597DB0-0x0000000180597DF0
	}

	[CompilerGenerated]
	private sealed class _TickLoop_d__143 : IEnumerator<object> // TypeDefIndex: 913
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
		private bool MoveNext(); // 0x0000000180597DF0-0x0000000180597F60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180597F60-0x0000000180597FA0
	}

	// Constructors
	public GuildRaidView(); // 0x00000001805948B0-0x0000000180594BB0
	static GuildRaidView(); // 0x0000000180594BB0-0x0000000180595230

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180580EB0-0x0000000180580F10
	public void Open(); // 0x0000000180580F10-0x00000001805811E0
	private void ShowOpenToastOnce(GuildRaidData d); // 0x00000001805811E0-0x0000000180581440
	private void ScheduleRescale(); // 0x0000000180581440-0x00000001805815C0
	[IteratorStateMachine(typeof(_RescaleRoutine_d__122))]
	private IEnumerator RescaleRoutine(); // 0x00000001805815C0-0x0000000180581660
	public void Close(); // 0x0000000180581660-0x0000000180581780
	private void OnDisable(); // 0x0000000180581780-0x00000001805817B0
	private void BackToHall(); // 0x00000001805817B0-0x00000001805818B0
	public void Reload(); // 0x00000001805818B0-0x0000000180581C60
	private void Render(GuildRaidData d); // 0x0000000180581C60-0x0000000180581F90
	private static RaidState ResolveState(GuildRaidData d); // 0x0000000180581F90-0x00000001805821D0
	private static int AttemptsLeft(GuildRaidData d); // 0x00000001805821D0-0x0000000180582210
	private void ApplyState(); // 0x0000000180582230-0x0000000180583230
	private void RenderStage(GuildRaidData d); // 0x0000000180583230-0x0000000180584010
	private static string HpSubLine(GuildRaidData d, long hpCur, long hpMax); // 0x0000000180584010-0x0000000180584260
	private void ApplyPetFloor(); // 0x0000000180584260-0x0000000180584370
	private void RenderRank(GuildRaidData d); // 0x0000000180584370-0x0000000180584EA0
	private static string MyName(GuildRaidData d); // 0x0000000180584EA0-0x0000000180585110
	private static float MyPct(GuildRaidData d); // 0x0000000180585110-0x0000000180585240
	private void RenderRewardStrip(GuildRaidData d); // 0x0000000180585240-0x0000000180585BE0
	private void RenderActionBar(GuildRaidData d); // 0x0000000180585BE0-0x00000001805863C0
	private void StartLoops(); // 0x00000001805863C0-0x0000000180586610
	private void StopLoops(); // 0x0000000180586610-0x0000000180586780
	[IteratorStateMachine(typeof(_TickLoop_d__143))]
	private IEnumerator TickLoop(); // 0x0000000180586780-0x0000000180586820
	[IteratorStateMachine(typeof(_PollLoop_d__144))]
	private IEnumerator PollLoop(); // 0x0000000180586820-0x00000001805868C0
	private long NowServerMs(); // 0x00000001805868C0-0x0000000180586930
	private void TickClock(); // 0x0000000180586930-0x0000000180587200
	private void OnClickFight(); // 0x0000000180587200-0x0000000180587580
	public void StartBattle(); // 0x0000000180587580-0x0000000180587680
	[IteratorStateMachine(typeof(_StartBattleRoutine_d__149))]
	private IEnumerator StartBattleRoutine(); // 0x0000000180587680-0x0000000180587720
	private void FailStart(string msg); // 0x0000000180587720-0x00000001805877F0
	private void SetFightInteractable(bool on); // 0x00000001805877F0-0x0000000180587990
	private void OpenSchedule(); // 0x0000000180587990-0x0000000180587D10
	private void OpenRewards(); // 0x0000000180587D10-0x0000000180588220
	private void ClosePopups(); // 0x0000000180588220-0x0000000180588620
	private GuildRaidLoadoutPopup EnsureLoadoutPopup(); // 0x0000000180588620-0x0000000180588890
	private void OpenPetPicker(); // 0x0000000180588890-0x00000001805889E0
	private void OpenCardPicker(); // 0x00000001805889E0-0x0000000180588B30
	private void RenderLoadout(); // 0x0000000180588B30-0x0000000180589190
	private static void SetSlotPlus(Button slot, bool empty); // 0x0000000180589190-0x0000000180589390
	private void OnClickSecondary(); // 0x0000000180589390-0x0000000180589490
	private void ShowHelp(); // 0x0000000180589490-0x00000001805896B0
	private void Track(int id); // 0x00000001805896B0-0x0000000180589750
	private void CancelFx(); // 0x0000000180589750-0x000000018058A1F0
	private void PlayOpenFx(); // 0x000000018058A1F0-0x000000018058AAA0
	private void PlayConfetti(); // 0x000000018058AAA0-0x000000018058B4C0
	private void StartPulse(); // 0x000000018058B4C0-0x000000018058B710
	private void StopPulse(); // 0x000000018058B710-0x000000018058B920
	private void SetChipBlink(bool on); // 0x000000018058B920-0x000000018058BC90
	private void ReleasePet(); // 0x000000018058BC90-0x000000018058BD10
	private void EnsureBuilt(); // 0x000000018058BD10-0x000000018058C4F0
	private void SkinBackdrop(); // 0x000000018058C4F0-0x000000018058C830
	private void HideLegacy(string nodeName); // 0x000000018058C830-0x000000018058CA40
	private static RectTransform EnsureNode(Transform parent, string name); // 0x000000018058CA40-0x000000018058CDF0
	private void BuildTitleBar(Font font); // 0x000000018058CDF0-0x000000018058D880
	private void BuildStage(Font font); // 0x000000018058D880-0x000000018058F3A0
	private void BuildRankPanel(Font font); // 0x000000018058F3A0-0x00000001805901C0
	private void BuildRewardStrip(Font font); // 0x00000001805901C0-0x00000001805911A0
	private void BuildLoadoutBar(Font font); // 0x00000001805911A0-0x0000000180591DA0
	private Button BuildLoadoutSlot(Transform parent, string name, Font font, Vector2 pos, Vector2 size, UnityAction onTap, out Image icon); // 0x0000000180591DA0-0x0000000180592200
	private void BuildActionBar(Font font); // 0x0000000180592200-0x00000001805932A0
	private GuildRaidRankRow EnsureRow(int index); // 0x00000001805932A0-0x00000001805936F0
	private void ApplyPanelScale(); // 0x00000001805936F0-0x0000000180593CA0
	private static float AvailableHalfWidth(Transform host); // 0x0000000180593CA0-0x0000000180594080
	private static float AvailableHalfHeight(Transform host, out string source); // 0x0000000180594080-0x00000001805948B0
}

