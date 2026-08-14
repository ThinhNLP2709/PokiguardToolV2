namespace UnityEngine.Rendering.Universal.Internal;

public class FinalBlitPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__17_0(PassData data, RasterGraphContext context) { }

	}

	private struct BlitMaterialData
	{
		public Material material; //Field offset: 0x0
		public int nearestSamplerPass; //Field offset: 0x8
		public int bilinearSamplerPass; //Field offset: 0xC

	}

	private static class BlitPassNames
	{
		public const string NearestSampler = "NearestDebugDraw"; //Field offset: 0x0
		public const string BilinearSampler = "BilinearDebugDraw"; //Field offset: 0x0

	}

	private enum BlitType
	{
		Core = 0,
		HDR = 1,
		Count = 2,
	}

	private class PassData
	{
		internal TextureHandle source; //Field offset: 0x10
		internal TextureHandle destination; //Field offset: 0x20
		internal int sourceID; //Field offset: 0x30
		internal Vector4 hdrOutputLuminanceParams; //Field offset: 0x34
		internal bool requireSrgbConversion; //Field offset: 0x44
		internal bool enableAlphaOutput; //Field offset: 0x45
		internal BlitMaterialData blitMaterialData; //Field offset: 0x48
		internal UniversalCameraData cameraData; //Field offset: 0x58

		public PassData() { }

	}

	private static readonly int s_CameraDepthTextureID; //Field offset: 0x0
	private RTHandle m_Source; //Field offset: 0xB8
	private PassData m_PassData; //Field offset: 0xC0
	private BlitMaterialData[] m_BlitMaterialData; //Field offset: 0xC8

	private static FinalBlitPass() { }

	public FinalBlitPass(RenderPassEvent evt, Material blitMaterial, Material blitHDRMaterial) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData data, RTHandle source, RTHandle destination, UniversalCameraData cameraData) { }

	private void InitPassData(UniversalCameraData cameraData, ref PassData passData, BlitType blitType, bool enableAlphaOutput) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, UniversalCameraData cameraData, in TextureHandle src, in TextureHandle dest, TextureHandle overlayUITexture) { }

	[Obsolete("Use RTHandles for colorHandle", True)]
	public void Setup(RenderTextureDescriptor baseDescriptor, RenderTargetHandle colorHandle) { }

	public void Setup(RenderTextureDescriptor baseDescriptor, RTHandle colorHandle) { }

	private static void SetupHDROutput(ColorGamut hdrDisplayColorGamut, Material material, Operation hdrOperation, Vector4 hdrOutputParameters, bool rendersOverlayUI) { }

}

