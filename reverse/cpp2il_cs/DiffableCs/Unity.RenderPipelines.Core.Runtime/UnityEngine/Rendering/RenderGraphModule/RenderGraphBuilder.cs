namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RenderGraphBuilder : IDisposable
{
	private RenderGraphPass m_RenderPass; //Field offset: 0x0
	private RenderGraphResourceRegistry m_Resources; //Field offset: 0x8
	private RenderGraph m_RenderGraph; //Field offset: 0x10
	private bool m_Disposed; //Field offset: 0x18

	internal RenderGraphBuilder(RenderGraphPass renderPass, RenderGraphResourceRegistry resources, RenderGraph renderGraph) { }

	public void AllowPassCulling(bool value) { }

	public void AllowRendererListCulling(bool value) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckResource(in ResourceHandle res, bool checkTransientReadWrite = true) { }

	public BufferHandle CreateTransientBuffer(in BufferDesc desc) { }

	public BufferHandle CreateTransientBuffer(in BufferHandle graphicsbuffer) { }

	public TextureHandle CreateTransientTexture(in TextureDesc desc) { }

	public TextureHandle CreateTransientTexture(in TextureHandle texture) { }

	public RendererListHandle DependsOn(in RendererListHandle input) { }

	private void Dispose(bool disposing) { }

	public override void Dispose() { }

	public void EnableAsyncCompute(bool value) { }

	public void EnableFoveatedRasterization(bool value) { }

	internal void GenerateDebugData(bool value) { }

	public BufferHandle ReadBuffer(in BufferHandle input) { }

	public RayTracingAccelerationStructureHandle ReadRayTracingAccelerationStructure(in RayTracingAccelerationStructureHandle input) { }

	public TextureHandle ReadTexture(in TextureHandle input) { }

	public TextureHandle ReadWriteTexture(in TextureHandle input) { }

	public void SetRenderFunc(BaseRenderFunc<PassData, RenderGraphContext> renderFunc) { }

	public TextureHandle UseColorBuffer(in TextureHandle input, int index) { }

	public TextureHandle UseDepthBuffer(in TextureHandle input, DepthAccess flags) { }

	public RendererListHandle UseRendererList(in RendererListHandle input) { }

	public BufferHandle WriteBuffer(in BufferHandle input) { }

	public RayTracingAccelerationStructureHandle WriteRayTracingAccelerationStructure(in RayTracingAccelerationStructureHandle input) { }

	public TextureHandle WriteTexture(in TextureHandle input) { }

}

