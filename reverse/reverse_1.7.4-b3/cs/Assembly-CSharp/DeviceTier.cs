/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class DeviceTier // TypeDefIndex: 1885
{
	// Fields
	private static bool _resolved; // 0x00
	private static DeviceTierLevel _level; // 0x04
	private static string _reason; // 0x08

	// Properties
	public static DeviceTierLevel Current { get; } // 0x000000018091DDF0-0x000000018091DE60 
	public static string Reason { get; } // 0x000000018091DE60-0x000000018091DED0 
	public static string TierProp { get; } // 0x000000018091DED0-0x000000018091DFA0 

	// Constructors
	static DeviceTier(); // 0x000000018091EB20-0x000000018091EBE0

	// Methods
	private static void Resolve(); // 0x000000018091DFA0-0x000000018091E650
	private static DeviceTierLevel Min(DeviceTierLevel a, DeviceTierLevel b); // 0x000000018091E650-0x000000018091E660
	private static DeviceTierLevel ClassifyGpu(string raw); // 0x000000018091E660-0x000000018091E990
	private static int FirstNumberAfter(string s, string marker); // 0x000000018091E990-0x000000018091EA50
	private static int FirstNumber(string s); // 0x000000018091EA50-0x000000018091EB20
}

