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

public class GuildMembersPopup : GuildInfoPopup // TypeDefIndex: 811
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005EEA43
	private const float CARD_H = 720f; // Metadata: 0x005EEA47
	private const float CARD_L_X = 64f; // Metadata: 0x005EEA4B
	private const float CARD_L_W = 1130f; // Metadata: 0x005EEA4F
	private const float CARD_R_X = 1220f; // Metadata: 0x005EEA53
	private const float CARD_R_W = 490f; // Metadata: 0x005EEA57
	private const float HDR_Y = 22f; // Metadata: 0x005EEA5B
	private const float HDR_H = 40f; // Metadata: 0x005EEA5F
	private const float HDR_FS = 22f; // Metadata: 0x005EEA63
	private const float DIV_Y = 70f; // Metadata: 0x005EEA67
	private const float VP_X = 24f; // Metadata: 0x005EEA6B
	private const float VP_Y = 80f; // Metadata: 0x005EEA6F
	private const float VP_W = 1082f; // Metadata: 0x005EEA73
	private const float VP_H = 616f; // Metadata: 0x005EEA77
	private const float ROW_W = 1082f; // Metadata: 0x005EEA7B
	private const float ROW_H = 96f; // Metadata: 0x005EEA7F
	private const float ROW_GAP = 6f; // Metadata: 0x005EEA83
	private const float C_BADGE_X = 12f; // Metadata: 0x005EEA87
	private const float C_BADGE_Y = 24f; // Metadata: 0x005EEA8B
	private const float C_BADGE_D = 48f; // Metadata: 0x005EEA8F
	private const float C_AVA_X = 68f; // Metadata: 0x005EEA93
	private const float C_AVA_Y = 12f; // Metadata: 0x005EEA97
	private const float C_AVA_D = 72f; // Metadata: 0x005EEA9B
	private const float C_NAME_X = 156f; // Metadata: 0x005EEA9F
	private const float C_NAME_Y = 6f; // Metadata: 0x005EEAA3
	private const float C_NAME_W = 380f; // Metadata: 0x005EEAA7
	private const float C_NAME_H = 38f; // Metadata: 0x005EEAAB
	private const float C_SUB_Y = 46f; // Metadata: 0x005EEAAF
	private const float C_SUB_W = 396f; // Metadata: 0x005EEAB3
	private const float C_SUB_H = 30f; // Metadata: 0x005EEAB7
	private const float C_ROLE_X = 560f; // Metadata: 0x005EEABB
	private const float C_MID_Y = 30f; // Metadata: 0x005EEABF
	private const float C_ROLE_W = 150f; // Metadata: 0x005EEAC3
	private const float C_MID_H = 36f; // Metadata: 0x005EEAC7
	private const float C_POWER_X = 720f; // Metadata: 0x005EEACB
	private const float C_POWER_W = 160f; // Metadata: 0x005EEACF
	private const float C_CONTRIB_X = 890f; // Metadata: 0x005EEAD3
	private const float C_CONTRIB_W = 190f; // Metadata: 0x005EEAD7
	private const float C_CONTRIB_Y = 14f; // Metadata: 0x005EEADB
	private const float C_WEEK_Y = 52f; // Metadata: 0x005EEADF
	private const float C_WEEK_H = 28f; // Metadata: 0x005EEAE3
	private const float C_DOT_X = 124f; // Metadata: 0x005EEAE7
	private const float C_DOT_Y = 8f; // Metadata: 0x005EEAEB
	private const float C_DOT_D = 20f; // Metadata: 0x005EEAEF
	private const int MAX_ROWS = 100; // Metadata: 0x005EEAF3
	private const int ROWS_PER_FRAME = 8; // Metadata: 0x005EEAF5
	private const float R_PAD = 36f; // Metadata: 0x005EEAF6
	private const float R_INNER = 418f; // Metadata: 0x005EEAFA
	private const float R_FLAG_X = 185f; // Metadata: 0x005EEAFE
	private const float R_FLAG_Y = 74f; // Metadata: 0x005EEB02
	private const float R_FLAG_D = 120f; // Metadata: 0x005EEB06
	private const float R_NAME_Y = 202f; // Metadata: 0x005EEB0A
	private const float R_CHIP_Y = 248f; // Metadata: 0x005EEB0E
	private const float R_STAT_Y0 = 300f; // Metadata: 0x005EEB12
	private const float R_STAT_STEP = 52f; // Metadata: 0x005EEB16
	private const float R_STAT_H = 44f; // Metadata: 0x005EEB1A
	private const float R_EXP_LBL_Y = 562f; // Metadata: 0x005EEB1E
	private const float R_EXP_LBL_H = 28f; // Metadata: 0x005EEB22
	private const float R_BAR_Y = 592f; // Metadata: 0x005EEB26
	private const float R_BAR_H = 44f; // Metadata: 0x005EEB2A
	private const float R_FILL_INSET = 7f; // Metadata: 0x005EEB2E
	private const float R_FILL_H = 30f; // Metadata: 0x005EEB32
	private const float R_DIV_Y = 652f; // Metadata: 0x005EEB36
	private const float R_BTN_X = 95f; // Metadata: 0x005EEB3A
	private const float R_BTN_Y = 662f; // Metadata: 0x005EEB3E
	private const float R_BTN_W = 300f; // Metadata: 0x005EEB42
	private const float R_BTN_H = 54f; // Metadata: 0x005EEB46
	private const int LEVEL_MAX = 30; // Metadata: 0x005EEB4A
	private const float ACT_W = 470f; // Metadata: 0x005EEB4B
	private const float ACT_TOP = 124f; // Metadata: 0x005EEB4F
	private const float ACT_BTN_H = 68f; // Metadata: 0x005EEB53
	private const float ACT_STEP = 84f; // Metadata: 0x005EEB57
	private const float ACT_BTN_X = 70f; // Metadata: 0x005EEB5B
	private const float ACT_BTN_W = 330f; // Metadata: 0x005EEB5F
	private const float ACT_PAD_BOTTOM = 16f; // Metadata: 0x005EEB63
	private static readonly Color ROW_ODD; // 0x00
	private static readonly Color ROW_EVEN; // 0x10
	private static readonly Color ROW_MINE; // 0x20
	private static readonly Color MINE_EDGE; // 0x30
	private static readonly Color DOT_ON; // 0x40
	private static readonly Color DOT_OFF; // 0x50
	private static readonly Color POWER_COLOR; // 0x60
	private GuildPanelController _owner; // 0x70
	private bool _built; // 0x78
	private GuildDetailData _detail; // 0x80
	private int _myRole; // 0x88
	private int _slotPrice; // 0x8C
	private int _capMax; // 0x90
	private bool _buyingSlot; // 0x94
	private Coroutine _fillCo; // 0x98
	private RectTransform _listContent; // 0xA0
	private ScrollRect _scroll; // 0xA8
	private UnityEngine.UI.Text _txtEmpty; // 0xB0
	private readonly List<RowUi> _pool; // 0xB8
	private Flag _flag; // 0xC0
	private UnityEngine.UI.Text _txtName; // 0xD8
	private UnityEngine.UI.Text _txtLevel; // 0xE0
	private UnityEngine.UI.Text _statRank; // 0xE8
	private UnityEngine.UI.Text _statPoints; // 0xF0
	private UnityEngine.UI.Text _statMembers; // 0xF8
	private UnityEngine.UI.Text _statMaster; // 0x100
	private UnityEngine.UI.Text _statOnline; // 0x108
	private UnityEngine.UI.Text _txtExpLabel; // 0x110
	private UnityEngine.UI.Text _txtExp; // 0x118
	private Image _expFill; // 0x120
	private RectTransform _barRt; // 0x128
	private Button _btnSlot; // 0x130
	private UnityEngine.UI.Text _txtSlotLabel; // 0x138
	private RectTransform _actRoot; // 0x140
	private RectTransform _actBox; // 0x148
	private UnityEngine.UI.Text _actName; // 0x150
	private UnityEngine.UI.Text _actSub; // 0x158
	private Button _btnView; // 0x160
	private Button _btnFriend; // 0x168
	private Button _btnPromote; // 0x170
	private Button _btnDemote; // 0x178
	private Button _btnKick; // 0x180
	private GuildMemberItem _actTarget; // 0x188
	private GuildGuidePopup _guide; // 0x190

	// Nested types
	private class RowUi // TypeDefIndex: 812
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public Outline edge; // 0x20
		public GuildInfoPopup.Badge badge; // 0x28
		public Image dot; // 0x40
		public UnityEngine.UI.Text name; // 0x48
		public UnityEngine.UI.Text sub; // 0x50
		public UnityEngine.UI.Text role; // 0x58
		public UnityEngine.UI.Text power; // 0x60
		public UnityEngine.UI.Text contrib; // 0x68
		public UnityEngine.UI.Text week; // 0x70
		public GuildMemberItem data; // 0x78

		// Constructors
		public RowUi(); // 0x000000018028A320-0x000000018028A330
	}

	private enum ActionKind // TypeDefIndex: 813
	{
		View = 0,
		Friend = 1,
		Promote = 2,
		Demote = 3,
		Kick = 4
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 814
	{
		// Fields
		public GuildMembersPopup __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x0000000180544460-0x0000000180544490
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass150_0 // TypeDefIndex: 815
	{
		// Fields
		public GuildMemberItem m; // 0x10

		// Constructors
		public __c__DisplayClass150_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Act_b__0(); // 0x0000000180544490-0x00000001805445B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass152_0 // TypeDefIndex: 816
	{
		// Fields
		public GuildMembersPopup __4__this; // 0x10
		public string url; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildActionData> __9__1; // 0x28
		public Action __9__2; // 0x30

		// Constructors
		public __c__DisplayClass152_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Send_b__0(); // 0x00000001805445B0-0x0000000180544800
		internal void _Send_b__1(GuildActionData d); // 0x0000000180544800-0x0000000180544960
		internal void _Send_b__2(); // 0x0000000180544960-0x0000000180544990
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__131 : IEnumerator<object> // TypeDefIndex: 817
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildMembersPopup __4__this; // 0x20
		public List<GuildMemberItem> members; // 0x28
		public int n; // 0x30
		private Transform _artRoot_5__2; // 0x38
		private int _i_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FillRows_d__131(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180544990-0x0000000180544E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180544E80-0x0000000180544EC0
	}

	// Constructors
	public GuildMembersPopup(); // 0x0000000180543F60-0x00000001805440C0
	static GuildMembersPopup(); // 0x00000001805440C0-0x00000001805441E0

	// Methods
	public void Open(GuildPanelController owner, GuildDetailData detail); // 0x000000018053B520-0x000000018053B750
	public override void Hide(); // 0x000000018053B750-0x000000018053B780
	protected override void OnDisable(); // 0x000000018053B780-0x000000018053B7B0
	private void StopFill(); // 0x000000018053B7B0-0x000000018053B830
	private void Build(); // 0x000000018053B830-0x000000018053BCA0
	private void BuildHeader(RectTransform card); // 0x000000018053BCA0-0x000000018053C190
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x000000018053C190-0x000000018053C290
	private void BuildList(RectTransform card); // 0x000000018053C290-0x000000018053CB40
	private void BuildGuildCard(RectTransform card); // 0x000000018053CB40-0x000000018053DD90
	private UnityEngine.UI.Text Stat(RectTransform card, string name, int index, string label, string value, Color color); // 0x000000018053DD90-0x000000018053DE20
	public void Render(GuildDetailData detail); // 0x000000018053DE20-0x000000018053E280
	[IteratorStateMachine(typeof(_FillRows_d__131))]
	private IEnumerator FillRows(List<GuildMemberItem> members, int n); // 0x000000018053E280-0x000000018053E390
	private RowUi EnsureRow(int index); // 0x000000018053E390-0x000000018053E680
	private RowUi BuildRow(int index); // 0x000000018053E680-0x000000018053F6D0
	private void BindRow(RowUi r, GuildMemberItem m, int index, Sprite medal); // 0x000000018053F6D0-0x000000018053FDD0
	private static string SubLine(GuildMemberItem m); // 0x000000018053FDD0-0x00000001805400F0
	private void RenderGuildCard(GuildDetailData d); // 0x00000001805400F0-0x0000000180540450
	private void RenderExpBar(GuildInfo g); // 0x0000000180540450-0x0000000180540960
	private void RenderSlotButton(); // 0x0000000180540960-0x0000000180540D20
	private void OnClickBuySlot(); // 0x0000000180540D20-0x0000000180540F90
	private void BuySlot(); // 0x0000000180540F90-0x00000001805412D0
	private void OnClickHelp(); // 0x00000001805412D0-0x0000000180541580
	public void RaiseChildren(); // 0x0000000180541580-0x0000000180541680
	public void HideChildren(); // 0x0000000180541680-0x0000000180541790
	private void OpenActions(GuildMemberItem m); // 0x0000000180541790-0x0000000180542000
	private void CloseActions(); // 0x0000000180542000-0x0000000180542230
	private void LayoutActions(); // 0x0000000180542230-0x0000000180542790
	private void EnsureActions(); // 0x0000000180542790-0x00000001805433B0
	private Button ActionButton(string name, string label, Color tint, UnityAction onTap); // 0x00000001805433B0-0x00000001805434B0
	private void Act(ActionKind kind); // 0x00000001805434B0-0x0000000180543A30
	private void ShowBrief(GuildMemberItem m); // 0x0000000180543A30-0x0000000180543D80
	private void Send(string url, GuildMemberItem target, string confirmMsg); // 0x0000000180543D80-0x0000000180543F60
	[CompilerGenerated]
	private void _BuySlot_b__140_0(GuildBuySlotData d); // 0x00000001805441E0-0x00000001805443A0
	[CompilerGenerated]
	private void _BuySlot_b__140_1(); // 0x00000001805443A0-0x0000000180544410
	[CompilerGenerated]
	private void _EnsureActions_b__147_0(); // 0x0000000180544410-0x0000000180544420
	[CompilerGenerated]
	private void _EnsureActions_b__147_1(); // 0x0000000180544420-0x0000000180544430
	[CompilerGenerated]
	private void _EnsureActions_b__147_2(); // 0x0000000180544430-0x0000000180544440
	[CompilerGenerated]
	private void _EnsureActions_b__147_3(); // 0x0000000180544440-0x0000000180544450
	[CompilerGenerated]
	private void _EnsureActions_b__147_4(); // 0x0000000180544450-0x0000000180544460
}

