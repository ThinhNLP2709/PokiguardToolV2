/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class WeaponRarity // TypeDefIndex: 1503
{
	// Fields
	private static readonly Dictionary<int, Sprite> _iconCache; // 0x00
	private static readonly Dictionary<string, Sprite> _uiCache; // 0x08
	private static readonly Color ColCommon; // 0x10
	private static readonly Color ColRare; // 0x20
	private static readonly Color ColEpic; // 0x30
	private static readonly Color ColLegend; // 0x40

	// Constructors
	static WeaponRarity(); // 0x00000001808275A0-0x00000001808277B0

	// Methods
	public static Color GetColor(string rarity); // 0x0000000180826810-0x0000000180826A40
	public static string GetLabel(string rarity); // 0x0000000180826A40-0x0000000180826CD0
	public static string GetElementLabel(string element); // 0x0000000180826CD0-0x0000000180826D80
	public static Sprite LoadRarityCircle(string rarity); // 0x0000000180826D80-0x0000000180827010
	public static Sprite LoadIcon(int imageId); // 0x0000000180827010-0x0000000180827320
	public static bool IsValidImageId(int imageId); // 0x0000000180827320-0x0000000180827340
	public static Sprite LoadUI(string fileName); // 0x0000000180827340-0x00000001808274D0
	public static string StarText(int star); // 0x00000001808274D0-0x0000000180827530
	private static string Normalize(string rarity); // 0x0000000180827530-0x00000001808275A0
}

