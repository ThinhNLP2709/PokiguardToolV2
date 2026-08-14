namespace UnityEngine.Rendering.Universal.Internal;

internal class GBufferPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__21_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__21_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle[] gbuffer; //Field offset: 0x10
		internal TextureHandle depth; //Field offset: 0x18
		internal DeferredLights deferredLights; //Field offset: 0x28
		internal RendererListHandle rendererListHdl; //Field offset: 0x30
		internal RendererListHandle objectsWithErrorRendererListHdl; //Field offset: 0x3C
		internal RendererList rendererList; //Field offset: 0x48
		internal RendererList objectsWithErrorRendererList; //Field offset: 0x60

		public PassData() { }

	}

	private static readonly int s_CameraNormalsTextureID; //Field offset: 0x0
	private static readonly int s_CameraRenderingLayersTextureID; //Field offset: 0x4
	private static readonly ShaderTagId s_ShaderTagLit; //Field offset: 0x8
	private static readonly ShaderTagId s_ShaderTagSimpleLit; //Field offset: 0xC
	private static readonly ShaderTagId s_ShaderTagUnlit; //Field offset: 0x10
	private static readonly ShaderTagId s_ShaderTagComplexLit; //Field offset: 0x14
	private static readonly ShaderTagId s_ShaderTagUniversalGBuffer; //Field offset: 0x18
	private static readonly ShaderTagId s_ShaderTagUniversalMaterialType; //Field offset: 0x1C
	private static ShaderTagId[] s_ShaderTagValues; //Field offset: 0x20
	private static RenderStateBlock[] s_RenderStateBlocks; //Field offset: 0x28
	private DeferredLights m_DeferredLights; //Field offset: 0xB8
	private FilteringSettings m_FilteringSettings; //Field offset: 0xC0
	private RenderStateBlock m_RenderStateBlock; //Field offset: 0xE0
	private PassData m_PassData; //Field offset: 0x150

	private static GBufferPass() { }

	public GBufferPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference, DeferredLights deferredLights) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData data, RendererList rendererList, RendererList errorRendererList) { }

	private void InitRendererLists(ref PassData passData, ScriptableRenderContext context, RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, bool useRenderGraph) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle cameraColor, TextureHandle cameraDepth, bool setGlobalTextures) { }

}

