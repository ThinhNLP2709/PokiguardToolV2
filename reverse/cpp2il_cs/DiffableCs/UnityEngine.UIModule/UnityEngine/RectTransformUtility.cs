namespace UnityEngine;

[NativeHeader("Modules/UI/Canvas.h")]
[NativeHeader("Runtime/Transform/RectTransform.h")]
[NativeHeader("Modules/UI/RectTransformUtil.h")]
[NativeHeader("Runtime/Camera/Camera.h")]
[StaticAccessor("UI", StaticAccessorType::DoubleColon (2))]
public sealed class RectTransformUtility
{
	private static readonly Vector3[] s_Corners; //Field offset: 0x0

	private static RectTransformUtility() { }

	public static Bounds CalculateRelativeRectTransformBounds(Transform root, Transform child) { }

	public static Bounds CalculateRelativeRectTransformBounds(Transform trans) { }

	public static void FlipLayoutAxes(RectTransform rect, bool keepPositioning, bool recursive) { }

	public static void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive) { }

	private static Vector2 GetTransposed(Vector2 input) { }

	public static Vector2 PixelAdjustPoint(Vector2 point, Transform elementTransform, Canvas canvas) { }

	private static void PixelAdjustPoint_Injected(in Vector2 point, IntPtr elementTransform, IntPtr canvas, out Vector2 ret) { }

	public static Rect PixelAdjustRect(RectTransform rectTransform, Canvas canvas) { }

	private static void PixelAdjustRect_Injected(IntPtr rectTransform, IntPtr canvas, out Rect ret) { }

	private static bool PointInRectangle(Vector2 screenPoint, RectTransform rect, Camera cam, Vector4 offset) { }

	private static bool PointInRectangle_Injected(in Vector2 screenPoint, IntPtr rect, IntPtr cam, in Vector4 offset) { }

	public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam, Vector4 offset) { }

	public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam) { }

	public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint) { }

	public static Ray ScreenPointToRay(Camera cam, Vector2 screenPos) { }

	public static bool ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector3 worldPoint) { }

	public static Vector2 WorldToScreenPoint(Camera cam, Vector3 worldPoint) { }

}

