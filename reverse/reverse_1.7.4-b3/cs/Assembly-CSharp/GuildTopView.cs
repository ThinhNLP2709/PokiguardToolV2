/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildTopView : GuildInfoPopup // TypeDefIndex: 940
{
	// Fields
	private const float CARD_L_X = 64f; // Metadata: 0x005EEE6B
	private const float CARD_Y = 118f; // Metadata: 0x005EEE6F
	private const float CARD_L_W = 1130f; // Metadata: 0x005EEE73
	private const float CARD_H = 720f; // Metadata: 0x005EEE77
	private const float CARD_R_X = 1220f; // Metadata: 0x005EEE7B
	private const float CARD_R_W = 490f; // Metadata: 0x005EEE7F
	private const float HDR_Y = 22f; // Metadata: 0x005EEE83
	private const float HDR_H = 40f; // Metadata: 0x005EEE87
	private const float HDR_FS = 22f; // Metadata: 0x005EEE8B
	private const float DIV_Y = 70f; // Metadata: 0x005EEE8F
	private const float VP_X = 24f; // Metadata: 0x005EEE93
	private const float VP_Y = 80f; // Metadata: 0x005EEE97
	private const float VP_W = 1082f; // Metadata: 0x005EEE9B
	private const float VP_H = 616f; // Metadata: 0x005EEE9F
	private const float ROW_W = 1082f; // Metadata: 0x005EEEA3
	private const float ROW_H = 76f; // Metadata: 0x005EEEA7
	private const float ROW_GAP = 6f; // Metadata: 0x005EEEAB
	private const float R_BADGE_X = 12f; // Metadata: 0x005EEEAF
	private const float R_BADGE_Y = 16f; // Metadata: 0x005EEEB3
	private const float R_BADGE_D = 44f; // Metadata: 0x005EEEB7
	private const float R_FLAG_X = 76f; // Metadata: 0x005EEEBB
	private const float R_FLAG_Y = 12f; // Metadata: 0x005EEEBF
	private const float R_FLAG_D = 52f; // Metadata: 0x005EEEC3
	private const float R_NAME_X = 144f; // Metadata: 0x005EEEC7
	private const float R_NAME_Y = 4f; // Metadata: 0x005EEECB
	private const float R_NAME_W = 400f; // Metadata: 0x005EEECF
	private const float R_NAME_H = 36f; // Metadata: 0x005EEED3
	private const float R_SLOGAN_X = 144f; // Metadata: 0x005EEED7
	private const float R_SLOGAN_Y = 42f; // Metadata: 0x005EEEDB
	private const float R_SLOGAN_W = 420f; // Metadata: 0x005EEEDF
	private const float R_SLOGAN_H = 30f; // Metadata: 0x005EEEE3
	private const float R_CHIP_X = 580f; // Metadata: 0x005EEEE7
	private const float R_CHIP_Y = 20f; // Metadata: 0x005EEEEB
	private const float R_CHIP_W = 100f; // Metadata: 0x005EEEEF
	private const float R_CHIP_H = 36f; // Metadata: 0x005EEEF3
	private const float R_MEM_X = 700f; // Metadata: 0x005EEEF7
	private const float R_MEM_W = 170f; // Metadata: 0x005EEEFB
	private const float R_PTS_X = 890f; // Metadata: 0x005EEEFF
	private const float R_PTS_W = 190f; // Metadata: 0x005EEF03
	private const float SEC_X = 36f; // Metadata: 0x005EEF07
	private const float SEC_W = 418f; // Metadata: 0x005EEF0B
	private const float SEC_SEASON_Y = 22f; // Metadata: 0x005EEF0F
	private const float SEC_SEASON_H = 36f; // Metadata: 0x005EEF13
	private const float CLOCK_Y = 64f; // Metadata: 0x005EEF17
	private const float CLOCK_H = 56f; // Metadata: 0x005EEF1B
	private const float RW_Y0 = 130f; // Metadata: 0x005EEF1F
	private const float RW_STEP = 62f; // Metadata: 0x005EEF23
	private const float RW_H = 56f; // Metadata: 0x005EEF27
	private const int RW_SLOTS = 3; // Metadata: 0x005EEF2B
	private const float DIV_SEASON_Y = 322f; // Metadata: 0x005EEF2C
	private const float GRP_Y = 330f; // Metadata: 0x005EEF30
	private const float GRP_H = 390f; // Metadata: 0x005EEF34
	private const int MAX_ROWS = 20; // Metadata: 0x005EEF38
	private const int LEVEL_MAX = 30; // Metadata: 0x005EEF39
	private const string ST_SETTLING = "SETTLING"; // Metadata: 0x005EEF3A
	private const string ST_PAUSED = "PAUSED"; // Metadata: 0x005EEF43
	private const long CLOCK_URGENT_SEC = 3600; // Metadata: 0x005EEF4A
	private const float SETTLE_REFETCH_SEC = 20f; // Metadata: 0x005EEF52
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color ROW_MINE; // 0x20
	private static readonly Color MINE_EDGE; // 0x30
	private static readonly Color TOP_GLOW; // 0x40
	private const float GLOW_MIN = 0.35f; // Metadata: 0x005EEF56
	private const float GLOW_MAX = 0.85f; // Metadata: 0x005EEF5A
	private const float GLOW_SEC = 2f; // Metadata: 0x005EEF5E
	private const float BREATH_SCALE = 1.05f; // Metadata: 0x005EEF62
	private const float BREATH_SEC = 0.6f; // Metadata: 0x005EEF66
	private GuildPanelController _owner; // 0x70
	private bool _built; // 0x78
	private bool _loading; // 0x79
	private RectTransform _listContent; // 0x80
	private UnityEngine.UI.Text _txtEmpty; // 0x88
	private UnityEngine.UI.Text _txtLoading; // 0x90
	private UnityEngine.UI.Text _txtHint; // 0x98
	private readonly List<RowUi> _pool; // 0xA0
	private readonly Sprite[] _medal; // 0xA8
	private UnityEngine.UI.Text _secSeason; // 0xB0
	private Image _clockChip; // 0xB8
	private UnityEngine.UI.Text _txtClockLabel; // 0xC0
	private UnityEngine.UI.Text _txtClock; // 0xC8
	private readonly RewardUi[] _rewards; // 0xD0
	private RectTransform _grpMine; // 0xD8
	private RectTransform _grpNoGuild; // 0xE0
	private Flag _flagMine; // 0xE8
	private UnityEngine.UI.Text _txtMineName; // 0x100
	private UnityEngine.UI.Text _txtMineLevel; // 0x108
	private UnityEngine.UI.Text _statRank; // 0x110
	private UnityEngine.UI.Text _statPoints; // 0x118
	private Button _btnVault; // 0x120
	private Image _dotVault; // 0x128
	private UnityEngine.UI.Text _txtVault; // 0x130
	private UnityEngine.UI.Text _txtLast; // 0x138
	private GuildGuidePopup _guide; // 0x140
	private GuildSeasonInfo _season; // 0x148
	private GuildVaultBrief _vaultBrief; // 0x150
	private long _endSec; // 0x158
	private long _serverNowSec; // 0x160
	private float _syncAt; // 0x168
	private Coroutine _clockCo; // 0x170
	private int _settleAskedSeason; // 0x178
	private float _settleAt; // 0x17C
	private readonly List<int> _tweens; // 0x180
	private int _glowId; // 0x188
	private int _breathId; // 0x18C

	// Nested types
	private class RowUi // TypeDefIndex: 941
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public Outline edge; // 0x20
		public Outline glow; // 0x28
		public GuildInfoPopup.Badge badge; // 0x30
		public GuildInfoPopup.Flag flag; // 0x48
		public UnityEngine.UI.Text name; // 0x60
		public UnityEngine.UI.Text slogan; // 0x68
		public UnityEngine.UI.Text level; // 0x70
		public UnityEngine.UI.Text members; // 0x78
		public UnityEngine.UI.Text points; // 0x80
		public long guildId; // 0x88

		// Constructors
		public RowUi(); // 0x000000018028A320-0x000000018028A330
	}

	private class RewardUi // TypeDefIndex: 942
	{
		// Fields
		public RectTransform root; // 0x10
		public GuildInfoPopup.Badge badge; // 0x18
		public Image iconGold; // 0x30
		public UnityEngine.UI.Text txtGold; // 0x38
		public RectTransform ticketRt; // 0x40
		public Image iconTicket; // 0x48
		public UnityEngine.UI.Text txtTicket; // 0x50
		public int tier; // 0x58

		// Constructors
		public RewardUi(); // 0x00000001805C2A20-0x00000001805C2A30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 943
	{
		// Fields
		public GuildTopView __4__this; // 0x10
		public int slot; // 0x18

		// Constructors
		public __c__DisplayClass114_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRewardRow_b__0(); // 0x00000001805C2A30-0x00000001805C2AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass122_0 // TypeDefIndex: 944
	{
		// Fields
		public GuildTopView __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass122_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x00000001805C2AE0-0x00000001805C2C10
	}

	[CompilerGenerated]
	private sealed class _ClockLoop_d__132 : IEnumerator<object> // TypeDefIndex: 945
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildTopView __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClockLoop_d__132(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001805C2C10-0x00000001805C2DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805C2DF0-0x00000001805C2E30
	}

	// Constructors
	public GuildTopView(); // 0x00000001805C24C0-0x00000001805C27C0
	static GuildTopView(); // 0x00000001805C27C0-0x00000001805C2870

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805B7D60-0x00000001805B7DE0
	public void Refetch(); // 0x00000001805B7DE0-0x00000001805B7E10
	private void Build(); // 0x00000001805B7E10-0x00000001805B8910
	private void BuildHeader(RectTransform card); // 0x00000001805B8910-0x00000001805B8E00
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x00000001805B8E00-0x00000001805B8F00
	private void BuildList(RectTransform card); // 0x00000001805B8F00-0x00000001805B9960
	private void BuildSeasonBlock(RectTransform card); // 0x00000001805B9960-0x00000001805BA070
	private RewardUi BuildRewardRow(RectTransform card, int index); // 0x00000001805BA070-0x00000001805BA8F0
	private Button BuildMineCard(RectTransform card); // 0x00000001805BA8F0-0x00000001805BB780
	private Button BuildNoGuildCard(RectTransform card); // 0x00000001805BB780-0x00000001805BBB30
	private void Fetch(); // 0x00000001805BBB30-0x00000001805BBE50
	private void SetLoadingLabel(bool on); // 0x00000001805BBE50-0x00000001805BC0F0
	private bool HasVisibleRows(); // 0x00000001805BC0F0-0x00000001805BC2E0
	private void Render(GuildTopGuildsData d); // 0x00000001805BC2E0-0x00000001805BCB90
	private RowUi EnsureRow(int index); // 0x00000001805BCB90-0x00000001805BCE80
	private RowUi BuildRow(int index); // 0x00000001805BCE80-0x00000001805BDD50
	private void BindRow(RowUi r, GuildTopGuildRow data, int index); // 0x00000001805BDD50-0x00000001805BE300
	private Sprite MedalFor(int rank); // 0x00000001805BE300-0x00000001805BE350
	private void RenderSeason(GuildTopGuildsData d); // 0x00000001805BE350-0x00000001805BE870
	private void BindReward(RewardUi u, GuildSeasonReward r, bool show); // 0x00000001805BE870-0x00000001805BEE20
	private void ShowSeason(bool on); // 0x00000001805BEE20-0x00000001805BF1E0
	private void UpdateHint(); // 0x00000001805BF1E0-0x00000001805BF440
	private long RemainSec(); // 0x00000001805BF440-0x00000001805BF4D0
	private void StartClock(); // 0x00000001805BF4D0-0x00000001805BF690
	private void StopClock(); // 0x00000001805BF690-0x00000001805BF720
	[IteratorStateMachine(typeof(_ClockLoop_d__132))]
	private IEnumerator ClockLoop(); // 0x00000001805BF720-0x00000001805BF7C0
	private void ApplyClock(); // 0x00000001805BF7C0-0x00000001805BFCF0
	private void Track(int id); // 0x00000001805BFCF0-0x00000001805BFDA0
	private void StartBreath(); // 0x00000001805BFDA0-0x00000001805C0060
	private void StopBreath(); // 0x00000001805C0060-0x00000001805C02B0
	private void ApplyTopGlow(); // 0x00000001805C02B0-0x00000001805C04D0
	private void SetGlowAlpha(float a); // 0x00000001805C04D0-0x00000001805C0730
	private void CancelFx(); // 0x00000001805C0730-0x00000001805C09C0
	private void RenderMine(GuildTopGuildsData d); // 0x00000001805C09C0-0x00000001805C0F50
	private void RenderLast(GuildSeasonLast last); // 0x00000001805C0F50-0x00000001805C12B0
	private void RenderVault(GuildVaultBrief v); // 0x00000001805C12B0-0x00000001805C15C0
	private void ShowVaultEntry(bool on); // 0x00000001805C15C0-0x00000001805C1930
	private void OnClickMyGuild(); // 0x00000001805C1930-0x00000001805C1A60
	private void OnClickVault(); // 0x00000001805C1A60-0x00000001805C1B60
	private void OnClickTicket(int slot); // 0x00000001805C1B60-0x00000001805C1C00
	private void OnClickHelp(); // 0x00000001805C1C00-0x00000001805C1F40
	private List<GuildGuidePopup.Section> GuideSections(); // 0x00000001805C1F40-0x00000001805C2260
	public void RaiseChildren(); // 0x00000001805C2260-0x00000001805C2360
	public void HideChildren(); // 0x00000001805C2360-0x00000001805C2460
	public override void Hide(); // 0x00000001805C2460-0x00000001805C2490
	protected override void OnDisable(); // 0x00000001805C2490-0x00000001805C24C0
	[CompilerGenerated]
	private void _Fetch_b__117_0(GuildTopGuildsData d); // 0x00000001805C2870-0x00000001805C28B0
	[CompilerGenerated]
	private void _Fetch_b__117_1(string err); // 0x00000001805C28B0-0x00000001805C2930
	[CompilerGenerated]
	private void _ApplyTopGlow_b__137_0(float a); // 0x00000001805C2930-0x00000001805C2940
}

