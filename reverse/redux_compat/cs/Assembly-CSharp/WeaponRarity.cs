/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class WeaponRarity // TypeDefIndex: 888
{
	// Fields
	public const string COMMON = "COMMON"; // Metadata: 0x0064CCCD
	public const string RARE = "RARE"; // Metadata: 0x0064CCD4
	public const string EPIC = "EPIC"; // Metadata: 0x0064CCD9
	public const string LEGENDARY = "LEGENDARY"; // Metadata: 0x0064CCDE
	private const string WEAPON_ICON_DIR = "Image/weapons/"; // Metadata: 0x0064CCE8
	public const string UI_DIR = "Image/weaponUI/"; // Metadata: 0x0064CCF7
	private static readonly Dictionary<int, Sprite> _iconCache; // 0x00
	private static readonly Dictionary<string, Sprite> _uiCache; // 0x08
	private static readonly Color ColCommon; // 0x10
	private static readonly Color ColRare; // 0x20
	private static readonly Color ColEpic; // 0x30
	private static readonly Color ColLegend; // 0x40

	// Constructors
	static WeaponRarity(); // 0x0000000180459EC0-0x000000018045A010

	// Methods
	public static Color GetColor(string rarity); // 0x00000001804593D0-0x0000000180459560
	public static string GetLabel(string rarity); // 0x0000000180459720-0x00000001804598C0
	public static string GetElementLabel(string element); // 0x0000000180459560-0x0000000180459720
	public static Sprite LoadRarityCircle(string rarity); // 0x0000000180459AF0-0x0000000180459CA0
	public static Sprite LoadIcon(int imageId); // 0x00000001804598E0-0x0000000180459AF0
	public static bool IsValidImageId(int imageId); // 0x00000001804598C0-0x00000001804598E0
	public static Sprite LoadUI(string fileName); // 0x0000000180459CA0-0x0000000180459DF0
	public static string StarText(int star); // 0x0000000180459E60-0x0000000180459EC0
	private static string Normalize(string rarity); // 0x0000000180459DF0-0x0000000180459E60
}

