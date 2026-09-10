/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RechargeEventRewardUtil // TypeDefIndex: 928
{
	// Methods
	public static List<RewardDisplayHelper.Entry> BuildEntries(RechargeEventReward r); // 0x00000001804DBBC0-0x00000001804DC190
	public static List<GachaRollItemDTO> BuildRevealItems(RechargeEventReward r); // 0x00000001804DC190-0x00000001804DCB30
	public static bool IsEmpty(RechargeEventReward r); // 0x00000001804DCB30-0x00000001804DCB60
	public static WeaponRewardView[] WeaponViews(RechargeEventReward r); // 0x00000001804DDA80-0x00000001804DDAF0
	public static WeaponRewardView[] ParseWeaponViews(string json); // 0x00000001804DD4D0-0x00000001804DDA80
	public static void AddWeaponRevealItems(List<GachaRollItemDTO> list, WeaponRewardView[] views); // 0x00000001804DB6D0-0x00000001804DBAA0
	private static void Add(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0068BF75 */); // 0x00000001804DBAA0-0x00000001804DBBC0
	private static List<KeyValuePair<long, int>> ParsePairs(string json, string idKey); // 0x00000001804DCB60-0x00000001804DD040
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x00000001804DD040-0x00000001804DD4D0
}

