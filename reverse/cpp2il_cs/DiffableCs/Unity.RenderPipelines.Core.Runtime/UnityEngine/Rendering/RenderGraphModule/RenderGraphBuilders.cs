namespace UnityEngine.Rendering.RenderGraphModule;

internal class RenderGraphBuilders : IBaseRenderGraphBuilder, IDisposable, IComputeRenderGraphBuilder, IRasterRenderGraphBuilder, IUnsafeRenderGraphBuilder
{
	private RenderGraphPass m_RenderPass; //Field offset: 0x10
	private RenderGraphResourceRegistry m_Resources; //Field offset: 0x18
	private RenderGraph m_RenderGraph; //Field offset: 0x20
	private bool m_Disposed; //Field offset: 0x28

	public RenderGraphBuilders() { }

	public override void AllowGlobalStateModification(bool value) { }

	public override void AllowPassCulling(bool value) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckNotUseFragment(TextureHandle tex) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckResource(in ResourceHandle res, bool checkTransientReadWrite = false) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckUseFragment(TextureHandle tex, bool isDepth) { }

	public BufferHandle CreateTransientBuffer(in BufferDesc desc) { }

	public BufferHandle CreateTransientBuffer(in BufferHandle computebuffer) { }

	public TextureHandle CreateTransientTexture(in TextureDesc desc) { }

	public TextureHandle CreateTransientTexture(in TextureHandle texture) { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	public override void EnableAsyncCompute(bool value) { }

	public override void EnableFoveatedRasterization(bool value) { }

	private ResourceHandle GetLatestVersionHandle(in ResourceHandle handle) { }

	public void SetGlobalTextureAfterPass(in TextureHandle input, int propertyId) { }

	public override void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice) { }

	public override TextureHandle SetRandomAccessAttachment(TextureHandle input, int index, AccessFlags flags = 1) { }

	public override void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice) { }

	public override void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice) { }

	public override void SetRenderFunc(BaseRenderFunc<PassData, ComputeGraphContext> renderFunc) { }

	public override void SetRenderFunc(BaseRenderFunc<PassData, RasterGraphContext> renderFunc) { }

	public override void SetRenderFunc(BaseRenderFunc<PassData, UnsafeGraphContext> renderFunc) { }

	public void Setup(RenderGraphPass renderPass, RenderGraphResourceRegistry resources, RenderGraph renderGraph) { }

	private override BufferHandle UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.CreateTransientBuffer(in BufferHandle computebuffer) { }

	private override BufferHandle UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.CreateTransientBuffer(in BufferDesc desc) { }

	private override TextureHandle UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.CreateTransientTexture(in TextureHandle texture) { }

	private override TextureHandle UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.CreateTransientTexture(in TextureDesc desc) { }

	private override void UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.SetGlobalTextureAfterPass(in TextureHandle input, int propertyId) { }

	private override BufferHandle UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.UseBuffer(in BufferHandle input, AccessFlags flags) { }

	private override void UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.UseRendererList(in RendererListHandle input) { }

	private override void UnityEngine.Rendering.RenderGraphModule.IBaseRenderGraphBuilder.UseTexture(in TextureHandle input, AccessFlags flags) { }

	public override void UseAllGlobalTextures(bool enable) { }

	public BufferHandle UseBuffer(in BufferHandle input, AccessFlags flags) { }

	public override BufferHandle UseBufferRandomAccess(BufferHandle input, int index, bool preserveCounterValue, AccessFlags flags = 1) { }

	public override BufferHandle UseBufferRandomAccess(BufferHandle input, int index, AccessFlags flags = 1) { }

	public override void UseGlobalTexture(int propertyId, AccessFlags flags) { }

	public void UseRendererList(in RendererListHandle input) { }

	private ResourceHandle UseResource(in ResourceHandle handle, AccessFlags flags, bool isTransient = false) { }

	public void UseTexture(in TextureHandle input, AccessFlags flags) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateWriteTo(in ResourceHandle handle) { }

}

