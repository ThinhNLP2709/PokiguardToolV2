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
public class GuildRaidSchedulePopup : MonoBehaviour // TypeDefIndex: 901
{
	// Fields
	public const string NODE_NAME = "GuildRaidSchedulePopup"; // Metadata: 0x005F007F
	private const float PANEL_W = 700f; // Metadata: 0x005F0096
	private const float PANEL_H = 470f; // Metadata: 0x005F009A
	private const float ROW_H = 64f; // Metadata: 0x005F009E
	private const float ROW_GAP = 6f; // Metadata: 0x005F00A2
	private const float ROW_W = 640f; // Metadata: 0x005F00A6
	private static readonly Color DIM; // 0x00
	private static readonly Color PANEL_BG; // 0x10
	private static readonly Color TITLE; // 0x20
	private static readonly Color LABEL; // 0x30
	private static readonly Color SUB; // 0x40
	private static readonly Color TODAY; // 0x50
	private static readonly Color TODAY_BG; // 0x60
	private static readonly Color TODAY_EDGE; // 0x70
	private static readonly Color ROW_BG; // 0x80
	private static readonly Color OFF; // 0x90
	private Font _font; // 0x20
	private RectTransform _content; // 0x28
	private readonly List<GameObject> _rows; // 0x30
	private bool _built; // 0x38

	// Constructors
	public GuildRaidSchedulePopup(); // 0x0000000180582550-0x0000000180582650
	static GuildRaidSchedulePopup(); // 0x0000000180582650-0x0000000180582790

	// Methods
	public static GuildRaidSchedulePopup Ensure(Transform host, UnityEngine.UI.Text fontSample); // 0x000000018057DEF0-0x000000018057E5B0
	private void Build(); // 0x000000018057E5B0-0x000000018057F610
	public void Open(List<GuildRaidDayRow> week, long serverTimeMs, string raidStatus = null, string windowStatus = null); // 0x000000018057F610-0x000000018057F7C0
	public void Close(); // 0x0000000180518440-0x0000000180518530
	private void Render(List<GuildRaidDayRow> week, long serverTimeMs, string raidStatus, string windowStatus); // 0x000000018057F7C0-0x00000001805804F0
	private static string SubLine(GuildRaidDayRow d); // 0x00000001805804F0-0x0000000180580640
	private static string StateOf(GuildRaidDayRow d, long now, string raidStatus, string windowStatus, out string stateKey); // 0x0000000180580640-0x0000000180580B30
	private static void SetRowText(GameObject row, string nodeName, string value, Color color); // 0x0000000180580B30-0x0000000180580DC0
	private static void SetRowImage(GameObject row, string nodeName, Color color, bool on); // 0x0000000180580DC0-0x0000000180581080
	private GameObject EnsureRow(int index); // 0x0000000180581080-0x0000000180582550
}

