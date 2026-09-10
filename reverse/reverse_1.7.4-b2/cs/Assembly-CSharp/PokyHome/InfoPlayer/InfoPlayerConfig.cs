/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerConfig // TypeDefIndex: 2369
	{
		// Fields
		public const string UI_KEY = "infoplayer"; // Metadata: 0x0068EDE4
		public const string RESOURCE_NAME = "InfoPlayerConfig"; // Metadata: 0x0068EDEF
		private static RootCfg _cfg; // 0x00
		private static bool _loaded; // 0x08
		private static string[] _slotLabelCache; // 0x10
		private static string _slotLabelSource; // 0x18
	
		// Properties
		public static RoutesCfg Routes { get; } // 0x00000001807DBD00-0x00000001807DBD70 
		public static CurrencyCfg Currency { get; } // 0x00000001807DBC20-0x00000001807DBC90 
		public static StringsCfg Strings { get; } // 0x00000001807DBDE0-0x00000001807DBE50 
		public static float TextScale { get; } // 0x00000001807DBE50-0x00000001807DBEC0 
		public static FxCfg Fx { get; } // 0x00000001807DBC90-0x00000001807DBD00 
		public static bool ShowVip { get; } // 0x00000001807DBD70-0x00000001807DBDE0 
	
		// Nested types
		[Serializable]
		public class RoutesCfg // TypeDefIndex: 2370
		{
			// Fields
			public string pets; // 0x10
			public string cards; // 0x18
			public string items; // 0x20
	
			// Constructors
			public RoutesCfg(); // 0x00000001807F2430-0x00000001807F24D0
		}
	
		[Serializable]
		public class CurrencyCfg // TypeDefIndex: 2371
		{
			// Fields
			public string honor; // 0x10
			public string gold; // 0x18
			public string star; // 0x20
			public string ticket; // 0x28
	
			// Constructors
			public CurrencyCfg(); // 0x00000001807DCD00-0x00000001807DCDD0
		}
	
		[Serializable]
		public class StringsCfg // TypeDefIndex: 2372
		{
			// Fields
			public string slotEmpty; // 0x10
			public string petEmpty; // 0x18
			public string equipFailed; // 0x20
			public string equipRejected; // 0x28
			public string unequipFailed; // 0x30
			public string avatarRequired; // 0x38
			public string bagFailed; // 0x40
			public string filterInvalid; // 0x48
			public string toggleFailed; // 0x50
			public string starSoon; // 0x58
			public string profileFailed; // 0x60
			public string upgradeFailed; // 0x68
			public string upgradeRejected; // 0x70
			public string upgradeNotEnough; // 0x78
			public string upgradeDone; // 0x80
			public string salvageFailed; // 0x88
			public string salvageRejected; // 0x90
			public string salvageDone; // 0x98
			public string tooltipShards; // 0xA0
			public string tooltipUpgradeCost; // 0xA8
			public string tooltipUpgrade; // 0xB0
			public string tooltipSalvage; // 0xB8
			public string tooltipSalvageConfirm; // 0xC0
			public string equipOff; // 0xC8
			public string petPickerTitle; // 0xD0
			public string petNone; // 0xD8
			public string petListFailed; // 0xE0
			public string petOffline; // 0xE8
			public string petPickFailed; // 0xF0
			public string petPicked; // 0xF8
			public string petPickOff; // 0x100
			public string clubPrefix; // 0x108
			public string avatarSummaryLabels; // 0x110
			public string avatarLevel; // 0x118
			public string avatarExp; // 0x120
			public string avatarCollection; // 0x128
			public string avatarCopyName; // 0x130
			public string avatarNameCopied; // 0x138
			public string avatarAddFriend; // 0x140
			public string avatarFriendSent; // 0x148
			public string avatarFriendFailed; // 0x150
			public string avatarNoGuild; // 0x158
			public string equipCompare; // 0x160
			public string equipCompareEmpty; // 0x168
			public string rarityLabels; // 0x170
			public string slotLabels; // 0x178
	
			// Constructors
			public StringsCfg(); // 0x00000001807F3440-0x00000001807F3C30
		}
	
		[Serializable]
		public class FxCfg // TypeDefIndex: 2373
		{
			// Fields
			public bool enabled; // 0x10
			public float openTime; // 0x14
			public float sweepTime; // 0x18
			public float sparkTime; // 0x1C
			public float newPulseTime; // 0x20
	
			// Constructors
			public FxCfg(); // 0x00000001807DCF90-0x00000001807DCFC0
		}
	
		[Serializable]
		private class RootCfg // TypeDefIndex: 2374
		{
			// Fields
			public RoutesCfg routes; // 0x10
			public CurrencyCfg currency; // 0x18
			public StringsCfg strings; // 0x20
			public float textScale; // 0x28
			public FxCfg fx; // 0x30
			public bool showVip; // 0x38
	
			// Constructors
			public RootCfg(); // 0x00000001807F21D0-0x00000001807F2430
		}
	
		// Constructors
		static InfoPlayerConfig(); // 0x00000001807DBBA0-0x00000001807DBC20
	
		// Methods
		public static void Load(TextAsset json); // 0x00000001807DB1B0-0x00000001807DB320
		private static void EnsureLoaded(); // 0x00000001807DAF60-0x00000001807DB110
		public static void ApplyJson(string raw); // 0x00000001807D9DE0-0x00000001807D9F00
		private static void ApplyRemote(); // 0x00000001807D9F00-0x00000001807DAF60
		private static bool Get(string prop, out string val); // 0x00000001807DB110-0x00000001807DB1B0
		private static bool ParseBool(string v, bool fallback); // 0x00000001807DB320-0x00000001807DB430
		private static void Sanitize(); // 0x00000001807DB600-0x00000001807DB970
		public static string SlotLabel(EquipSlot slot); // 0x00000001807DB970-0x00000001807DBBA0
		public static long ResValue(ProfileResDTO res, string field); // 0x00000001807DB430-0x00000001807DB600
	}
}
