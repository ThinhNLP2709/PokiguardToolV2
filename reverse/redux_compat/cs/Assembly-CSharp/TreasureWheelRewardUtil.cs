/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class TreasureWheelRewardUtil // TypeDefIndex: 817
{
	// Methods
	public static List<GachaRollItemDTO> ToItems(TreasureWheelReward r); // 0x0000000180435A50-0x00000001804363D0
	private static void AddWeapons(List<GachaRollItemDTO> list, TreasureWheelReward r); // 0x0000000180434A20-0x0000000180435120
	public static GachaRollItemDTO Best(TreasureWheelReward r); // 0x0000000180435240-0x0000000180435410
	private static int TypeWeight(string prizeType); // 0x00000001804364D0-0x00000001804365A0
	public static List<RewardDisplayHelper.Entry> ToTooltipEntries(TreasureWheelReward r); // 0x00000001804363D0-0x00000001804364D0
	public static string Describe(TreasureWheelReward r); // 0x0000000180435410-0x0000000180435580
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0064C97E */); // 0x0000000180435120-0x0000000180435240
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey, string amountKey); // 0x0000000180435580-0x0000000180435A50
}

