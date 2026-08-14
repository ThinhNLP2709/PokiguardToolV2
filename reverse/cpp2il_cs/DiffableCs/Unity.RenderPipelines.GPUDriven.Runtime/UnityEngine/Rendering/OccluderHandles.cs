namespace UnityEngine.Rendering;

internal struct OccluderHandles
{
	public TextureHandle occluderDepthPyramid; //Field offset: 0x0
	public BufferHandle occlusionDebugOverlay; //Field offset: 0x10

	public bool IsValid() { }

	public void UseForOccluderUpdate(IBaseRenderGraphBuilder builder) { }

	public void UseForOcclusionTest(IBaseRenderGraphBuilder builder) { }

}

