/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EquipRewardArt // TypeDefIndex: 1492
{
	// Fields
	private static readonly string[] RarityLabels; // 0x00
	private static readonly string[] RarityKeys; // 0x08
	private static readonly string[] SlotLabels; // 0x10

	// Constructors
	static EquipRewardArt(); // 0x00000001808199F0-0x0000000180819F10

	// Methods
	public static Sprite LoadIcon(long equipId, long iconId); // 0x0000000180819080-0x00000001808191C0
	public static string IconPath(long equipId, long iconId); // 0x00000001808191C0-0x00000001808191E0
	public static Sprite LoadIcon(WeaponDropDTO drop); // 0x00000001808191E0-0x0000000180819370
	public static Sprite LoadIcon(WeaponRewardView view); // 0x0000000180819370-0x0000000180819500
	public static Sprite LoadIcon(WeaponRewardItem item); // 0x0000000180819500-0x0000000180819690
	public static string RarityLabel(int rarityIdx); // 0x0000000180819690-0x0000000180819730
	public static string RarityKey(int rarityIdx); // 0x0000000180819730-0x00000001808197D0
	public static string SlotLabel(int slot); // 0x00000001808197D0-0x0000000180819870
	public static string Label(string name, int star, long equipId); // 0x0000000180819870-0x00000001808199F0
}

