/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class TreasureWheelRewardUtil // TypeDefIndex: 1384
{
	// Methods
	public static List<GachaRollItemDTO> ToItems(TreasureWheelReward r); // 0x0000000180780170-0x0000000180781000
	private static void AddWeapons(List<GachaRollItemDTO> list, TreasureWheelReward r); // 0x0000000180781000-0x0000000180781050
	public static GachaRollItemDTO Best(TreasureWheelReward r); // 0x0000000180781050-0x00000001807811B0
	private static int TypeWeight(string prizeType); // 0x00000001807811B0-0x00000001807813A0
	public static List<RewardDisplayHelper.Entry> ToTooltipEntries(TreasureWheelReward r); // 0x00000001807813A0-0x0000000180781640
	public static string Describe(TreasureWheelReward r); // 0x0000000180781640-0x00000001807817A0
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005F0DF7 */); // 0x00000001807817A0-0x00000001807818F0
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey, string amountKey); // 0x00000001807818F0-0x0000000180781E30
}

