/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarConfig // TypeDefIndex: 2742
	{
		// Fields
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
		public static StringsCfg Strings { get; } // 0x0000000180C78860-0x0000000180C788D0 
		public static FxCfg Fx { get; } // 0x0000000180C788D0-0x0000000180C78940 
		public static RoutesCfg Routes { get; } // 0x0000000180C78940-0x0000000180C789B0 
		public static PortraitCfg Portrait { get; } // 0x0000000180C789B0-0x0000000180C78A20 
		public static PreviewCfg Preview { get; } // 0x0000000180C78A20-0x0000000180C78A90 
		public static int PageSize { get; } // 0x0000000180C78A90-0x0000000180C78B00 
	
		// Nested types
		[Serializable]
		public class TabCfg // TypeDefIndex: 2743
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
			public TabCfg(); // 0x0000000180CA3020-0x0000000180CA3610
		}
	
		[Serializable]
		public class SortCfg // TypeDefIndex: 2744
		{
			// Fields
			public string @new; // 0x10
			public string price; // 0x18
			public string power; // 0x20
	
			// Constructors
			public SortCfg(); // 0x0000000180CA3610-0x0000000180CA3790
		}
	
		[Serializable]
		public class StringsCfg // TypeDefIndex: 2745
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
			public StringsCfg(); // 0x0000000180CA3790-0x0000000180CA4BB0
		}
	
		[Serializable]
		public class FxCfg // TypeDefIndex: 2746
		{
			// Fields
			public bool enabled; // 0x10
			public float openTime; // 0x14
			public float stagger; // 0x18
			public float selectPulse; // 0x1C
			public float sweepTime; // 0x20
	
			// Constructors
			public FxCfg(); // 0x0000000180CA4BB0-0x0000000180CA4BE0
		}
	
		[Serializable]
		public class RoutesCfg // TypeDefIndex: 2747
		{
			// Fields
			public string recharge; // 0x10
	
			// Constructors
			public RoutesCfg(); // 0x0000000180CA4BE0-0x0000000180CA4C70
		}
	
		[Serializable]
		public class PortraitCfg // TypeDefIndex: 2748
		{
			// Fields
			public bool enabled; // 0x10
	
			// Constructors
			public PortraitCfg(); // 0x0000000180308BA0-0x0000000180308BB0
		}
	
		[Serializable]
		public class PreviewCfg // TypeDefIndex: 2749
		{
			// Fields
			public float avatarFill; // 0x10
			public float avatarOffsetY; // 0x14
			public float fallbackScale; // 0x18
	
			// Constructors
			public PreviewCfg(); // 0x0000000180CA4C70-0x0000000180CA4C80
		}
	
		[Serializable]
		private class RootCfg // TypeDefIndex: 2750
		{
			// Fields
			public StringsCfg strings; // 0x10
			public FxCfg fx; // 0x18
			public RoutesCfg routes; // 0x20
			public PortraitCfg portrait; // 0x28
			public PreviewCfg preview; // 0x30
			public int pageSize; // 0x38
	
			// Constructors
			public RootCfg(); // 0x0000000180CA4C80-0x0000000180CA4F50
		}
	
		// Constructors
		static ShopAvatarConfig(); // 0x0000000180C7D050-0x0000000180C7D110
	
		// Methods
		public static void Load(TextAsset json); // 0x0000000180C78B00-0x0000000180C78DA0
		private static void EnsureLoaded(); // 0x0000000180C78DA0-0x0000000180C78E10
		public static void ApplyJson(string raw); // 0x0000000180C78E10-0x0000000180C78F40
		private static void ApplyRemote(); // 0x0000000180C78F40-0x0000000180C7B040
		private static bool Get(string prop, out string val); // 0x0000000180C7B040-0x0000000180C7B130
		private static bool ParseBool(string v, bool fallback); // 0x0000000180C7B130-0x0000000180C7B370
		private static float ParseFloat(string v, float fallback); // 0x0000000180C7B370-0x0000000180C7B450
		private static void Sanitize(); // 0x0000000180C7B450-0x0000000180C7BA40
		public static string TabLabel(string key); // 0x0000000180C7BA40-0x0000000180C7C0F0
		public static string SortLabel(string sort); // 0x0000000180C7C0F0-0x0000000180C7C290
		public static string ReasonText(int reason); // 0x0000000180C7C290-0x0000000180C7C3F0
		public static string CurrencyName(string currencyType); // 0x0000000180C7C3F0-0x0000000180C7C7E0
		public static string RarityLabel(int rarity); // 0x0000000180C7C7E0-0x0000000180C7CAB0
		public static string ElementName(int index); // 0x0000000180C7CAB0-0x0000000180C7CD80
		public static string RarityFilterLabel(int index); // 0x0000000180C7CD80-0x0000000180C7D050
	}
}
