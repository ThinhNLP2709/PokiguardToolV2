namespace UnityEngine.Rendering.Universal;

internal class DBufferCopyDepthPass : CopyDepthPass
{

	public DBufferCopyDepthPass(RenderPassEvent evt, Shader copyDepthShader, bool shouldClear = false, bool copyToDepth = false, bool copyResolvedDepth = false) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

}

