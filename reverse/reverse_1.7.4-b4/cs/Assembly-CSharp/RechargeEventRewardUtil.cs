/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RechargeEventRewardUtil // TypeDefIndex: 1189
{
	// Methods
	public static List<RewardDisplayHelper.Entry> BuildEntries(RechargeEventReward r); // 0x00000001806CA340-0x00000001806CAD30
	public static List<GachaRollItemDTO> BuildRevealItems(RechargeEventReward r); // 0x00000001806CAD30-0x00000001806CBBB0
	public static WeaponRewardView[] WeaponViews(RechargeEventReward r); // 0x00000001806CBBB0-0x00000001806CBC30
	public static WeaponRewardView[] ParseWeaponViews(string json); // 0x00000001806CBC30-0x00000001806CC210
	public static void AddWeaponRevealItems(List<GachaRollItemDTO> list, WeaponRewardView[] views); // 0x00000001806CC210-0x00000001806CC640
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005F092E */); // 0x00000001806CC640-0x00000001806CC790
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey); // 0x00000001806CC790-0x00000001806CCCD0
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x00000001806CCCD0-0x00000001806CD1C0
}

