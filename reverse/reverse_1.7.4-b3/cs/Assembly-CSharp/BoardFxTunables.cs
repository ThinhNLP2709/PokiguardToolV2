/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class BoardFxTunables // TypeDefIndex: 2327
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
	public static Color ManaAuraColor { get; } // 0x0000000180B2B940-0x0000000180B2B9B0 
	public static Color PowerAuraColor { get; } // 0x0000000180B2B9B0-0x0000000180B2BA20 
	public static Color ShieldAuraColor { get; } // 0x0000000180B2BA20-0x0000000180B2BA90 
	public static bool HealAura { get; } // 0x0000000180B2BA90-0x0000000180B2BB00 
	public static bool StealFlow { get; } // 0x0000000180B2BB00-0x0000000180B2BB70 
	public static float HealSec { get; } // 0x0000000180B2BB70-0x0000000180B2BBD0 
	public static float StealSec { get; } // 0x0000000180B2BBD0-0x0000000180B2BC30 
	public static float StealArc { get; } // 0x0000000180B2BC30-0x0000000180B2BC90 
	public static int HealMotes { get; } // 0x0000000180B2BC90-0x0000000180B2BD00 
	public static int StealMotes { get; } // 0x0000000180B2BD00-0x0000000180B2BD70 
	public static Color HealColor { get; } // 0x0000000180B2BD70-0x0000000180B2BDE0 
	public static Color ManaColor { get; } // 0x0000000180B2BDE0-0x0000000180B2BE50 
	public static Color PowerColor { get; } // 0x0000000180B2BE50-0x0000000180B2BEC0 

	// Constructors
	static BoardFxTunables(); // 0x0000000180B2D080-0x0000000180B2D260

	// Methods
	public static void Invalidate(); // 0x0000000180B2BEC0-0x0000000180B2BF90
	private static int Budget(int want, int lowCap); // 0x0000000180B2BF90-0x0000000180B2C030
	private static void EnsureSnapshot(); // 0x0000000180B2C030-0x0000000180B2C2E0
	private static void Snapshot(); // 0x0000000180B2C2E0-0x0000000180B2C8F0
	private static void EnsureLoaded(); // 0x0000000180B2C8F0-0x0000000180B2C950
	private static float GetFloat(string key, string prop, float def, float min, float max); // 0x0000000180B2C950-0x0000000180B2CB70
	private static int GetInt(string key, string prop, int def, int min, int max); // 0x0000000180B2CB70-0x0000000180B2CD80
	private static string GetString(string key, string prop, string def); // 0x0000000180B2CD80-0x0000000180B2CE90
	private static Color GetColor(string key, string prop, Color def); // 0x0000000180B2CE90-0x0000000180B2D080
}

