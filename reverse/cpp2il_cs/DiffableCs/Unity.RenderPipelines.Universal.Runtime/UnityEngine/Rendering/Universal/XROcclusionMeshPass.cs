namespace UnityEngine.Rendering.Universal;

public class XROcclusionMeshPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__6_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal XRPass xr; //Field offset: 0x10
		internal TextureHandle cameraColorAttachment; //Field offset: 0x18
		internal TextureHandle cameraDepthAttachment; //Field offset: 0x28
		internal bool isActiveTargetBackBuffer; //Field offset: 0x38

		public PassData() { }

	}

	private PassData m_PassData; //Field offset: 0xB8
	public bool m_IsActiveTargetBackBuffer; //Field offset: 0xC0

	public XROcclusionMeshPass(RenderPassEvent evt) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData data) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, in TextureHandle cameraColorAttachment, in TextureHandle cameraDepthAttachment) { }

}

