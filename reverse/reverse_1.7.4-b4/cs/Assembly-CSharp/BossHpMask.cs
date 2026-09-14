/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class BossHpMask // TypeDefIndex: 354
{
	// Fields
	private static readonly Color KILLABLE_COLOR; // 0x00

	// Properties
	public static bool IsWorldBossMatch { get; } // 0x0000000180302940-0x0000000180302A60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 355
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyMaskedFx_b__0(float a); // 0x0000000180303320-0x00000001803034A0
	}

	// Constructors
	static BossHpMask(); // 0x00000001803032D0-0x0000000180303320

	// Methods
	public static string Digits(long v); // 0x0000000180302A60-0x0000000180302BC0
	public static void FitIfLong(UnityEngine.UI.Text t); // 0x0000000180302BC0-0x0000000180302D50
	public static string Format(int current, int max); // 0x0000000180302D50-0x0000000180302EC0
	public static string Format(int current, int max, bool masked); // 0x0000000180302EC0-0x0000000180303040
	public static void ApplyMaskedFx(UnityEngine.UI.Text text); // 0x0000000180303040-0x00000001803032D0
}

