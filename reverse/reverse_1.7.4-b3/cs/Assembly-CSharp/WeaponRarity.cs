/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class WeaponRarity // TypeDefIndex: 1501
{
	// Fields
	private static readonly Dictionary<int, Sprite> _iconCache; // 0x00
	private static readonly Dictionary<string, Sprite> _uiCache; // 0x08
	private static readonly Color ColCommon; // 0x10
	private static readonly Color ColRare; // 0x20
	private static readonly Color ColEpic; // 0x30
	private static readonly Color ColLegend; // 0x40

	// Constructors
	static WeaponRarity(); // 0x00000001808254B0-0x00000001808256C0

	// Methods
	public static Color GetColor(string rarity); // 0x0000000180824720-0x0000000180824950
	public static string GetLabel(string rarity); // 0x0000000180824950-0x0000000180824BE0
	public static string GetElementLabel(string element); // 0x0000000180824BE0-0x0000000180824C90
	public static Sprite LoadRarityCircle(string rarity); // 0x0000000180824C90-0x0000000180824F20
	public static Sprite LoadIcon(int imageId); // 0x0000000180824F20-0x0000000180825230
	public static bool IsValidImageId(int imageId); // 0x0000000180825230-0x0000000180825250
	public static Sprite LoadUI(string fileName); // 0x0000000180825250-0x00000001808253E0
	public static string StarText(int star); // 0x00000001808253E0-0x0000000180825440
	private static string Normalize(string rarity); // 0x0000000180825440-0x00000001808254B0
}

