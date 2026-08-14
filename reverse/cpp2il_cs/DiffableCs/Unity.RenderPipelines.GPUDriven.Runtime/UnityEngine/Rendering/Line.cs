namespace UnityEngine.Rendering;

internal struct Line
{
	public float3 m; //Field offset: 0x0
	public float3 t; //Field offset: 0xC

	internal static Line LineOfPlaneIntersectingPlane(float4 a, float4 b) { }

	internal static float4 PlaneContainingLineAndPoint(Line a, float3 b) { }

	internal static float4 PlaneContainingLineWithNormalPerpendicularToVector(Line a, float3 b) { }

}

