/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class RageFxTunables // TypeDefIndex: 2372
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
	public static bool Burst { get; } // 0x0000000180B4ED60-0x0000000180B4EDE0 
	public static bool Ready { get; } // 0x0000000180B4EDE0-0x0000000180B4EE50 
	public static bool Popup { get; } // 0x0000000180B4EE50-0x0000000180B4EED0 
	public static float BurstSec { get; } // 0x0000000180B4EED0-0x0000000180B4EF30 
	public static float PulseHz { get; } // 0x0000000180B4EF30-0x0000000180B4EF90 
	public static float RingScale { get; } // 0x0000000180B4EF90-0x0000000180B4EFF0 
	public static Color BurstColor { get; } // 0x0000000180B4EFF0-0x0000000180B4F060 
	private static bool IsLowTier { get; } // 0x0000000180B501E0-0x0000000180B50240 

	// Constructors
	static RageFxTunables(); // 0x0000000180B50240-0x0000000180B503D0

	// Methods
	public static string SpendLabel(int cost); // 0x0000000180B4F060-0x0000000180B4F1F0
	public static void Invalidate(); // 0x0000000180B4F1F0-0x0000000180B4F2C0
	private static void EnsureSnapshot(); // 0x0000000180B4F2C0-0x0000000180B4F570
	private static void Snapshot(); // 0x0000000180B4F570-0x0000000180B4FB00
	private static void EnsureLoaded(); // 0x0000000180B4FB00-0x0000000180B4FB60
	private static float GetFloat(string key, string prop, float def, float min, float max); // 0x0000000180B4FB60-0x0000000180B4FD80
	private static int GetInt(string key, string prop, int def, int min, int max); // 0x0000000180B4FD80-0x0000000180B4FF90
	private static string GetString(string key, string prop, string def); // 0x0000000180B4FF90-0x0000000180B500A0
	private static Color GetColor(string key, string prop, Color def); // 0x0000000180B500A0-0x0000000180B501E0
}

