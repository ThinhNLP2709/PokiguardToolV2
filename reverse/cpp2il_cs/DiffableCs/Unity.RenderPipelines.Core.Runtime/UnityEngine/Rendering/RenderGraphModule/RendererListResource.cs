namespace UnityEngine.Rendering.RenderGraphModule;

internal struct RendererListResource
{
	public RendererListParams desc; //Field offset: 0x0
	public RendererList rendererList; //Field offset: 0x130

	internal RendererListResource(in RendererListParams desc) { }

}

