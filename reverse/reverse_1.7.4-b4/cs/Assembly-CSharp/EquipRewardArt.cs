/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EquipRewardArt // TypeDefIndex: 1494
{
	// Fields
	private static readonly string[] RarityLabels; // 0x00
	private static readonly string[] RarityKeys; // 0x08
	private static readonly string[] SlotLabels; // 0x10

	// Constructors
	static EquipRewardArt(); // 0x000000018081BAE0-0x000000018081C000

	// Methods
	public static Sprite LoadIcon(long equipId, long iconId); // 0x000000018081B170-0x000000018081B2B0
	public static string IconPath(long equipId, long iconId); // 0x000000018081B2B0-0x000000018081B2D0
	public static Sprite LoadIcon(WeaponDropDTO drop); // 0x000000018081B2D0-0x000000018081B460
	public static Sprite LoadIcon(WeaponRewardView view); // 0x000000018081B460-0x000000018081B5F0
	public static Sprite LoadIcon(WeaponRewardItem item); // 0x000000018081B5F0-0x000000018081B780
	public static string RarityLabel(int rarityIdx); // 0x000000018081B780-0x000000018081B820
	public static string RarityKey(int rarityIdx); // 0x000000018081B820-0x000000018081B8C0
	public static string SlotLabel(int slot); // 0x000000018081B8C0-0x000000018081B960
	public static string Label(string name, int star, long equipId); // 0x000000018081B960-0x000000018081BAE0
}

