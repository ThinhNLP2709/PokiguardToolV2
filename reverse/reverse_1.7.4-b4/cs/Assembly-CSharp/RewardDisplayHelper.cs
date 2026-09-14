/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RewardDisplayHelper // TypeDefIndex: 1451
{
	// Fields
	private static readonly Dictionary<string, GameObject> _hubPrefabs; // 0x00
	private static readonly Dictionary<string, Sprite[]> _hubStones; // 0x08
	private static readonly string[] HubPrefabKeys; // 0x10
	private static GameObject _pokyCell; // 0x18
	private static bool _pokyCellTried; // 0x20

	// Nested types
	public class Entry // TypeDefIndex: 1452
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20
		public string label; // 0x28
		public Sprite icon; // 0x30

		// Constructors
		public Entry(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	static RewardDisplayHelper(); // 0x00000001807E8B70-0x00000001807E9280

	// Methods
	public static Sprite SpriteOf(string type); // 0x00000001807DF980-0x00000001807DFC30
	public static void WarmHubIcons(ManagerQuangTruong qt); // 0x00000001807DFC30-0x00000001807E0270
	private static void CacheStones(string element, Sprite[] arr); // 0x00000001807E0270-0x00000001807E0330
	public static GameObject GetPrefab(string type); // 0x00000001807E0330-0x00000001807E05E0
	private static GameObject PrefabFromHub(ManagerQuangTruong qt, string type); // 0x00000001807E05E0-0x00000001807E1170
	public static List<Entry> BuildEntries(int gold, int ruby, int energy, int exp, int starWhite, int starBlue, int starRed, int wheel, int wheelDay, int eitem1, int eitem2, int eitem3, int eitem4, int crystal, long avt, long pet, long card, string stonesJson); // 0x00000001807E1170-0x00000001807E1BE0
	public static List<Entry> BuildEntries(TowerGiftBundle g); // 0x00000001807E1BE0-0x00000001807E2960
	public static List<Entry> BuildPackageEntries(ShopPackageDTO pkg, Sprite safiaIcon = null, Sprite stoneIcon = null); // 0x00000001807E2960-0x00000001807E34C0
	public static void AddWeaponEntries(List<Entry> list, WeaponRewardItem[] weapons); // 0x00000001807E34C0-0x00000001807E3830
	public static void AddWeaponEntries(List<Entry> list, WeaponRewardView[] weapons); // 0x00000001807E3830-0x00000001807E3BE0
	public static string StoneName(string element, int level, string fallback); // 0x00000001807E3BE0-0x00000001807E3D50
	private static string NormalizeStoneElement(string element); // 0x00000001807E3D50-0x00000001807E42C0
	public static string StoneElementFromId(long stoneId); // 0x00000001807E42C0-0x00000001807E43B0
	public static int StoneLevelFromId(long stoneId); // 0x00000001807E43B0-0x00000001807E43F0
	public static Sprite StoneSpriteFromId(long stoneId); // 0x00000001807E43F0-0x00000001807E4490
	public static Sprite StoneSpriteFor(string element, int level); // 0x00000001807E4490-0x00000001807E4850
	private static void Add(List<Entry> list, string type, int amount); // 0x00000001807E4850-0x00000001807E4930
	public static List<GameObject> Render(Transform container, List<Entry> rewards, float cellSize = 84f /* Metadata: 0x005F0F6A */); // 0x00000001807E4930-0x00000001807E5E40
	private static GameObject PokyCellPrefab(); // 0x00000001807E5E40-0x00000001807E60E0
	private static GameObject RenderPokyCell(Transform container, float cellSize, Entry reward, GameObject prefab); // 0x00000001807E60E0-0x00000001807E6AC0
	public static Sprite IconSpriteFor(Entry reward); // 0x00000001807E6AC0-0x00000001807E6E20
	public static string IconPathFor(string type, long id); // 0x00000001807E6E20-0x00000001807E71E0
	public static Sprite IconSpriteFor(string type); // 0x00000001807E71E0-0x00000001807E7450
	private static Image FindIcon(GameObject go, string type); // 0x00000001807E7450-0x00000001807E78A0
	public static string FormatAmount(int amount); // 0x00000001807E78A0-0x00000001807E7A10
	public static string RewardTypeNormalize(string rewardType); // 0x00000001807E7A10-0x00000001807E8B70
}

