namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal sealed class UnsafeRenderGraphPass : BaseRenderGraphPass<PassData, UnsafeGraphContext>
{
	internal static UnsafeGraphContext c; //Field offset: 0x0

	private static UnsafeRenderGraphPass`1() { }

	public UnsafeRenderGraphPass`1() { }

	public virtual void Execute(InternalRenderGraphContext renderGraphContext) { }

	public virtual void Release(RenderGraphObjectPool pool) { }

}

