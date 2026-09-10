/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class BossHpMask // TypeDefIndex: 357
{
	// Fields
	public const string MASKED = "????/????"; // Metadata: 0x0068AEFB
	private const int SHORTEN_FROM = 1000000; // Metadata: 0x0068AF05
	private const int FIT_FROM_CHARS = 12; // Metadata: 0x0068AF09
	private const int FIT_MIN_FONT = 10; // Metadata: 0x0068AF0A
	private const float PULSE_MIN_ALPHA = 0.72f; // Metadata: 0x0068AF0B
	private const float PULSE_SECONDS = 1.3f; // Metadata: 0x0068AF0F
	private static readonly Color KILLABLE_COLOR; // 0x00
	private const float KILLABLE_MIN_ALPHA = 0.45f; // Metadata: 0x0068AF13
	private const float KILLABLE_SECONDS = 0.85f; // Metadata: 0x0068AF17
	private static UnityEngine.UI.Text _killableTarget; // 0x10
	private static Color _killableRestore; // 0x18

	// Properties
	public static bool IsWorldBossMatch { get; } // 0x0000000180332320-0x00000001803323C0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 358
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyMaskedFx_b__0(float a); // 0x000000018034A960-0x000000018034AA50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 359
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyKillableFx_b__0(float a); // 0x000000018034AA50-0x000000018034AB40
	}

	// Constructors
	static BossHpMask(); // 0x00000001803322E0-0x0000000180332320

	// Methods
	public static string Compact(int v); // 0x0000000180331D80-0x0000000180331E70
	public static string Compact(long v); // 0x0000000180331C90-0x0000000180331D80
	public static string Digits(long v); // 0x0000000180331E70-0x0000000180331F10
	public static void FitIfLong(UnityEngine.UI.Text t); // 0x0000000180331F10-0x0000000180332020
	public static string Format(int current, int max); // 0x0000000180332140-0x00000001803322E0
	public static string Format(int current, int max, bool masked); // 0x0000000180332020-0x0000000180332140
	public static void ApplyMaskedFx(UnityEngine.UI.Text text); // 0x0000000180331980-0x0000000180331B40
	public static void ApplyKillableFx(UnityEngine.UI.Text text); // 0x0000000180331530-0x0000000180331980
	public static void ClearKillableFx(); // 0x0000000180331B40-0x0000000180331C70
	private static Color ColorWithAlpha(Color current, Color target); // 0x0000000180331C70-0x0000000180331C90
}

