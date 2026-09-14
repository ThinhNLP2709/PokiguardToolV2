/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class LoginConfig // TypeDefIndex: 1036
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180645FE0-0x0000000180646040 0x0000000180646040-0x00000001806460A0
	public static StringsCfg Strings { get; } // 0x00000001806460A0-0x0000000180646110 
	public static BgCfg Bg { get; } // 0x0000000180646110-0x0000000180646180 
	public static LayoutCfg Layout { get; } // 0x0000000180646180-0x00000001806461F0 
	public static LoginFxCfg Fx { get; } // 0x00000001806461F0-0x0000000180646260 
	public static RegisterCfg Register { get; } // 0x0000000180646260-0x00000001806462D0 
	public static long HeroPetId { get; } // 0x00000001806462D0-0x0000000180646340 
	public static string HeroMode { get; } // 0x0000000180646340-0x00000001806463B0 
	public static string RigJson { get; } // 0x00000001806463B0-0x0000000180646440 
	public static string SupportUrl { get; } // 0x0000000180646440-0x00000001806464B0 
	public static float TextScale { get; } // 0x00000001806464B0-0x0000000180646520 
	public static bool RegisterEnabled { get; } // 0x0000000180646520-0x0000000180646590 
	public static bool RememberEnabled { get; } // 0x0000000180646590-0x0000000180646630 
	public static bool FxEnabled { get; } // 0x0000000180646630-0x00000001806466D0 
	public static bool BgAnimEnabled { get; } // 0x00000001806466D0-0x0000000180646770 

	// Nested types
	[Serializable]
	public class StringsCfg // TypeDefIndex: 1037
	{
		// Fields
		public string tabLogin; // 0x10
		public string tabRegister; // 0x18
		public string tagline; // 0x20
		public string user; // 0x28
		public string userPh; // 0x30
		public string pass; // 0x38
		public string passPh; // 0x40
		public string remember; // 0x48
		public string forgot; // 0x50
		public string login; // 0x58
		public string retry; // 0x60
		public string update; // 0x68
		public string loginHint; // 0x70
		public string registerClosed; // 0x78
		public string termsNote; // 0x80
		public string name; // 0x88
		public string namePh; // 0x90
		public string nameRule; // 0x98
		public string userRule; // 0xA0
		public string confirm; // 0xA8
		public string register; // 0xB0
		public string registerOk; // 0xB8
		public string deviceNote; // 0xC0
		public string strengthWeak; // 0xC8
		public string strengthMedium; // 0xD0
		public string strengthStrong; // 0xD8
		public string errEmpty; // 0xE0
		public string errMismatch; // 0xE8
		public string errNet; // 0xF0
		public string errRate; // 0xF8
		public string rememberExpired; // 0x100
		public string autoLogin; // 0x108
		public string loggingIn; // 0x110
		public string entering; // 0x118
		public string switchAccount; // 0x120
		public string version; // 0x128
		public string serverOk; // 0x130
		public string serverMaint; // 0x138
		public string serverUnknown; // 0x140
		public string support; // 0x148
		public string forgotNoSupport; // 0x150

		// Constructors
		public StringsCfg(); // 0x0000000180649AE0-0x000000018064AD70
	}

	[Serializable]
	public class BgCfg // TypeDefIndex: 1038
	{
		// Fields
		public bool enabled; // 0x10
		public int orbs; // 0x14
		public int orbsLow; // 0x18
		public bool rays; // 0x1C
		public float starFar; // 0x20
		public float starNear; // 0x24
		public bool shooting; // 0x28
		public bool nebulaDrift; // 0x29
		public int clouds; // 0x2C

		// Constructors
		public BgCfg(); // 0x000000018064AD70-0x000000018064ADB0
	}

	[Serializable]
	public class LayoutCfg // TypeDefIndex: 1039
	{
		// Fields
		public float wideSpread; // 0x10

		// Constructors
		public LayoutCfg(); // 0x000000018064ADB0-0x000000018064ADC0
	}

	[Serializable]
	public class LoginFxCfg // TypeDefIndex: 1040
	{
		// Fields
		public bool enabled; // 0x10
		public float fadeTime; // 0x14
		public bool heroAura; // 0x18
		public int heroSparks; // 0x1C
		public int heroSparksLow; // 0x20
		public int heroPuffs; // 0x24
		public int heroRays; // 0x28

		// Constructors
		public LoginFxCfg(); // 0x000000018064ADC0-0x000000018064ADF0
	}

	[Serializable]
	public class RegisterCfg // TypeDefIndex: 1041
	{
		// Fields
		public int maxPerDevice; // 0x10

		// Constructors
		public RegisterCfg(); // 0x000000018064ADF0-0x000000018064AE00
	}

	[Serializable]
	public class RememberCfg // TypeDefIndex: 1042
	{
		// Fields
		public bool enabled; // 0x10

		// Constructors
		public RememberCfg(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1043
	{
		// Fields
		public StringsCfg strings; // 0x10
		public BgCfg bg; // 0x18
		public LayoutCfg layout; // 0x20
		public LoginFxCfg fx; // 0x28
		public RegisterCfg register; // 0x30
		public RememberCfg remember; // 0x38
		public long heroPetId; // 0x40
		public string heroMode; // 0x48
		public string rigJson; // 0x50
		public string supportUrl; // 0x58
		public float textScale; // 0x60

		// Constructors
		public RootCfg(); // 0x000000018064AE00-0x000000018064B290
	}

	// Constructors
	static LoginConfig(); // 0x0000000180649A20-0x0000000180649AE0

	// Methods
	private static bool Flag(string key); // 0x0000000180646770-0x00000001806467D0
	public static void Reload(); // 0x00000001806467D0-0x0000000180646A80
	public static void Invalidate(); // 0x0000000180646A80-0x0000000180646AE0
	public static void EnsureLoaded(); // 0x0000000180646AE0-0x0000000180646B50
	public static void ApplyJson(string raw); // 0x0000000180646B50-0x0000000180646C80
	private static void ApplyRemote(); // 0x0000000180646C80-0x0000000180648520
	private static bool Get(string prop, out string val); // 0x0000000180648520-0x0000000180648610
	private static bool ParseBool(string v, bool fallback); // 0x0000000180648610-0x0000000180648850
	private static float ParseFloat(string v, float fallback); // 0x0000000180648850-0x0000000180648960
	private static int ParseInt(string v, int fallback); // 0x0000000180648960-0x0000000180648AB0
	private static long ParseLong(string v, long fallback); // 0x0000000180648AB0-0x0000000180648C00
	private static void Sanitize(); // 0x0000000180648C00-0x00000001806499E0
	private static float SafeSpeed(float v, float def); // 0x00000001806499E0-0x0000000180649A20
}

