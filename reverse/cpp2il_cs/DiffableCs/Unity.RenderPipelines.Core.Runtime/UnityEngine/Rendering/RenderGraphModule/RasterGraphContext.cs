namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RasterGraphContext : IDerivedRendergraphContext
{
	internal static RasterCommandBuffer rastercmd; //Field offset: 0x0
	private InternalRenderGraphContext wrappedContext; //Field offset: 0x0
	public RasterCommandBuffer cmd; //Field offset: 0x8

	public RenderGraphDefaultResources defaultResources
	{
		 get { } //Length: 26
	}

	public RenderGraphObjectPool renderGraphPool
	{
		 get { } //Length: 26
	}

	private static RasterGraphContext() { }

	public override void FromInternalContext(InternalRenderGraphContext context) { }

	public RenderGraphDefaultResources get_defaultResources() { }

	public RenderGraphObjectPool get_renderGraphPool() { }

}

