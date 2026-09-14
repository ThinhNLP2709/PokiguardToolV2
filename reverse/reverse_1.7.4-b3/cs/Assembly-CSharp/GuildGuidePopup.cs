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

public class GuildGuidePopup : GuildInfoPopup // TypeDefIndex: 792
{
	// Fields
	private const float BOX_W = 1400f; // Metadata: 0x005EE820
	private const float BOX_H = 780f; // Metadata: 0x005EE824
	private const float VP_X = 40f; // Metadata: 0x005EE828
	private const float VP_Y = 92f; // Metadata: 0x005EE82C
	private const float VP_W = 1320f; // Metadata: 0x005EE830
	private const float VP_H = 648f; // Metadata: 0x005EE834
	private const float HEAD_FS = 30f; // Metadata: 0x005EE838
	private const float BODY_FS = 24f; // Metadata: 0x005EE83C
	private const float DIV_H = 2f; // Metadata: 0x005EE840
	private static readonly Color BODY_COLOR; // 0x00
	private bool _built; // 0x70
	private RectTransform _content; // 0x78

	// Nested types
	public struct Section // TypeDefIndex: 793
	{
		// Fields
		public string head; // 0x00
		public string body; // 0x08
	}

	// Constructors
	public GuildGuidePopup(); // 0x000000018028A560-0x000000018028A5B0
	static GuildGuidePopup(); // 0x0000000180515180-0x00000001805151D0

	// Methods
	public void Open(GuildPanelController owner, GuildDetailData detail); // 0x0000000180510080-0x00000001805101C0
	public void Open(GuildPanelController owner, string title, List<Section> sections); // 0x00000001805101C0-0x0000000180510230
	private void SetTitle(string title); // 0x0000000180510230-0x0000000180510360
	private void Build(); // 0x0000000180510360-0x0000000180510AF0
	private void Fill(GuildPanelController owner, GuildDetailData d); // 0x0000000180510AF0-0x0000000180510B70
	private void Fill(List<Section> secs); // 0x0000000180510B70-0x00000001805112F0
	private void AddHeading(int index, string label); // 0x00000001805112F0-0x0000000180511480
	private void AddBody(int index, string body); // 0x0000000180511480-0x0000000180511670
	private void AddDivider(int index); // 0x0000000180511670-0x0000000180511820
	private static void Wrap(UnityEngine.UI.Text t); // 0x0000000180511820-0x00000001805119E0
	private static List<Section> BuildSections(GuildPanelController owner, GuildDetailData d); // 0x00000001805119E0-0x0000000180512400
	public static void Add(List<Section> list, string head, string body); // 0x0000000180512400-0x0000000180512540
	public static List<Section> SectionsForTop(int seasonNo, int cycleDays, [TupleElementNames(new string[5] {"rankFrom", "rankTo", "gold", "ticketCount", "ticketLabel" })] IList<ValueTuple<int, int, long, int, string>> rewards, bool ticketPerMember, int minMemberDays, bool vaultOn); // 0x0000000180512540-0x00000001805129D0
	private static string SeasonBody(int seasonNo, int cycleDays); // 0x00000001805129D0-0x0000000180512C80
	private static string RewardBody([TupleElementNames(new string[5] {"rankFrom", "rankTo", "gold", "ticketCount", "ticketLabel" })] IList<ValueTuple<int, int, long, int, string>> rewards); // 0x0000000180512C80-0x00000001805134E0
	private static string WhoBody(bool ticketPerMember, int minMemberDays); // 0x00000001805134E0-0x00000001805137C0
	public static List<Section> SectionsForVault(long gold, int membersCount, long equalShare, long minPerMember, bool canDistribute, bool canManual); // 0x00000001805137C0-0x0000000180513C60
	private static string VaultWhatBody(long gold); // 0x0000000180513C60-0x0000000180513E70
	private static string EqualBody(int membersCount, long equalShare); // 0x0000000180513E70-0x0000000180514080
	private static string ManualBody(long minPerMember); // 0x0000000180514080-0x00000001805142D0
	private static string BuildLevelBody(GuildDetailData d); // 0x00000001805142D0-0x0000000180514830
	private static string BuildBossBody(GuildPanelController owner, GuildDetailData d); // 0x0000000180514830-0x0000000180514D70
	private static int MyFreeAttempts(GuildPanelController owner, GuildDetailData d); // 0x0000000180514D70-0x0000000180514EE0
	private static string BuildSlotBody(GuildDetailData d); // 0x0000000180514EE0-0x0000000180515180
}

