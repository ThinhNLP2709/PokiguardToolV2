/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RewardDisplayHelper // TypeDefIndex: 869
{
	// Fields
	private const float NaturalSize = 84f; // Metadata: 0x0064CC1F
	private const float CenterOffsetY = 7.7f; // Metadata: 0x0064CC23
	private const float IconBudget = 64f; // Metadata: 0x0064CC27
	private const string POKY_CELL_PATH = "Prefabs/Poky/PokyRewardCell"; // Metadata: 0x0064CC2B
	private const string POKY_CELL_KEY = "RewardCell"; // Metadata: 0x0064CC47
	private static GameObject _pokyCell; // 0x00
	private static bool _pokyCellTried; // 0x08

	// Nested types
	public class Entry // TypeDefIndex: 870
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20
		public string label; // 0x28
		public Sprite icon; // 0x30

		// Constructors
		public Entry(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	// Methods
	public static Sprite SpriteOf(string type); // 0x0000000180446700-0x0000000180446800
	public static GameObject GetPrefab(string type); // 0x00000001804438D0-0x0000000180443F70
	public static List<Entry> BuildEntries(int gold, int ruby, int energy, int exp, int starWhite, int starBlue, int starRed, int wheel, int wheelDay, int eitem1, int eitem2, int eitem3, int eitem4, int crystal, long avt, long pet, long card, string stonesJson); // 0x0000000180441B20-0x00000001804424A0
	public static List<Entry> BuildEntries(TowerGiftBundle g); // 0x00000001804424A0-0x0000000180442B60
	public static List<Entry> BuildPackageEntries(ShopPackageDTO pkg, Sprite safiaIcon = null, Sprite stoneIcon = null); // 0x0000000180442B60-0x0000000180443610
	public static string StoneName(string element, int level, string fallback); // 0x0000000180446910-0x0000000180446B00
	private static string NormalizeStoneElement(string element); // 0x00000001804441F0-0x0000000180444510
	public static string StoneElementFromId(long stoneId); // 0x0000000180446800-0x00000001804468D0
	public static int StoneLevelFromId(long stoneId); // 0x00000001804468D0-0x0000000180446910
	public static Sprite StoneSpriteFromId(long stoneId); // 0x0000000180446CF0-0x0000000180446D50
	public static Sprite StoneSpriteFor(string element, int level); // 0x0000000180446B00-0x0000000180446CF0
	private static void Add(List<Entry> list, string type, int amount); // 0x0000000180441A20-0x0000000180441B20
	public static List<GameObject> Render(Transform container, List<Entry> rewards, float cellSize = 84f /* Metadata: 0x0064CC1B */); // 0x0000000180444D50-0x0000000180445F60
	private static GameObject PokyCellPrefab(); // 0x0000000180444510-0x0000000180444690
	private static GameObject RenderPokyCell(Transform container, float cellSize, Entry reward, GameObject prefab); // 0x0000000180444690-0x0000000180444D50
	public static Sprite IconSpriteFor(Entry reward); // 0x00000001804440A0-0x00000001804441F0
	public static string IconPathFor(string type, long id); // 0x0000000180443F70-0x00000001804440A0
	private static Image FindIcon(GameObject go, string type); // 0x0000000180443610-0x0000000180443800
	public static string FormatAmount(int amount); // 0x0000000180443800-0x00000001804438D0
	public static string RewardTypeNormalize(string rewardType); // 0x0000000180445F60-0x0000000180446700
}

