namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal abstract class BaseRenderGraphPass : RenderGraphPass
{
	internal PassData data; //Field offset: 0x0
	internal BaseRenderFunc<PassData, TRenderGraphContext> renderFunc; //Field offset: 0x0

	protected BaseRenderGraphPass`2() { }

	public virtual int GetRenderFuncHash() { }

	public virtual bool HasRenderFunc() { }

	public void Initialize(int passIndex, PassData passData, string passName, RenderGraphPassType passType, ProfilingSampler sampler) { }

	public virtual void Release(RenderGraphObjectPool pool) { }

}

