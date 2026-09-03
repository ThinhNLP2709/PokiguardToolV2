/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class BossHpMask // TypeDefIndex: 331
{
	// Fields
	public const string MASKED = "????/????"; // Metadata: 0x0064C1E3
	private const float PULSE_MIN_ALPHA = 0.72f; // Metadata: 0x0064C1ED
	private const float PULSE_SECONDS = 1.3f; // Metadata: 0x0064C1F1

	// Properties
	public static bool IsWorldBossMatch { get; } // 0x00000001806F06E0-0x00000001806F0780 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass7_0 // TypeDefIndex: 332
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10

		// Constructors
		public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyMaskedFx_b__0(float a); // 0x00000001806FFB60-0x00000001806FFC50
	}

	// Methods
	public static string Format(int current, int max); // 0x00000001806F05B0-0x00000001806F06E0
	public static string Format(int current, int max, bool masked); // 0x00000001806F0500-0x00000001806F05B0
	public static void ApplyMaskedFx(UnityEngine.UI.Text text); // 0x00000001806F0340-0x00000001806F0500
}

