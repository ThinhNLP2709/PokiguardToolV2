namespace UnityEngine.Rendering;

internal struct AABB
{
	public float3 center; //Field offset: 0x0
	public float3 extents; //Field offset: 0xC

	public float3 max
	{
		 get { } //Length: 63
	}

	public float3 min
	{
		 get { } //Length: 63
	}

	public float3 get_max() { }

	public float3 get_min() { }

	private static float3 RotateExtents(float3 extents, float3 m0, float3 m1, float3 m2) { }

	public virtual string ToString() { }

	public static AABB Transform(float4x4 transform, AABB localBounds) { }

}

