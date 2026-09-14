/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class UIAnim // TypeDefIndex: 1887
{
	// Fields
	private static int _pokyMode; // 0x00
	private static AnimationCurve _pokyOpenCurve; // 0x08

	// Properties
	public static bool PokyMode { get; } // 0x000000018091F0A0-0x000000018091F1A0 
	public static AnimationCurve PokyOpenCurve { get; } // 0x000000018091F200-0x000000018091F2E0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1888
	{
		// Fields
		public GameObject panel; // 0x10
		public Action onComplete; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Close_b__0(); // 0x000000018091FEF0-0x0000000180920050
	}

	// Constructors
	static UIAnim(); // 0x000000018091FEB0-0x000000018091FEF0

	// Methods
	public static void RefreshSkinMode(); // 0x000000018091F1A0-0x000000018091F200
	private static AnimationCurve BuildPokyOpenCurve(); // 0x000000018091F2E0-0x000000018091F5F0
	private static float OutQuad(float t); // 0x000000018091F5F0-0x000000018091F610
	public static void Open(GameObject panel, CanvasGroup canvasGroup = null); // 0x000000018091F610-0x000000018091FA60
	public static void Close(GameObject panel, CanvasGroup canvasGroup = null, Action onComplete = null); // 0x000000018091FA60-0x000000018091FEB0
}

