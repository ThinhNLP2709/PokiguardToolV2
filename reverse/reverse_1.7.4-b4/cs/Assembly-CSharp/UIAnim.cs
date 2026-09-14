/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class UIAnim // TypeDefIndex: 1889
{
	// Fields
	private static int _pokyMode; // 0x00
	private static AnimationCurve _pokyOpenCurve; // 0x08

	// Properties
	public static bool PokyMode { get; } // 0x00000001809225E0-0x00000001809226E0 
	public static AnimationCurve PokyOpenCurve { get; } // 0x0000000180922740-0x0000000180922820 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1890
	{
		// Fields
		public GameObject panel; // 0x10
		public Action onComplete; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Close_b__0(); // 0x0000000180923430-0x0000000180923590
	}

	// Constructors
	static UIAnim(); // 0x00000001809233F0-0x0000000180923430

	// Methods
	public static void RefreshSkinMode(); // 0x00000001809226E0-0x0000000180922740
	private static AnimationCurve BuildPokyOpenCurve(); // 0x0000000180922820-0x0000000180922B30
	private static float OutQuad(float t); // 0x0000000180922B30-0x0000000180922B50
	public static void Open(GameObject panel, CanvasGroup canvasGroup = null); // 0x0000000180922B50-0x0000000180922FA0
	public static void Close(GameObject panel, CanvasGroup canvasGroup = null, Action onComplete = null); // 0x0000000180922FA0-0x00000001809233F0
}

