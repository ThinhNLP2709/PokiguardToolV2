namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal struct ResourceUnversionedData
{
	public readonly bool isImported; //Field offset: 0x0
	public bool isShared; //Field offset: 0x1
	public int tag; //Field offset: 0x4
	public int lastUsePassID; //Field offset: 0x8
	public int lastWritePassID; //Field offset: 0xC
	public int firstUsePassID; //Field offset: 0x10
	public bool memoryLess; //Field offset: 0x14
	public readonly int width; //Field offset: 0x18
	public readonly int height; //Field offset: 0x1C
	public readonly int volumeDepth; //Field offset: 0x20
	public readonly int msaaSamples; //Field offset: 0x24
	public readonly int latestVersionNumber; //Field offset: 0x28
	public readonly bool clear; //Field offset: 0x2C
	public readonly bool discard; //Field offset: 0x2D
	public readonly bool bindMS; //Field offset: 0x2E

	public ResourceUnversionedData(IRenderGraphResource rll, ref RenderTargetInfo info, ref TextureDesc desc, bool isResourceShared) { }

	public ResourceUnversionedData(IRenderGraphResource rll, ref BufferDesc _, bool isResourceShared) { }

	public ResourceUnversionedData(IRenderGraphResource rll, ref RayTracingAccelerationStructureDesc _, bool isResourceShared) { }

	public string GetName(CompilerContextData ctx, ResourceHandle h) { }

	public void InitializeNullResource() { }

}

