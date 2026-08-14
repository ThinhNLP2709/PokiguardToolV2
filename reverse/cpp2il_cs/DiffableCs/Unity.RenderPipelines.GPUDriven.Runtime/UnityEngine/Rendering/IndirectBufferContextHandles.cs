namespace UnityEngine.Rendering;

internal struct IndirectBufferContextHandles
{
	public BufferHandle instanceBuffer; //Field offset: 0x0
	public BufferHandle instanceInfoBuffer; //Field offset: 0xC
	public BufferHandle argsBuffer; //Field offset: 0x18
	public BufferHandle drawInfoBuffer; //Field offset: 0x24

	public void UseForOcclusionTest(IBaseRenderGraphBuilder builder) { }

}

