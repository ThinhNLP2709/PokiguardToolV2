namespace UnityEngine.Rendering;

internal struct InstanceOcclusionEventStats
{
	public int viewInstanceID; //Field offset: 0x0
	public InstanceOcclusionEventType eventType; //Field offset: 0x4
	public int occluderVersion; //Field offset: 0x8
	public int subviewMask; //Field offset: 0xC
	public OcclusionTest occlusionTest; //Field offset: 0x10
	public int visibleInstances; //Field offset: 0x14
	public int culledInstances; //Field offset: 0x18

}

