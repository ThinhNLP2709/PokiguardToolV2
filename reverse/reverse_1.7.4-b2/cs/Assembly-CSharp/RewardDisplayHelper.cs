/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RewardDisplayHelper // TypeDefIndex: 1070
{
	// Fields
	private static readonly Dictionary<string, GameObject> _hubPrefabs; // 0x00
	private static readonly Dictionary<string, Sprite[]> _hubStones; // 0x08
	private static readonly string[] HubPrefabKeys; // 0x10
	private const float NaturalSize = 84f; // Metadata: 0x0068C3BD
	private const float CenterOffsetY = 7.7f; // Metadata: 0x0068C3C1
	private const float IconBudget = 64f; // Metadata: 0x0068C3C5
	private const string POKY_CELL_PATH = "Prefabs/Poky/PokyRewardCell"; // Metadata: 0x0068C3C9
	private const string POKY_CELL_KEY = "RewardCell"; // Metadata: 0x0068C3E5
	private static GameObject _pokyCell; // 0x18
	private static bool _pokyCellTried; // 0x20

	// Nested types
	public class Entry // TypeDefIndex: 1071
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20
		public string label; // 0x28
		public Sprite icon; // 0x30

		// Constructors
		public Entry(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	// Constructors
	static RewardDisplayHelper(); // 0x000000018051D310-0x000000018051D930

	// Methods
	public static Sprite SpriteOf(string type); // 0x000000018051C810-0x000000018051C930
	public static void WarmHubIcons(ManagerQuangTruong qt); // 0x000000018051CEB0-0x000000018051D310
	private static void CacheStones(string element, Sprite[] arr); // 0x0000000180518C40-0x0000000180518CE0
	public static GameObject GetPrefab(string type); // 0x0000000180518FA0-0x0000000180519130
	private static GameObject PrefabFromHub(ManagerQuangTruong qt, string type); // 0x0000000180519B00-0x000000018051A280
	public static List<Entry> BuildEntries(int gold, int ruby, int energy, int exp, int starWhite, int starBlue, int starRed, int wheel, int wheelDay, int eitem1, int eitem2, int eitem3, int eitem4, int crystal, long avt, long pet, long card, string stonesJson); // 0x0000000180516F00-0x0000000180517900
	public static List<Entry> BuildEntries(TowerGiftBundle g); // 0x0000000180517900-0x0000000180518340
	public static List<Entry> BuildPackageEntries(ShopPackageDTO pkg, Sprite safiaIcon = null, Sprite stoneIcon = null); // 0x0000000180518340-0x0000000180518C40
	public static void AddWeaponEntries(List<Entry> list, WeaponRewardItem[] weapons); // 0x00000001805166F0-0x0000000180516A60
	public static void AddWeaponEntries(List<Entry> list, WeaponRewardView[] weapons); // 0x0000000180516A60-0x0000000180516E00
	public static string StoneName(string element, int level, string fallback); // 0x000000018051CA40-0x000000018051CB80
	private static string NormalizeStoneElement(string element); // 0x0000000180519640-0x0000000180519960
	public static string StoneElementFromId(long stoneId); // 0x000000018051C930-0x000000018051CA00
	public static int StoneLevelFromId(long stoneId); // 0x000000018051CA00-0x000000018051CA40
	public static Sprite StoneSpriteFromId(long stoneId); // 0x000000018051CE20-0x000000018051CEB0
	public static Sprite StoneSpriteFor(string element, int level); // 0x000000018051CB80-0x000000018051CE20
	private static void Add(List<Entry> list, string type, int amount); // 0x0000000180516E00-0x0000000180516F00
	public static List<GameObject> Render(Transform container, List<Entry> rewards, float cellSize = 84f /* Metadata: 0x0068C3B9 */); // 0x000000018051A990-0x000000018051BD30
	private static GameObject PokyCellPrefab(); // 0x0000000180519960-0x0000000180519B00
	private static GameObject RenderPokyCell(Transform container, float cellSize, Entry reward, GameObject prefab); // 0x000000018051A280-0x000000018051A990
	public static Sprite IconSpriteFor(Entry reward); // 0x0000000180519380-0x0000000180519500
	public static string IconPathFor(string type, long id); // 0x0000000180519130-0x0000000180519380
	public static Sprite IconSpriteFor(string type); // 0x0000000180519500-0x0000000180519640
	private static Image FindIcon(GameObject go, string type); // 0x0000000180518CE0-0x0000000180518ED0
	public static string FormatAmount(int amount); // 0x0000000180518ED0-0x0000000180518FA0
	public static string RewardTypeNormalize(string rewardType); // 0x000000018051BD30-0x000000018051C810
}

