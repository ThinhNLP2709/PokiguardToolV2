/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarConfig // TypeDefIndex: 2306
	{
		// Fields
		public const string UI_KEY = "shopavatar"; // Metadata: 0x0068E739
		public const string RESOURCE_NAME = "ShopAvatarConfig"; // Metadata: 0x0068E744
		private static RootCfg _cfg; // 0x00
		private static bool _loaded; // 0x08
		private static string[] _currencyCache; // 0x10
		private static string _currencySource; // 0x18
		private static string[] _rarityCache; // 0x20
		private static string _raritySource; // 0x28
		private static string[] _elementCache; // 0x30
		private static string _elementSource; // 0x38
		private static string[] _rarityFilterCache; // 0x40
		private static string _rarityFilterSource; // 0x48
	
		// Properties
		public static StringsCfg Strings { get; } // 0x00000001807BB410-0x00000001807BB480 
		public static FxCfg Fx { get; } // 0x00000001807BB1F0-0x00000001807BB260 
		public static RoutesCfg Routes { get; } // 0x00000001807BB3A0-0x00000001807BB410 
		public static PortraitCfg Portrait { get; } // 0x00000001807BB2C0-0x00000001807BB330 
		public static PreviewCfg Preview { get; } // 0x00000001807BB330-0x00000001807BB3A0 
		public static int PageSize { get; } // 0x00000001807BB260-0x00000001807BB2C0 
	
		// Nested types
		[Serializable]
		public class TabCfg // TypeDefIndex: 2307
		{
			// Fields
			public string all; // 0x10
			public string hat; // 0x18
			public string hair; // 0x20
			public string eyes; // 0x28
			public string aura; // 0x30
			public string wings; // 0x38
			public string weapon; // 0x40
			public string shirt; // 0x48
			public string pants; // 0x50
			public string shoes; // 0x58
			public string background; // 0x60
			public string avatarset; // 0x68
			public string portrait; // 0x70
	
			// Constructors
			public TabCfg(); // 0x00000001807C6900-0x00000001807C6B30
		}
	
		[Serializable]
		public class SortCfg // TypeDefIndex: 2308
		{
			// Fields
			public string @new; // 0x10
			public string price; // 0x18
			public string power; // 0x20
	
			// Constructors
			public SortCfg(); // 0x00000001807C60A0-0x00000001807C6140
		}
	
		[Serializable]
		public class StringsCfg // TypeDefIndex: 2309
		{
			// Fields
			public string title; // 0x10
			public string buy; // 0x18
			public string owned; // 0x20
			public string ownedNote; // 0x28
			public string needLevel; // 0x30
			public string notEnough; // 0x38
			public string confirmTitle; // 0x40
			public string confirmBody; // 0x48
			public string equipNow; // 0x50
			public string bought; // 0x58
			public string boughtEquipped; // 0x60
			public string netFail; // 0x68
			public string reason1; // 0x70
			public string reason2; // 0x78
			public string reason3; // 0x80
			public string reason4; // 0x88
			public string reason5; // 0x90
			public string reason6; // 0x98
			public string reason7; // 0xA0
			public string reason8; // 0xA8
			public string reason9; // 0xB0
			public string displayOnly; // 0xB8
			public string displayOnlyNote; // 0xC0
			public string setNote; // 0xC8
			public TabCfg tab; // 0xD0
			public SortCfg sort; // 0xD8
			public string hideOwned; // 0xE0
			public string compare; // 0xE8
			public string sortPrefix; // 0xF0
			public string empty; // 0xF8
			public string loading; // 0x100
			public string serverMissing; // 0x108
			public string loadFail; // 0x110
			public string featureOff; // 0x118
			public string alreadyOwned; // 0x120
			public string currencyNames; // 0x128
			public string rarityLabels; // 0x130
			public string rarityFilters; // 0x138
			public string elementNames; // 0x140
			public string stats; // 0x148
			public string setLine; // 0x150
			public string page; // 0x158
			public string portraitBought; // 0x160
			public string portraitFail; // 0x168
	
			// Constructors
			public StringsCfg(); // 0x00000001807C6140-0x00000001807C6900
		}
	
		[Serializable]
		public class FxCfg // TypeDefIndex: 2310
		{
			// Fields
			public bool enabled; // 0x10
			public float openTime; // 0x14
			public float stagger; // 0x18
			public float selectPulse; // 0x1C
			public float sweepTime; // 0x20
	
			// Constructors
			public FxCfg(); // 0x00000001807B4120-0x00000001807B4150
		}
	
		[Serializable]
		public class RoutesCfg // TypeDefIndex: 2311
		{
			// Fields
			public string recharge; // 0x10
	
			// Constructors
			public RoutesCfg(); // 0x00000001807B4330-0x00000001807B4380
		}
	
		[Serializable]
		public class PortraitCfg // TypeDefIndex: 2312
		{
			// Fields
			public bool enabled; // 0x10
	
			// Constructors
			public PortraitCfg(); // 0x00000001807B4150-0x00000001807B4160
		}
	
		[Serializable]
		public class PreviewCfg // TypeDefIndex: 2313
		{
			// Fields
			public float avatarFill; // 0x10
			public float avatarOffsetY; // 0x14
			public float fallbackScale; // 0x18
	
			// Constructors
			public PreviewCfg(); // 0x00000001807B4160-0x00000001807B4180
		}
	
		[Serializable]
		private class RootCfg // TypeDefIndex: 2314
		{
			// Fields
			public StringsCfg strings; // 0x10
			public FxCfg fx; // 0x18
			public RoutesCfg routes; // 0x20
			public PortraitCfg portrait; // 0x28
			public PreviewCfg preview; // 0x30
			public int pageSize; // 0x38
	
			// Constructors
			public RootCfg(); // 0x00000001807B4180-0x00000001807B4330
		}
	
		// Constructors
		static ShopAvatarConfig(); // 0x00000001807BB170-0x00000001807BB1F0
	
		// Methods
		public static void Load(TextAsset json); // 0x00000001807B9E60-0x00000001807B9FD0
		private static void EnsureLoaded(); // 0x00000001807B9C10-0x00000001807B9DC0
		public static void ApplyJson(string raw); // 0x00000001807B7C00-0x00000001807B7D20
		private static void ApplyRemote(); // 0x00000001807B7D20-0x00000001807B9780
		private static bool Get(string prop, out string val); // 0x00000001807B9DC0-0x00000001807B9E60
		private static bool ParseBool(string v, bool fallback); // 0x00000001807B9FD0-0x00000001807BA0E0
		private static float ParseFloat(string v, float fallback); // 0x00000001807BA0E0-0x00000001807BA170
		private static void Sanitize(); // 0x00000001807BA720-0x00000001807BAB80
		public static string TabLabel(string key); // 0x00000001807BACC0-0x00000001807BB170
		public static string SortLabel(string sort); // 0x00000001807BAB80-0x00000001807BACC0
		public static string ReasonText(int reason); // 0x00000001807BA570-0x00000001807BA720
		public static string CurrencyName(string currencyType); // 0x00000001807B9780-0x00000001807B9A10
		public static string RarityLabel(int rarity); // 0x00000001807BA370-0x00000001807BA570
		public static string ElementName(int index); // 0x00000001807B9A10-0x00000001807B9C10
		public static string RarityFilterLabel(int index); // 0x00000001807BA170-0x00000001807BA370
	}
}
