/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class DeviceTier // TypeDefIndex: 1887
{
	// Fields
	private static bool _resolved; // 0x00
	private static DeviceTierLevel _level; // 0x04
	private static string _reason; // 0x08

	// Properties
	public static DeviceTierLevel Current { get; } // 0x0000000180921330-0x00000001809213A0 
	public static string Reason { get; } // 0x00000001809213A0-0x0000000180921410 
	public static string TierProp { get; } // 0x0000000180921410-0x00000001809214E0 

	// Constructors
	static DeviceTier(); // 0x0000000180922060-0x0000000180922120

	// Methods
	private static void Resolve(); // 0x00000001809214E0-0x0000000180921B90
	private static DeviceTierLevel Min(DeviceTierLevel a, DeviceTierLevel b); // 0x0000000180921B90-0x0000000180921BA0
	private static DeviceTierLevel ClassifyGpu(string raw); // 0x0000000180921BA0-0x0000000180921ED0
	private static int FirstNumberAfter(string s, string marker); // 0x0000000180921ED0-0x0000000180921F90
	private static int FirstNumber(string s); // 0x0000000180921F90-0x0000000180922060
}

