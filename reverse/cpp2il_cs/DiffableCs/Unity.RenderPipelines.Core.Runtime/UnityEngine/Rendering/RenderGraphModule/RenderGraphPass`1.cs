namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal sealed class RenderGraphPass : BaseRenderGraphPass<PassData, RenderGraphContext>
{
	internal static RenderGraphContext c; //Field offset: 0x0

	private static RenderGraphPass`1() { }

	public RenderGraphPass`1() { }

	public virtual void Execute(InternalRenderGraphContext renderGraphContext) { }

	public virtual void Release(RenderGraphObjectPool pool) { }

}

