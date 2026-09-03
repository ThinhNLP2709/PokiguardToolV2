/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 41: UnityEngine.UIModule.dll - Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15192-15207

namespace UnityEngine
{
	[NativeHeader("Modules/UI/Canvas.h")]
	[NativeHeader("Runtime/Camera/Camera.h")]
	[NativeHeader("Modules/UI/RectTransformUtil.h")]
	[NativeHeader("Runtime/Transform/RectTransform.h")]
	[StaticAccessor("UI", StaticAccessorType.DoubleColon)]
	public static class RectTransformUtility // TypeDefIndex: 15199
	{
		// Fields
		private static readonly Vector3[] s_Corners; // 0x00
	
		// Constructors
		static RectTransformUtility(); // 0x00000001825820D0-0x0000000182582140
	
		// Methods
		public static Vector2 PixelAdjustPoint(Vector2 point, Transform elementTransform, Canvas canvas); // 0x0000000182581280-0x0000000182581330
		public static Rect PixelAdjustRect(RectTransform rectTransform, Canvas canvas); // 0x0000000182581390-0x0000000182581440
		private static bool PointInRectangle(Vector2 screenPoint, RectTransform rect, Camera cam, Vector4 offset); // 0x00000001825814B0-0x0000000182581560
		public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam); // 0x0000000182581660-0x00000001825817B0
		public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam, Vector4 offset); // 0x0000000182581560-0x0000000182581660
		public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint); // 0x0000000182581A10-0x0000000182582010
		public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint); // 0x00000001825817B0-0x00000001825818B0
		public static Ray ScreenPointToRay(Camera cam, Vector2 screenPos); // 0x00000001825818B0-0x0000000182581A10
		public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint); // 0x0000000182582010-0x00000001825820D0
		public static Bounds CalculateRelativeRectTransformBounds(Transform root, Transform child); // 0x0000000182580600-0x0000000182580B00
		public static Bounds CalculateRelativeRectTransformBounds(Transform trans); // 0x0000000182580B00-0x0000000182580B80
		public static void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive); // 0x0000000182580DD0-0x00000001825811F0
		public static void FlipLayoutAxes(RectTransform rect, bool keepPositioning, bool recursive); // 0x0000000182580B80-0x0000000182580DD0
		private static Vector2 GetTransposed(Vector2 input); // 0x00000001825811F0-0x0000000182581210
		private static void PixelAdjustPoint_Injected(in Vector2 point, IntPtr elementTransform, IntPtr canvas, ); // 0x0000000182581210-0x0000000182581280
		private static void PixelAdjustRect_Injected(IntPtr rectTransform, IntPtr canvas, ); // 0x0000000182581330-0x0000000182581390
		private static bool PointInRectangle_Injected(in Vector2 screenPoint, IntPtr rect, IntPtr cam, in Vector4 offset); // 0x0000000182581440-0x00000001825814B0
	}
}
