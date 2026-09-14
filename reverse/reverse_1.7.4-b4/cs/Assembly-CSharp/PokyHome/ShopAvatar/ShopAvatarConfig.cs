/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.ShopAvatar
{
	public static class ShopAvatarConfig // TypeDefIndex: 2749
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
		public static StringsCfg Strings { get; } // 0x0000000180CABF40-0x0000000180CABFB0 
		public static FxCfg Fx { get; } // 0x0000000180CABFB0-0x0000000180CAC020 
		public static RoutesCfg Routes { get; } // 0x0000000180CAC020-0x0000000180CAC090 
		public static PortraitCfg Portrait { get; } // 0x0000000180CAC090-0x0000000180CAC100 
		public static PreviewCfg Preview { get; } // 0x0000000180CAC100-0x0000000180CAC170 
		public static int PageSize { get; } // 0x0000000180CAC170-0x0000000180CAC1E0 
	
		// Nested types
		[Serializable]
		public class TabCfg // TypeDefIndex: 2750
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
			public TabCfg(); // 0x0000000180CB07F0-0x0000000180CB0DE0
		}
	
		[Serializable]
		public class SortCfg // TypeDefIndex: 2751
		{
			// Fields
			public string @new; // 0x10
			public string price; // 0x18
			public string power; // 0x20
	
			// Constructors
			public SortCfg(); // 0x0000000180CB0DE0-0x0000000180CB0F60
		}
	
		[Serializable]
		public class StringsCfg // TypeDefIndex: 2752
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
			public StringsCfg(); // 0x0000000180CB0F60-0x0000000180CB2380
		}
	
		[Serializable]
		public class FxCfg // TypeDefIndex: 2753
		{
			// Fields
			public bool enabled; // 0x10
			public float openTime; // 0x14
			public float stagger; // 0x18
			public float selectPulse; // 0x1C
			public float sweepTime; // 0x20
	
			// Constructors
			public FxCfg(); // 0x0000000180CB2380-0x0000000180CB23B0
		}
	
		[Serializable]
		public class RoutesCfg // TypeDefIndex: 2754
		{
			// Fields
			public string recharge; // 0x10
	
			// Constructors
			public RoutesCfg(); // 0x0000000180CB23B0-0x0000000180CB2440
		}
	
		[Serializable]
		public class PortraitCfg // TypeDefIndex: 2755
		{
			// Fields
			public bool enabled; // 0x10
	
			// Constructors
			public PortraitCfg(); // 0x0000000180308BD0-0x0000000180308BE0
		}
	
		[Serializable]
		public class PreviewCfg // TypeDefIndex: 2756
		{
			// Fields
			public float avatarFill; // 0x10
			public float avatarOffsetY; // 0x14
			public float fallbackScale; // 0x18
	
			// Constructors
			public PreviewCfg(); // 0x0000000180CB2440-0x0000000180CB2450
		}
	
		[Serializable]
		private class RootCfg // TypeDefIndex: 2757
		{
			// Fields
			public StringsCfg strings; // 0x10
			public FxCfg fx; // 0x18
			public RoutesCfg routes; // 0x20
			public PortraitCfg portrait; // 0x28
			public PreviewCfg preview; // 0x30
			public int pageSize; // 0x38
	
			// Constructors
			public RootCfg(); // 0x0000000180CB2450-0x0000000180CB2720
		}
	
		// Constructors
		static ShopAvatarConfig(); // 0x0000000180CB0730-0x0000000180CB07F0
	
		// Methods
		public static void Load(TextAsset json); // 0x0000000180CAC1E0-0x0000000180CAC480
		private static void EnsureLoaded(); // 0x0000000180CAC480-0x0000000180CAC4F0
		public static void ApplyJson(string raw); // 0x0000000180CAC4F0-0x0000000180CAC620
		private static void ApplyRemote(); // 0x0000000180CAC620-0x0000000180CAE720
		private static bool Get(string prop, out string val); // 0x0000000180CAE720-0x0000000180CAE810
		private static bool ParseBool(string v, bool fallback); // 0x0000000180CAE810-0x0000000180CAEA50
		private static float ParseFloat(string v, float fallback); // 0x0000000180CAEA50-0x0000000180CAEB30
		private static void Sanitize(); // 0x0000000180CAEB30-0x0000000180CAF120
		public static string TabLabel(string key); // 0x0000000180CAF120-0x0000000180CAF7D0
		public static string SortLabel(string sort); // 0x0000000180CAF7D0-0x0000000180CAF970
		public static string ReasonText(int reason); // 0x0000000180CAF970-0x0000000180CAFAD0
		public static string CurrencyName(string currencyType); // 0x0000000180CAFAD0-0x0000000180CAFEC0
		public static string RarityLabel(int rarity); // 0x0000000180CAFEC0-0x0000000180CB0190
		public static string ElementName(int index); // 0x0000000180CB0190-0x0000000180CB0460
		public static string RarityFilterLabel(int index); // 0x0000000180CB0460-0x0000000180CB0730
	}
}
