namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public class InternalRenderGraphContext
{
	internal ScriptableRenderContext renderContext; //Field offset: 0x10
	internal CommandBuffer cmd; //Field offset: 0x18
	internal RenderGraphObjectPool renderGraphPool; //Field offset: 0x20
	internal RenderGraphDefaultResources defaultResources; //Field offset: 0x28
	internal RenderGraphPass executingPass; //Field offset: 0x30
	internal bool contextlessTesting; //Field offset: 0x38

	public InternalRenderGraphContext() { }

}

