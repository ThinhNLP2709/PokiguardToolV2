/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class BoardFxTunables // TypeDefIndex: 2334
{
	// Fields
	public static readonly Color DefaultHealColor; // 0x00
	private static bool _snapshotTaken; // 0x10
	private static string _snapshotMatchId; // 0x18
	private static bool _enabled; // 0x20
	private static bool _healAura; // 0x21
	private static bool _stealFlow; // 0x22
	private static float _healSec; // 0x24
	private static float _stealSec; // 0x28
	private static float _stealArc; // 0x2C
	private static int _healMotes; // 0x30
	private static int _stealMotes; // 0x34
	private static Color _healColor; // 0x38
	private static Color _manaColor; // 0x48
	private static Color _powerColor; // 0x58
	private static Color _manaAura; // 0x68
	private static Color _powerAura; // 0x78
	private static Color _shieldAura; // 0x88

	// Properties
	public static Color ManaAuraColor { get; } // 0x0000000180B38B20-0x0000000180B38B90 
	public static Color PowerAuraColor { get; } // 0x0000000180B38B90-0x0000000180B38C00 
	public static Color ShieldAuraColor { get; } // 0x0000000180B38C00-0x0000000180B38C70 
	public static bool HealAura { get; } // 0x0000000180B38C70-0x0000000180B38CE0 
	public static bool StealFlow { get; } // 0x0000000180B38CE0-0x0000000180B38D50 
	public static float HealSec { get; } // 0x0000000180B38D50-0x0000000180B38DB0 
	public static float StealSec { get; } // 0x0000000180B38DB0-0x0000000180B38E10 
	public static float StealArc { get; } // 0x0000000180B38E10-0x0000000180B38E70 
	public static int HealMotes { get; } // 0x0000000180B38E70-0x0000000180B38EE0 
	public static int StealMotes { get; } // 0x0000000180B38EE0-0x0000000180B38F50 
	public static Color HealColor { get; } // 0x0000000180B38F50-0x0000000180B38FC0 
	public static Color ManaColor { get; } // 0x0000000180B38FC0-0x0000000180B39030 
	public static Color PowerColor { get; } // 0x0000000180B39030-0x0000000180B390A0 

	// Constructors
	static BoardFxTunables(); // 0x0000000180B3A260-0x0000000180B3A5A0

	// Methods
	public static void Invalidate(); // 0x0000000180B390A0-0x0000000180B39170
	private static int Budget(int want, int lowCap); // 0x0000000180B39170-0x0000000180B39210
	private static void EnsureSnapshot(); // 0x0000000180B39210-0x0000000180B394C0
	private static void Snapshot(); // 0x0000000180B394C0-0x0000000180B39AD0
	private static void EnsureLoaded(); // 0x0000000180B39AD0-0x0000000180B39B30
	private static float GetFloat(string key, string prop, float def, float min, float max); // 0x0000000180B39B30-0x0000000180B39D50
	private static int GetInt(string key, string prop, int def, int min, int max); // 0x0000000180B39D50-0x0000000180B39F60
	private static string GetString(string key, string prop, string def); // 0x0000000180B39F60-0x0000000180B3A070
	private static Color GetColor(string key, string prop, Color def); // 0x0000000180B3A070-0x0000000180B3A260
}

