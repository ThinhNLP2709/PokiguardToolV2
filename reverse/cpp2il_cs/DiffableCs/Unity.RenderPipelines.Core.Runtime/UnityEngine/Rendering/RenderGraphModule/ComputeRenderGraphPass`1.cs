namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal sealed class ComputeRenderGraphPass : BaseRenderGraphPass<PassData, ComputeGraphContext>
{
	internal static ComputeGraphContext c; //Field offset: 0x0

	private static ComputeRenderGraphPass`1() { }

	public ComputeRenderGraphPass`1() { }

	public virtual void Execute(InternalRenderGraphContext renderGraphContext) { }

	public virtual void Release(RenderGraphObjectPool pool) { }

}

