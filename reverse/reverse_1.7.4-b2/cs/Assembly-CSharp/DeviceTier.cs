/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class DeviceTier // TypeDefIndex: 1502
{
	// Fields
	private static bool _resolved; // 0x00
	private static DeviceTierLevel _level; // 0x04
	private static string _reason; // 0x08

	// Properties
	public static DeviceTierLevel Current { get; } // 0x00000001805DC080-0x00000001805DC0F0 
	public static string Reason { get; } // 0x00000001805DC0F0-0x00000001805DC160 
	public static string TierProp { get; } // 0x00000001805DC160-0x00000001805DC240 

	// Constructors
	static DeviceTier(); // 0x00000001805DC010-0x00000001805DC080

	// Methods
	private static void Resolve(); // 0x00000001805DBAA0-0x00000001805DC010
	private static DeviceTierLevel Min(DeviceTierLevel a, DeviceTierLevel b); // 0x00000001805DBA90-0x00000001805DBAA0
	private static DeviceTierLevel ClassifyGpu(string raw); // 0x00000001805DB650-0x00000001805DB910
	private static int FirstNumberAfter(string s, string marker); // 0x00000001805DB910-0x00000001805DB9B0
	private static int FirstNumber(string s); // 0x00000001805DB9B0-0x00000001805DBA90
}

