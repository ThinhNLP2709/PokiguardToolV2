/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class TreasureWheelStatusData // TypeDefIndex: 811
{
	// Fields
	public bool success; // 0x10
	public string message; // 0x18
	public long serverTime; // 0x20
	public bool active; // 0x28
	public TreasureWheelEventDTO @event; // 0x30
	public TreasureWheelPrizeDTO[] prizes; // 0x38
	public TreasureWheelBonusDTO[] bonuses; // 0x40
	public int totalSpins; // 0x48
	public int spinsToday; // 0x4C
	public TreasureWheelWallet wallet; // 0x50

	// Constructors
	public TreasureWheelStatusData(); // 0x00000001802E5CB0-0x00000001802E5CC0
}

