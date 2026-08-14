namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public class ComputeGraphContext : IDerivedRendergraphContext
{
	internal static ComputeCommandBuffer computecmd; //Field offset: 0x0
	private InternalRenderGraphContext wrappedContext; //Field offset: 0x10
	public ComputeCommandBuffer cmd; //Field offset: 0x18

	public RenderGraphDefaultResources defaultResources
	{
		 get { } //Length: 27
	}

	public RenderGraphObjectPool renderGraphPool
	{
		 get { } //Length: 27
	}

	private static ComputeGraphContext() { }

	public ComputeGraphContext() { }

	public override void FromInternalContext(InternalRenderGraphContext context) { }

	public RenderGraphDefaultResources get_defaultResources() { }

	public RenderGraphObjectPool get_renderGraphPool() { }

}

