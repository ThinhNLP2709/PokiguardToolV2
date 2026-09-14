/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildDetailPopup : GuildInfoPopup // TypeDefIndex: 776
{
	// Fields
	private const float BOX_W = 1180f; // Metadata: 0x005EE72A
	private const float BOX_H = 760f; // Metadata: 0x005EE72E
	private const float VP_X = 50f; // Metadata: 0x005EE732
	private const float VP_Y = 350f; // Metadata: 0x005EE736
	private const float VP_W = 1080f; // Metadata: 0x005EE73A
	private const float VP_H = 300f; // Metadata: 0x005EE73E
	private const float MROW_H = 84f; // Metadata: 0x005EE742
	private const float MROW_GAP = 6f; // Metadata: 0x005EE746
	private const float MEDAL_D = 56f; // Metadata: 0x005EE74A
	private const int MAX_MEMBER_ROWS = 3; // Metadata: 0x005EE74E
	private static readonly Color DOT_ON; // 0x00
	private static readonly Color DOT_OFF; // 0x10
	private const float RCHIP_Y = 350f; // Metadata: 0x005EE74F
	private const float RVP_X = 50f; // Metadata: 0x005EE753
	private const float RVP_Y = 418f; // Metadata: 0x005EE757
	private const float RVP_W = 1080f; // Metadata: 0x005EE75B
	private const float RVP_H = 232f; // Metadata: 0x005EE75F
	private const float RROW_H = 46f; // Metadata: 0x005EE763
	private const float RROW_GAP = 4f; // Metadata: 0x005EE767
	private const int MAX_RAID_ROWS = 14; // Metadata: 0x005EE76B
	private static readonly Color TODAY_BG; // 0x20
	private static readonly Color PILL_NONE; // 0x30
	private GuildPanelController _owner; // 0x70
	private long _guildId; // 0x78
	private Action<long, bool> _onRequestChanged; // 0x80
	private bool _built; // 0x88
	private bool _pending; // 0x89
	private bool _flying; // 0x8A
	private RectTransform _body; // 0x90
	private UnityEngine.UI.Text _txtLoading; // 0x98
	private Flag _flag; // 0xA0
	private UnityEngine.UI.Text _txtName; // 0xB8
	private UnityEngine.UI.Text _txtLevel; // 0xC0
	private UnityEngine.UI.Text _txtRank; // 0xC8
	private UnityEngine.UI.Text _txtSlogan; // 0xD0
	private UnityEngine.UI.Text _valPoints; // 0xD8
	private UnityEngine.UI.Text _valMembers; // 0xE0
	private UnityEngine.UI.Text _valMaster; // 0xE8
	private UnityEngine.UI.Text _valOnline; // 0xF0
	private RectTransform _memberContent; // 0xF8
	private UnityEngine.UI.Text _txtMembersEmpty; // 0x100
	private readonly List<MemberUi> _pool; // 0x108
	private Button _btnJoin; // 0x110
	private Button _btnCancel; // 0x118
	private UnityEngine.UI.Text _txtRelation; // 0x120
	private RectTransform _grpMembers; // 0x128
	private RectTransform _grpRaid; // 0x130
	private UnityEngine.UI.Text _txtRaidSub; // 0x138
	private UnityEngine.UI.Text _txtRaidEmpty; // 0x140
	private UnityEngine.UI.Text _valRaidKills; // 0x148
	private UnityEngine.UI.Text _valRaidDays; // 0x150
	private UnityEngine.UI.Text _valRaidWeek; // 0x158
	private UnityEngine.UI.Text _valRaidBest; // 0x160
	private RectTransform _raidContent; // 0x168
	private readonly List<RaidUi> _raidPool; // 0x170

	// Nested types
	private class RaidUi // TypeDefIndex: 777
	{
		// Fields
		public RectTransform root; // 0x10
		public Image bg; // 0x18
		public Image icon; // 0x20
		public Image pill; // 0x28
		public UnityEngine.UI.Text date; // 0x30
		public UnityEngine.UI.Text boss; // 0x38
		public UnityEngine.UI.Text status; // 0x40
		public UnityEngine.UI.Text damage; // 0x48
		public UnityEngine.UI.Text part; // 0x50

		// Constructors
		public RaidUi(); // 0x000000018028A320-0x000000018028A330
	}

	private class MemberUi // TypeDefIndex: 778
	{
		// Fields
		public RectTransform root; // 0x10
		public GuildInfoPopup.Badge badge; // 0x18
		public Image avatar; // 0x30
		public Image dot; // 0x38
		public UnityEngine.UI.Text name; // 0x40
		public UnityEngine.UI.Text role; // 0x48
		public UnityEngine.UI.Text level; // 0x50
		public UnityEngine.UI.Text power; // 0x58

		// Constructors
		public MemberUi(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 779
	{
		// Fields
		public GuildDetailPopup __4__this; // 0x10
		public bool requested; // 0x18
		public string okMessage; // 0x20

		// Constructors
		public __c__DisplayClass82_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Send_b__0(GuildActionData _); // 0x0000000180504570-0x00000001805046C0
	}

	// Constructors
	public GuildDetailPopup(); // 0x0000000180504160-0x00000001805043C0
	static GuildDetailPopup(); // 0x00000001805043C0-0x0000000180504490

	// Methods
	public void Open(GuildPanelController owner, long guildId, Action<long, bool> onRequestChanged = null); // 0x00000001804FB430-0x00000001804FB550
	private void Build(); // 0x00000001804FB550-0x00000001804FBB20
	private void BuildHead(); // 0x00000001804FBB20-0x00000001804FC0A0
	private void BuildStatChips(); // 0x00000001804FC0A0-0x00000001804FC900
	private UnityEngine.UI.Text StatChip(Transform parent, string name, float x, float y, string label); // 0x00000001804FC900-0x00000001804FCB40
	private void BuildMemberList(); // 0x00000001804FCB40-0x00000001804FD3A0
	private void BuildRaidBlock(); // 0x00000001804FD3A0-0x00000001804FE2A0
	private void BuildFooter(); // 0x00000001804FE2A0-0x00000001804FE7B0
	private void ShowLoading(); // 0x00000001804FE7B0-0x00000001804FEA20
	private void Fetch(); // 0x00000001804FEA20-0x00000001804FED70
	private void Render(GuildDetailData d); // 0x00000001804FED70-0x00000001804FF820
	private bool IsMine(GuildInfo g); // 0x00000001804FF820-0x00000001804FF980
	private void RenderMembers(GuildDetailData d); // 0x00000001804FF980-0x00000001804FFF10
	private MemberUi EnsureMemberRow(int index); // 0x00000001804FFF10-0x0000000180500200
	private MemberUi BuildMemberRow(int index); // 0x0000000180500200-0x0000000180500AE0
	private void BindMember(MemberUi r, GuildMemberItem m, int rank, Sprite medal); // 0x0000000180500AE0-0x0000000180501070
	private void RenderRaid(GuildDetailData d); // 0x0000000180501070-0x0000000180501990
	private RaidUi EnsureRaidRow(int index); // 0x0000000180501990-0x0000000180501C80
	private RaidUi BuildRaidRow(int index); // 0x0000000180501C80-0x0000000180502720
	private void BindRaid(RaidUi r, GuildRaidHistoryRow m); // 0x0000000180502720-0x00000001805030D0
	private void RenderFooter(); // 0x00000001805030D0-0x0000000180503400
	private void SetButtons(bool join, bool cancel); // 0x0000000180503400-0x00000001805036A0
	private void SetRelation(string text, bool besideButton); // 0x00000001805036A0-0x0000000180503970
	private void OnClickJoin(); // 0x0000000180503970-0x0000000180503B50
	private void OnClickCancel(); // 0x0000000180503B50-0x0000000180503D30
	private void Send(string url, bool requested, string okMessage); // 0x0000000180503D30-0x00000001805040B0
	private void Unlock(); // 0x00000001805040B0-0x0000000180504140
	protected override void OnDisable(); // 0x0000000180504140-0x0000000180504160
	[CompilerGenerated]
	private void _Fetch_b__66_0(string err); // 0x0000000180504490-0x0000000180504520
}

