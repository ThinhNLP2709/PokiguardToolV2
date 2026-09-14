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
public class CanDauVanTray : MonoBehaviour // TypeDefIndex: 437
{
	// Fields
	public const float TRAY_W = 1234f; // Metadata: 0x005EF437
	public const float TRAY_H = 96f; // Metadata: 0x005EF43B
	public const float SLOT = 84f; // Metadata: 0x005EF43F
	public const float STEP = 96f; // Metadata: 0x005EF443
	public const float SLOT_PAD = 6f; // Metadata: 0x005EF447
	public const float ICON = 60f; // Metadata: 0x005EF44B
	public const float QTY_FONT = 20f; // Metadata: 0x005EF44F
	public const float QTY_X = -8f; // Metadata: 0x005EF453
	public const float QTY_Y = 56f; // Metadata: 0x005EF457
	public const float QTY_W = 100f; // Metadata: 0x005EF45B
	public const float QTY_H = 32f; // Metadata: 0x005EF45F
	public const float MORE_FONT = 26f; // Metadata: 0x005EF463
	public const int MAX_SHOWN = 12; // Metadata: 0x005EF467
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private readonly RectTransform[] _slots; // 0x30
	private readonly Image[] _icons; // 0x38
	private readonly UnityEngine.UI.Text[] _qtys; // 0x40
	private UnityEngine.UI.Text _more; // 0x48
	private readonly List<RewardDisplayHelper.Entry> _entries; // 0x50

	// Properties
	public int Count { get; } // 0x0000000180359B30-0x0000000180359B50 
	public int NextSlot { get; } // 0x0000000180359B50-0x0000000180359B80 

	// Constructors
	public CanDauVanTray(); // 0x000000018035B6B0-0x000000018035B980

	// Methods
	public static CanDauVanTray Build(MonoBehaviour host, Transform parent, float x, float y); // 0x0000000180359B80-0x0000000180359D50
	private void BuildSlots(); // 0x0000000180359D50-0x000000018035A750
	public void Render(RechargeEventReward[] tray); // 0x000000018035A750-0x000000018035A7F0
	public void AppendAnimated(RechargeEventReward reward); // 0x000000018035A7F0-0x000000018035AA30
	public Vector3 SlotWorldPos(int n); // 0x000000018035AA30-0x000000018035AE10
	private void AddEntries(RechargeEventReward reward); // 0x000000018035AE10-0x000000018035AEF0
	private void Redraw(); // 0x000000018035AEF0-0x000000018035B6B0
}

