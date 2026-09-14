/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildRaidHud : MonoBehaviour // TypeDefIndex: 885
{
	// Fields
	public const string NODE_NAME = "GuildRaidHud"; // Metadata: 0x005EEBC5
	public const float LEFT_X = 162f; // Metadata: 0x005EEBD2
	public const float GAP_TO_TURN_HUD = 7f; // Metadata: 0x005EEBD6
	public const float MARGIN_RIGHT = 131f; // Metadata: 0x005EEBDA
	public const float MARGIN_TOP = 42f; // Metadata: 0x005EEBDE
	public const float HEIGHT = 31f; // Metadata: 0x005EEBE2
	public const float FX_MARGIN = 6f; // Metadata: 0x005EEBE6
	public const int FONT_MAX = 14; // Metadata: 0x005EEBEA
	public const int FONT_MIN = 8; // Metadata: 0x005EEBEB
	public const long DANGER_SEC = 60; // Metadata: 0x005EEBEC
	public static readonly Color ClockColor; // 0x00
	public static readonly Color DangerColor; // 0x10
	public static readonly Color DamageColor; // 0x20
	private static readonly Color BgColor; // 0x30
	[Header("Node (d\u1EF1ng l\u00FAc ch\u1EA1y)")]
	public Image imgBg; // 0x20
	public UnityEngine.UI.Text txtClock; // 0x28
	public UnityEngine.UI.Text txtDamage; // 0x30

	// Constructors
	public GuildRaidHud(); // 0x000000018028A560-0x000000018028A5B0
	static GuildRaidHud(); // 0x00000001805676C0-0x0000000180567760

	// Methods
	public static GuildRaidHud Ensure(Transform host, Font font); // 0x0000000180564510-0x0000000180564B40
	private void Build(Font font); // 0x0000000180564B40-0x0000000180565090
	private Image MakeBg(); // 0x0000000180565090-0x00000001805658D0
	private UnityEngine.UI.Text MakeText(string nodeName, Color color, Font font); // 0x00000001805658D0-0x00000001805662A0
	public void ApplyLayout(); // 0x00000001805662A0-0x0000000180566500
	private void LayoutChildren(bool clockVisible); // 0x0000000180566500-0x00000001805665B0
	private static void Place(UnityEngine.UI.Text t, float ay0, float ay1); // 0x00000001805665B0-0x0000000180566770
	public void SetClock(long leftSec); // 0x0000000180566770-0x0000000180566AB0
	public void HideClock(); // 0x0000000180566AB0-0x0000000180566C90
	public void SetDamage(long damage); // 0x0000000180566C90-0x0000000180566DE0
	public void Show(bool on); // 0x0000000180566DE0-0x0000000180566EE0
	public string DescribeInRoot(); // 0x0000000180566EE0-0x00000001805676C0
}

