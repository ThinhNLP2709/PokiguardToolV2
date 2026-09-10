/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ScreenInvertFx // TypeDefIndex: 1984
{
	// Fields
	private const string CANVAS_NAME = "ScreenInvertCanvas"; // Metadata: 0x0068DDE3
	private const string NODE_NAME = "ScreenInvertOverlay"; // Metadata: 0x0068DDF6
	private const string DIM_NAME = "ScreenInvertDim"; // Metadata: 0x0068DE0A
	private const string SHADER_NAME = "UI/InvertScreen"; // Metadata: 0x0068DE1A
	private static readonly int AmountId; // 0x00
	public const int SORT_ORDER = 500; // Metadata: 0x0068DE2A
	public const int ABOVE_ORDER = 520; // Metadata: 0x0068DE2C
	private const float FADE_IN_SEC = 0.18f; // Metadata: 0x0068DE2E
	private const float FADE_OUT_SEC = 0.25f; // Metadata: 0x0068DE32
	private static Canvas _canvas; // 0x08
	private static Image _overlay; // 0x10
	private static Image _dim; // 0x18
	private static Material _mat; // 0x20
	private static bool _shaderMissingLogged; // 0x28

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1985
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__14_0; // 0x08
		public static Action<float> __9__15_0; // 0x10
		public static Action<float> __9__17_0; // 0x18
		public static Action<float> __9__18_0; // 0x20

		// Constructors
		static __c(); // 0x00000001807275B0-0x0000000180727620
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Begin_b__14_0(float v); // 0x0000000180726870-0x0000000180726930
		internal void _End_b__15_0(float v); // 0x00000001807269F0-0x0000000180726AB0
		internal void _BeginDim_b__17_0(float v); // 0x0000000180726820-0x0000000180726870
		internal void _EndDim_b__18_0(float v); // 0x00000001807269A0-0x00000001807269F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1986
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _End_b__1(); // 0x0000000180726DC0-0x0000000180726E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1987
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EndDim_b__1(); // 0x0000000180726F40-0x0000000180726FC0
	}

	// Constructors
	static ScreenInvertFx(); // 0x0000000180720F10-0x0000000180720F60

	// Methods
	public static void Begin(); // 0x000000018071F2A0-0x000000018071F570
	public static void End(); // 0x000000018071FB70-0x000000018071FE60
	public static void EndImmediate(); // 0x000000018071F940-0x000000018071FB70
	private static void BeginDim(); // 0x000000018071EFC0-0x000000018071F2A0
	private static void EndDim(); // 0x000000018071F670-0x000000018071F940
	private static void EndDimImmediate(); // 0x000000018071F570-0x000000018071F670
	private static void SetDimAlpha(float a); // 0x0000000180720DD0-0x0000000180720F10
	public static void KeepAbove(GameObject uiRoot); // 0x0000000180720B90-0x0000000180720C70
	public static void PrewarmMaterial(); // 0x0000000180720C70-0x0000000180720DD0
	private static Image EnsureOverlay(); // 0x00000001807206C0-0x0000000180720B90
	private static void EnsureDim(Canvas canvas); // 0x0000000180720330-0x00000001807206C0
	private static Canvas EnsureCanvas(); // 0x000000018071FE60-0x0000000180720330
}

