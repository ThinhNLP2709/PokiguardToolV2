/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class SettingsConfig // TypeDefIndex: 1209
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08

	// Properties
	public static StringsCfg Strings { get; } // 0x00000001806D45B0-0x00000001806D4620 
	public static ShowCfg Show { get; } // 0x00000001806D4620-0x00000001806D4690 
	public static FxCfg Fx { get; } // 0x00000001806D4690-0x00000001806D4700 
	public static string SupportUrl { get; } // 0x00000001806D4700-0x00000001806D4770 
	public static float TextScale { get; } // 0x00000001806D4770-0x00000001806D47E0 

	// Nested types
	[Serializable]
	public class StringsCfg // TypeDefIndex: 1210
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
		public StringsCfg(); // 0x00000001806D7560-0x00000001806D8C00
	}

	[Serializable]
	public class ShowCfg // TypeDefIndex: 1211
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
		public ShowCfg(); // 0x00000001806D8C00-0x00000001806D8C20
	}

	[Serializable]
	public class FxCfg // TypeDefIndex: 1212
	{
		// Fields
		public bool enabled; // 0x10
		public float fadeTime; // 0x14
		public float sweepTime; // 0x18
		public float shakeTime; // 0x1C

		// Constructors
		public FxCfg(); // 0x00000001806D8C20-0x00000001806D8C40
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1213
	{
		// Fields
		public StringsCfg strings; // 0x10
		public ShowCfg show; // 0x18
		public FxCfg fx; // 0x20
		public string supportUrl; // 0x28
		public float textScale; // 0x30

		// Constructors
		public RootCfg(); // 0x00000001806D8C40-0x00000001806D8E70
	}

	// Constructors
	static SettingsConfig(); // 0x00000001806D74A0-0x00000001806D7560

	// Methods
	public static void Reload(); // 0x00000001806D47E0-0x00000001806D4A00
	private static void EnsureLoaded(); // 0x00000001806D4A00-0x00000001806D4A70
	public static void ApplyJson(string raw); // 0x00000001806D4A70-0x00000001806D4BA0
	private static void ApplyRemote(); // 0x00000001806D4BA0-0x00000001806D69C0
	private static bool Get(string prop, out string val); // 0x00000001806D69C0-0x00000001806D6AB0
	private static bool ParseBool(string v, bool fallback); // 0x00000001806D6AB0-0x00000001806D6CF0
	private static void Sanitize(); // 0x00000001806D6CF0-0x00000001806D74A0
}

