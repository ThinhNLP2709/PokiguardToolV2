/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildDetailPopup : GuildInfoPopup // TypeDefIndex: 777
{
	// Fields
	private const float BOX_W = 1180f; // Metadata: 0x005EFAFA
	private const float BOX_H = 760f; // Metadata: 0x005EFAFE
	private const float VP_X = 50f; // Metadata: 0x005EFB02
	private const float VP_Y = 350f; // Metadata: 0x005EFB06
	private const float VP_W = 1080f; // Metadata: 0x005EFB0A
	private const float VP_H = 300f; // Metadata: 0x005EFB0E
	private const float MROW_H = 84f; // Metadata: 0x005EFB12
	private const float MROW_GAP = 6f; // Metadata: 0x005EFB16
	private const float MEDAL_D = 56f; // Metadata: 0x005EFB1A
	private const int MAX_MEMBER_ROWS = 3; // Metadata: 0x005EFB1E
	private static readonly Color DOT_ON; // 0x00
	private static readonly Color DOT_OFF; // 0x10
	private const float RCHIP_Y = 350f; // Metadata: 0x005EFB1F
	private const float RVP_X = 50f; // Metadata: 0x005EFB23
	private const float RVP_Y = 418f; // Metadata: 0x005EFB27
	private const float RVP_W = 1080f; // Metadata: 0x005EFB2B
	private const float RVP_H = 232f; // Metadata: 0x005EFB2F
	private const float RROW_H = 46f; // Metadata: 0x005EFB33
	private const float RROW_GAP = 4f; // Metadata: 0x005EFB37
	private const int MAX_RAID_ROWS = 14; // Metadata: 0x005EFB3B
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
	private class RaidUi // TypeDefIndex: 778
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

	private class MemberUi // TypeDefIndex: 779
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
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 780
	{
		// Fields
		public GuildDetailPopup __4__this; // 0x10
		public bool requested; // 0x18
		public string okMessage; // 0x20

		// Constructors
		public __c__DisplayClass82_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Send_b__0(GuildActionData _); // 0x0000000180505D10-0x0000000180505E60
	}

	// Constructors
	public GuildDetailPopup(); // 0x0000000180505900-0x0000000180505B60
	static GuildDetailPopup(); // 0x0000000180505B60-0x0000000180505C30

	// Methods
	public void Open(GuildPanelController owner, long guildId, Action<long, bool> onRequestChanged = null); // 0x00000001804FCBD0-0x00000001804FCCF0
	private void Build(); // 0x00000001804FCCF0-0x00000001804FD2C0
	private void BuildHead(); // 0x00000001804FD2C0-0x00000001804FD840
	private void BuildStatChips(); // 0x00000001804FD840-0x00000001804FE0A0
	private UnityEngine.UI.Text StatChip(Transform parent, string name, float x, float y, string label); // 0x00000001804FE0A0-0x00000001804FE2E0
	private void BuildMemberList(); // 0x00000001804FE2E0-0x00000001804FEB40
	private void BuildRaidBlock(); // 0x00000001804FEB40-0x00000001804FFA40
	private void BuildFooter(); // 0x00000001804FFA40-0x00000001804FFF50
	private void ShowLoading(); // 0x00000001804FFF50-0x00000001805001C0
	private void Fetch(); // 0x00000001805001C0-0x0000000180500510
	private void Render(GuildDetailData d); // 0x0000000180500510-0x0000000180500FC0
	private bool IsMine(GuildInfo g); // 0x0000000180500FC0-0x0000000180501120
	private void RenderMembers(GuildDetailData d); // 0x0000000180501120-0x00000001805016B0
	private MemberUi EnsureMemberRow(int index); // 0x00000001805016B0-0x00000001805019A0
	private MemberUi BuildMemberRow(int index); // 0x00000001805019A0-0x0000000180502280
	private void BindMember(MemberUi r, GuildMemberItem m, int rank, Sprite medal); // 0x0000000180502280-0x0000000180502810
	private void RenderRaid(GuildDetailData d); // 0x0000000180502810-0x0000000180503130
	private RaidUi EnsureRaidRow(int index); // 0x0000000180503130-0x0000000180503420
	private RaidUi BuildRaidRow(int index); // 0x0000000180503420-0x0000000180503EC0
	private void BindRaid(RaidUi r, GuildRaidHistoryRow m); // 0x0000000180503EC0-0x0000000180504870
	private void RenderFooter(); // 0x0000000180504870-0x0000000180504BA0
	private void SetButtons(bool join, bool cancel); // 0x0000000180504BA0-0x0000000180504E40
	private void SetRelation(string text, bool besideButton); // 0x0000000180504E40-0x0000000180505110
	private void OnClickJoin(); // 0x0000000180505110-0x00000001805052F0
	private void OnClickCancel(); // 0x00000001805052F0-0x00000001805054D0
	private void Send(string url, bool requested, string okMessage); // 0x00000001805054D0-0x0000000180505850
	private void Unlock(); // 0x0000000180505850-0x00000001805058E0
	protected override void OnDisable(); // 0x00000001805058E0-0x0000000180505900
	[CompilerGenerated]
	private void _Fetch_b__66_0(string err); // 0x0000000180505C30-0x0000000180505CC0
}

