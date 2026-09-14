/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildMemberRow : MonoBehaviour // TypeDefIndex: 808
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
	private const int BADGE_MAX_RANK = 10; // Metadata: 0x005EE9FF
	private const int MOBILE_MIN_FONT = 24; // Metadata: 0x005EEA00
	private const float DETAIL_TOUCH_SIDE = 72f; // Metadata: 0x005EEA01
	private static readonly Color RANK_GOLD; // 0x20
	private static readonly Color RANK_SILVER; // 0x30
	private static readonly Color RANK_BRONZE; // 0x40
	private static readonly Color LC_COLOR; // 0x50
	private const float MID_X = 30f; // Metadata: 0x005EEA05
	private const float MID_Y_STATUS = 25f; // Metadata: 0x005EEA09
	private const float MID_Y_ROLE = 0f; // Metadata: 0x005EEA0D
	private const float MID_Y_RAID = -25f; // Metadata: 0x005EEA11
	private const float MID_STEP = 25f; // Metadata: 0x005EEA15
	private static readonly Vector2 MID_SIZE; // 0x60
	private const int MID_MIN_FONT = 13; // Metadata: 0x005EEA19
	private const int MID_FONT = 18; // Metadata: 0x005EEA1A
	private static readonly Color RAID_GOLD; // 0x68
	private static readonly Color RAID_DIM; // 0x78
	private const string NODE_RANK = "txtGuildRank"; // Metadata: 0x005EEA1B
	private const string NODE_POWER = "txtGuildPower"; // Metadata: 0x005EEA28
	private const string NODE_RAID = "txtGuildRaid"; // Metadata: 0x005EEA36
	private bool _wired; // 0x68
	private GuildMemberItem _data; // 0x70
	private UnityEngine.UI.Text _txtRank; // 0x78
	private UnityEngine.UI.Text _txtPower; // 0x80
	private UnityEngine.UI.Text _txtGuildRaid; // 0x88

	// Properties
	public GuildMemberItem Data { get; } // 0x00000001803C6080-0x00000001803C6090 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 809
	{
		// Fields
		public Action<GuildMemberItem, RectTransform> onDetail; // 0x10
		public GuildMemberRow __4__this; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x000000018053B180-0x000000018053B220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 810
	{
		// Fields
		public GuildMemberRow __4__this; // 0x10
		public Color target; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlashRole_b__0(float k); // 0x000000018053B220-0x000000018053B3F0
		internal void _FlashRole_b__1(); // 0x000000018053B3F0-0x000000018053B520
	}

	// Constructors
	public GuildMemberRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildMemberRow(); // 0x000000018053B070-0x000000018053B180

	// Methods
	private void Awake(); // 0x0000000180536720-0x0000000180536730
	private void EnsureWired(); // 0x0000000180536730-0x0000000180537360
	private void WidenDetailTouch(); // 0x0000000180537360-0x0000000180537AD0
	public void Bind(GuildMemberItem data, Action<GuildMemberItem, RectTransform> onDetail, int rank = 0 /* Metadata: 0x005EE9FD */); // 0x0000000180537AD0-0x0000000180538320
	private void NormalizeRowLayout(); // 0x0000000180538320-0x0000000180538410
	private static void PlaceMidLine(UnityEngine.UI.Text t, float y); // 0x0000000180538410-0x00000001805384C0
	private static void PlaceCentered(UnityEngine.UI.Text t, Vector2 pos, Vector2 size, TextAnchor align, int bestFitMin = 0 /* Metadata: 0x005EE9FE */); // 0x00000001805384C0-0x0000000180538830
	private void ApplyRankBadge(int rank); // 0x0000000180538830-0x0000000180538D40
	private void ApplyCombatPower(long combatPower); // 0x0000000180538D40-0x00000001805391B0
	private void ApplyGuildRaid(GuildMemberItem data); // 0x00000001805391B0-0x0000000180539830
	private UnityEngine.UI.Text EnsureRankNode(); // 0x0000000180539830-0x0000000180539DE0
	private UnityEngine.UI.Text EnsurePowerNode(); // 0x0000000180539DE0-0x000000018053A2C0
	private UnityEngine.UI.Text EnsureGuildRaidNode(); // 0x000000018053A2C0-0x000000018053A730
	private static UnityEngine.UI.Text CloneText(UnityEngine.UI.Text sample, Transform parent, string nodeName); // 0x000000018053A730-0x000000018053ACF0
	public void FlashRole(); // 0x000000018053ACF0-0x000000018053B070
}

