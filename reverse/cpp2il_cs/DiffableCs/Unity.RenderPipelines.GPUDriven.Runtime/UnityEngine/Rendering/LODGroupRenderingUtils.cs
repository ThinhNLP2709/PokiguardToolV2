namespace UnityEngine.Rendering;

[Extension]
internal static class LODGroupRenderingUtils
{

	public static float CalculateFOVHalfAngle(float fieldOfView) { }

	public static float CalculateLODDistance(float relativeScreenHeight, float size) { }

	public static float CalculatePerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric) { }

	public static float CalculateScreenRelativeMetric(LODParameters lodParams, float lodBias) { }

	public static float CalculateSqrPerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric) { }

	[Extension]
	public static Vector3 GetWorldReferencePoint(LODGroup lodGroup) { }

	[Extension]
	public static float GetWorldSpaceScale(LODGroup lodGroup) { }

	[Extension]
	public static float GetWorldSpaceSize(LODGroup lodGroup) { }

}

