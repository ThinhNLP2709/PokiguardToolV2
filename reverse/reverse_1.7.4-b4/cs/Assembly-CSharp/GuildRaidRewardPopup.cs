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

[DisallowMultipleComponent]
public class GuildRaidRewardPopup : MonoBehaviour // TypeDefIndex: 900
{
	// Fields
	public const string NODE_NAME = "GuildRaidRewardPopup"; // Metadata: 0x005F004A
	private const float PANEL_W = 700f; // Metadata: 0x005F005F
	private const float PANEL_H = 470f; // Metadata: 0x005F0063
	private const float BLOCK_W = 640f; // Metadata: 0x005F0067
	private const float BLOCK_GAP = 8f; // Metadata: 0x005F006B
	private const float TOP_PAD = 12f; // Metadata: 0x005F006F
	private const float CELL_HERO = 72f; // Metadata: 0x005F0073
	private const float CELL_ROW = 46f; // Metadata: 0x005F0077
	private const float TIER_LABEL_W = 190f; // Metadata: 0x005F007B
	private static readonly Color DIM; // 0x00
	private static readonly Color PANEL_BG; // 0x10
	private static readonly Color TITLE; // 0x20
	private static readonly Color LABEL; // 0x30
	private static readonly Color NOTE; // 0x40
	private static readonly Color BLOCK_BG; // 0x50
	private Font _font; // 0x20
	private RectTransform _content; // 0x28
	private readonly List<GameObject> _blocks; // 0x30
	private readonly List<GameObject> _cells; // 0x38
	private bool _built; // 0x40

	// Constructors
	public GuildRaidRewardPopup(); // 0x000000018057DCA0-0x000000018057DE20
	static GuildRaidRewardPopup(); // 0x000000018057DE20-0x000000018057DEF0

	// Methods
	public static GuildRaidRewardPopup Ensure(Transform host, UnityEngine.UI.Text fontSample); // 0x0000000180578D30-0x00000001805793F0
	private void Build(); // 0x00000001805793F0-0x000000018057A410
	public void Open(GuildRaidRewardsData d, int bossPetId = 0 /* Metadata: 0x005F0049 */); // 0x000000018057A410-0x000000018057A6D0
	public void Close(); // 0x0000000180518440-0x0000000180518530
	private void Render(GuildRaidRewardsData d, int bossPetId); // 0x000000018057A6D0-0x000000018057B420
	private static List<RewardDisplayHelper.Entry> KillEntries(GuildRaidRewardsData d, int bossPetId); // 0x000000018057B420-0x000000018057B5D0
	private float FillHeader(ref int used, float y, string label); // 0x000000018057B5D0-0x000000018057B860
	private float FillBlock(ref int used, float y, string label, string note, List<RewardDisplayHelper.Entry> entries, float cell, bool sideLabel); // 0x000000018057B860-0x000000018057BF70
	private static void Apply(GameObject blk, string label, string note, bool sideLabel, float h); // 0x000000018057BF70-0x000000018057C5F0
	private static UnityEngine.UI.Text Txt(GameObject blk, string nodeName); // 0x000000018057C5F0-0x000000018057C790
	private GameObject EnsureBlock(int index); // 0x000000018057C790-0x000000018057DB30
	private static void LayoutBlock(GameObject blk, float y, float h); // 0x000000018057DB30-0x000000018057DCA0
}

