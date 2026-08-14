namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public interface IBaseRenderGraphBuilder : IDisposable
{

	public void AllowGlobalStateModification(bool value) { }

	public void AllowPassCulling(bool value) { }

	public BufferHandle CreateTransientBuffer(in BufferDesc desc) { }

	public BufferHandle CreateTransientBuffer(in BufferHandle computebuffer) { }

	public TextureHandle CreateTransientTexture(in TextureDesc desc) { }

	public TextureHandle CreateTransientTexture(in TextureHandle texture) { }

	public void EnableAsyncCompute(bool value) { }

	public void EnableFoveatedRasterization(bool value) { }

	public void SetGlobalTextureAfterPass(in TextureHandle input, int propertyId) { }

	public void UseAllGlobalTextures(bool enable) { }

	public BufferHandle UseBuffer(in BufferHandle input, AccessFlags flags = 1) { }

	public void UseGlobalTexture(int propertyId, AccessFlags flags = 1) { }

	public void UseRendererList(in RendererListHandle input) { }

	public void UseTexture(in TextureHandle input, AccessFlags flags = 1) { }

}

