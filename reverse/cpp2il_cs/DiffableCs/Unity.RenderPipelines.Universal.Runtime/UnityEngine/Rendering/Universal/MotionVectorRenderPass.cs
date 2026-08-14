namespace UnityEngine.Rendering.Universal;

internal sealed class MotionVectorRenderPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__23_0; //Field offset: 0x8
		public static BaseRenderFunc<MotionMatrixPassData, RasterGraphContext> <>9__26_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__23_0(PassData data, RasterGraphContext context) { }

		internal void <SetRenderGraphMotionVectorGlobalMatrices>b__26_0(MotionMatrixPassData data, RasterGraphContext context) { }

	}

	internal class MotionMatrixPassData
	{
		public MotionVectorsPersistentData motionData; //Field offset: 0x10
		public XRPass xr; //Field offset: 0x18

		public MotionMatrixPassData() { }

	}

	private class PassData
	{
		internal Camera camera; //Field offset: 0x10
		internal XRPass xr; //Field offset: 0x18
		internal TextureHandle motionVectorColor; //Field offset: 0x20
		internal TextureHandle motionVectorDepth; //Field offset: 0x30
		internal TextureHandle cameraDepth; //Field offset: 0x40
		internal Material cameraMaterial; //Field offset: 0x50
		internal RendererListHandle rendererListHdl; //Field offset: 0x58
		internal RendererList rendererList; //Field offset: 0x68

		public PassData() { }

	}

	internal const string k_MotionVectorTextureName = "_MotionVectorTexture"; //Field offset: 0x0
	internal const string k_MotionVectorDepthTextureName = "_MotionVectorDepthTexture"; //Field offset: 0x0
	internal const GraphicsFormat k_TargetFormat = 46; //Field offset: 0x0
	public const string k_MotionVectorsLightModeTag = "MotionVectors"; //Field offset: 0x0
	private static readonly String[] s_ShaderTags; //Field offset: 0x0
	private static readonly int s_CameraDepthTextureID; //Field offset: 0x8
	private static readonly ProfilingSampler s_SetMotionMatrixProfilingSampler; //Field offset: 0x10
	private RTHandle m_Color; //Field offset: 0xB8
	private RTHandle m_Depth; //Field offset: 0xC0
	private readonly Material m_CameraMaterial; //Field offset: 0xC8
	private readonly FilteringSettings m_FilteringSettings; //Field offset: 0xD0
	private PassData m_PassData; //Field offset: 0xF0

	private static MotionVectorRenderPass() { }

	internal MotionVectorRenderPass(RenderPassEvent evt, Material cameraMaterial, LayerMask opaqueLayerMask) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

	private static void DrawCameraMotionVectors(RasterCommandBuffer cmd, XRPass xr, Material cameraMaterial) { }

	private static void DrawObjectMotionVectors(RasterCommandBuffer cmd, XRPass xr, ref RendererList rendererList) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	private static DrawingSettings GetDrawingSettings(Camera camera, bool supportsDynamicBatching) { }

	private void InitPassData(ref PassData passData, UniversalCameraData cameraData) { }

	private void InitRendererLists(ref PassData passData, ref CullingResults cullResults, bool supportsDynamicBatching, ScriptableRenderContext context, RenderGraph renderGraph, bool useRenderGraph) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle cameraDepthTexture, TextureHandle motionVectorColor, TextureHandle motionVectorDepth) { }

	internal static void SetMotionVectorGlobalMatrices(CommandBuffer cmd, UniversalCameraData cameraData) { }

	internal static void SetRenderGraphMotionVectorGlobalMatrices(RenderGraph renderGraph, UniversalCameraData cameraData) { }

	internal void Setup(RTHandle color, RTHandle depth) { }

}

