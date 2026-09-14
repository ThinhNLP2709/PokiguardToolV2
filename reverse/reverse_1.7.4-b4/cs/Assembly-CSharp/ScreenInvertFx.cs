/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ScreenInvertFx // TypeDefIndex: 2388
{
	// Fields
	private static readonly int AmountId; // 0x00
	private static Canvas _canvas; // 0x08
	private static Image _overlay; // 0x10
	private static Image _dim; // 0x18
	private static Material _mat; // 0x20
	private static bool _shaderMissingLogged; // 0x28

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2389
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__14_0; // 0x08
		public static Action<float> __9__15_0; // 0x10
		public static Action<float> __9__17_0; // 0x18
		public static Action<float> __9__18_0; // 0x20

		// Constructors
		static __c(); // 0x0000000180B647D0-0x0000000180B64870
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Begin_b__14_0(float v); // 0x0000000180B64870-0x0000000180B649C0
		internal void _End_b__15_0(float v); // 0x0000000180B649C0-0x0000000180B64B10
		internal void _BeginDim_b__17_0(float v); // 0x0000000180B64B10-0x0000000180B64B70
		internal void _EndDim_b__18_0(float v); // 0x0000000180B64B70-0x0000000180B64BD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 2390
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _End_b__1(); // 0x0000000180B64BD0-0x0000000180B64D10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2391
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EndDim_b__1(); // 0x0000000180B64D10-0x0000000180B64E50
	}

	// Constructors
	static ScreenInvertFx(); // 0x0000000180B64770-0x0000000180B647D0

	// Methods
	public static void Begin(); // 0x0000000180B610E0-0x0000000180B61530
	public static void End(); // 0x0000000180B61530-0x0000000180B619E0
	public static void EndImmediate(); // 0x0000000180B619E0-0x0000000180B61CC0
	private static void BeginDim(); // 0x0000000180B61CC0-0x0000000180B62120
	private static void EndDim(); // 0x0000000180B62120-0x0000000180B62520
	private static void EndDimImmediate(); // 0x0000000180B62520-0x0000000180B62750
	private static void SetDimAlpha(float a); // 0x0000000180B62750-0x0000000180B62910
	public static void KeepAbove(GameObject uiRoot); // 0x0000000180B62910-0x0000000180B62AF0
	public static void PrewarmMaterial(); // 0x0000000180B62AF0-0x0000000180B62D90
	private static Image EnsureOverlay(); // 0x0000000180B62D90-0x0000000180B63650
	private static void EnsureDim(Canvas canvas); // 0x0000000180B63650-0x0000000180B63D40
	private static Canvas EnsureCanvas(); // 0x0000000180B63D40-0x0000000180B64770
}

