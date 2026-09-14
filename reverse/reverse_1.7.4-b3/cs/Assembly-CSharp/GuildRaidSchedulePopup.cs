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
public class GuildRaidSchedulePopup : MonoBehaviour // TypeDefIndex: 899
{
	// Fields
	public const string NODE_NAME = "GuildRaidSchedulePopup"; // Metadata: 0x005EECB1
	private const float PANEL_W = 700f; // Metadata: 0x005EECC8
	private const float PANEL_H = 470f; // Metadata: 0x005EECCC
	private const float ROW_H = 64f; // Metadata: 0x005EECD0
	private const float ROW_GAP = 6f; // Metadata: 0x005EECD4
	private const float ROW_W = 640f; // Metadata: 0x005EECD8
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
	public GuildRaidSchedulePopup(); // 0x0000000180580BF0-0x0000000180580CF0
	static GuildRaidSchedulePopup(); // 0x0000000180580CF0-0x0000000180580E30

	// Methods
	public static GuildRaidSchedulePopup Ensure(Transform host, UnityEngine.UI.Text fontSample); // 0x000000018057C590-0x000000018057CC50
	private void Build(); // 0x000000018057CC50-0x000000018057DCB0
	public void Open(List<GuildRaidDayRow> week, long serverTimeMs, string raidStatus = null, string windowStatus = null); // 0x000000018057DCB0-0x000000018057DE60
	public void Close(); // 0x0000000180516CA0-0x0000000180516D90
	private void Render(List<GuildRaidDayRow> week, long serverTimeMs, string raidStatus, string windowStatus); // 0x000000018057DE60-0x000000018057EB90
	private static string SubLine(GuildRaidDayRow d); // 0x000000018057EB90-0x000000018057ECE0
	private static string StateOf(GuildRaidDayRow d, long now, string raidStatus, string windowStatus, out string stateKey); // 0x000000018057ECE0-0x000000018057F1D0
	private static void SetRowText(GameObject row, string nodeName, string value, Color color); // 0x000000018057F1D0-0x000000018057F460
	private static void SetRowImage(GameObject row, string nodeName, Color color, bool on); // 0x000000018057F460-0x000000018057F720
	private GameObject EnsureRow(int index); // 0x000000018057F720-0x0000000180580BF0
}

