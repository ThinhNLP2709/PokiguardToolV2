/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EventTrackConfig // TypeDefIndex: 608
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	private static int _flag; // 0x0C

	// Properties
	public static FxCfg FxOptions { get; } // 0x0000000180433A30-0x0000000180433AA0 
	public static StringsCfg Strings { get; } // 0x0000000180433AA0-0x0000000180433B10 
	public static int HubRefetchSec { get; } // 0x0000000180433B10-0x0000000180433B80 
	public static float TextScale { get; } // 0x0000000180433B80-0x0000000180433BF0 
	public static bool Enabled { get; } // 0x0000000180433BF0-0x0000000180433CF0 
	public static bool FxEnabled { get; } // 0x0000000180433CF0-0x0000000180433DB0 

	// Nested types
	[Serializable]
	public class FxCfg // TypeDefIndex: 609
	{
		// Fields
		public bool enabled; // 0x10
		public bool rain; // 0x11
		public bool lightning; // 0x12
		public bool claimBurst; // 0x13
		public bool revealEquip; // 0x14
		public bool hubFloat; // 0x15

		// Constructors
		public FxCfg(); // 0x000000018032DCA0-0x000000018032DCB0
	}

	[Serializable]
	private class HubCfg // TypeDefIndex: 610
	{
		// Fields
		public int refetchSec; // 0x10

		// Constructors
		public HubCfg(); // 0x0000000180435770-0x0000000180435780
	}

	[Serializable]
	public class StringsCfg // TypeDefIndex: 611
	{
		// Fields
		public string errNetwork; // 0x10
		public string off; // 0x18
		public string comingSoon; // 0x20

		// Constructors
		public StringsCfg(); // 0x0000000180435780-0x0000000180435900
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 612
	{
		// Fields
		public FxCfg fx; // 0x10
		public HubCfg hub; // 0x18
		public StringsCfg strings; // 0x20
		public float textScale; // 0x28

		// Constructors
		public RootCfg(); // 0x0000000180435900-0x0000000180435AC0
	}

	// Constructors
	static EventTrackConfig(); // 0x00000001804356A0-0x0000000180435770

	// Methods
	public static bool Fx(string name); // 0x0000000180433DB0-0x0000000180434090
	public static void Reload(); // 0x0000000180434090-0x00000001804342D0
	private static void EnsureLoaded(); // 0x00000001804342D0-0x0000000180434340
	public static void ApplyJson(string raw); // 0x0000000180434340-0x0000000180434470
	private static void ApplyRemote(); // 0x0000000180434470-0x0000000180434EB0
	private static bool Get(string prop, out string val); // 0x0000000180434EB0-0x0000000180434FA0
	private static bool ParseBool(string v, bool fallback); // 0x0000000180434FA0-0x00000001804351E0
	private static float ParseFloat(string v, float fallback); // 0x000000018032D260-0x000000018032D340
	private static int ParseInt(string v, int fallback); // 0x000000018032D340-0x000000018032D450
	private static void Sanitize(); // 0x00000001804351E0-0x00000001804356A0
}

