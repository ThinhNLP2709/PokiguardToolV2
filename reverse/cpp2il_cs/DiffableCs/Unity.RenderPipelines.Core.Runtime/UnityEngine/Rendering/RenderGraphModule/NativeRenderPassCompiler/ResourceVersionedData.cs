namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal struct ResourceVersionedData
{
	public bool written; //Field offset: 0x0
	public int writePassId; //Field offset: 0x4
	public int numReaders; //Field offset: 0x8

	public void RegisterReadingPass(CompilerContextData ctx, ResourceHandle h, int passId, int index) { }

	public void RemoveReadingPass(CompilerContextData ctx, ResourceHandle h, int passId) { }

	public void SetWritingPass(CompilerContextData ctx, ResourceHandle h, int passId) { }

}

