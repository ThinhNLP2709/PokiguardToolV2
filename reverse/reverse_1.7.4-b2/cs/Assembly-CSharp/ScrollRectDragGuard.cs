/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ScrollRectDragGuard // TypeDefIndex: 1031
{
	// Fields
	public const float MIN_SCROLL_SENSITIVITY = 30f; // Metadata: 0x0068C17D
	public const string HIT_AREA_NAME = "ScrollHitArea"; // Metadata: 0x0068C181

	// Methods
	public static void Ensure(ScrollRect scroll, float minSensitivity = 30f /* Metadata: 0x0068C179 */); // 0x0000000180509AF0-0x0000000180509D70
	private static bool HasRaycastGraphic(RectTransform rt); // 0x0000000180509D70-0x0000000180509E90
}

