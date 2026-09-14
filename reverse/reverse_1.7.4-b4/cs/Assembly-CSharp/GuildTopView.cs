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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildTopView : GuildInfoPopup // TypeDefIndex: 942
{
	// Fields
	private const float CARD_L_X = 64f; // Metadata: 0x005F0239
	private const float CARD_Y = 118f; // Metadata: 0x005F023D
	private const float CARD_L_W = 1130f; // Metadata: 0x005F0241
	private const float CARD_H = 720f; // Metadata: 0x005F0245
	private const float CARD_R_X = 1220f; // Metadata: 0x005F0249
	private const float CARD_R_W = 490f; // Metadata: 0x005F024D
	private const float HDR_Y = 22f; // Metadata: 0x005F0251
	private const float HDR_H = 40f; // Metadata: 0x005F0255
	private const float HDR_FS = 22f; // Metadata: 0x005F0259
	private const float DIV_Y = 70f; // Metadata: 0x005F025D
	private const float VP_X = 24f; // Metadata: 0x005F0261
	private const float VP_Y = 80f; // Metadata: 0x005F0265
	private const float VP_W = 1082f; // Metadata: 0x005F0269
	private const float VP_H = 616f; // Metadata: 0x005F026D
	private const float ROW_W = 1082f; // Metadata: 0x005F0271
	private const float ROW_H = 76f; // Metadata: 0x005F0275
	private const float ROW_GAP = 6f; // Metadata: 0x005F0279
	private const float R_BADGE_X = 12f; // Metadata: 0x005F027D
	private const float R_BADGE_Y = 16f; // Metadata: 0x005F0281
	private const float R_BADGE_D = 44f; // Metadata: 0x005F0285
	private const float R_FLAG_X = 76f; // Metadata: 0x005F0289
	private const float R_FLAG_Y = 12f; // Metadata: 0x005F028D
	private const float R_FLAG_D = 52f; // Metadata: 0x005F0291
	private const float R_NAME_X = 144f; // Metadata: 0x005F0295
	private const float R_NAME_Y = 4f; // Metadata: 0x005F0299
	private const float R_NAME_W = 400f; // Metadata: 0x005F029D
	private const float R_NAME_H = 36f; // Metadata: 0x005F02A1
	private const float R_SLOGAN_X = 144f; // Metadata: 0x005F02A5
	private const float R_SLOGAN_Y = 42f; // Metadata: 0x005F02A9
	private const float R_SLOGAN_W = 420f; // Metadata: 0x005F02AD
	private const float R_SLOGAN_H = 30f; // Metadata: 0x005F02B1
	private const float R_CHIP_X = 580f; // Metadata: 0x005F02B5
	private const float R_CHIP_Y = 20f; // Metadata: 0x005F02B9
	private const float R_CHIP_W = 100f; // Metadata: 0x005F02BD
	private const float R_CHIP_H = 36f; // Metadata: 0x005F02C1
	private const float R_MEM_X = 700f; // Metadata: 0x005F02C5
	private const float R_MEM_W = 170f; // Metadata: 0x005F02C9
	private const float R_PTS_X = 890f; // Metadata: 0x005F02CD
	private const float R_PTS_W = 190f; // Metadata: 0x005F02D1
	private const float SEC_X = 36f; // Metadata: 0x005F02D5
	private const float SEC_W = 418f; // Metadata: 0x005F02D9
	private const float SEC_SEASON_Y = 22f; // Metadata: 0x005F02DD
	private const float SEC_SEASON_H = 36f; // Metadata: 0x005F02E1
	private const float CLOCK_Y = 64f; // Metadata: 0x005F02E5
	private const float CLOCK_H = 56f; // Metadata: 0x005F02E9
	private const float RW_Y0 = 130f; // Metadata: 0x005F02ED
	private const float RW_STEP = 62f; // Metadata: 0x005F02F1
	private const float RW_H = 56f; // Metadata: 0x005F02F5
	private const int RW_SLOTS = 3; // Metadata: 0x005F02F9
	private const float DIV_SEASON_Y = 322f; // Metadata: 0x005F02FA
	private const float GRP_Y = 330f; // Metadata: 0x005F02FE
	private const float GRP_H = 390f; // Metadata: 0x005F0302
	private const int MAX_ROWS = 20; // Metadata: 0x005F0306
	private const string ST_SETTLING = "SETTLING"; // Metadata: 0x005F0307
	private const string ST_PAUSED = "PAUSED"; // Metadata: 0x005F0310
	private const long CLOCK_URGENT_SEC = 3600; // Metadata: 0x005F0317
	private const float SETTLE_REFETCH_SEC = 20f; // Metadata: 0x005F031F
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color ROW_MINE; // 0x20
	private static readonly Color MINE_EDGE; // 0x30
	private static readonly Color TOP_GLOW; // 0x40
	private const float GLOW_MIN = 0.35f; // Metadata: 0x005F0323
	private const float GLOW_MAX = 0.85f; // Metadata: 0x005F0327
	private const float GLOW_SEC = 2f; // Metadata: 0x005F032B
	private const float BREATH_SCALE = 1.05f; // Metadata: 0x005F032F
	private const float BREATH_SEC = 0.6f; // Metadata: 0x005F0333
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
	private class RowUi // TypeDefIndex: 943
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

	private class RewardUi // TypeDefIndex: 944
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
		public RewardUi(); // 0x00000001805C4380-0x00000001805C4390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 945
	{
		// Fields
		public GuildTopView __4__this; // 0x10
		public int slot; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRewardRow_b__0(); // 0x00000001805C4390-0x00000001805C4440
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 946
	{
		// Fields
		public GuildTopView __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass121_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x00000001805C4440-0x00000001805C4570
	}

	[CompilerGenerated]
	private sealed class _ClockLoop_d__131 : IEnumerator<object> // TypeDefIndex: 947
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
		public _ClockLoop_d__131(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001805C4570-0x00000001805C4750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805C4750-0x00000001805C4790
	}

	// Constructors
	public GuildTopView(); // 0x00000001805C3E20-0x00000001805C4120
	static GuildTopView(); // 0x00000001805C4120-0x00000001805C41D0

	// Methods
	public void Open(GuildPanelController owner); // 0x00000001805B96C0-0x00000001805B9740
	public void Refetch(); // 0x00000001805B9740-0x00000001805B9770
	private void Build(); // 0x00000001805B9770-0x00000001805BA270
	private void BuildHeader(RectTransform card); // 0x00000001805BA270-0x00000001805BA760
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x00000001805BA760-0x00000001805BA860
	private void BuildList(RectTransform card); // 0x00000001805BA860-0x00000001805BB2C0
	private void BuildSeasonBlock(RectTransform card); // 0x00000001805BB2C0-0x00000001805BB9D0
	private RewardUi BuildRewardRow(RectTransform card, int index); // 0x00000001805BB9D0-0x00000001805BC250
	private Button BuildMineCard(RectTransform card); // 0x00000001805BC250-0x00000001805BD0E0
	private Button BuildNoGuildCard(RectTransform card); // 0x00000001805BD0E0-0x00000001805BD490
	private void Fetch(); // 0x00000001805BD490-0x00000001805BD7B0
	private void SetLoadingLabel(bool on); // 0x00000001805BD7B0-0x00000001805BDA50
	private bool HasVisibleRows(); // 0x00000001805BDA50-0x00000001805BDC40
	private void Render(GuildTopGuildsData d); // 0x00000001805BDC40-0x00000001805BE4F0
	private RowUi EnsureRow(int index); // 0x00000001805BE4F0-0x00000001805BE7E0
	private RowUi BuildRow(int index); // 0x00000001805BE7E0-0x00000001805BF6B0
	private void BindRow(RowUi r, GuildTopGuildRow data, int index); // 0x00000001805BF6B0-0x00000001805BFC60
	private Sprite MedalFor(int rank); // 0x00000001805BFC60-0x00000001805BFCB0
	private void RenderSeason(GuildTopGuildsData d); // 0x00000001805BFCB0-0x00000001805C01D0
	private void BindReward(RewardUi u, GuildSeasonReward r, bool show); // 0x00000001805C01D0-0x00000001805C0780
	private void ShowSeason(bool on); // 0x00000001805C0780-0x00000001805C0B40
	private void UpdateHint(); // 0x00000001805C0B40-0x00000001805C0DA0
	private long RemainSec(); // 0x00000001805C0DA0-0x00000001805C0E30
	private void StartClock(); // 0x00000001805C0E30-0x00000001805C0FF0
	private void StopClock(); // 0x00000001805C0FF0-0x00000001805C1080
	[IteratorStateMachine(typeof(_ClockLoop_d__131))]
	private IEnumerator ClockLoop(); // 0x00000001805C1080-0x00000001805C1120
	private void ApplyClock(); // 0x00000001805C1120-0x00000001805C1650
	private void Track(int id); // 0x00000001805C1650-0x00000001805C1700
	private void StartBreath(); // 0x00000001805C1700-0x00000001805C19C0
	private void StopBreath(); // 0x00000001805C19C0-0x00000001805C1C10
	private void ApplyTopGlow(); // 0x00000001805C1C10-0x00000001805C1E30
	private void SetGlowAlpha(float a); // 0x00000001805C1E30-0x00000001805C2090
	private void CancelFx(); // 0x00000001805C2090-0x00000001805C2320
	private void RenderMine(GuildTopGuildsData d); // 0x00000001805C2320-0x00000001805C28B0
	private void RenderLast(GuildSeasonLast last); // 0x00000001805C28B0-0x00000001805C2C10
	private void RenderVault(GuildVaultBrief v); // 0x00000001805C2C10-0x00000001805C2F20
	private void ShowVaultEntry(bool on); // 0x00000001805C2F20-0x00000001805C3290
	private void OnClickMyGuild(); // 0x00000001805C3290-0x00000001805C33C0
	private void OnClickVault(); // 0x00000001805C33C0-0x00000001805C34C0
	private void OnClickTicket(int slot); // 0x00000001805C34C0-0x00000001805C3560
	private void OnClickHelp(); // 0x00000001805C3560-0x00000001805C38A0
	private List<GuildGuidePopup.Section> GuideSections(); // 0x00000001805C38A0-0x00000001805C3BC0
	public void RaiseChildren(); // 0x00000001805C3BC0-0x00000001805C3CC0
	public void HideChildren(); // 0x00000001805C3CC0-0x00000001805C3DC0
	public override void Hide(); // 0x00000001805C3DC0-0x00000001805C3DF0
	protected override void OnDisable(); // 0x00000001805C3DF0-0x00000001805C3E20
	[CompilerGenerated]
	private void _Fetch_b__116_0(GuildTopGuildsData d); // 0x00000001805C41D0-0x00000001805C4210
	[CompilerGenerated]
	private void _Fetch_b__116_1(string err); // 0x00000001805C4210-0x00000001805C4290
	[CompilerGenerated]
	private void _ApplyTopGlow_b__136_0(float a); // 0x00000001805C4290-0x00000001805C42A0
}

