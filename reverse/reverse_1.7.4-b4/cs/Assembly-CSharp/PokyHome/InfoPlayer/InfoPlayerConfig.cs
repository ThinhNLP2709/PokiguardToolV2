/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerConfig // TypeDefIndex: 2819
	{
		// Fields
		private static RootCfg _cfg; // 0x00
		private static bool _loaded; // 0x08
		private static string[] _slotLabelCache; // 0x10
		private static string _slotLabelSource; // 0x18
	
		// Properties
		public static RoutesCfg Routes { get; } // 0x0000000180CFA180-0x0000000180CFA1F0 
		public static CurrencyCfg Currency { get; } // 0x0000000180CFA1F0-0x0000000180CFA260 
		public static StringsCfg Strings { get; } // 0x0000000180CFA260-0x0000000180CFA2D0 
		public static float TextScale { get; } // 0x0000000180CFA2D0-0x0000000180CFA340 
		public static FxCfg Fx { get; } // 0x0000000180CFA340-0x0000000180CFA3B0 
		public static TooltipCfg Tooltip { get; } // 0x0000000180CFA3B0-0x0000000180CFA420 
		public static PerkSummaryCfg PerkSummary { get; } // 0x0000000180CFA420-0x0000000180CFA490 
		public static bool ShowVip { get; } // 0x0000000180CFA490-0x0000000180CFA500 
	
		// Nested types
		[Serializable]
		public class RoutesCfg // TypeDefIndex: 2820
		{
			// Fields
			public string pets; // 0x10
			public string cards; // 0x18
			public string items; // 0x20
	
			// Constructors
			public RoutesCfg(); // 0x0000000180CFE320-0x0000000180CFE4A0
		}
	
		[Serializable]
		public class CurrencyCfg // TypeDefIndex: 2821
		{
			// Fields
			public string honor; // 0x10
			public string gold; // 0x18
			public string star; // 0x20
			public string ticket; // 0x28
	
			// Constructors
			public CurrencyCfg(); // 0x0000000180CFE4A0-0x0000000180CFE690
		}
	
		[Serializable]
		public class StringsCfg // TypeDefIndex: 2822
		{
			// Fields
			public string slotEmpty; // 0x10
			public string petEmpty; // 0x18
			public string equipFailed; // 0x20
			public string equipRejected; // 0x28
			public string unequipFailed; // 0x30
			public string avatarRequired; // 0x38
			public string bagFailed; // 0x40
			public string memberItemFailed; // 0x48
			public string filterInvalid; // 0x50
			public string toggleFailed; // 0x58
			public string starSoon; // 0x60
			public string profileFailed; // 0x68
			public string upgradeFailed; // 0x70
			public string upgradeRejected; // 0x78
			public string upgradeNotEnough; // 0x80
			public string upgradeDone; // 0x88
			public string salvageFailed; // 0x90
			public string salvageRejected; // 0x98
			public string salvageDone; // 0xA0
			public string tooltipShards; // 0xA8
			public string tooltipUpgradeCost; // 0xB0
			public string tooltipUpgrade; // 0xB8
			public string tooltipSalvage; // 0xC0
			public string tooltipSalvageConfirm; // 0xC8
			public string equipOff; // 0xD0
			public string petPickerTitle; // 0xD8
			public string petNone; // 0xE0
			public string petListFailed; // 0xE8
			public string petOffline; // 0xF0
			public string petPickFailed; // 0xF8
			public string petPicked; // 0x100
			public string petPickOff; // 0x108
			public string clubPrefix; // 0x110
			public string avatarSummaryLabels; // 0x118
			public string avatarLevel; // 0x120
			public string avatarExp; // 0x128
			public string avatarCollection; // 0x130
			public string avatarCopyName; // 0x138
			public string avatarNameCopied; // 0x140
			public string avatarAddFriend; // 0x148
			public string avatarFriendSent; // 0x150
			public string avatarFriendFailed; // 0x158
			public string avatarNoGuild; // 0x160
			public string equipCompare; // 0x168
			public string equipCompareEmpty; // 0x170
			public string rarityLabels; // 0x178
			public string slotLabels; // 0x180
			public string tooltipSlot; // 0x188
			public string tooltipPerkTitle; // 0x190
			public string tooltipSetTitle; // 0x198
			public string tooltipSetHint; // 0x1A0
			public string tooltipLuckHint; // 0x1A8
			public string tooltipPerkMore; // 0x1B0
			public string tooltipMemberWorn; // 0x1B8
			public string tooltipMemberOwned; // 0x1C0
			public string tooltipMemberMissing; // 0x1C8
			public string tooltipPerkNote; // 0x1D0
			public string perkSummaryTitle; // 0x1D8
			public string perkSummaryMore; // 0x1E0
	
			// Constructors
			public StringsCfg(); // 0x0000000180CFE690-0x0000000180D00030
		}
	
		[Serializable]
		public class TooltipCfg // TypeDefIndex: 2823
		{
			// Fields
			public bool showPerks; // 0x10
			public bool showSetMembers; // 0x11
			public int setCols; // 0x14
			public int perkMaxRows; // 0x18
			public int memberIcon; // 0x1C
			public bool fx; // 0x20
			public bool perkHints; // 0x21
	
			// Constructors
			public TooltipCfg(); // 0x0000000180D00030-0x0000000180D00050
		}
	
		[Serializable]
		public class PerkSummaryCfg // TypeDefIndex: 2824
		{
			// Fields
			public bool show; // 0x10
			public int fontSize; // 0x14
			public int maxLines; // 0x18
			public float top; // 0x1C
	
			// Constructors
			public PerkSummaryCfg(); // 0x0000000180D00050-0x0000000180D00070
		}
	
		[Serializable]
		public class FxCfg // TypeDefIndex: 2825
		{
			// Fields
			public bool enabled; // 0x10
			public float openTime; // 0x14
			public float sweepTime; // 0x18
			public float sparkTime; // 0x1C
			public float newPulseTime; // 0x20
	
			// Constructors
			public FxCfg(); // 0x0000000180D00070-0x0000000180D000A0
		}
	
		[Serializable]
		private class RootCfg // TypeDefIndex: 2826
		{
			// Fields
			public RoutesCfg routes; // 0x10
			public CurrencyCfg currency; // 0x18
			public StringsCfg strings; // 0x20
			public float textScale; // 0x28
			public FxCfg fx; // 0x30
			public TooltipCfg tooltip; // 0x38
			public PerkSummaryCfg perkSummary; // 0x40
			public bool showVip; // 0x48
	
			// Constructors
			public RootCfg(); // 0x0000000180D000A0-0x0000000180D00410
		}
	
		// Constructors
		static InfoPlayerConfig(); // 0x0000000180CFE260-0x0000000180CFE320
	
		// Methods
		public static void Load(TextAsset json); // 0x0000000180CFA500-0x0000000180CFA7A0
		private static void EnsureLoaded(); // 0x0000000180CFA7A0-0x0000000180CFA810
		public static void ApplyJson(string raw); // 0x0000000180CFA810-0x0000000180CFA940
		private static void ApplyRemote(); // 0x0000000180CFA940-0x0000000180CFCFB0
		private static bool Get(string prop, out string val); // 0x0000000180CFCFB0-0x0000000180CFD0A0
		private static int ParseInt(string v, int fallback); // 0x0000000180CFD0A0-0x0000000180CFD1C0
		private static bool ParseBool(string v, bool fallback); // 0x0000000180CFD1C0-0x0000000180CFD400
		private static void Sanitize(); // 0x0000000180CFD400-0x0000000180CFDC80
		public static string SlotLabel(EquipSlot slot); // 0x0000000180CFDC80-0x0000000180CFDF70
		public static long ResValue(ProfileResDTO res, string field); // 0x0000000180CFDF70-0x0000000180CFE260
	}
}
