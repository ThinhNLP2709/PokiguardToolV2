/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class GuildRaidHud : MonoBehaviour // TypeDefIndex: 887
{
	// Fields
	public const string NODE_NAME = "GuildRaidHud"; // Metadata: 0x005EFF93
	public const float LEFT_X = 162f; // Metadata: 0x005EFFA0
	public const float GAP_TO_TURN_HUD = 7f; // Metadata: 0x005EFFA4
	public const float MARGIN_RIGHT = 131f; // Metadata: 0x005EFFA8
	public const float MARGIN_TOP = 42f; // Metadata: 0x005EFFAC
	public const float HEIGHT = 31f; // Metadata: 0x005EFFB0
	public const float FX_MARGIN = 6f; // Metadata: 0x005EFFB4
	public const int FONT_MAX = 14; // Metadata: 0x005EFFB8
	public const int FONT_MIN = 8; // Metadata: 0x005EFFB9
	public const long DANGER_SEC = 60; // Metadata: 0x005EFFBA
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
	static GuildRaidHud(); // 0x0000000180568FF0-0x0000000180569090

	// Methods
	public static GuildRaidHud Ensure(Transform host, Font font); // 0x0000000180565E40-0x0000000180566470
	private void Build(Font font); // 0x0000000180566470-0x00000001805669C0
	private Image MakeBg(); // 0x00000001805669C0-0x0000000180567200
	private UnityEngine.UI.Text MakeText(string nodeName, Color color, Font font); // 0x0000000180567200-0x0000000180567BD0
	public void ApplyLayout(); // 0x0000000180567BD0-0x0000000180567E30
	private void LayoutChildren(bool clockVisible); // 0x0000000180567E30-0x0000000180567EE0
	private static void Place(UnityEngine.UI.Text t, float ay0, float ay1); // 0x0000000180567EE0-0x00000001805680A0
	public void SetClock(long leftSec); // 0x00000001805680A0-0x00000001805683E0
	public void HideClock(); // 0x00000001805683E0-0x00000001805685C0
	public void SetDamage(long damage); // 0x00000001805685C0-0x0000000180568710
	public void Show(bool on); // 0x0000000180568710-0x0000000180568810
	public string DescribeInRoot(); // 0x0000000180568810-0x0000000180568FF0
}

