/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class DotAffixConfig // TypeDefIndex: 2179
{
	// Fields
	public static readonly string[] TAGS; // 0x00
	public static readonly string[] LABELS; // 0x08
	private static readonly string[] ICON_NAMES; // 0x10
	public static readonly Color[] COLORS; // 0x18
	public static readonly Color LuckColor; // 0x20
	private static bool _snapshotTaken; // 0x30
	private static string _snapshotMatchId; // 0x38
	private static bool _enabled; // 0x40
	private static bool _fx; // 0x41
	private static float _reelSec; // 0x44
	private static float _delaySec; // 0x48
	private static string _hudTitle; // 0x50
	private static int _hudCols; // 0x58
	private static float _hudScale; // 0x5C
	private static float _hudMinScale; // 0x60
	private static float _hudGap; // 0x64
	private static float _hudMargin; // 0x68
	private static bool _hudShowFoe; // 0x6C
	private static readonly Sprite[] _iconCache; // 0x70
	private static Sprite _luckIcon; // 0x78

	// Properties
	public static bool Enabled { get; } // 0x0000000180A6EE30-0x0000000180A6EE90 
	public static bool Fx { get; } // 0x0000000180A6EE90-0x0000000180A6EEF0 
	public static float ReelSec { get; } // 0x0000000180A6EEF0-0x0000000180A6EF50 
	public static float DelaySec { get; } // 0x0000000180A6EF50-0x0000000180A6EFB0 
	public static string HudTitle { get; } // 0x0000000180A6EFB0-0x0000000180A6F010 
	public static int HudCols { get; } // 0x0000000180A6F010-0x0000000180A6F070 
	public static float HudScale { get; } // 0x0000000180A6F070-0x0000000180A6F0D0 
	public static float HudMinScale { get; } // 0x0000000180A6F0D0-0x0000000180A6F130 
	public static float HudGap { get; } // 0x0000000180A6F130-0x0000000180A6F190 
	public static float HudMargin { get; } // 0x0000000180A6F190-0x0000000180A6F1F0 
	public static bool HudShowFoe { get; } // 0x0000000180A6F1F0-0x0000000180A6F250 

	// Constructors
	static DotAffixConfig(); // 0x0000000180A70E80-0x0000000180A718A0

	// Methods
	public static void Invalidate(); // 0x0000000180A6F250-0x0000000180A6F320
	private static void EnsureSnapshot(); // 0x0000000180A6F320-0x0000000180A6F5D0
	private static void Snapshot(); // 0x0000000180A6F5D0-0x0000000180A6FB80
	private static void EnsureLoaded(); // 0x0000000180A6FB80-0x0000000180A6FBE0
	private static float GetFloat(string prop, float def, float min, float max); // 0x0000000180A6FBE0-0x0000000180A6FE20
	private static string GetString(string prop, string def); // 0x0000000180A6FE20-0x0000000180A6FF90
	public static int IndexOfTag(string tag); // 0x0000000180A6FF90-0x0000000180A70150
	public static string LabelAt(int index); // 0x0000000180A70150-0x0000000180A701F0
	public static Color ColorAt(int index); // 0x0000000180A701F0-0x0000000180A702A0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A702A0-0x0000000180A70540
	public static Sprite Icon(int index); // 0x0000000180A70540-0x0000000180A70830
	public static Sprite LuckIcon(); // 0x0000000180A70830-0x0000000180A709C0
	private static Sprite BuildStarSprite(); // 0x0000000180A709C0-0x0000000180A70E80
}

