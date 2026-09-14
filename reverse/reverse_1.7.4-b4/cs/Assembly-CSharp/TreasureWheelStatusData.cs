/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class TreasureWheelStatusData // TypeDefIndex: 1378
{
	// Fields
	public long serverTime; // 0x10
	public bool active; // 0x18
	public TreasureWheelEventDTO @event; // 0x20
	public TreasureWheelPrizeDTO[] prizes; // 0x28
	public TreasureWheelBonusDTO[] bonuses; // 0x30
	public int totalSpins; // 0x38
	public int spinsToday; // 0x3C
	public TreasureWheelWallet wallet; // 0x40

	// Constructors
	public TreasureWheelStatusData(); // 0x000000018028A320-0x000000018028A330
}

