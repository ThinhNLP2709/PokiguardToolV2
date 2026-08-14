namespace UnityEngine.Rendering.Universal.Internal;

internal class DeferredPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__5_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__5_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal UniversalCameraData cameraData; //Field offset: 0x10
		internal UniversalLightData lightData; //Field offset: 0x18
		internal UniversalShadowData shadowData; //Field offset: 0x20
		internal TextureHandle color; //Field offset: 0x28
		internal TextureHandle depth; //Field offset: 0x38
		internal TextureHandle[] gbuffer; //Field offset: 0x48
		internal DeferredLights deferredLights; //Field offset: 0x50

		public PassData() { }

	}

	private DeferredLights m_DeferredLights; //Field offset: 0xB8

	public DeferredPass(RenderPassEvent evt, DeferredLights deferredLights) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescripor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle color, TextureHandle depth, TextureHandle[] gbuffer) { }

}

