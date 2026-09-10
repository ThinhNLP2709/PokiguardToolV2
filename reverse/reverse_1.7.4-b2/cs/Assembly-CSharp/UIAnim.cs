/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class UIAnim // TypeDefIndex: 1504
{
	// Fields
	public const float OpenTime = 0.18f; // Metadata: 0x0068D37E
	public const float CloseTime = 0.12f; // Metadata: 0x0068D382
	public const LeanTweenType OpenEase = LeanTweenType.easeOutBack; // Metadata: 0x0068D386
	public const LeanTweenType CloseEase = LeanTweenType.easeInBack; // Metadata: 0x0068D387
	public const float PokyOvershoot = 1.1f; // Metadata: 0x0068D388
	public const float PokyZoomInTime = 0.2f; // Metadata: 0x0068D38C
	public const float PokyZoomOutTime = 0.2f; // Metadata: 0x0068D390
	public const float PokyOpenTime = 0.4f; // Metadata: 0x0068D394
	public const float PokyCloseTime = 0.14f; // Metadata: 0x0068D398
	private static int _pokyMode; // 0x00
	private static AnimationCurve _pokyOpenCurve; // 0x08
	public const string PokyFxKey = "UiFx"; // Metadata: 0x0068D39C

	// Properties
	public static bool PokyMode { get; } // 0x00000001805ECA00-0x00000001805ECAE0 
	public static AnimationCurve PokyOpenCurve { get; } // 0x00000001805ECAE0-0x00000001805ECB80 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1505
	{
		// Fields
		public GameObject panel; // 0x10
		public Action onComplete; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Close_b__0(); // 0x00000001805EAE60-0x00000001805EAEF0
	}

	// Constructors
	static UIAnim(); // 0x00000001805EC9C0-0x00000001805ECA00

	// Methods
	public static void RefreshSkinMode(); // 0x00000001805EC960-0x00000001805EC9C0
	private static AnimationCurve BuildPokyOpenCurve(); // 0x00000001805EC1B0-0x00000001805EC400
	private static float OutQuad(float t); // 0x00000001805EC940-0x00000001805EC960
	public static void Open(GameObject panel, CanvasGroup canvasGroup = null); // 0x00000001805EC680-0x00000001805EC940
	public static void Close(GameObject panel, CanvasGroup canvasGroup = null, Action onComplete = null); // 0x00000001805EC400-0x00000001805EC680
}

