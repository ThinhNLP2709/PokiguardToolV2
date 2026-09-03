/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RechargeEventRewardUtil // TypeDefIndex: 738
{
	// Methods
	public static List<RewardDisplayHelper.Entry> BuildEntries(RechargeEventReward r); // 0x00000001803FB570-0x00000001803FBBD0
	public static List<GachaRollItemDTO> BuildRevealItems(RechargeEventReward r); // 0x00000001803FBBD0-0x00000001803FC6C0
	public static bool IsEmpty(RechargeEventReward r); // 0x00000001803FC6C0-0x00000001803FC6F0
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0064C8B5 */); // 0x00000001803FB450-0x00000001803FB570
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey); // 0x00000001803FC6F0-0x00000001803FCBD0
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x00000001803FCBD0-0x00000001803FD060
}

