/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ScrollRectDragGuard // TypeDefIndex: 835
{
	// Fields
	public const float MIN_SCROLL_SENSITIVITY = 30f; // Metadata: 0x0064CA6C
	public const string HIT_AREA_NAME = "ScrollHitArea"; // Metadata: 0x0064CA70

	// Methods
	public static void Ensure(ScrollRect scroll, float minSensitivity = 30f /* Metadata: 0x0064CA68 */); // 0x000000018042ED30-0x000000018042EFB0
	private static bool HasRaycastGraphic(RectTransform rt); // 0x000000018042EFB0-0x000000018042F0D0
}

