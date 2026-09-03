/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ScreenInvertFx // TypeDefIndex: 1706
{
	// Fields
	private const string CANVAS_NAME = "ScreenInvertCanvas"; // Metadata: 0x0064D9B0
	private const string NODE_NAME = "ScreenInvertOverlay"; // Metadata: 0x0064D9C3
	private const string SHADER_NAME = "UI/InvertScreen"; // Metadata: 0x0064D9D7
	private static readonly int AmountId; // 0x00
	public const int SORT_ORDER = 500; // Metadata: 0x0064D9E7
	public const int ABOVE_ORDER = 520; // Metadata: 0x0064D9E9
	private const float FADE_IN_SEC = 0.18f; // Metadata: 0x0064D9EB
	private const float FADE_OUT_SEC = 0.25f; // Metadata: 0x0064D9EF
	private const float MAX_AMOUNT = 0.85f; // Metadata: 0x0064D9F3
	private static Canvas _canvas; // 0x08
	private static Image _overlay; // 0x10
	private static Material _mat; // 0x18
	private static bool _shaderMissingLogged; // 0x20

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1707
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__13_0; // 0x08
		public static Action<float> __9__14_0; // 0x10

		// Constructors
		static __c(); // 0x00000001805E90E0-0x00000001805E9150
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Begin_b__13_0(float v); // 0x00000001805E8590-0x00000001805E8650
		internal void _End_b__14_0(float v); // 0x00000001805E8650-0x00000001805E8710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 1708
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _End_b__1(); // 0x00000001805E8940-0x00000001805E89C0
	}

	// Constructors
	static ScreenInvertFx(); // 0x00000001805E2DC0-0x00000001805E2E10

	// Methods
	public static void Begin(); // 0x00000001805E1D10-0x00000001805E1F60
	public static void End(); // 0x00000001805E20A0-0x00000001805E2380
	public static void EndImmediate(); // 0x00000001805E1F60-0x00000001805E20A0
	public static void KeepAbove(GameObject uiRoot); // 0x00000001805E2CE0-0x00000001805E2DC0
	private static Image EnsureOverlay(); // 0x00000001805E2820-0x00000001805E2CE0
	private static Canvas EnsureCanvas(); // 0x00000001805E2380-0x00000001805E2820
}

