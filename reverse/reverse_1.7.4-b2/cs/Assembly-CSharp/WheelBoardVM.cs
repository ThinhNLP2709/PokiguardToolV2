/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WheelBoardVM // TypeDefIndex: 1149
{
	// Fields
	public WheelKind kind; // 0x10
	public string title; // 0x18
	public string currency; // 0x20
	public int cost1; // 0x28
	public int cost10; // 0x2C
	public int bulkCount; // 0x30
	public bool free; // 0x34
	public int freeSpins; // 0x38
	public long wallet; // 0x40
	public long countdownSec; // 0x48
	public string dailyText; // 0x50
	public bool dailyWarning; // 0x58
	public bool pityEnabled; // 0x59
	public int pityCounter; // 0x5C
	public int pityMax; // 0x60
	public string pityRarity; // 0x68
	public List<WheelSlotVM> slots; // 0x70
	public TreasureWheelBonusDTO[] bonuses; // 0x78
	public bool needsGoldConfirm; // 0x80
	public bool showRates; // 0x81
	public bool showHistory; // 0x82
	public string emptyMessage; // 0x88

	// Properties
	public bool IsEmpty { get; } // 0x0000000180563E40-0x0000000180563E60 

	// Constructors
	public WheelBoardVM(); // 0x0000000180563DB0-0x0000000180563E40
}

