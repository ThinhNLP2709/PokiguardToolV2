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
public class CanDauVanTray : MonoBehaviour // TypeDefIndex: 437
{
	// Fields
	public const float TRAY_W = 1234f; // Metadata: 0x005EE067
	public const float TRAY_H = 96f; // Metadata: 0x005EE06B
	public const float SLOT = 84f; // Metadata: 0x005EE06F
	public const float STEP = 96f; // Metadata: 0x005EE073
	public const float SLOT_PAD = 6f; // Metadata: 0x005EE077
	public const float ICON = 60f; // Metadata: 0x005EE07B
	public const float QTY_FONT = 20f; // Metadata: 0x005EE07F
	public const float QTY_X = -8f; // Metadata: 0x005EE083
	public const float QTY_Y = 56f; // Metadata: 0x005EE087
	public const float QTY_W = 100f; // Metadata: 0x005EE08B
	public const float QTY_H = 32f; // Metadata: 0x005EE08F
	public const float MORE_FONT = 26f; // Metadata: 0x005EE093
	public const int MAX_SHOWN = 12; // Metadata: 0x005EE097
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private readonly RectTransform[] _slots; // 0x30
	private readonly Image[] _icons; // 0x38
	private readonly UnityEngine.UI.Text[] _qtys; // 0x40
	private UnityEngine.UI.Text _more; // 0x48
	private readonly List<RewardDisplayHelper.Entry> _entries; // 0x50

	// Properties
	public int Count { get; } // 0x0000000180359920-0x0000000180359940 
	public int NextSlot { get; } // 0x0000000180359940-0x0000000180359970 

	// Constructors
	public CanDauVanTray(); // 0x000000018035B4A0-0x000000018035B770

	// Methods
	public static CanDauVanTray Build(MonoBehaviour host, Transform parent, float x, float y); // 0x0000000180359970-0x0000000180359B40
	private void BuildSlots(); // 0x0000000180359B40-0x000000018035A540
	public void Render(RechargeEventReward[] tray); // 0x000000018035A540-0x000000018035A5E0
	public void AppendAnimated(RechargeEventReward reward); // 0x000000018035A5E0-0x000000018035A820
	public Vector3 SlotWorldPos(int n); // 0x000000018035A820-0x000000018035AC00
	private void AddEntries(RechargeEventReward reward); // 0x000000018035AC00-0x000000018035ACE0
	private void Redraw(); // 0x000000018035ACE0-0x000000018035B4A0
}

