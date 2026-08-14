namespace UnityEngine.Rendering.Universal.Internal;

internal class DeferredLights
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<SetupLightPassData, UnsafeGraphContext> <>9__139_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <SetupRenderGraphLights>b__139_0(SetupLightPassData data, UnsafeGraphContext rgContext) { }

	}

	public struct InitParams
	{
		public Material stencilDeferredMaterial; //Field offset: 0x0
		public LightCookieManager lightCookieManager; //Field offset: 0x8

	}

	private class SetupLightPassData
	{
		internal UniversalCameraData cameraData; //Field offset: 0x10
		internal UniversalLightData lightData; //Field offset: 0x18
		internal DeferredLights deferredLights; //Field offset: 0x20
		internal Vector2Int cameraTargetSizeCopy; //Field offset: 0x28

		public SetupLightPassData() { }

	}

	public static class ShaderConstants
	{
		public static readonly int _LitStencilRef; //Field offset: 0x0
		public static readonly int _LitStencilReadMask; //Field offset: 0x4
		public static readonly int _LitStencilWriteMask; //Field offset: 0x8
		public static readonly int _SimpleLitStencilRef; //Field offset: 0xC
		public static readonly int _SimpleLitStencilReadMask; //Field offset: 0x10
		public static readonly int _SimpleLitStencilWriteMask; //Field offset: 0x14
		public static readonly int _StencilRef; //Field offset: 0x18
		public static readonly int _StencilReadMask; //Field offset: 0x1C
		public static readonly int _StencilWriteMask; //Field offset: 0x20
		public static readonly int _LitPunctualStencilRef; //Field offset: 0x24
		public static readonly int _LitPunctualStencilReadMask; //Field offset: 0x28
		public static readonly int _LitPunctualStencilWriteMask; //Field offset: 0x2C
		public static readonly int _SimpleLitPunctualStencilRef; //Field offset: 0x30
		public static readonly int _SimpleLitPunctualStencilReadMask; //Field offset: 0x34
		public static readonly int _SimpleLitPunctualStencilWriteMask; //Field offset: 0x38
		public static readonly int _LitDirStencilRef; //Field offset: 0x3C
		public static readonly int _LitDirStencilReadMask; //Field offset: 0x40
		public static readonly int _LitDirStencilWriteMask; //Field offset: 0x44
		public static readonly int _SimpleLitDirStencilRef; //Field offset: 0x48
		public static readonly int _SimpleLitDirStencilReadMask; //Field offset: 0x4C
		public static readonly int _SimpleLitDirStencilWriteMask; //Field offset: 0x50
		public static readonly int _ClearStencilRef; //Field offset: 0x54
		public static readonly int _ClearStencilReadMask; //Field offset: 0x58
		public static readonly int _ClearStencilWriteMask; //Field offset: 0x5C
		public static readonly int _ScreenToWorld; //Field offset: 0x60
		public static int _MainLightPosition; //Field offset: 0x64
		public static int _MainLightColor; //Field offset: 0x68
		public static int _MainLightLayerMask; //Field offset: 0x6C
		public static int _SpotLightScale; //Field offset: 0x70
		public static int _SpotLightBias; //Field offset: 0x74
		public static int _SpotLightGuard; //Field offset: 0x78
		public static int _LightPosWS; //Field offset: 0x7C
		public static int _LightColor; //Field offset: 0x80
		public static int _LightAttenuation; //Field offset: 0x84
		public static int _LightOcclusionProbInfo; //Field offset: 0x88
		public static int _LightDirection; //Field offset: 0x8C
		public static int _LightFlags; //Field offset: 0x90
		public static int _ShadowLightIndex; //Field offset: 0x94
		public static int _LightLayerMask; //Field offset: 0x98
		public static int _CookieLightIndex; //Field offset: 0x9C

		private static ShaderConstants() { }

	}

	public enum StencilDeferredPasses
	{
		StencilVolume = 0,
		PunctualLit = 1,
		PunctualSimpleLit = 2,
		DirectionalLit = 3,
		DirectionalSimpleLit = 4,
		ClearStencilPartial = 5,
		Fog = 6,
		SSAOOnly = 7,
	}

	internal static readonly String[] k_GBufferNames; //Field offset: 0x0
	internal static readonly Int32[] k_GBufferShaderPropertyIDs; //Field offset: 0x8
	private static readonly String[] k_StencilDeferredPassNames; //Field offset: 0x10
	private static readonly ushort k_InvalidLightOffset; //Field offset: 0x18
	private static readonly string k_SetupLights; //Field offset: 0x20
	private static readonly string k_DeferredPass; //Field offset: 0x28
	private static readonly string k_DeferredStencilPass; //Field offset: 0x30
	private static readonly string k_DeferredFogPass; //Field offset: 0x38
	private static readonly string k_ClearStencilPartial; //Field offset: 0x40
	private static readonly string k_SetupLightConstants; //Field offset: 0x48
	private static readonly float kStencilShapeGuard; //Field offset: 0x50
	private static readonly ProfilingSampler m_ProfilingSetupLights; //Field offset: 0x58
	private static readonly ProfilingSampler m_ProfilingDeferredPass; //Field offset: 0x60
	private static readonly ProfilingSampler m_ProfilingSetupLightConstants; //Field offset: 0x68
	private static ProfilingSampler s_SetupDeferredLights; //Field offset: 0x70
	[CompilerGenerated]
	private MaskSize <RenderingLayerMaskSize>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <UseDecalLayers>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private bool <UseFramebufferFetch>k__BackingField; //Field offset: 0x15
	[CompilerGenerated]
	private bool <HasDepthPrepass>k__BackingField; //Field offset: 0x16
	[CompilerGenerated]
	private bool <HasNormalPrepass>k__BackingField; //Field offset: 0x17
	[CompilerGenerated]
	private bool <HasRenderingLayerPrepass>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <IsOverlay>k__BackingField; //Field offset: 0x19
	[CompilerGenerated]
	private bool <AccurateGbufferNormals>k__BackingField; //Field offset: 0x1A
	[CompilerGenerated]
	private MixedLightingSetup <MixedLightingSetup>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private bool <UseJobSystem>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <RenderWidth>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private int <RenderHeight>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private RTHandle[] <GbufferAttachments>k__BackingField; //Field offset: 0x30
	private RTHandle[] GbufferRTHandles; //Field offset: 0x38
	[CompilerGenerated]
	private TextureHandle[] <GbufferTextureHandles>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private RTHandle[] <DeferredInputAttachments>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private Boolean[] <DeferredInputIsTransient>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private RTHandle <DepthAttachment>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private RTHandle <DepthCopyTexture>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private GraphicsFormat[] <GbufferFormats>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private RTHandle <DepthAttachmentHandle>k__BackingField; //Field offset: 0x70
	private NativeArray<UInt16> m_stencilVisLights; //Field offset: 0x78
	private NativeArray<UInt16> m_stencilVisLightOffsets; //Field offset: 0x88
	private AdditionalLightsShadowCasterPass m_AdditionalLightsShadowCasterPass; //Field offset: 0x98
	private Mesh m_SphereMesh; //Field offset: 0xA0
	private Mesh m_HemisphereMesh; //Field offset: 0xA8
	private Mesh m_FullscreenMesh; //Field offset: 0xB0
	private Material m_StencilDeferredMaterial; //Field offset: 0xB8
	private Int32[] m_StencilDeferredPasses; //Field offset: 0xC0
	private Matrix4x4[] m_ScreenToWorld; //Field offset: 0xC8
	private ProfilingSampler m_ProfilingSamplerDeferredStencilPass; //Field offset: 0xD0
	private ProfilingSampler m_ProfilingSamplerDeferredFogPass; //Field offset: 0xD8
	private ProfilingSampler m_ProfilingSamplerClearStencilPartialPass; //Field offset: 0xE0
	private LightCookieManager m_LightCookieManager; //Field offset: 0xE8

	internal bool AccurateGbufferNormals
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal RTHandle[] DeferredInputAttachments
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal Boolean[] DeferredInputIsTransient
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal RTHandle DepthAttachment
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal RTHandle DepthAttachmentHandle
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal RTHandle DepthCopyTexture
	{
		[CompilerGenerated]
		internal get { } //Length: 694
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal int GBufferAlbedoIndex
	{
		internal get { } //Length: 3
	}

	internal RTHandle[] GbufferAttachments
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal int GbufferDepthIndex
	{
		internal get { } //Length: 18
	}

	internal GraphicsFormat[] GbufferFormats
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal int GBufferInputAttachmentCount
	{
		internal get { } //Length: 14
	}

	internal int GBufferLightingIndex
	{
		internal get { } //Length: 6
	}

	internal int GBufferNormalSmoothnessIndex
	{
		internal get { } //Length: 6
	}

	internal int GBufferRenderingLayers
	{
		internal get { } //Length: 118
	}

	internal int GBufferShadowMask
	{
		internal get { } //Length: 149
	}

	internal int GBufferSliceCount
	{
		internal get { } //Length: 155
	}

	internal int GBufferSpecularMetallicIndex
	{
		internal get { } //Length: 6
	}

	internal TextureHandle[] GbufferTextureHandles
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal bool HasDepthPrepass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool HasNormalPrepass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool HasRenderingLayerPrepass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool IsOverlay
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal MixedLightingSetup MixedLightingSetup
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal int RenderHeight
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal MaskSize RenderingLayerMaskSize
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal int RenderWidth
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool UseDecalLayers
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool UseFramebufferFetch
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool UseJobSystem
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 1011
	}

	internal bool UseLightLayers
	{
		internal get { } //Length: 82
	}

	internal bool UseRenderingLayers
	{
		internal get { } //Length: 102
	}

	internal bool UseShadowMask
	{
		internal get { } //Length: 8
	}

	private static DeferredLights() { }

	internal DeferredLights(InitParams initParams, bool useNativeRenderPass = false) { }

	internal void ClearStencilPartial(RasterCommandBuffer cmd) { }

	private static Mesh CreateFullscreenMesh() { }

	internal void CreateGbufferResources() { }

	private static Mesh CreateHemisphereMesh() { }

	private static Mesh CreateSphereMesh() { }

	internal void DisableFramebufferFetchInput() { }

	internal void ExecuteDeferredPass(RasterCommandBuffer cmd, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData) { }

	[CompilerGenerated]
	internal bool get_AccurateGbufferNormals() { }

	[CompilerGenerated]
	internal RTHandle[] get_DeferredInputAttachments() { }

	[CompilerGenerated]
	internal Boolean[] get_DeferredInputIsTransient() { }

	[CompilerGenerated]
	internal RTHandle get_DepthAttachment() { }

	[CompilerGenerated]
	internal RTHandle get_DepthAttachmentHandle() { }

	[CompilerGenerated]
	internal RTHandle get_DepthCopyTexture() { }

	internal int get_GBufferAlbedoIndex() { }

	[CompilerGenerated]
	internal RTHandle[] get_GbufferAttachments() { }

	internal int get_GbufferDepthIndex() { }

	[CompilerGenerated]
	internal GraphicsFormat[] get_GbufferFormats() { }

	internal int get_GBufferInputAttachmentCount() { }

	internal int get_GBufferLightingIndex() { }

	internal int get_GBufferNormalSmoothnessIndex() { }

	internal int get_GBufferRenderingLayers() { }

	internal int get_GBufferShadowMask() { }

	internal int get_GBufferSliceCount() { }

	internal int get_GBufferSpecularMetallicIndex() { }

	[CompilerGenerated]
	internal TextureHandle[] get_GbufferTextureHandles() { }

	[CompilerGenerated]
	internal bool get_HasDepthPrepass() { }

	[CompilerGenerated]
	internal bool get_HasNormalPrepass() { }

	[CompilerGenerated]
	internal bool get_HasRenderingLayerPrepass() { }

	[CompilerGenerated]
	internal bool get_IsOverlay() { }

	[CompilerGenerated]
	internal MixedLightingSetup get_MixedLightingSetup() { }

	[CompilerGenerated]
	internal int get_RenderHeight() { }

	[CompilerGenerated]
	internal MaskSize get_RenderingLayerMaskSize() { }

	[CompilerGenerated]
	internal int get_RenderWidth() { }

	[CompilerGenerated]
	internal bool get_UseDecalLayers() { }

	[CompilerGenerated]
	internal bool get_UseFramebufferFetch() { }

	[CompilerGenerated]
	internal bool get_UseJobSystem() { }

	internal bool get_UseLightLayers() { }

	internal bool get_UseRenderingLayers() { }

	internal bool get_UseShadowMask() { }

	internal GraphicsFormat GetGBufferFormat(int index) { }

	private bool HasStencilLightsOfType(LightType type) { }

	private void InitStencilDeferredMaterial() { }

	internal bool IsRuntimeSupportedThisFrame() { }

	public void OnCameraCleanup(CommandBuffer cmd) { }

	internal static RenderStateBlock OverwriteStencil(RenderStateBlock block, int stencilWriteMask, int stencilRef) { }

	internal static StencilState OverwriteStencil(StencilState s, int stencilWriteMask) { }

	private void PrecomputeLights(out NativeArray<UInt16>& stencilVisLights, out NativeArray<UInt16>& stencilVisLightOffsets, ref NativeArray<VisibleLight>& visibleLights, bool hasAdditionalLights) { }

	internal void ReAllocateGBufferIfNeeded(RenderTextureDescriptor gbufferSlice, int gbufferIndex) { }

	internal void ReleaseGbufferResources() { }

	private void RenderFog(RasterCommandBuffer cmd, bool isOrthographic) { }

	private void RenderSSAOBeforeShading(RasterCommandBuffer cmd) { }

	private void RenderStencilDirectionalLights(RasterCommandBuffer cmd, bool stripShadowsOffVariants, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager, int mainLightIndex) { }

	private void RenderStencilLights(RasterCommandBuffer cmd, UniversalLightData lightData, UniversalShadowData shadowData, bool stripShadowsOffVariants) { }

	private void RenderStencilPointLights(RasterCommandBuffer cmd, bool stripShadowsOffVariants, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager) { }

	private void RenderStencilSpotLights(RasterCommandBuffer cmd, bool stripShadowsOffVariants, UniversalLightData lightData, UniversalShadowData shadowData, NativeArray<VisibleLight> visibleLights, bool hasAdditionalLightPass, bool hasLightCookieManager) { }

	internal void ResolveMixedLightingMode(UniversalLightData lightData) { }

	[CompilerGenerated]
	internal void set_AccurateGbufferNormals(bool value) { }

	[CompilerGenerated]
	internal void set_DeferredInputAttachments(RTHandle[] value) { }

	[CompilerGenerated]
	internal void set_DeferredInputIsTransient(Boolean[] value) { }

	[CompilerGenerated]
	internal void set_DepthAttachment(RTHandle value) { }

	[CompilerGenerated]
	internal void set_DepthAttachmentHandle(RTHandle value) { }

	[CompilerGenerated]
	internal void set_DepthCopyTexture(RTHandle value) { }

	[CompilerGenerated]
	internal void set_GbufferAttachments(RTHandle[] value) { }

	[CompilerGenerated]
	internal void set_GbufferFormats(GraphicsFormat[] value) { }

	[CompilerGenerated]
	internal void set_GbufferTextureHandles(TextureHandle[] value) { }

	[CompilerGenerated]
	internal void set_HasDepthPrepass(bool value) { }

	[CompilerGenerated]
	internal void set_HasNormalPrepass(bool value) { }

	[CompilerGenerated]
	internal void set_HasRenderingLayerPrepass(bool value) { }

	[CompilerGenerated]
	internal void set_IsOverlay(bool value) { }

	[CompilerGenerated]
	internal void set_MixedLightingSetup(MixedLightingSetup value) { }

	[CompilerGenerated]
	internal void set_RenderHeight(int value) { }

	[CompilerGenerated]
	internal void set_RenderingLayerMaskSize(MaskSize value) { }

	[CompilerGenerated]
	internal void set_RenderWidth(int value) { }

	[CompilerGenerated]
	internal void set_UseDecalLayers(bool value) { }

	[CompilerGenerated]
	internal void set_UseFramebufferFetch(bool value) { }

	[CompilerGenerated]
	internal void set_UseJobSystem(bool value) { }

	private void SetAdditionalLightsShadowsKeyword(ref RasterCommandBuffer cmd, bool stripShadowsOffVariants, bool additionalLightShadowsEnabled, bool hasDeferredShadows, bool shouldOverride, ref bool lastShadowsKeyword) { }

	private void SetLightCookiesKeyword(RasterCommandBuffer cmd, int visLightIndex, bool hasLightCookieManager, bool shouldOverride, ref bool lastLightCookieState, ref int lastCookieLightIndex) { }

	private void SetRenderingLayersMask(RasterCommandBuffer cmd, Light light, int shaderPropertyID) { }

	private void SetSoftShadowsKeyword(RasterCommandBuffer cmd, UniversalShadowData shadowData, Light light, bool hasDeferredShadows, bool shouldOverride, ref bool lastHasSoftShadow) { }

	internal void Setup(AdditionalLightsShadowCasterPass additionalLightsShadowCasterPass) { }

	public void Setup(AdditionalLightsShadowCasterPass additionalLightsShadowCasterPass, bool hasDepthPrepass, bool hasNormalPrepass, bool hasRenderingLayerPrepass, RTHandle depthCopyTexture, RTHandle depthAttachment, RTHandle colorAttachment) { }

	internal void SetupLights(CommandBuffer cmd, UniversalCameraData cameraData, Vector2Int cameraTargetSizeCopy, UniversalLightData lightData, bool isRenderGraph = false) { }

	private void SetupMainLightConstants(CommandBuffer cmd, UniversalLightData lightData) { }

	private void SetupMatrixConstants(RasterCommandBuffer cmd, UniversalCameraData cameraData) { }

	internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalLightData lightData) { }

	private void SetupShaderLightConstants(CommandBuffer cmd, UniversalLightData lightData) { }

	internal void UpdateDeferredInputAttachments() { }

}

