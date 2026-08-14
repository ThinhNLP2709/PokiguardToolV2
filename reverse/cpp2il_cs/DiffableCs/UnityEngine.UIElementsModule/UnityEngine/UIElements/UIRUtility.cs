namespace UnityEngine.UIElements;

[Extension]
internal static class UIRUtility
{
	[ThreadStatic]
	private static Nullable<Int32> s_ThreadIndex; //Field offset: 0x80000000
	private static readonly ProfilerMarker k_ComputeTransformMatrixMarker; //Field offset: 0x0
	public static readonly string k_DefaultShaderName; //Field offset: 0x8
	public static readonly string k_DefaultWorldSpaceShaderName; //Field offset: 0x10

	private static UIRUtility() { }

	internal static void ComputeTransformMatrix(VisualElement ve, VisualElement ancestor, out Matrix4x4 result) { }

	public static void Destroy(object obj) { }

	public static int GetNextPow2(int n) { }

	public static int GetNextPow2Exp(int n) { }

	public static int GetPrevPow2(int n) { }

	public static int GetThreadIndex() { }

	public static void GetVerticesTransformInfo(VisualElement ve, out Matrix4x4 transform) { }

	public static bool IsRoundRect(VisualElement ve) { }

	public static bool IsVectorImageBackground(VisualElement ve) { }

	public static bool ShapeWindingIsClockwise(int maskDepth, int stencilRef) { }

}

