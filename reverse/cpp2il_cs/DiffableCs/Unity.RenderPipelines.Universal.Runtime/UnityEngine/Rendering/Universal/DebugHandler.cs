namespace UnityEngine.Rendering.Universal;

internal class DebugHandler : IDebugDisplaySettingsQuery
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<DebugFinalValidationPassData, RasterGraphContext> <>9__101_0; //Field offset: 0x8
		public static BaseRenderFunc<DebugSetupPassData, RasterGraphContext> <>9__106_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Setup>b__106_0(DebugSetupPassData data, RasterGraphContext context) { }

		internal void <UpdateShaderGlobalPropertiesForFinalValidationPass>b__101_0(DebugFinalValidationPassData data, RasterGraphContext context) { }

	}

	private class DebugFinalValidationPassData
	{
		public bool isFinalPass; //Field offset: 0x10
		public bool resolveFinalTarget; //Field offset: 0x11
		public bool isActiveForCamera; //Field offset: 0x12
		public bool hasDebugRenderTarget; //Field offset: 0x13
		public TextureHandle debugRenderTargetHandle; //Field offset: 0x14
		public int debugTexturePropertyId; //Field offset: 0x24
		public Vector4 debugRenderTargetPixelRect; //Field offset: 0x28
		public int debugRenderTargetSupportsStereo; //Field offset: 0x38
		public Vector4 debugRenderTargetRangeRemap; //Field offset: 0x3C
		public TextureHandle debugFontTextureHandle; //Field offset: 0x4C
		public DebugDisplaySettingsRendering renderingSettings; //Field offset: 0x60

		public DebugFinalValidationPassData() { }

	}

	private class DebugSetupPassData
	{
		public bool isActiveForCamera; //Field offset: 0x10
		public DebugDisplaySettingsMaterial materialSettings; //Field offset: 0x18
		public DebugDisplaySettingsRendering renderingSettings; //Field offset: 0x20
		public DebugDisplaySettingsLighting lightingSettings; //Field offset: 0x28

		public DebugSetupPassData() { }

	}

	private static readonly int k_DebugColorInvalidModePropertyId; //Field offset: 0x0
	private static readonly int k_DebugCurrentRealTimeId; //Field offset: 0x4
	private static readonly int k_DebugColorPropertyId; //Field offset: 0x8
	private static readonly int k_DebugTexturePropertyId; //Field offset: 0xC
	private static readonly int k_DebugFontId; //Field offset: 0x10
	private static readonly int k_DebugTextureNoStereoPropertyId; //Field offset: 0x14
	private static readonly int k_DebugTextureDisplayRect; //Field offset: 0x18
	private static readonly int k_DebugRenderTargetSupportsStereo; //Field offset: 0x1C
	private static readonly int k_DebugRenderTargetRangeRemap; //Field offset: 0x20
	private static readonly int k_DebugMaterialModeId; //Field offset: 0x24
	private static readonly int k_DebugVertexAttributeModeId; //Field offset: 0x28
	private static readonly int k_DebugMaterialValidationModeId; //Field offset: 0x2C
	private static readonly int k_DebugMipInfoModeId; //Field offset: 0x30
	private static readonly int k_DebugMipMapStatusModeId; //Field offset: 0x34
	private static readonly int k_DebugMipMapShowStatusCodeId; //Field offset: 0x38
	private static readonly int k_DebugMipMapOpacityId; //Field offset: 0x3C
	private static readonly int k_DebugMipMapRecentlyUpdatedCooldownId; //Field offset: 0x40
	private static readonly int k_DebugMipMapTerrainTextureModeId; //Field offset: 0x44
	private static readonly int k_DebugSceneOverrideModeId; //Field offset: 0x48
	private static readonly int k_DebugFullScreenModeId; //Field offset: 0x4C
	private static readonly int k_DebugValidationModeId; //Field offset: 0x50
	private static readonly int k_DebugValidateBelowMinThresholdColorPropertyId; //Field offset: 0x54
	private static readonly int k_DebugValidateAboveMaxThresholdColorPropertyId; //Field offset: 0x58
	private static readonly int k_DebugMaxPixelCost; //Field offset: 0x5C
	private static readonly int k_DebugLightingModeId; //Field offset: 0x60
	private static readonly int k_DebugLightingFeatureFlagsId; //Field offset: 0x64
	private static readonly int k_DebugValidateAlbedoMinLuminanceId; //Field offset: 0x68
	private static readonly int k_DebugValidateAlbedoMaxLuminanceId; //Field offset: 0x6C
	private static readonly int k_DebugValidateAlbedoSaturationToleranceId; //Field offset: 0x70
	private static readonly int k_DebugValidateAlbedoHueToleranceId; //Field offset: 0x74
	private static readonly int k_DebugValidateAlbedoCompareColorId; //Field offset: 0x78
	private static readonly int k_DebugValidateMetallicMinValueId; //Field offset: 0x7C
	private static readonly int k_DebugValidateMetallicMaxValueId; //Field offset: 0x80
	private static readonly int k_ValidationChannelsId; //Field offset: 0x84
	private static readonly int k_RangeMinimumId; //Field offset: 0x88
	private static readonly int k_RangeMaximumId; //Field offset: 0x8C
	private static readonly ProfilingSampler s_DebugSetupSampler; //Field offset: 0x90
	private static readonly ProfilingSampler s_DebugFinalValidationSampler; //Field offset: 0x98
	private DebugSetupPassData s_DebugSetupPassData; //Field offset: 0x10
	private DebugFinalValidationPassData s_DebugFinalValidationPassData; //Field offset: 0x18
	private readonly Material m_ReplacementMaterial; //Field offset: 0x20
	private readonly Material m_HDRDebugViewMaterial; //Field offset: 0x28
	private HDRDebugViewPass m_HDRDebugViewPass; //Field offset: 0x30
	private RTHandle m_DebugScreenColorHandle; //Field offset: 0x38
	private RTHandle m_DebugScreenDepthHandle; //Field offset: 0x40
	private readonly UniversalRenderPipelineRuntimeTextures m_RuntimeTextures; //Field offset: 0x48
	private bool m_HasDebugRenderTarget; //Field offset: 0x50
	private bool m_DebugRenderTargetSupportsStereo; //Field offset: 0x51
	private Vector4 m_DebugRenderTargetPixelRect; //Field offset: 0x54
	private Vector4 m_DebugRenderTargetRangeRemap; //Field offset: 0x64
	private RTHandle m_DebugRenderTarget; //Field offset: 0x78
	private RTHandle m_DebugFontTexture; //Field offset: 0x80
	private GraphicsBuffer m_debugDisplayConstant; //Field offset: 0x88
	private readonly UniversalRenderPipelineDebugDisplaySettings m_DebugDisplaySettings; //Field offset: 0x90

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 45
	}

	internal UniversalRenderPipelineDebugDisplaySettings DebugDisplaySettings
	{
		internal get { } //Length: 8
	}

	internal RTHandle DebugScreenColorHandle
	{
		internal get { } //Length: 5
	}

	internal RTHandle DebugScreenDepthHandle
	{
		internal get { } //Length: 5
	}

	internal HDRDebugViewPass hdrDebugViewPass
	{
		internal get { } //Length: 5
	}

	internal bool IsActiveModeUnsupportedForDeferred
	{
		internal get { } //Length: 118
	}

	public override bool IsLightingActive
	{
		 get { } //Length: 45
	}

	public override bool IsPostProcessingAllowed
	{
		 get { } //Length: 45
	}

	internal bool IsRenderPassSupported
	{
		internal get { } //Length: 66
	}

	internal bool IsScreenClearNeeded
	{
		internal get { } //Length: 63
	}

	private DebugDisplaySettingsLighting LightingSettings
	{
		private get { } //Length: 30
	}

	private DebugDisplaySettingsMaterial MaterialSettings
	{
		private get { } //Length: 30
	}

	private DebugDisplaySettingsRendering RenderingSettings
	{
		private get { } //Length: 30
	}

	internal Material ReplacementMaterial
	{
		internal get { } //Length: 5
	}

	internal int stpDebugViewIndex
	{
		internal get { } //Length: 38
	}

	private static DebugHandler() { }

	internal DebugHandler() { }

	internal static void ConfigureColorDescriptorForDebugScreen(ref RenderTextureDescriptor descriptor, int cameraWidth, int cameraHeight) { }

	internal static void ConfigureDepthDescriptorForDebugScreen(ref RenderTextureDescriptor descriptor, GraphicsFormat depthStencilFormat, int cameraWidth, int cameraHeight) { }

	internal DebugRendererLists CreateRendererListsWithDebugRenderState(ScriptableRenderContext context, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock) { }

	internal DebugRendererLists CreateRendererListsWithDebugRenderState(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock) { }

	public void Dispose() { }

	public override bool get_AreAnySettingsActive() { }

	internal UniversalRenderPipelineDebugDisplaySettings get_DebugDisplaySettings() { }

	internal RTHandle get_DebugScreenColorHandle() { }

	internal RTHandle get_DebugScreenDepthHandle() { }

	internal HDRDebugViewPass get_hdrDebugViewPass() { }

	internal bool get_IsActiveModeUnsupportedForDeferred() { }

	public override bool get_IsLightingActive() { }

	public override bool get_IsPostProcessingAllowed() { }

	internal bool get_IsRenderPassSupported() { }

	internal bool get_IsScreenClearNeeded() { }

	private DebugDisplaySettingsLighting get_LightingSettings() { }

	private DebugDisplaySettingsMaterial get_MaterialSettings() { }

	private DebugDisplaySettingsRendering get_RenderingSettings() { }

	internal Material get_ReplacementMaterial() { }

	internal int get_stpDebugViewIndex() { }

	internal bool HDRDebugViewIsActive(bool resolveFinalTarget) { }

	private DebugFinalValidationPassData InitDebugFinalValidationPassData(DebugFinalValidationPassData passData, UniversalCameraData cameraData, bool isFinalPass) { }

	private DebugSetupPassData InitDebugSetupPassData(DebugSetupPassData passData, bool isPreviewCamera) { }

	internal bool IsActiveForCamera(bool isPreviewCamera) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void Render(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle srcColor, TextureHandle overlayTexture, TextureHandle dstColor) { }

	internal void ResetDebugRenderTarget() { }

	internal void SetDebugRenderTarget(RTHandle renderTarget, Rect displayRect, bool supportsStereo, Vector4 dataRangeRemap) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void Setup(RenderGraph renderGraph, bool isPreviewCamera) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private static void Setup(RasterCommandBuffer cmd, DebugSetupPassData passData) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void Setup(CommandBuffer cmd, bool isPreviewCamera) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void SetupShaderProperties(RasterCommandBuffer cmd, int passIndex = 0) { }

	internal bool TryGetFullscreenDebugMode(out DebugFullScreenMode debugFullScreenMode, out int textureHeightPercent) { }

	internal bool TryGetFullscreenDebugMode(out DebugFullScreenMode debugFullScreenMode) { }

	public override bool TryGetScreenClearColor(ref Color color) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void UpdateShaderGlobalPropertiesForFinalValidationPass(CommandBuffer cmd, UniversalCameraData cameraData, bool isFinalPass) { }

	private static void UpdateShaderGlobalPropertiesForFinalValidationPass(RasterCommandBuffer cmd, DebugFinalValidationPassData data) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void UpdateShaderGlobalPropertiesForFinalValidationPass(RenderGraph renderGraph, UniversalCameraData cameraData, bool isFinalPass) { }

	internal bool WriteToDebugScreenTexture(bool resolveFinalTarget) { }

}

