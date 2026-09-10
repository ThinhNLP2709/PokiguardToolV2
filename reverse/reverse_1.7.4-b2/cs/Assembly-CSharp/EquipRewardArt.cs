/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class EquipRewardArt // TypeDefIndex: 1076
{
	// Fields
	private static readonly string[] RarityLabels; // 0x00
	private static readonly string[] RarityKeys; // 0x08
	private static readonly string[] SlotLabels; // 0x10

	// Constructors
	static EquipRewardArt(); // 0x00000001805109F0-0x0000000180510E80

	// Methods
	public static Sprite LoadIcon(long equipId, long iconId); // 0x0000000180510710-0x0000000180510840
	public static string IconPath(long equipId, long iconId); // 0x0000000180510320-0x0000000180510340
	public static Sprite LoadIcon(WeaponDropDTO drop); // 0x0000000180510610-0x0000000180510710
	public static Sprite LoadIcon(WeaponRewardView view); // 0x0000000180510400-0x0000000180510500
	public static Sprite LoadIcon(WeaponRewardItem item); // 0x0000000180510500-0x0000000180510610
	public static string RarityLabel(int rarityIdx); // 0x00000001805108D0-0x0000000180510960
	public static string RarityKey(int rarityIdx); // 0x0000000180510840-0x00000001805108D0
	public static string SlotLabel(int slot); // 0x0000000180510960-0x00000001805109F0
	public static string Label(string name, int star, long equipId); // 0x0000000180510340-0x0000000180510400
}

