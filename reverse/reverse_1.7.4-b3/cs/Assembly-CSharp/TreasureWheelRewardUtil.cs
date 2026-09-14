/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class TreasureWheelRewardUtil // TypeDefIndex: 1382
{
	// Methods
	public static List<GachaRollItemDTO> ToItems(TreasureWheelReward r); // 0x000000018077E220-0x000000018077F0B0
	private static void AddWeapons(List<GachaRollItemDTO> list, TreasureWheelReward r); // 0x000000018077F0B0-0x000000018077F100
	public static GachaRollItemDTO Best(TreasureWheelReward r); // 0x000000018077F100-0x000000018077F260
	private static int TypeWeight(string prizeType); // 0x000000018077F260-0x000000018077F450
	public static List<RewardDisplayHelper.Entry> ToTooltipEntries(TreasureWheelReward r); // 0x000000018077F450-0x000000018077F6F0
	public static string Describe(TreasureWheelReward r); // 0x000000018077F6F0-0x000000018077F850
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005EFA2A */); // 0x000000018077F850-0x000000018077F9A0
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey, string amountKey); // 0x000000018077F9A0-0x000000018077FEE0
}

