namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public struct RenderGraphParameters
{
	public string executionName; //Field offset: 0x0
	public int currentFrameIndex; //Field offset: 0x8
	public bool rendererListCulling; //Field offset: 0xC
	public ScriptableRenderContext scriptableRenderContext; //Field offset: 0x10
	public CommandBuffer commandBuffer; //Field offset: 0x18
	internal bool invalidContextForTesting; //Field offset: 0x20

}

