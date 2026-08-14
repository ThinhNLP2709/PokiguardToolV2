namespace UnityEngine.Rendering;

internal static class ProbeVolumePositioning
{
	internal static Vector3[] m_Axes; //Field offset: 0x0
	internal static Vector3[] m_AABBCorners; //Field offset: 0x8

	private static ProbeVolumePositioning() { }

	public static bool OBBAABBIntersect(in Volume a, in Bounds b, in Bounds aAABB) { }

	public static bool OBBContains(in Volume obb, Vector3 point) { }

	public static bool OBBIntersect(in Volume a, in Volume b) { }

	private static Vector2 ProjectAABB(in Vector3[] corners, Vector3 axis) { }

	private static Vector2 ProjectOBB(in Volume a, Vector3 axis) { }

}

