/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class VipConfig // TypeDefIndex: 1465
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	private static int _flag; // 0x0C

	// Properties
	public static StringsCfg Strings { get; } // 0x00000001807FA4D0-0x00000001807FA540 
	public static FxCfg Fx { get; } // 0x00000001807FA540-0x00000001807FA5B0 
	public static BadgeCfg Badge { get; } // 0x00000001807FA5B0-0x00000001807FA620 
	public static NameCfg Name { get; } // 0x00000001807FA620-0x00000001807FA690 
	public static float TextScale { get; } // 0x00000001807FA690-0x00000001807FA700 
	public static bool Enabled { get; } // 0x00000001807FA700-0x00000001807FA800 
	public static bool FxEnabled { get; } // 0x00000001807FA800-0x00000001807FA8C0 

	// Nested types
	[Serializable]
	public class StringsCfg // TypeDefIndex: 1466
	{
		// Fields
		public string title; // 0x10
		public string subCurrent; // 0x18
		public string subNone; // 0x20
		public string close; // 0x28
		public string tierName; // 0x30
		public string costDays; // 0x38
		public string activate; // 0x40
		public string extend; // 0x48
		public string locked; // 0x50
		public string needPrev; // 0x58
		public string remaining; // 0x60
		public string notActive; // 0x68
		public string todayTitle; // 0x70
		public string claim; // 0x78
		public string claimed; // 0x80
		public string nextIn; // 0x88
		public string claimBefore; // 0x90
		public string noVip; // 0x98
		public string note; // 0xA0
		public string confirmTitle; // 0xA8
		public string confirmActivate; // 0xB0
		public string confirmExtend; // 0xB8
		public string yes; // 0xC0
		public string no; // 0xC8
		public string sending; // 0xD0
		public string okActivated; // 0xD8
		public string okExtended; // 0xE0
		public string okClaimed; // 0xE8
		public string errNetwork; // 0xF0
		public string off; // 0xF8
		public string comingSoon; // 0x100
		public string safia; // 0x108

		// Constructors
		public StringsCfg(); // 0x00000001807FD5C0-0x00000001807FE440
	}

	[Serializable]
	public class FxCfg // TypeDefIndex: 1467
	{
		// Fields
		public bool enabled; // 0x10
		public bool badgePulse; // 0x11
		public bool claimBurst; // 0x12
		public bool sweep; // 0x13

		// Constructors
		public FxCfg(); // 0x00000001807FE440-0x00000001807FE450
	}

	[Serializable]
	public class BadgeCfg // TypeDefIndex: 1468
	{
		// Fields
		public float scale; // 0x10
		public int minPx; // 0x14
		public int maxPx; // 0x18
		public float gap; // 0x1C
		public bool showInChat; // 0x20
		public bool showInRooms; // 0x21
		public bool showInRankings; // 0x22
		public bool roomFx; // 0x23
		public float roomScale; // 0x24
		public bool compact; // 0x28

		// Constructors
		public BadgeCfg(); // 0x00000001807FE450-0x00000001807FE480
	}

	[Serializable]
	public class NameCfg // TypeDefIndex: 1469
	{
		// Fields
		public bool enabled; // 0x10
		public string color1; // 0x18
		public string color2; // 0x20
		public string color3; // 0x28
		public string plate; // 0x30
		public float padX; // 0x38
		public float padY; // 0x3C
		public float radius; // 0x40
		public bool darkenOutline; // 0x44
		[NonSerialized]
		private Color _c1; // 0x48
		[NonSerialized]
		private Color _c2; // 0x58
		[NonSerialized]
		private Color _c3; // 0x68
		[NonSerialized]
		private Color _plate; // 0x78
		[NonSerialized]
		private bool _parsed; // 0x88

		// Properties
		public Color PlateColor { get; } // 0x00000001807FE500-0x00000001807FE540 

		// Constructors
		public NameCfg(); // 0x00000001807FEAE0-0x00000001807FECF0

		// Methods
		public Color TextColor(int level); // 0x00000001807FE480-0x00000001807FE500
		public void Reparse(); // 0x00000001807FE540-0x00000001807FEA50
		private void EnsureParsed(); // 0x00000001807FEA50-0x00000001807FEA70
		private static Color ParseColor(string hex, string fallback); // 0x00000001807FEA70-0x00000001807FEAE0
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 1470
	{
		// Fields
		public StringsCfg strings; // 0x10
		public FxCfg fx; // 0x18
		public BadgeCfg badge; // 0x20
		public NameCfg name; // 0x28
		public float textScale; // 0x30

		// Constructors
		public RootCfg(); // 0x00000001807FECF0-0x00000001807FEF50
	}

	// Constructors
	static VipConfig(); // 0x00000001807FD4F0-0x00000001807FD5C0

	// Methods
	public static void Reload(); // 0x00000001807FA8C0-0x00000001807FAB00
	private static void EnsureLoaded(); // 0x00000001807FAB00-0x00000001807FAB70
	public static void ApplyJson(string raw); // 0x00000001807FAB70-0x00000001807FACA0
	private static void ApplyRemote(); // 0x00000001807FACA0-0x00000001807FC4C0
	private static bool Get(string prop, out string val); // 0x00000001807FC4C0-0x00000001807FC5B0
	private static bool ParseBool(string v, bool fallback); // 0x00000001807FC5B0-0x00000001807FC7F0
	private static float ParseFloat(string v, float fallback); // 0x000000018032D140-0x000000018032D220
	private static int ParseInt(string v, int fallback); // 0x000000018032D220-0x000000018032D330
	private static void Sanitize(); // 0x00000001807FC7F0-0x00000001807FCDD0
	public static string FormatRemaining(long seconds); // 0x00000001807FCDD0-0x00000001807FD070
	public static string FormatClock(long seconds); // 0x00000001807FD070-0x00000001807FD200
	public static string FormatDate(long untilMs); // 0x00000001807FD200-0x00000001807FD4F0
}

