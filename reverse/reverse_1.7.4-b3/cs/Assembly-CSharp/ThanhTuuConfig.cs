/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ThanhTuuConfig // TypeDefIndex: 1242
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	private static int _flag; // 0x0C
	private static readonly Dictionary<string, Vector4> _rects; // 0x10
	private static readonly Dictionary<string, Color> _colors; // 0x18
	private static readonly Dictionary<string, int> _fonts; // 0x20
	private static int _version; // 0x28
	private static long _seenRemoteVersion; // 0x30
	private static ThanhTuuStrings _stringsSrc; // 0x38
	private static ThanhTuuStrings _stringsMerged; // 0x40

	// Properties
	public static FxCfg FxOptions { get; } // 0x00000001806FFB00-0x00000001806FFB70 
	public static int HubRefetchSec { get; } // 0x00000001806FFB70-0x00000001806FFBE0 
	public static Vector2 HubPlazaPos { get; } // 0x00000001806FFBE0-0x00000001806FFC60 
	public static Vector2 HubNarrowPos { get; } // 0x00000001806FFC60-0x00000001806FFCE0 
	public static float HubNarrowScale { get; } // 0x00000001806FFCE0-0x00000001806FFD60 
	public static float TextScale { get; } // 0x00000001806FFD60-0x00000001806FFDD0 
	public static float FontBonus { get; } // 0x00000001806FFDD0-0x00000001806FFE40 
	public static float MarqueeSpeed { get; } // 0x00000001806FFE40-0x00000001806FFEB0 
	public static int Version { get; } // 0x00000001806FFEB0-0x00000001806FFF10 
	public static ThanhTuuStrings Strings { get; } // 0x00000001806FFF10-0x0000000180700140 
	public static bool Enabled { get; } // 0x0000000180700140-0x0000000180700240 
	public static bool FxEnabled { get; } // 0x0000000180700240-0x0000000180700300 

	// Nested types
	[Serializable]
	public class FxCfg // TypeDefIndex: 1243
	{
		// Fields
		public bool enabled; // 0x10
		public bool burst; // 0x11
		public bool stars; // 0x12
		public bool twinkle; // 0x13
		public bool countUp; // 0x14
		public bool fly; // 0x15
		public bool stamp; // 0x16
		public bool pulse; // 0x17

		// Constructors
		public FxCfg(); // 0x0000000180702E50-0x0000000180702E60
	}

	[Serializable]
	private class HubCfg // TypeDefIndex: 1244
	{
		// Fields
		public int refetchSec; // 0x10
		public float plazaX; // 0x14
		public float plazaY; // 0x18
		public float narrowX; // 0x1C
		public float narrowY; // 0x20
		public float narrowScale; // 0x24

		// Constructors
		public HubCfg(); // 0x0000000180702E60-0x0000000180702E90
	}

	[Serializable]
	public class RectOverride // TypeDefIndex: 1245
	{
		// Fields
		public string k; // 0x10
		public float[] v; // 0x18

		// Constructors
		public RectOverride(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class ColorOverride // TypeDefIndex: 1246
	{
		// Fields
		public string k; // 0x10
		public string v; // 0x18

		// Constructors
		public ColorOverride(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class FontOverride // TypeDefIndex: 1247
	{
		// Fields
		public string k; // 0x10
		public float v; // 0x18

		// Constructors
		public FontOverride(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1248
	{
		// Fields
		public FxCfg fx; // 0x10
		public HubCfg hub; // 0x18
		public float textScale; // 0x20
		public float fontBonus; // 0x24
		public float marqueeSpeed; // 0x28
		public RectOverride[] rects; // 0x30
		public ColorOverride[] colors; // 0x38
		public FontOverride[] fonts; // 0x40

		// Constructors
		public RootCfg(); // 0x0000000180702E90-0x0000000180702FF0
	}

	// Constructors
	static ThanhTuuConfig(); // 0x0000000180702A20-0x0000000180702E50

	// Methods
	public static bool Fx(string name); // 0x0000000180700300-0x00000001807007D0
	public static Vector4 Rect(string key, Vector4 def); // 0x00000001807007D0-0x00000001807008D0
	public static Color Color(string key, Color def); // 0x00000001807008D0-0x00000001807009D0
	public static int Font(string key, int def); // 0x00000001807009D0-0x0000000180700AD0
	public static void Reload(); // 0x0000000180700AD0-0x0000000180700C50
	private static void EnsureLoaded(); // 0x0000000180700C50-0x0000000180700CC0
	public static void ApplyJson(string raw); // 0x0000000180700CC0-0x0000000180700DF0
	private static void ApplyRemote(); // 0x0000000180700DF0-0x0000000180701980
	private static bool Get(string prop, out string val); // 0x0000000180701980-0x0000000180701A70
	private static bool ParseBool(string v, bool fallback); // 0x0000000180701A70-0x0000000180701CB0
	private static float ParseFloat(string v, float fallback); // 0x000000018032D140-0x000000018032D220
	private static int ParseInt(string v, int fallback); // 0x000000018032D220-0x000000018032D330
	private static void Sanitize(); // 0x0000000180701CB0-0x0000000180702140
	private static void RebuildOverrides(); // 0x0000000180702140-0x0000000180702850
	private static bool ValidKey(string k); // 0x0000000180702850-0x00000001807028E0
	private static bool IsHexColor(string v); // 0x00000001807028E0-0x0000000180702960
	private static bool IsFinite(float f); // 0x0000000180702960-0x0000000180702990
	private static float Finite(float f, float fallback); // 0x0000000180702990-0x0000000180702A20
}

