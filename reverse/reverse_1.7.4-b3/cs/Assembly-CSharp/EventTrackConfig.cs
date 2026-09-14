/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EventTrackConfig // TypeDefIndex: 607
{
	// Fields
	private static RootCfg _cfg; // 0x00
	private static bool _loaded; // 0x08
	private static int _flag; // 0x0C

	// Properties
	public static FxCfg FxOptions { get; } // 0x0000000180432600-0x0000000180432670 
	public static StringsCfg Strings { get; } // 0x0000000180432670-0x00000001804326E0 
	public static int HubRefetchSec { get; } // 0x00000001804326E0-0x0000000180432750 
	public static float TextScale { get; } // 0x0000000180432750-0x00000001804327C0 
	public static bool Enabled { get; } // 0x00000001804327C0-0x00000001804328C0 
	public static bool FxEnabled { get; } // 0x00000001804328C0-0x0000000180432980 

	// Nested types
	[Serializable]
	public class FxCfg // TypeDefIndex: 608
	{
		// Fields
		public bool enabled; // 0x10
		public bool rain; // 0x11
		public bool lightning; // 0x12
		public bool claimBurst; // 0x13
		public bool revealEquip; // 0x14
		public bool hubFloat; // 0x15

		// Constructors
		public FxCfg(); // 0x000000018032DB80-0x000000018032DB90
	}

	[Serializable]
	private class HubCfg // TypeDefIndex: 609
	{
		// Fields
		public int refetchSec; // 0x10

		// Constructors
		public HubCfg(); // 0x00000001804346A0-0x00000001804346B0
	}

	[Serializable]
	public class StringsCfg // TypeDefIndex: 610
	{
		// Fields
		public string errNetwork; // 0x10
		public string off; // 0x18
		public string comingSoon; // 0x20

		// Constructors
		public StringsCfg(); // 0x00000001804346B0-0x0000000180434830
	}

	[Serializable]
	private class RootCfg // TypeDefIndex: 611
	{
		// Fields
		public FxCfg fx; // 0x10
		public HubCfg hub; // 0x18
		public StringsCfg strings; // 0x20
		public float textScale; // 0x28

		// Constructors
		public RootCfg(); // 0x0000000180434830-0x00000001804349F0
	}

	// Constructors
	static EventTrackConfig(); // 0x0000000180434270-0x0000000180434400

	// Methods
	public static bool Fx(string name); // 0x0000000180432980-0x0000000180432C60
	public static void Reload(); // 0x0000000180432C60-0x0000000180432EA0
	private static void EnsureLoaded(); // 0x0000000180432EA0-0x0000000180432F10
	public static void ApplyJson(string raw); // 0x0000000180432F10-0x0000000180433040
	private static void ApplyRemote(); // 0x0000000180433040-0x0000000180433A80
	private static bool Get(string prop, out string val); // 0x0000000180433A80-0x0000000180433B70
	private static bool ParseBool(string v, bool fallback); // 0x0000000180433B70-0x0000000180433DB0
	private static float ParseFloat(string v, float fallback); // 0x000000018032D140-0x000000018032D220
	private static int ParseInt(string v, int fallback); // 0x000000018032D220-0x000000018032D330
	private static void Sanitize(); // 0x0000000180433DB0-0x0000000180434270
}

