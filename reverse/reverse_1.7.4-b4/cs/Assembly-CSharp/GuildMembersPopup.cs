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

public class GuildMembersPopup : GuildInfoPopup // TypeDefIndex: 812
{
	// Fields
	private const float CARD_Y = 118f; // Metadata: 0x005EFE12
	private const float CARD_H = 720f; // Metadata: 0x005EFE16
	private const float CARD_L_X = 64f; // Metadata: 0x005EFE1A
	private const float CARD_L_W = 1130f; // Metadata: 0x005EFE1E
	private const float CARD_R_X = 1220f; // Metadata: 0x005EFE22
	private const float CARD_R_W = 490f; // Metadata: 0x005EFE26
	private const float HDR_Y = 22f; // Metadata: 0x005EFE2A
	private const float HDR_H = 40f; // Metadata: 0x005EFE2E
	private const float HDR_FS = 22f; // Metadata: 0x005EFE32
	private const float DIV_Y = 70f; // Metadata: 0x005EFE36
	private const float VP_X = 24f; // Metadata: 0x005EFE3A
	private const float VP_Y = 80f; // Metadata: 0x005EFE3E
	private const float VP_W = 1082f; // Metadata: 0x005EFE42
	private const float VP_H = 616f; // Metadata: 0x005EFE46
	private const float ROW_W = 1082f; // Metadata: 0x005EFE4A
	private const float ROW_H = 96f; // Metadata: 0x005EFE4E
	private const float ROW_GAP = 6f; // Metadata: 0x005EFE52
	private const float C_BADGE_X = 12f; // Metadata: 0x005EFE56
	private const float C_BADGE_Y = 24f; // Metadata: 0x005EFE5A
	private const float C_BADGE_D = 48f; // Metadata: 0x005EFE5E
	private const float C_AVA_X = 68f; // Metadata: 0x005EFE62
	private const float C_AVA_Y = 12f; // Metadata: 0x005EFE66
	private const float C_AVA_D = 72f; // Metadata: 0x005EFE6A
	private const float C_NAME_X = 156f; // Metadata: 0x005EFE6E
	private const float C_NAME_Y = 6f; // Metadata: 0x005EFE72
	private const float C_NAME_W = 380f; // Metadata: 0x005EFE76
	private const float C_NAME_H = 38f; // Metadata: 0x005EFE7A
	private const float C_SUB_Y = 46f; // Metadata: 0x005EFE7E
	private const float C_SUB_W = 396f; // Metadata: 0x005EFE82
	private const float C_SUB_H = 30f; // Metadata: 0x005EFE86
	private const float C_ROLE_X = 560f; // Metadata: 0x005EFE8A
	private const float C_MID_Y = 30f; // Metadata: 0x005EFE8E
	private const float C_ROLE_W = 150f; // Metadata: 0x005EFE92
	private const float C_MID_H = 36f; // Metadata: 0x005EFE96
	private const float C_POWER_X = 720f; // Metadata: 0x005EFE9A
	private const float C_POWER_W = 160f; // Metadata: 0x005EFE9E
	private const float C_CONTRIB_X = 890f; // Metadata: 0x005EFEA2
	private const float C_CONTRIB_W = 190f; // Metadata: 0x005EFEA6
	private const float C_CONTRIB_Y = 14f; // Metadata: 0x005EFEAA
	private const float C_WEEK_Y = 52f; // Metadata: 0x005EFEAE
	private const float C_WEEK_H = 28f; // Metadata: 0x005EFEB2
	private const float C_DOT_X = 124f; // Metadata: 0x005EFEB6
	private const float C_DOT_Y = 8f; // Metadata: 0x005EFEBA
	private const float C_DOT_D = 20f; // Metadata: 0x005EFEBE
	private const int MAX_ROWS = 100; // Metadata: 0x005EFEC2
	private const int ROWS_PER_FRAME = 8; // Metadata: 0x005EFEC4
	private const float R_PAD = 36f; // Metadata: 0x005EFEC5
	private const float R_INNER = 418f; // Metadata: 0x005EFEC9
	private const float R_FLAG_X = 185f; // Metadata: 0x005EFECD
	private const float R_FLAG_Y = 74f; // Metadata: 0x005EFED1
	private const float R_FLAG_D = 120f; // Metadata: 0x005EFED5
	private const float R_NAME_Y = 202f; // Metadata: 0x005EFED9
	private const float R_CHIP_Y = 248f; // Metadata: 0x005EFEDD
	private const float R_STAT_Y0 = 300f; // Metadata: 0x005EFEE1
	private const float R_STAT_STEP = 52f; // Metadata: 0x005EFEE5
	private const float R_STAT_H = 44f; // Metadata: 0x005EFEE9
	private const float R_EXP_LBL_Y = 562f; // Metadata: 0x005EFEED
	private const float R_EXP_LBL_H = 28f; // Metadata: 0x005EFEF1
	private const float R_BAR_Y = 592f; // Metadata: 0x005EFEF5
	private const float R_BAR_H = 44f; // Metadata: 0x005EFEF9
	private const float R_FILL_INSET = 7f; // Metadata: 0x005EFEFD
	private const float R_FILL_H = 30f; // Metadata: 0x005EFF01
	private const float R_DIV_Y = 652f; // Metadata: 0x005EFF05
	private const float R_BTN_X = 95f; // Metadata: 0x005EFF09
	private const float R_BTN_Y = 662f; // Metadata: 0x005EFF0D
	private const float R_BTN_W = 300f; // Metadata: 0x005EFF11
	private const float R_BTN_H = 54f; // Metadata: 0x005EFF15
	private const float ACT_W = 470f; // Metadata: 0x005EFF19
	private const float ACT_TOP = 124f; // Metadata: 0x005EFF1D
	private const float ACT_BTN_H = 68f; // Metadata: 0x005EFF21
	private const float ACT_STEP = 84f; // Metadata: 0x005EFF25
	private const float ACT_BTN_X = 70f; // Metadata: 0x005EFF29
	private const float ACT_BTN_W = 330f; // Metadata: 0x005EFF2D
	private const float ACT_PAD_BOTTOM = 16f; // Metadata: 0x005EFF31
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
	private class RowUi // TypeDefIndex: 813
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

	private enum ActionKind // TypeDefIndex: 814
	{
		View = 0,
		Friend = 1,
		Promote = 2,
		Demote = 3,
		Kick = 4
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass132_0 // TypeDefIndex: 815
	{
		// Fields
		public GuildMembersPopup __4__this; // 0x10
		public RowUi r; // 0x18

		// Constructors
		public __c__DisplayClass132_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x0000000180545C50-0x0000000180545C80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 816
	{
		// Fields
		public GuildMemberItem m; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Act_b__0(); // 0x0000000180545C80-0x0000000180545DA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass151_0 // TypeDefIndex: 817
	{
		// Fields
		public GuildMembersPopup __4__this; // 0x10
		public string url; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildActionData> __9__1; // 0x28
		public Action __9__2; // 0x30

		// Constructors
		public __c__DisplayClass151_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Send_b__0(); // 0x0000000180545DA0-0x0000000180545FF0
		internal void _Send_b__1(GuildActionData d); // 0x0000000180545FF0-0x0000000180546150
		internal void _Send_b__2(); // 0x0000000180546150-0x0000000180546180
	}

	[CompilerGenerated]
	private sealed class _FillRows_d__130 : IEnumerator<object> // TypeDefIndex: 818
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
		public _FillRows_d__130(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180546180-0x0000000180546670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180546670-0x00000001805466B0
	}

	// Constructors
	public GuildMembersPopup(); // 0x0000000180545750-0x00000001805458B0
	static GuildMembersPopup(); // 0x00000001805458B0-0x00000001805459D0

	// Methods
	public void Open(GuildPanelController owner, GuildDetailData detail); // 0x000000018053CD00-0x000000018053CF30
	public override void Hide(); // 0x000000018053CF30-0x000000018053CF60
	protected override void OnDisable(); // 0x000000018053CF60-0x000000018053CF90
	private void StopFill(); // 0x000000018053CF90-0x000000018053D010
	private void Build(); // 0x000000018053D010-0x000000018053D480
	private void BuildHeader(RectTransform card); // 0x000000018053D480-0x000000018053D970
	private void Head(RectTransform card, string name, float x, float w, string label, TextAnchor align); // 0x000000018053D970-0x000000018053DA70
	private void BuildList(RectTransform card); // 0x000000018053DA70-0x000000018053E320
	private void BuildGuildCard(RectTransform card); // 0x000000018053E320-0x000000018053F570
	private UnityEngine.UI.Text Stat(RectTransform card, string name, int index, string label, string value, Color color); // 0x000000018053F570-0x000000018053F600
	public void Render(GuildDetailData detail); // 0x000000018053F600-0x000000018053FA60
	[IteratorStateMachine(typeof(_FillRows_d__130))]
	private IEnumerator FillRows(List<GuildMemberItem> members, int n); // 0x000000018053FA60-0x000000018053FB70
	private RowUi EnsureRow(int index); // 0x000000018053FB70-0x000000018053FE60
	private RowUi BuildRow(int index); // 0x000000018053FE60-0x0000000180540EB0
	private void BindRow(RowUi r, GuildMemberItem m, int index, Sprite medal); // 0x0000000180540EB0-0x00000001805415B0
	private static string SubLine(GuildMemberItem m); // 0x00000001805415B0-0x00000001805418D0
	private void RenderGuildCard(GuildDetailData d); // 0x00000001805418D0-0x0000000180541C30
	private void RenderExpBar(GuildInfo g); // 0x0000000180541C30-0x0000000180542150
	private void RenderSlotButton(); // 0x0000000180542150-0x0000000180542510
	private void OnClickBuySlot(); // 0x0000000180542510-0x0000000180542780
	private void BuySlot(); // 0x0000000180542780-0x0000000180542AC0
	private void OnClickHelp(); // 0x0000000180542AC0-0x0000000180542D70
	public void RaiseChildren(); // 0x0000000180542D70-0x0000000180542E70
	public void HideChildren(); // 0x0000000180542E70-0x0000000180542F80
	private void OpenActions(GuildMemberItem m); // 0x0000000180542F80-0x00000001805437F0
	private void CloseActions(); // 0x00000001805437F0-0x0000000180543A20
	private void LayoutActions(); // 0x0000000180543A20-0x0000000180543F80
	private void EnsureActions(); // 0x0000000180543F80-0x0000000180544BA0
	private Button ActionButton(string name, string label, Color tint, UnityAction onTap); // 0x0000000180544BA0-0x0000000180544CA0
	private void Act(ActionKind kind); // 0x0000000180544CA0-0x0000000180545220
	private void ShowBrief(GuildMemberItem m); // 0x0000000180545220-0x0000000180545570
	private void Send(string url, GuildMemberItem target, string confirmMsg); // 0x0000000180545570-0x0000000180545750
	[CompilerGenerated]
	private void _BuySlot_b__139_0(GuildBuySlotData d); // 0x00000001805459D0-0x0000000180545B90
	[CompilerGenerated]
	private void _BuySlot_b__139_1(); // 0x0000000180545B90-0x0000000180545C00
	[CompilerGenerated]
	private void _EnsureActions_b__146_0(); // 0x0000000180545C00-0x0000000180545C10
	[CompilerGenerated]
	private void _EnsureActions_b__146_1(); // 0x0000000180545C10-0x0000000180545C20
	[CompilerGenerated]
	private void _EnsureActions_b__146_2(); // 0x0000000180545C20-0x0000000180545C30
	[CompilerGenerated]
	private void _EnsureActions_b__146_3(); // 0x0000000180545C30-0x0000000180545C40
	[CompilerGenerated]
	private void _EnsureActions_b__146_4(); // 0x0000000180545C40-0x0000000180545C50
}

