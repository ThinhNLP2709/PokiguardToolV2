/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WheelBoardVM // TypeDefIndex: 954
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
	public List<WheelSlotVM> slots; // 0x60
	public TreasureWheelBonusDTO[] bonuses; // 0x68
	public bool needsGoldConfirm; // 0x70
	public bool showRates; // 0x71
	public bool showHistory; // 0x72
	public string emptyMessage; // 0x78

	// Properties
	public bool IsEmpty { get; } // 0x000000018047A8C0-0x000000018047A8E0 

	// Constructors
	public WheelBoardVM(); // 0x000000018047A830-0x000000018047A8C0
}

