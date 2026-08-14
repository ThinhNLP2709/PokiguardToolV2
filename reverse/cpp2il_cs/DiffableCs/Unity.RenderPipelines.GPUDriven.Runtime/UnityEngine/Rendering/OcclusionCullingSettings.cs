namespace UnityEngine.Rendering;

public struct OcclusionCullingSettings
{
	public int viewInstanceID; //Field offset: 0x0
	public OcclusionTest occlusionTest; //Field offset: 0x4
	public int instanceMultiplier; //Field offset: 0x8

	public OcclusionCullingSettings(int viewInstanceID, OcclusionTest occlusionTest) { }

}

