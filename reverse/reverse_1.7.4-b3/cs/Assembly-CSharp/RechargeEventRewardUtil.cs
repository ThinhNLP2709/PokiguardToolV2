/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class RechargeEventRewardUtil // TypeDefIndex: 1187
{
	// Methods
	public static List<RewardDisplayHelper.Entry> BuildEntries(RechargeEventReward r); // 0x00000001806C8720-0x00000001806C9110
	public static List<GachaRollItemDTO> BuildRevealItems(RechargeEventReward r); // 0x00000001806C9110-0x00000001806C9F90
	public static WeaponRewardView[] WeaponViews(RechargeEventReward r); // 0x00000001806C9F90-0x00000001806CA010
	public static WeaponRewardView[] ParseWeaponViews(string json); // 0x00000001806CA010-0x00000001806CA5F0
	public static void AddWeaponRevealItems(List<GachaRollItemDTO> list, WeaponRewardView[] views); // 0x00000001806CA5F0-0x00000001806CAA20
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005EF561 */); // 0x00000001806CAA20-0x00000001806CAB70
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey); // 0x00000001806CAB70-0x00000001806CB0B0
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x00000001806CB0B0-0x00000001806CB5A0
}

