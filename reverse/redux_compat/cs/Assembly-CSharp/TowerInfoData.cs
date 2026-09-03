/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class TowerInfoData // TypeDefIndex: 777
{
	// Fields
	public TowerFloorInfo floor; // 0x10
	public int maxFloor; // 0x18
	public int maxFloorReached; // 0x1C
	public int power; // 0x20
	public int powerMax; // 0x24
	public int nextPowerSec; // 0x28
	public List<TowerFloorInfo> nextFloors; // 0x30
	public TowerResetOffer giftReset; // 0x38
	public long timeResetSec; // 0x40
	public string seasonKey; // 0x48
	public long serverTime; // 0x50
	public List<TowerTopRow> top; // 0x58
	public int myRank; // 0x60
	public int buyPriceRuby; // 0x64
	public int buyQuantity; // 0x68
	public int buyTodayCount; // 0x6C
	public int buyDailyCap; // 0x70
	public bool atMaxFloor; // 0x74

	// Constructors
	public TowerInfoData(); // 0x00000001803FEFA0-0x00000001803FF060
}

