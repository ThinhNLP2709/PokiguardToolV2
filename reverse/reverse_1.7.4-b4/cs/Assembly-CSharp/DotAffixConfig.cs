/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class DotAffixConfig // TypeDefIndex: 2181
{
	// Fields
	public static readonly string[] TAGS; // 0x00
	public static readonly string[] LABELS; // 0x08
	private static readonly string[] ICON_NAMES; // 0x10
	public static readonly Color[] COLORS; // 0x18
	public static readonly string[] EFFECTS; // 0x20
	public static readonly Color LuckColor; // 0x28
	private static bool _snapshotTaken; // 0x38
	private static string _snapshotMatchId; // 0x40
	private static bool _enabled; // 0x48
	private static bool _fx; // 0x49
	private static float _reelSec; // 0x4C
	private static float _delaySec; // 0x50
	private static string _hudTitle; // 0x58
	private static int _hudCols; // 0x60
	private static float _hudScale; // 0x64
	private static float _hudMinScale; // 0x68
	private static float _hudGap; // 0x6C
	private static float _hudMargin; // 0x70
	private static bool _hudShowFoe; // 0x74
	private static bool _hudTap; // 0x75
	private static string _tipTitle; // 0x78
	private static string _tipNote; // 0x80
	private static readonly Sprite[] _iconCache; // 0x88
	private static Sprite _luckIcon; // 0x90

	// Properties
	public static bool Enabled { get; } // 0x0000000180A39F10-0x0000000180A39F70 
	public static bool Fx { get; } // 0x0000000180A39F70-0x0000000180A39FD0 
	public static float ReelSec { get; } // 0x0000000180A39FD0-0x0000000180A3A030 
	public static float DelaySec { get; } // 0x0000000180A3A030-0x0000000180A3A090 
	public static string HudTitle { get; } // 0x0000000180A3A090-0x0000000180A3A0F0 
	public static int HudCols { get; } // 0x0000000180A3A0F0-0x0000000180A3A150 
	public static float HudScale { get; } // 0x0000000180A3A150-0x0000000180A3A1B0 
	public static float HudMinScale { get; } // 0x0000000180A3A1B0-0x0000000180A3A210 
	public static float HudGap { get; } // 0x0000000180A3A210-0x0000000180A3A270 
	public static float HudMargin { get; } // 0x0000000180A3A270-0x0000000180A3A2D0 
	public static bool HudShowFoe { get; } // 0x0000000180A3A2D0-0x0000000180A3A330 
	public static bool HudTap { get; } // 0x0000000180A3A330-0x0000000180A3A390 
	public static string TipTitle { get; } // 0x0000000180A3A390-0x0000000180A3A3F0 
	public static string TipNote { get; } // 0x0000000180A3A3F0-0x0000000180A3A450 

	// Constructors
	static DotAffixConfig(); // 0x0000000180A3C1A0-0x0000000180A3CE60

	// Methods
	public static void Invalidate(); // 0x0000000180A3A450-0x0000000180A3A520
	private static void EnsureSnapshot(); // 0x0000000180A3A520-0x0000000180A3A7D0
	private static void Snapshot(); // 0x0000000180A3A7D0-0x0000000180A3ADD0
	private static void EnsureLoaded(); // 0x0000000180A3ADD0-0x0000000180A3AE30
	private static float GetFloat(string prop, float def, float min, float max); // 0x0000000180A3AE30-0x0000000180A3B070
	private static string GetString(string prop, string def); // 0x0000000180A3B070-0x0000000180A3B1E0
	public static int IndexOfTag(string tag); // 0x0000000180A3B1E0-0x0000000180A3B3A0
	public static string LabelAt(int index); // 0x0000000180A3B3A0-0x0000000180A3B440
	public static string EffectAt(int index); // 0x0000000180A3B440-0x0000000180A3B4E0
	public static Color ColorAt(int index); // 0x0000000180A3B4E0-0x0000000180A3B590
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A3B590-0x0000000180A3B840
	public static Sprite Icon(int index); // 0x0000000180A3B840-0x0000000180A3BB40
	public static Sprite LuckIcon(); // 0x0000000180A3BB40-0x0000000180A3BCE0
	private static Sprite BuildStarSprite(); // 0x0000000180A3BCE0-0x0000000180A3C1A0
}

