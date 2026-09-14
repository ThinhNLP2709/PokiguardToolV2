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

public class GuildGuidePopup : GuildInfoPopup // TypeDefIndex: 793
{
	// Fields
	private const float BOX_W = 1400f; // Metadata: 0x005EFBF0
	private const float BOX_H = 780f; // Metadata: 0x005EFBF4
	private const float VP_X = 40f; // Metadata: 0x005EFBF8
	private const float VP_Y = 92f; // Metadata: 0x005EFBFC
	private const float VP_W = 1320f; // Metadata: 0x005EFC00
	private const float VP_H = 648f; // Metadata: 0x005EFC04
	private const float HEAD_FS = 30f; // Metadata: 0x005EFC08
	private const float BODY_FS = 24f; // Metadata: 0x005EFC0C
	private const float DIV_H = 2f; // Metadata: 0x005EFC10
	private static readonly Color BODY_COLOR; // 0x00
	private bool _built; // 0x70
	private RectTransform _content; // 0x78

	// Nested types
	public struct Section // TypeDefIndex: 794
	{
		// Fields
		public string head; // 0x00
		public string body; // 0x08
	}

	// Constructors
	public GuildGuidePopup(); // 0x000000018028A560-0x000000018028A5B0
	static GuildGuidePopup(); // 0x0000000180516920-0x0000000180516970

	// Methods
	public void Open(GuildPanelController owner, GuildDetailData detail); // 0x0000000180511820-0x0000000180511960
	public void Open(GuildPanelController owner, string title, List<Section> sections); // 0x0000000180511960-0x00000001805119D0
	private void SetTitle(string title); // 0x00000001805119D0-0x0000000180511B00
	private void Build(); // 0x0000000180511B00-0x0000000180512290
	private void Fill(GuildPanelController owner, GuildDetailData d); // 0x0000000180512290-0x0000000180512310
	private void Fill(List<Section> secs); // 0x0000000180512310-0x0000000180512A90
	private void AddHeading(int index, string label); // 0x0000000180512A90-0x0000000180512C20
	private void AddBody(int index, string body); // 0x0000000180512C20-0x0000000180512E10
	private void AddDivider(int index); // 0x0000000180512E10-0x0000000180512FC0
	private static void Wrap(UnityEngine.UI.Text t); // 0x0000000180512FC0-0x0000000180513180
	private static List<Section> BuildSections(GuildPanelController owner, GuildDetailData d); // 0x0000000180513180-0x0000000180513BA0
	public static void Add(List<Section> list, string head, string body); // 0x0000000180513BA0-0x0000000180513CE0
	public static List<Section> SectionsForTop(int seasonNo, int cycleDays, [TupleElementNames(new string[5] {"rankFrom", "rankTo", "gold", "ticketCount", "ticketLabel" })] IList<ValueTuple<int, int, long, int, string>> rewards, bool ticketPerMember, int minMemberDays, bool vaultOn); // 0x0000000180513CE0-0x0000000180514170
	private static string SeasonBody(int seasonNo, int cycleDays); // 0x0000000180514170-0x0000000180514420
	private static string RewardBody([TupleElementNames(new string[5] {"rankFrom", "rankTo", "gold", "ticketCount", "ticketLabel" })] IList<ValueTuple<int, int, long, int, string>> rewards); // 0x0000000180514420-0x0000000180514C80
	private static string WhoBody(bool ticketPerMember, int minMemberDays); // 0x0000000180514C80-0x0000000180514F60
	public static List<Section> SectionsForVault(long gold, int membersCount, long equalShare, long minPerMember, bool canDistribute, bool canManual); // 0x0000000180514F60-0x0000000180515400
	private static string VaultWhatBody(long gold); // 0x0000000180515400-0x0000000180515610
	private static string EqualBody(int membersCount, long equalShare); // 0x0000000180515610-0x0000000180515820
	private static string ManualBody(long minPerMember); // 0x0000000180515820-0x0000000180515A70
	private static string BuildLevelBody(GuildDetailData d); // 0x0000000180515A70-0x0000000180515FD0
	private static string BuildBossBody(GuildPanelController owner, GuildDetailData d); // 0x0000000180515FD0-0x0000000180516510
	private static int MyFreeAttempts(GuildPanelController owner, GuildDetailData d); // 0x0000000180516510-0x0000000180516680
	private static string BuildSlotBody(GuildDetailData d); // 0x0000000180516680-0x0000000180516920
}

