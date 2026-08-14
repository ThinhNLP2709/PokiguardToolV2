namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("Res({handle.index}) : {loadAction} : {storeAction} : {memoryless}")]
internal struct NativePassAttachment
{
	public ResourceHandle handle; //Field offset: 0x0
	public RenderBufferLoadAction loadAction; //Field offset: 0xC
	public RenderBufferStoreAction storeAction; //Field offset: 0x10
	public bool memoryless; //Field offset: 0x14
	public int mipLevel; //Field offset: 0x18
	public int depthSlice; //Field offset: 0x1C

}

