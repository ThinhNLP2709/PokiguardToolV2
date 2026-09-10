/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class TreasureWheelRewardUtil // TypeDefIndex: 1012
{
	// Methods
	public static List<GachaRollItemDTO> ToItems(TreasureWheelReward r); // 0x000000018050DAC0-0x000000018050E470
	private static void AddWeapons(List<GachaRollItemDTO> list, TreasureWheelReward r); // 0x000000018050D120-0x000000018050D170
	public static GachaRollItemDTO Best(TreasureWheelReward r); // 0x000000018050D290-0x000000018050D480
	private static int TypeWeight(string prizeType); // 0x000000018050E6F0-0x000000018050E7E0
	public static List<RewardDisplayHelper.Entry> ToTooltipEntries(TreasureWheelReward r); // 0x000000018050E470-0x000000018050E6F0
	public static string Describe(TreasureWheelReward r); // 0x000000018050D480-0x000000018050D5F0
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0068C054 */); // 0x000000018050D170-0x000000018050D290
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey, string amountKey); // 0x000000018050D5F0-0x000000018050DAC0
}

