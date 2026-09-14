/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class CanDauVanConfig // TypeDefIndex: 389
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	private static int _flag; // 0x0C

	// Properties
	public static FxCfg FxOptions { get; } // 0x000000018032B890-0x000000018032B900 
	public static StringsCfg Strings { get; } // 0x000000018032B900-0x000000018032B970 
	public static int HubRefetchSec { get; } // 0x000000018032B970-0x000000018032B9E0 
	public static Vector2 HubPlazaPos { get; } // 0x000000018032B9E0-0x000000018032BA60 
	public static float TextScale { get; } // 0x000000018032BA60-0x000000018032BAD0 
	public static float FontBonus { get; } // 0x000000018032BAD0-0x000000018032BB40 
	public static bool Enabled { get; } // 0x000000018032BB40-0x000000018032BC40 
	public static bool FxEnabled { get; } // 0x000000018032BC40-0x000000018032BD00 

	// Nested types
	[Serializable]
	public class FxCfg // TypeDefIndex: 390
	{
		// Fields
		public bool enabled; // 0x10
		public bool diceRing; // 0x11
		public bool hop; // 0x12
		public bool rewardFly; // 0x13
		public bool giftRays; // 0x14
		public bool glow; // 0x15

		// Constructors
		public FxCfg(); // 0x000000018032DB80-0x000000018032DB90
	}

	[Serializable]
	private class HubCfg // TypeDefIndex: 391
	{
		// Fields
		public int refetchSec; // 0x10
		public float plazaX; // 0x14
		public float plazaY; // 0x18

		// Constructors
		public HubCfg(); // 0x000000018032DB90-0x000000018032DBB0
	}

	[Serializable]
	public class StringsCfg // TypeDefIndex: 392
	{
		// Fields
		public string errNetwork; // 0x10
		public string off; // 0x18
		public string comingSoon; // 0x20

		// Constructors
		public StringsCfg(); // 0x000000018032DBB0-0x000000018032DD30
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 393
	{
		// Fields
		public FxCfg fx; // 0x10
		public HubCfg hub; // 0x18
		public StringsCfg strings; // 0x20
		public float textScale; // 0x28
		public float fontBonus; // 0x2C

		// Constructors
		public RootCfg(); // 0x000000018032DD30-0x000000018032DF00
	}

	// Constructors
	static CanDauVanConfig(); // 0x000000018032DAB0-0x000000018032DB80

	// Methods
	public static bool Fx(string name); // 0x000000018032BD00-0x000000018032C020
	public static void Reload(); // 0x000000018032C020-0x000000018032C260
	private static void EnsureLoaded(); // 0x000000018032C260-0x000000018032C2D0
	public static void ApplyJson(string raw); // 0x000000018032C2D0-0x000000018032C400
	private static void ApplyRemote(); // 0x000000018032C400-0x000000018032CE10
	private static bool Get(string prop, out string val); // 0x000000018032CE10-0x000000018032CF00
	private static bool ParseBool(string v, bool fallback); // 0x000000018032CF00-0x000000018032D140
	private static float ParseFloat(string v, float fallback); // 0x000000018032D140-0x000000018032D220
	private static int ParseInt(string v, int fallback); // 0x000000018032D220-0x000000018032D330
	private static void Sanitize(); // 0x000000018032D330-0x000000018032DAB0
}

