/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class SettingsConfig // TypeDefIndex: 1211
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08

	// Properties
	public static StringsCfg Strings { get; } // 0x00000001806D6220-0x00000001806D6290 
	public static ShowCfg Show { get; } // 0x00000001806D6290-0x00000001806D6300 
	public static FxCfg Fx { get; } // 0x00000001806D6300-0x00000001806D6370 
	public static string SupportUrl { get; } // 0x00000001806D6370-0x00000001806D63E0 
	public static float TextScale { get; } // 0x00000001806D63E0-0x00000001806D6450 

	// Nested types
	[Serializable]
	public class StringsCfg // TypeDefIndex: 1212
	{
		// Fields
		public string title; // 0x10
		public string close; // 0x18
		public string secAudio; // 0x20
		public string bgm; // 0x28
		public string sfx; // 0x30
		public string soundOn; // 0x38
		public string soundOff; // 0x40
		public string secStatus; // 0x48
		public string busy; // 0x50
		public string busyHint; // 0x58
		public string secOther; // 0x60
		public string terms; // 0x68
		public string support; // 0x70
		public string version; // 0x78
		public string secAccount; // 0x80
		public string nameLabel; // 0x88
		public string nameUnknown; // 0x90
		public string rename; // 0x98
		public string renameCost; // 0xA0
		public string passwordLabel; // 0xA8
		public string passwordMask; // 0xB0
		public string passwordBtn; // 0xB8
		public string protectLabel; // 0xC0
		public string protectNone; // 0xC8
		public string protectBtn; // 0xD0
		public string idLabel; // 0xD8
		public string copyBtn; // 0xE0
		public string idCopied; // 0xE8
		public string logout; // 0xF0
		public string logoutTitle; // 0xF8
		public string logoutBody; // 0x100
		public string cancel; // 0x108
		public string renameTitle; // 0x110
		public string renameCurrent; // 0x118
		public string renamePlaceholder; // 0x120
		public string renameRules; // 0x128
		public string renameFee; // 0x130
		public string renameWallet; // 0x138
		public string renameCooldown; // 0x140
		public string renameConfirm; // 0x148
		public string renameSending; // 0x150
		public string renameOk; // 0x158
		public string renameLoadFailed; // 0x160
		public string renameFailed; // 0x168
		public string renameOff; // 0x170
		public string errEmpty; // 0x178
		public string errLength; // 0x180
		public string errChars; // 0x188
		public string errSame; // 0x190
		public string errGold; // 0x198

		// Constructors
		public StringsCfg(); // 0x00000001806D91D0-0x00000001806DA870
	}

	[Serializable]
	public class ShowCfg // TypeDefIndex: 1213
	{
		// Fields
		public bool rename; // 0x10
		public bool password; // 0x11
		public bool copyId; // 0x12
		public bool busy; // 0x13
		public bool terms; // 0x14
		public bool support; // 0x15
		public bool version; // 0x16

		// Constructors
		public ShowCfg(); // 0x00000001806DA870-0x00000001806DA890
	}

	[Serializable]
	public class FxCfg // TypeDefIndex: 1214
	{
		// Fields
		public bool enabled; // 0x10
		public float fadeTime; // 0x14
		public float sweepTime; // 0x18
		public float shakeTime; // 0x1C

		// Constructors
		public FxCfg(); // 0x00000001806DA890-0x00000001806DA8B0
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1215
	{
		// Fields
		public StringsCfg strings; // 0x10
		public ShowCfg show; // 0x18
		public FxCfg fx; // 0x20
		public string supportUrl; // 0x28
		public float textScale; // 0x30

		// Constructors
		public RootCfg(); // 0x00000001806DA8B0-0x00000001806DAAE0
	}

	// Constructors
	static SettingsConfig(); // 0x00000001806D9110-0x00000001806D91D0

	// Methods
	public static void Reload(); // 0x00000001806D6450-0x00000001806D6670
	private static void EnsureLoaded(); // 0x00000001806D6670-0x00000001806D66E0
	public static void ApplyJson(string raw); // 0x00000001806D66E0-0x00000001806D6810
	private static void ApplyRemote(); // 0x00000001806D6810-0x00000001806D8630
	private static bool Get(string prop, out string val); // 0x00000001806D8630-0x00000001806D8720
	private static bool ParseBool(string v, bool fallback); // 0x00000001806D8720-0x00000001806D8960
	private static void Sanitize(); // 0x00000001806D8960-0x00000001806D9110
}

