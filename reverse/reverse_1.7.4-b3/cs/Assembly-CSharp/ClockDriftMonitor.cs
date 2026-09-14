/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ClockDriftMonitor // TypeDefIndex: 1189
{
	// Fields
	private static double _anchorMono; // 0x00
	private static DateTime _anchorUtc; // 0x08
	private static bool _anchored; // 0x10
	private static double _driftPct; // 0x18
	private static bool _hasSample; // 0x20

	// Properties
	public static double DriftPctRounded { get; } // 0x00000001806CB990-0x00000001806CBA60 

	// Methods
	public static long? MonoMs(); // 0x00000001806CBA60-0x00000001806CBAF0
	public static void Begin(); // 0x00000001806CBAF0-0x00000001806CBC10
	public static void Sample(); // 0x00000001806CBC10-0x00000001806CBE40
	private static void ReAnchor(double mono, DateTime utc); // 0x00000001806CBE40-0x00000001806CBEC0
}

