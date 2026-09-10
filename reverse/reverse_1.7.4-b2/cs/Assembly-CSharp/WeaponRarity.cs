/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class WeaponRarity // TypeDefIndex: 1090
{
	// Fields
	public const string COMMON = "COMMON"; // Metadata: 0x0068C46B
	public const string RARE = "RARE"; // Metadata: 0x0068C472
	public const string EPIC = "EPIC"; // Metadata: 0x0068C477
	public const string LEGENDARY = "LEGENDARY"; // Metadata: 0x0068C47C
	private const string WEAPON_ICON_DIR = "Image/weapons/"; // Metadata: 0x0068C486
	public const string UI_DIR = "Image/weaponUI/"; // Metadata: 0x0068C495
	private static readonly Dictionary<int, Sprite> _iconCache; // 0x00
	private static readonly Dictionary<string, Sprite> _uiCache; // 0x08
	private static readonly Color ColCommon; // 0x10
	private static readonly Color ColRare; // 0x20
	private static readonly Color ColEpic; // 0x30
	private static readonly Color ColLegend; // 0x40

	// Constructors
	static WeaponRarity(); // 0x000000018054C2F0-0x000000018054C440

	// Methods
	public static Color GetColor(string rarity); // 0x000000018054B920-0x000000018054BAB0
	public static string GetLabel(string rarity); // 0x000000018054BB50-0x000000018054BCF0
	public static string GetElementLabel(string element); // 0x000000018054BAB0-0x000000018054BB50
	public static Sprite LoadRarityCircle(string rarity); // 0x000000018054BF20-0x000000018054C0D0
	public static Sprite LoadIcon(int imageId); // 0x000000018054BD10-0x000000018054BF20
	public static bool IsValidImageId(int imageId); // 0x000000018054BCF0-0x000000018054BD10
	public static Sprite LoadUI(string fileName); // 0x000000018054C0D0-0x000000018054C220
	public static string StarText(int star); // 0x000000018054C290-0x000000018054C2F0
	private static string Normalize(string rarity); // 0x000000018054C220-0x000000018054C290
}

