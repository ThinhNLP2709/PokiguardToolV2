/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class MidAutumnState // TypeDefIndex: 653
{
	// Fields
	public bool active; // 0x10
	public string eventKey; // 0x18
	public string eventName; // 0x20
	public long secondsLeft; // 0x28
	public long secondsToDailyReset; // 0x30
	public int totalPoints; // 0x38
	public int dailyPoints; // 0x3C
	public int dailyMax; // 0x40
	public List<MidAutumnMission> missions; // 0x48
	public List<MidAutumnMilestone> milestones; // 0x50
	public int flipsLeft; // 0x58
	public int flipFreePerDay; // 0x5C
	public int flipBonusPoints; // 0x60
	public int flipBuyPriceRuby; // 0x64
	public int flipBuyLeftToday; // 0x68
	public int[] pieces; // 0x70
	public int craftCostEach; // 0x78
	public int craftCount; // 0x7C
	public int craftMaxPerEvent; // 0x80
	public string message; // 0x88
	public int pointsAdded; // 0x90
	public string description; // 0x98

	// Constructors
	public MidAutumnState(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public int Piece(int idx); // 0x00000001803CA140-0x00000001803CA180
	public bool CanCraft(); // 0x00000001803CA0D0-0x00000001803CA140
}

