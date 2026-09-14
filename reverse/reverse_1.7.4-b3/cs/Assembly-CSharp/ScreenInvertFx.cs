/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ScreenInvertFx // TypeDefIndex: 2381
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
	private sealed class __c // TypeDefIndex: 2382
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__14_0; // 0x08
		public static Action<float> __9__15_0; // 0x10
		public static Action<float> __9__17_0; // 0x18
		public static Action<float> __9__18_0; // 0x20

		// Constructors
		static __c(); // 0x0000000180B57490-0x0000000180B57530
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Begin_b__14_0(float v); // 0x0000000180B57530-0x0000000180B57680
		internal void _End_b__15_0(float v); // 0x0000000180B57680-0x0000000180B577D0
		internal void _BeginDim_b__17_0(float v); // 0x0000000180B577D0-0x0000000180B57830
		internal void _EndDim_b__18_0(float v); // 0x0000000180B57830-0x0000000180B57890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 2383
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _End_b__1(); // 0x0000000180B57890-0x0000000180B579D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2384
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EndDim_b__1(); // 0x0000000180B579D0-0x0000000180B57B10
	}

	// Constructors
	static ScreenInvertFx(); // 0x0000000180B57430-0x0000000180B57490

	// Methods
	public static void Begin(); // 0x0000000180B53DA0-0x0000000180B541F0
	public static void End(); // 0x0000000180B541F0-0x0000000180B546A0
	public static void EndImmediate(); // 0x0000000180B546A0-0x0000000180B54980
	private static void BeginDim(); // 0x0000000180B54980-0x0000000180B54DE0
	private static void EndDim(); // 0x0000000180B54DE0-0x0000000180B551E0
	private static void EndDimImmediate(); // 0x0000000180B551E0-0x0000000180B55410
	private static void SetDimAlpha(float a); // 0x0000000180B55410-0x0000000180B555D0
	public static void KeepAbove(GameObject uiRoot); // 0x0000000180B555D0-0x0000000180B557B0
	public static void PrewarmMaterial(); // 0x0000000180B557B0-0x0000000180B55A50
	private static Image EnsureOverlay(); // 0x0000000180B55A50-0x0000000180B56310
	private static void EnsureDim(Canvas canvas); // 0x0000000180B56310-0x0000000180B56A00
	private static Canvas EnsureCanvas(); // 0x0000000180B56A00-0x0000000180B57430
}

