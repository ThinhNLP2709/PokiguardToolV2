namespace UnityEngine.Rendering.Universal;

internal class HDRDebugViewPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassDataCIExy, UnsafeGraphContext> <>9__17_0; //Field offset: 0x8
		public static BaseRenderFunc<PassDataDebugView, RasterGraphContext> <>9__17_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <RenderHDRDebug>b__17_0(PassDataCIExy data, UnsafeGraphContext context) { }

		internal void <RenderHDRDebug>b__17_1(PassDataDebugView data, RasterGraphContext context) { }

	}

	private enum HDRDebugPassId
	{
		CIExyPrepass = 0,
		DebugViewPass = 1,
	}

	private class PassDataCIExy
	{
		internal Material material; //Field offset: 0x10
		internal Vector4 luminanceParameters; //Field offset: 0x18
		internal TextureHandle srcColor; //Field offset: 0x28
		internal TextureHandle xyBuffer; //Field offset: 0x38
		internal TextureHandle passThrough; //Field offset: 0x48

		public PassDataCIExy() { }

	}

	private class PassDataDebugView
	{
		internal Material material; //Field offset: 0x10
		internal HDRDebugMode hdrDebugMode; //Field offset: 0x18
		internal UniversalCameraData cameraData; //Field offset: 0x20
		internal Vector4 luminanceParameters; //Field offset: 0x28
		internal TextureHandle overlayUITexture; //Field offset: 0x38
		internal TextureHandle xyBuffer; //Field offset: 0x48
		internal TextureHandle srcColor; //Field offset: 0x58
		internal TextureHandle dstColor; //Field offset: 0x68

		public PassDataDebugView() { }

	}

	public class ShaderConstants
	{
		public static readonly int _DebugHDRModeId; //Field offset: 0x0
		public static readonly int _HDRDebugParamsId; //Field offset: 0x4
		public static readonly int _xyTextureId; //Field offset: 0x8
		public static readonly int _SizeOfHDRXYMapping; //Field offset: 0xC
		public static readonly int _CIExyUAVIndex; //Field offset: 0x10

		private static ShaderConstants() { }

		public ShaderConstants() { }

	}

	private PassDataCIExy m_PassDataCIExy; //Field offset: 0xB8
	private PassDataDebugView m_PassDataDebugView; //Field offset: 0xC0
	private RTHandle m_CIExyTarget; //Field offset: 0xC8
	private RTHandle m_PassthroughRT; //Field offset: 0xD0
	private Material m_material; //Field offset: 0xD8

	public HDRDebugViewPass(Material mat) { }

	public static void ConfigureDescriptorForCIEPrepass(ref RenderTextureDescriptor descriptor) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecuteCIExyPrepass(CommandBuffer cmd, PassDataCIExy data, RTHandle sourceTexture, RTHandle xyTarget, RTHandle destTexture) { }

	private static void ExecuteHDRDebugViewFinalPass(RasterCommandBuffer cmd, PassDataDebugView data, RTHandle sourceTexture, RTHandle destination, RTHandle xyTarget) { }

	private void ExecutePass(CommandBuffer cmd, PassDataCIExy dataCIExy, PassDataDebugView dataDebugView, RTHandle sourceTexture, RTHandle xyTarget, RTHandle destTexture) { }

	internal static Vector4 GetLuminanceParameters(UniversalCameraData cameraData) { }

	internal void RenderHDRDebug(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle srcColor, TextureHandle overlayUITexture, TextureHandle dstColor, HDRDebugMode hdrDebugMode) { }

	public void Setup(UniversalCameraData cameraData, HDRDebugMode hdrdebugMode) { }

}

