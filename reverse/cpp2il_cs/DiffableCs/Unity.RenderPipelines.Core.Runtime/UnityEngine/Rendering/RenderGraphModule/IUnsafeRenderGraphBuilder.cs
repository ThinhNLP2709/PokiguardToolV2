namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public interface IUnsafeRenderGraphBuilder : IBaseRenderGraphBuilder, IDisposable
{

	public void SetRenderFunc(BaseRenderFunc<PassData, UnsafeGraphContext> renderFunc) { }

}

