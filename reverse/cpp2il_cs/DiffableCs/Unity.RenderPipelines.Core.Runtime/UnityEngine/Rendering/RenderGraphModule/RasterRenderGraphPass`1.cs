namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal sealed class RasterRenderGraphPass : BaseRenderGraphPass<PassData, RasterGraphContext>
{
	internal static RasterGraphContext c; //Field offset: 0x0

	private static RasterRenderGraphPass`1() { }

	public RasterRenderGraphPass`1() { }

	public virtual void Execute(InternalRenderGraphContext renderGraphContext) { }

	public virtual void Release(RenderGraphObjectPool pool) { }

}

