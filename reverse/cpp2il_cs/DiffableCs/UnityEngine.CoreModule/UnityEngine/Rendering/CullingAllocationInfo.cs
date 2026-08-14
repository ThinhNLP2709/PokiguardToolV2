namespace UnityEngine.Rendering;

internal struct CullingAllocationInfo
{
	public VisibleLight* visibleLightsPtr; //Field offset: 0x0
	public VisibleLight* visibleOffscreenVertexLightsPtr; //Field offset: 0x8
	public VisibleReflectionProbe* visibleReflectionProbesPtr; //Field offset: 0x10
	public int visibleLightCount; //Field offset: 0x18
	public int visibleOffscreenVertexLightCount; //Field offset: 0x1C
	public int visibleReflectionProbeCount; //Field offset: 0x20

}

