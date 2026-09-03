/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class UIAnim // TypeDefIndex: 1271
{
	// Fields
	public const float OpenTime = 0.18f; // Metadata: 0x0064D566
	public const float CloseTime = 0.12f; // Metadata: 0x0064D56A
	public const LeanTweenType OpenEase = LeanTweenType.easeOutBack; // Metadata: 0x0064D56E
	public const LeanTweenType CloseEase = LeanTweenType.easeInBack; // Metadata: 0x0064D56F
	public const float PokyOvershoot = 1.1f; // Metadata: 0x0064D570
	public const float PokyZoomInTime = 0.2f; // Metadata: 0x0064D574
	public const float PokyZoomOutTime = 0.2f; // Metadata: 0x0064D578
	public const float PokyOpenTime = 0.4f; // Metadata: 0x0064D57C
	public const float PokyCloseTime = 0.14f; // Metadata: 0x0064D580
	private static int _pokyMode; // 0x00
	private static AnimationCurve _pokyOpenCurve; // 0x08
	public const string PokyFxKey = "UiFx"; // Metadata: 0x0064D584

	// Properties
	public static bool PokyMode { get; } // 0x00000001804ECE70-0x00000001804ECF50 
	public static AnimationCurve PokyOpenCurve { get; } // 0x00000001804ECF50-0x00000001804ECFF0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1272
	{
		// Fields
		public GameObject panel; // 0x10
		public Action onComplete; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Close_b__0(); // 0x00000001804EA8E0-0x00000001804EA970
	}

	// Constructors
	static UIAnim(); // 0x00000001804ECE30-0x00000001804ECE70

	// Methods
	public static void RefreshSkinMode(); // 0x00000001804ECDD0-0x00000001804ECE30
	private static AnimationCurve BuildPokyOpenCurve(); // 0x00000001804EC620-0x00000001804EC870
	private static float OutQuad(float t); // 0x00000001804ECDB0-0x00000001804ECDD0
	public static void Open(GameObject panel, CanvasGroup canvasGroup = null); // 0x00000001804ECAF0-0x00000001804ECDB0
	public static void Close(GameObject panel, CanvasGroup canvasGroup = null, Action onComplete = null); // 0x00000001804EC870-0x00000001804ECAF0
}

