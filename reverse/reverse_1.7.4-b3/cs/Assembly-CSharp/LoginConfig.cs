/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginConfig // TypeDefIndex: 1034
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	[CompilerGenerated]
	private static long _Version_k__BackingField; // 0x10

	// Properties
	public static long Version { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806445F0-0x0000000180644650 0x0000000180644650-0x00000001806446B0
	public static StringsCfg Strings { get; } // 0x00000001806446B0-0x0000000180644720 
	public static BgCfg Bg { get; } // 0x0000000180644720-0x0000000180644790 
	public static LayoutCfg Layout { get; } // 0x0000000180644790-0x0000000180644800 
	public static LoginFxCfg Fx { get; } // 0x0000000180644800-0x0000000180644870 
	public static RegisterCfg Register { get; } // 0x0000000180644870-0x00000001806448E0 
	public static long HeroPetId { get; } // 0x00000001806448E0-0x0000000180644950 
	public static string HeroMode { get; } // 0x0000000180644950-0x00000001806449C0 
	public static string RigJson { get; } // 0x00000001806449C0-0x0000000180644A50 
	public static string SupportUrl { get; } // 0x0000000180644A50-0x0000000180644AC0 
	public static float TextScale { get; } // 0x0000000180644AC0-0x0000000180644B30 
	public static bool RegisterEnabled { get; } // 0x0000000180644B30-0x0000000180644BA0 
	public static bool RememberEnabled { get; } // 0x0000000180644BA0-0x0000000180644C40 
	public static bool FxEnabled { get; } // 0x0000000180644C40-0x0000000180644CE0 
	public static bool BgAnimEnabled { get; } // 0x0000000180644CE0-0x0000000180644D80 

	// Nested types
	[Serializable]
	public class StringsCfg // TypeDefIndex: 1035
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
		public StringsCfg(); // 0x00000001806480F0-0x0000000180649380
	}

	[Serializable]
	public class BgCfg // TypeDefIndex: 1036
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
		public BgCfg(); // 0x0000000180649380-0x00000001806493C0
	}

	[Serializable]
	public class LayoutCfg // TypeDefIndex: 1037
	{
		// Fields
		public float wideSpread; // 0x10

		// Constructors
		public LayoutCfg(); // 0x00000001806493C0-0x00000001806493D0
	}

	[Serializable]
	public class LoginFxCfg // TypeDefIndex: 1038
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
		public LoginFxCfg(); // 0x00000001806493D0-0x0000000180649400
	}

	[Serializable]
	public class RegisterCfg // TypeDefIndex: 1039
	{
		// Fields
		public int maxPerDevice; // 0x10

		// Constructors
		public RegisterCfg(); // 0x0000000180649400-0x0000000180649410
	}

	[Serializable]
	public class RememberCfg // TypeDefIndex: 1040
	{
		// Fields
		public bool enabled; // 0x10

		// Constructors
		public RememberCfg(); // 0x0000000180308BA0-0x0000000180308BB0
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1041
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
		public RootCfg(); // 0x0000000180649410-0x00000001806498A0
	}

	// Constructors
	static LoginConfig(); // 0x0000000180648030-0x00000001806480F0

	// Methods
	private static bool Flag(string key); // 0x0000000180644D80-0x0000000180644DE0
	public static void Reload(); // 0x0000000180644DE0-0x0000000180645090
	public static void Invalidate(); // 0x0000000180645090-0x00000001806450F0
	public static void EnsureLoaded(); // 0x00000001806450F0-0x0000000180645160
	public static void ApplyJson(string raw); // 0x0000000180645160-0x0000000180645290
	private static void ApplyRemote(); // 0x0000000180645290-0x0000000180646B30
	private static bool Get(string prop, out string val); // 0x0000000180646B30-0x0000000180646C20
	private static bool ParseBool(string v, bool fallback); // 0x0000000180646C20-0x0000000180646E60
	private static float ParseFloat(string v, float fallback); // 0x0000000180646E60-0x0000000180646F70
	private static int ParseInt(string v, int fallback); // 0x0000000180646F70-0x00000001806470C0
	private static long ParseLong(string v, long fallback); // 0x00000001806470C0-0x0000000180647210
	private static void Sanitize(); // 0x0000000180647210-0x0000000180647FF0
	private static float SafeSpeed(float v, float def); // 0x0000000180647FF0-0x0000000180648030
}

