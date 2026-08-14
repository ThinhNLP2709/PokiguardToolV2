namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public interface IRasterRenderGraphBuilder : IBaseRenderGraphBuilder, IDisposable
{

	public void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags = 1) { }

	public void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice) { }

	public TextureHandle SetRandomAccessAttachment(TextureHandle tex, int index, AccessFlags flags = 3) { }

	public void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags = 2) { }

	public void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice) { }

	public void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags = 2) { }

	public void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice) { }

	public void SetRenderFunc(BaseRenderFunc<PassData, RasterGraphContext> renderFunc) { }

	public BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, AccessFlags flags = 1) { }

	public BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, bool preserveCounterValue, AccessFlags flags = 1) { }

}

