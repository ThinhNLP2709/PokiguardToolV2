namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public sealed class BaseRenderFunc : MulticastDelegate
{

	public BaseRenderFunc`2(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(PassData data, ContextType renderGraphContext, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(PassData data, ContextType renderGraphContext) { }

}

