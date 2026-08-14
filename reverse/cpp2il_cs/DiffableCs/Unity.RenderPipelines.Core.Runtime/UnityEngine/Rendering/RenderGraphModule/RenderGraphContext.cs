namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RenderGraphContext : IDerivedRendergraphContext
{
	private InternalRenderGraphContext wrappedContext; //Field offset: 0x0

	public CommandBuffer cmd
	{
		 get { } //Length: 26
	}

	public RenderGraphDefaultResources defaultResources
	{
		 get { } //Length: 26
	}

	public ScriptableRenderContext renderContext
	{
		 get { } //Length: 26
	}

	public RenderGraphObjectPool renderGraphPool
	{
		 get { } //Length: 26
	}

	public override void FromInternalContext(InternalRenderGraphContext context) { }

	public CommandBuffer get_cmd() { }

	public RenderGraphDefaultResources get_defaultResources() { }

	public ScriptableRenderContext get_renderContext() { }

	public RenderGraphObjectPool get_renderGraphPool() { }

}

