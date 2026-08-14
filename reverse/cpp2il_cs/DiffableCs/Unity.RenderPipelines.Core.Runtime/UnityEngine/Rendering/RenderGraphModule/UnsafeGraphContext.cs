namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public class UnsafeGraphContext : IDerivedRendergraphContext
{
	internal static UnsafeCommandBuffer unsCmd; //Field offset: 0x0
	private InternalRenderGraphContext wrappedContext; //Field offset: 0x10
	public UnsafeCommandBuffer cmd; //Field offset: 0x18

	public RenderGraphDefaultResources defaultResources
	{
		 get { } //Length: 27
	}

	public RenderGraphObjectPool renderGraphPool
	{
		 get { } //Length: 27
	}

	private static UnsafeGraphContext() { }

	public UnsafeGraphContext() { }

	public override void FromInternalContext(InternalRenderGraphContext context) { }

	public RenderGraphDefaultResources get_defaultResources() { }

	public RenderGraphObjectPool get_renderGraphPool() { }

}

