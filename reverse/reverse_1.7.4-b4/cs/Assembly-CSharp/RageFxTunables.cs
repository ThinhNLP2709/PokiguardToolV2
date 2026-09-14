/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RageFxTunables // TypeDefIndex: 2379
{
	// Fields
	private static bool _snapshotTaken; // 0x00
	private static string _snapshotMatchId; // 0x08
	private static bool _enabled; // 0x10
	private static bool _burst; // 0x11
	private static bool _ready; // 0x12
	private static bool _popup; // 0x13
	private static float _burstSec; // 0x14
	private static float _pulseHz; // 0x18
	private static float _ringScale; // 0x1C
	private static string _spendText; // 0x20
	private static Color _burstColor; // 0x28

	// Properties
	public static bool Burst { get; } // 0x0000000180B5BFE0-0x0000000180B5C060 
	public static bool Ready { get; } // 0x0000000180B5C060-0x0000000180B5C0D0 
	public static bool Popup { get; } // 0x0000000180B5C0D0-0x0000000180B5C150 
	public static float BurstSec { get; } // 0x0000000180B5C150-0x0000000180B5C1B0 
	public static float PulseHz { get; } // 0x0000000180B5C1B0-0x0000000180B5C210 
	public static float RingScale { get; } // 0x0000000180B5C210-0x0000000180B5C270 
	public static Color BurstColor { get; } // 0x0000000180B5C270-0x0000000180B5C2E0 
	private static bool IsLowTier { get; } // 0x0000000180B5D460-0x0000000180B5D4C0 

	// Constructors
	static RageFxTunables(); // 0x0000000180B5D4C0-0x0000000180B5D650

	// Methods
	public static string SpendLabel(int cost); // 0x0000000180B5C2E0-0x0000000180B5C470
	public static void Invalidate(); // 0x0000000180B5C470-0x0000000180B5C540
	private static void EnsureSnapshot(); // 0x0000000180B5C540-0x0000000180B5C7F0
	private static void Snapshot(); // 0x0000000180B5C7F0-0x0000000180B5CD80
	private static void EnsureLoaded(); // 0x0000000180B5CD80-0x0000000180B5CDE0
	private static float GetFloat(string key, string prop, float def, float min, float max); // 0x0000000180B5CDE0-0x0000000180B5D000
	private static int GetInt(string key, string prop, int def, int min, int max); // 0x0000000180B5D000-0x0000000180B5D210
	private static string GetString(string key, string prop, string def); // 0x0000000180B5D210-0x0000000180B5D320
	private static Color GetColor(string key, string prop, Color def); // 0x0000000180B5D320-0x0000000180B5D460
}

