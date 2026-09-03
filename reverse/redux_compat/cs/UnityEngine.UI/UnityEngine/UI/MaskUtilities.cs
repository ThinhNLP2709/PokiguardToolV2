/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class MaskUtilities // TypeDefIndex: 13090
	{
		// Constructors
		public MaskUtilities(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static void Notify2DMaskStateChanged(Component mask); // 0x0000000182598030-0x0000000182598200
		public static void NotifyStencilStateChanged(Component mask); // 0x0000000182598200-0x00000001825983D0
		public static Transform FindRootSortOverrideCanvas(Transform start); // 0x0000000182597640-0x0000000182597790
		public static int GetStencilDepth(Transform transform, Transform stopAfter); // 0x0000000182597D20-0x0000000182597F40
		public static bool IsDescendantOrSelf(Transform father, Transform child); // 0x0000000182597F40-0x0000000182598030
		public static RectMask2D GetRectMaskForClippable(IClippable clippable); // 0x0000000182597790-0x0000000182597A50
		public static void GetRectMasksForClip(RectMask2D clipper, List<RectMask2D> masks); // 0x0000000182597A50-0x0000000182597D20
	}
}
