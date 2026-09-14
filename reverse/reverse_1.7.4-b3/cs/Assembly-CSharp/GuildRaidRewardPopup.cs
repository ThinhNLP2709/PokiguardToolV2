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

[DisallowMultipleComponent]
public class GuildRaidRewardPopup : MonoBehaviour // TypeDefIndex: 898
{
	// Fields
	public const string NODE_NAME = "GuildRaidRewardPopup"; // Metadata: 0x005EEC7C
	private const float PANEL_W = 700f; // Metadata: 0x005EEC91
	private const float PANEL_H = 470f; // Metadata: 0x005EEC95
	private const float BLOCK_W = 640f; // Metadata: 0x005EEC99
	private const float BLOCK_GAP = 8f; // Metadata: 0x005EEC9D
	private const float TOP_PAD = 12f; // Metadata: 0x005EECA1
	private const float CELL_HERO = 72f; // Metadata: 0x005EECA5
	private const float CELL_ROW = 46f; // Metadata: 0x005EECA9
	private const float TIER_LABEL_W = 190f; // Metadata: 0x005EECAD
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
	public GuildRaidRewardPopup(); // 0x000000018057C340-0x000000018057C4C0
	static GuildRaidRewardPopup(); // 0x000000018057C4C0-0x000000018057C590

	// Methods
	public static GuildRaidRewardPopup Ensure(Transform host, UnityEngine.UI.Text fontSample); // 0x00000001805773D0-0x0000000180577A90
	private void Build(); // 0x0000000180577A90-0x0000000180578AB0
	public void Open(GuildRaidRewardsData d, int bossPetId = 0 /* Metadata: 0x005EEC7B */); // 0x0000000180578AB0-0x0000000180578D70
	public void Close(); // 0x0000000180516CA0-0x0000000180516D90
	private void Render(GuildRaidRewardsData d, int bossPetId); // 0x0000000180578D70-0x0000000180579AC0
	private static List<RewardDisplayHelper.Entry> KillEntries(GuildRaidRewardsData d, int bossPetId); // 0x0000000180579AC0-0x0000000180579C70
	private float FillHeader(ref int used, float y, string label); // 0x0000000180579C70-0x0000000180579F00
	private float FillBlock(ref int used, float y, string label, string note, List<RewardDisplayHelper.Entry> entries, float cell, bool sideLabel); // 0x0000000180579F00-0x000000018057A610
	private static void Apply(GameObject blk, string label, string note, bool sideLabel, float h); // 0x000000018057A610-0x000000018057AC90
	private static UnityEngine.UI.Text Txt(GameObject blk, string nodeName); // 0x000000018057AC90-0x000000018057AE30
	private GameObject EnsureBlock(int index); // 0x000000018057AE30-0x000000018057C1D0
	private static void LayoutBlock(GameObject blk, float y, float h); // 0x000000018057C1D0-0x000000018057C340
}

