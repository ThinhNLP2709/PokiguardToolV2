/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildMemberRow : MonoBehaviour // TypeDefIndex: 809
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtStatus; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtRole; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtEloPve; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtEloPvp; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtPoint; // 0x48
	[SerializeField]
	private GameObject iconEloPve; // 0x50
	[SerializeField]
	private GameObject iconEloPvp; // 0x58
	[SerializeField]
	private Button btnDetail; // 0x60
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_OFFLINE; // 0x10
	private const int BADGE_MAX_RANK = 10; // Metadata: 0x005EFDCE
	private const int MOBILE_MIN_FONT = 24; // Metadata: 0x005EFDCF
	private const float DETAIL_TOUCH_SIDE = 72f; // Metadata: 0x005EFDD0
	private static readonly Color RANK_GOLD; // 0x20
	private static readonly Color RANK_SILVER; // 0x30
	private static readonly Color RANK_BRONZE; // 0x40
	private static readonly Color LC_COLOR; // 0x50
	private const float MID_X = 30f; // Metadata: 0x005EFDD4
	private const float MID_Y_STATUS = 25f; // Metadata: 0x005EFDD8
	private const float MID_Y_ROLE = 0f; // Metadata: 0x005EFDDC
	private const float MID_Y_RAID = -25f; // Metadata: 0x005EFDE0
	private const float MID_STEP = 25f; // Metadata: 0x005EFDE4
	private static readonly Vector2 MID_SIZE; // 0x60
	private const int MID_MIN_FONT = 13; // Metadata: 0x005EFDE8
	private const int MID_FONT = 18; // Metadata: 0x005EFDE9
	private static readonly Color RAID_GOLD; // 0x68
	private static readonly Color RAID_DIM; // 0x78
	private const string NODE_RANK = "txtGuildRank"; // Metadata: 0x005EFDEA
	private const string NODE_POWER = "txtGuildPower"; // Metadata: 0x005EFDF7
	private const string NODE_RAID = "txtGuildRaid"; // Metadata: 0x005EFE05
	private bool _wired; // 0x68
	private GuildMemberItem _data; // 0x70
	private UnityEngine.UI.Text _txtRank; // 0x78
	private UnityEngine.UI.Text _txtPower; // 0x80
	private UnityEngine.UI.Text _txtGuildRaid; // 0x88

	// Properties
	public GuildMemberItem Data { get; } // 0x00000001803C6D50-0x00000001803C6D60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 810
	{
		// Fields
		public Action<GuildMemberItem, RectTransform> onDetail; // 0x10
		public GuildMemberRow __4__this; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x000000018053C960-0x000000018053CA00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 811
	{
		// Fields
		public GuildMemberRow __4__this; // 0x10
		public Color target; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlashRole_b__0(float k); // 0x000000018053CA00-0x000000018053CBD0
		internal void _FlashRole_b__1(); // 0x000000018053CBD0-0x000000018053CD00
	}

	// Constructors
	public GuildMemberRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildMemberRow(); // 0x000000018053C850-0x000000018053C960

	// Methods
	private void Awake(); // 0x0000000180537F00-0x0000000180537F10
	private void EnsureWired(); // 0x0000000180537F10-0x0000000180538B40
	private void WidenDetailTouch(); // 0x0000000180538B40-0x00000001805392B0
	public void Bind(GuildMemberItem data, Action<GuildMemberItem, RectTransform> onDetail, int rank = 0 /* Metadata: 0x005EFDCC */); // 0x00000001805392B0-0x0000000180539B00
	private void NormalizeRowLayout(); // 0x0000000180539B00-0x0000000180539BF0
	private static void PlaceMidLine(UnityEngine.UI.Text t, float y); // 0x0000000180539BF0-0x0000000180539CA0
	private static void PlaceCentered(UnityEngine.UI.Text t, Vector2 pos, Vector2 size, TextAnchor align, int bestFitMin = 0 /* Metadata: 0x005EFDCD */); // 0x0000000180539CA0-0x000000018053A010
	private void ApplyRankBadge(int rank); // 0x000000018053A010-0x000000018053A520
	private void ApplyCombatPower(long combatPower); // 0x000000018053A520-0x000000018053A990
	private void ApplyGuildRaid(GuildMemberItem data); // 0x000000018053A990-0x000000018053B010
	private UnityEngine.UI.Text EnsureRankNode(); // 0x000000018053B010-0x000000018053B5C0
	private UnityEngine.UI.Text EnsurePowerNode(); // 0x000000018053B5C0-0x000000018053BAA0
	private UnityEngine.UI.Text EnsureGuildRaidNode(); // 0x000000018053BAA0-0x000000018053BF10
	private static UnityEngine.UI.Text CloneText(UnityEngine.UI.Text sample, Transform parent, string nodeName); // 0x000000018053BF10-0x000000018053C4D0
	public void FlashRole(); // 0x000000018053C4D0-0x000000018053C850
}

