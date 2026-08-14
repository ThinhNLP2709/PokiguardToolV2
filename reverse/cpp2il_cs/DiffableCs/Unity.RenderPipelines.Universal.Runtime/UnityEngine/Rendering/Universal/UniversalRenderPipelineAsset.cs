namespace UnityEngine.Rendering.Universal;

[ExcludeFromPreset]
public class UniversalRenderPipelineAsset : RenderPipelineAsset<UniversalRenderPipeline>, ISerializationCallbackReceiver, IProbeVolumeEnabledRenderPipeline, IGPUResidentRenderPipeline, IRenderGraphEnabledRenderPipeline, ISTPEnabledRenderPipeline
{
	private static class Strings
	{
		public static readonly string notURPRenderer; //Field offset: 0x0
		public static readonly string forwardPlusMissing; //Field offset: 0x8

		private static Strings() { }

	}

	[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)", False)]
	[ReloadGroup]
	internal sealed class TextureResources
	{
		[Reload("Textures/BlueNoise64/L/LDR_LLL1_0.png", Package::Root (1))]
		public Texture2D blueNoise64LTex; //Field offset: 0x10
		[Reload("Textures/BayerMatrix.png", Package::Root (1))]
		public Texture2D bayerMatrixTex; //Field offset: 0x18

		public TextureResources() { }

		public bool NeedsReload() { }

	}

	public const int k_MinLutSize = 16; //Field offset: 0x0
	private const int k_LastVersion = 12; //Field offset: 0x0
	internal const int k_ShadowCascadeMinCount = 1; //Field offset: 0x0
	internal const int k_ShadowCascadeMaxCount = 4; //Field offset: 0x0
	public static readonly int AdditionalLightsDefaultShadowResolutionTierLow; //Field offset: 0x0
	public const int k_MaxLutSize = 65; //Field offset: 0x0
	public static readonly int AdditionalLightsDefaultShadowResolutionTierMedium; //Field offset: 0x4
	public static readonly int AdditionalLightsDefaultShadowResolutionTierHigh; //Field offset: 0x8
	private static String[] s_Names; //Field offset: 0x10
	private static Int32[] s_Values; //Field offset: 0x18
	private static GraphicsFormat[][] s_LightCookieFormatList; //Field offset: 0x20
	private ScriptableRenderer[] m_Renderers; //Field offset: 0x18
	[SerializeField]
	private int k_AssetVersion; //Field offset: 0x20
	[SerializeField]
	private int k_AssetPreviousVersion; //Field offset: 0x24
	[SerializeField]
	private RendererType m_RendererType; //Field offset: 0x28
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Use m_RendererDataList instead.")]
	[SerializeField]
	internal ScriptableRendererData m_RendererData; //Field offset: 0x30
	[SerializeField]
	internal ScriptableRendererData[] m_RendererDataList; //Field offset: 0x38
	[SerializeField]
	internal int m_DefaultRendererIndex; //Field offset: 0x40
	[SerializeField]
	private bool m_RequireDepthTexture; //Field offset: 0x44
	[SerializeField]
	private bool m_RequireOpaqueTexture; //Field offset: 0x45
	[SerializeField]
	private Downsampling m_OpaqueDownsampling; //Field offset: 0x48
	[SerializeField]
	private bool m_SupportsTerrainHoles; //Field offset: 0x4C
	[SerializeField]
	private bool m_SupportsHDR; //Field offset: 0x4D
	[SerializeField]
	private HDRColorBufferPrecision m_HDRColorBufferPrecision; //Field offset: 0x50
	[SerializeField]
	private MsaaQuality m_MSAA; //Field offset: 0x54
	[SerializeField]
	private float m_RenderScale; //Field offset: 0x58
	[SerializeField]
	private UpscalingFilterSelection m_UpscalingFilter; //Field offset: 0x5C
	[SerializeField]
	private bool m_FsrOverrideSharpness; //Field offset: 0x60
	[SerializeField]
	private float m_FsrSharpness; //Field offset: 0x64
	[SerializeField]
	private bool m_EnableLODCrossFade; //Field offset: 0x68
	[SerializeField]
	private LODCrossFadeDitheringType m_LODCrossFadeDitheringType; //Field offset: 0x6C
	[SerializeField]
	private ShEvalMode m_ShEvalMode; //Field offset: 0x70
	[SerializeField]
	private LightProbeSystem m_LightProbeSystem; //Field offset: 0x74
	[SerializeField]
	private ProbeVolumeTextureMemoryBudget m_ProbeVolumeMemoryBudget; //Field offset: 0x78
	[SerializeField]
	private ProbeVolumeBlendingTextureMemoryBudget m_ProbeVolumeBlendingMemoryBudget; //Field offset: 0x7C
	[FormerlySerializedAs("m_SupportProbeVolumeStreaming")]
	[SerializeField]
	private bool m_SupportProbeVolumeGPUStreaming; //Field offset: 0x80
	[SerializeField]
	private bool m_SupportProbeVolumeDiskStreaming; //Field offset: 0x81
	[SerializeField]
	private bool m_SupportProbeVolumeScenarios; //Field offset: 0x82
	[SerializeField]
	private bool m_SupportProbeVolumeScenarioBlending; //Field offset: 0x83
	[SerializeField]
	private ProbeVolumeSHBands m_ProbeVolumeSHBands; //Field offset: 0x84
	[SerializeField]
	private LightRenderingMode m_MainLightRenderingMode; //Field offset: 0x88
	[SerializeField]
	private bool m_MainLightShadowsSupported; //Field offset: 0x8C
	[SerializeField]
	private ShadowResolution m_MainLightShadowmapResolution; //Field offset: 0x90
	[SerializeField]
	private LightRenderingMode m_AdditionalLightsRenderingMode; //Field offset: 0x94
	[SerializeField]
	private int m_AdditionalLightsPerObjectLimit; //Field offset: 0x98
	[SerializeField]
	private bool m_AdditionalLightShadowsSupported; //Field offset: 0x9C
	[SerializeField]
	private ShadowResolution m_AdditionalLightsShadowmapResolution; //Field offset: 0xA0
	[SerializeField]
	private int m_AdditionalLightsShadowResolutionTierLow; //Field offset: 0xA4
	[SerializeField]
	private int m_AdditionalLightsShadowResolutionTierMedium; //Field offset: 0xA8
	[SerializeField]
	private int m_AdditionalLightsShadowResolutionTierHigh; //Field offset: 0xAC
	[SerializeField]
	private bool m_ReflectionProbeBlending; //Field offset: 0xB0
	[SerializeField]
	private bool m_ReflectionProbeBoxProjection; //Field offset: 0xB1
	[SerializeField]
	private float m_ShadowDistance; //Field offset: 0xB4
	[SerializeField]
	private int m_ShadowCascadeCount; //Field offset: 0xB8
	[SerializeField]
	private float m_Cascade2Split; //Field offset: 0xBC
	[SerializeField]
	private Vector2 m_Cascade3Split; //Field offset: 0xC0
	[SerializeField]
	private Vector3 m_Cascade4Split; //Field offset: 0xC8
	[SerializeField]
	private float m_CascadeBorder; //Field offset: 0xD4
	[SerializeField]
	private float m_ShadowDepthBias; //Field offset: 0xD8
	[SerializeField]
	private float m_ShadowNormalBias; //Field offset: 0xDC
	[SerializeField]
	private bool m_SoftShadowsSupported; //Field offset: 0xE0
	[SerializeField]
	private bool m_ConservativeEnclosingSphere; //Field offset: 0xE1
	[SerializeField]
	private int m_NumIterationsEnclosingSphere; //Field offset: 0xE4
	[SerializeField]
	private SoftShadowQuality m_SoftShadowQuality; //Field offset: 0xE8
	[SerializeField]
	private LightCookieResolution m_AdditionalLightsCookieResolution; //Field offset: 0xEC
	[SerializeField]
	private LightCookieFormat m_AdditionalLightsCookieFormat; //Field offset: 0xF0
	[SerializeField]
	private bool m_UseSRPBatcher; //Field offset: 0xF4
	[SerializeField]
	private bool m_SupportsDynamicBatching; //Field offset: 0xF5
	[SerializeField]
	private bool m_MixedLightingSupported; //Field offset: 0xF6
	[SerializeField]
	private bool m_SupportsLightCookies; //Field offset: 0xF7
	[SerializeField]
	private bool m_SupportsLightLayers; //Field offset: 0xF8
	[Obsolete(null, True)]
	[SerializeField]
	private PipelineDebugLevel m_DebugLevel; //Field offset: 0xFC
	[SerializeField]
	private StoreActionsOptimization m_StoreActionsOptimization; //Field offset: 0x100
	[SerializeField]
	private bool m_UseAdaptivePerformance; //Field offset: 0x104
	[SerializeField]
	private ColorGradingMode m_ColorGradingMode; //Field offset: 0x108
	[SerializeField]
	private int m_ColorGradingLutSize; //Field offset: 0x10C
	[SerializeField]
	private bool m_AllowPostProcessAlphaOutput; //Field offset: 0x110
	[SerializeField]
	private bool m_UseFastSRGBLinearConversion; //Field offset: 0x111
	[SerializeField]
	private bool m_SupportDataDrivenLensFlare; //Field offset: 0x112
	[SerializeField]
	private bool m_SupportScreenSpaceLensFlare; //Field offset: 0x113
	[FormerlySerializedAs("m_MacroBatcherMode")]
	[SerializeField]
	private GPUResidentDrawerMode m_GPUResidentDrawerMode; //Field offset: 0x114
	[SerializeField]
	private float m_SmallMeshScreenPercentage; //Field offset: 0x118
	[SerializeField]
	private bool m_GPUResidentDrawerEnableOcclusionCullingInCameras; //Field offset: 0x11C
	[SerializeField]
	private ShadowQuality m_ShadowType; //Field offset: 0x120
	[SerializeField]
	private bool m_LocalShadowsSupported; //Field offset: 0x124
	[SerializeField]
	private ShadowResolution m_LocalShadowsAtlasResolution; //Field offset: 0x128
	[SerializeField]
	private int m_MaxPixelLights; //Field offset: 0x12C
	[SerializeField]
	private ShadowResolution m_ShadowAtlasResolution; //Field offset: 0x130
	[SerializeField]
	private VolumeFrameworkUpdateMode m_VolumeFrameworkUpdateMode; //Field offset: 0x134
	[SerializeField]
	private VolumeProfile m_VolumeProfile; //Field offset: 0x138
	[Obsolete("Kept for migration. #from(2023.3")]
	[SerializeField]
	internal ProbeVolumeSceneData apvScenesData; //Field offset: 0x140
	private Shader m_DefaultShader; //Field offset: 0x148
	[SerializeField]
	private int m_ShaderVariantLogLevel; //Field offset: 0x150
	[Obsolete("This is obsolete, please use shadowCascadeCount instead.", False)]
	[SerializeField]
	private ShadowCascadesOption m_ShadowCascades; //Field offset: 0x154
	[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)", False)]
	[SerializeField]
	private TextureResources m_Textures; //Field offset: 0x158

	internal GraphicsFormat additionalLightsCookieFormat
	{
		internal get { } //Length: 524
	}

	internal Vector2Int additionalLightsCookieResolution
	{
		internal get { } //Length: 20
	}

	public internal LightRenderingMode additionalLightsRenderingMode
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public int additionalLightsShadowmapResolution
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public internal int additionalLightsShadowResolutionTierHigh
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public internal int additionalLightsShadowResolutionTierLow
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public internal int additionalLightsShadowResolutionTierMedium
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public bool allowPostProcessAlphaOutput
	{
		 get { } //Length: 8
	}

	public float cascade2Split
	{
		 get { } //Length: 9
		 set { } //Length: 9
	}

	public Vector2 cascade3Split
	{
		 get { } //Length: 25
		 set { } //Length: 8
	}

	public Vector3 cascade4Split
	{
		 get { } //Length: 25
		 set { } //Length: 22
	}

	public float cascadeBorder
	{
		 get { } //Length: 9
		 set { } //Length: 9
	}

	public int colorGradingLutSize
	{
		 get { } //Length: 7
		 set { } //Length: 39
	}

	public ColorGradingMode colorGradingMode
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public bool conservativeEnclosingSphere
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	[Obsolete("PipelineDebugLevel is deprecated and replaced to use the profiler. Calling debugLevel is not necessary.", True)]
	public PipelineDebugLevel debugLevel
	{
		 get { } //Length: 3
	}

	public Material decalMaterial
	{
		 get { } //Length: 3
	}

	public virtual Material default2DMaskMaterial
	{
		 get { } //Length: 3
	}

	public virtual Material default2DMaterial
	{
		 get { } //Length: 3
	}

	public virtual Material defaultLineMaterial
	{
		 get { } //Length: 3
	}

	public virtual Material defaultMaterial
	{
		 get { } //Length: 3
	}

	public virtual Material defaultParticleMaterial
	{
		 get { } //Length: 3
	}

	public virtual Shader defaultShader
	{
		 get { } //Length: 178
	}

	public virtual Material defaultTerrainMaterial
	{
		 get { } //Length: 3
	}

	public bool enableLODCrossFade
	{
		 get { } //Length: 5
	}

	[Obsolete("This has been deprecated, please use GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode instead.")]
	public bool enableRenderGraph
	{
		 get { } //Length: 237
	}

	public bool fsrOverrideSharpness
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public float fsrSharpness
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public bool gpuResidentDrawerEnableOcclusionCullingInCameras
	{
		 get { } //Length: 8
		 set { } //Length: 35
	}

	public override GPUResidentDrawerMode gpuResidentDrawerMode
	{
		 get { } //Length: 8
		 set { } //Length: 35
	}

	public HDRColorBufferPrecision hdrColorBufferPrecision
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public override bool isImmediateModeSupported
	{
		 get { } //Length: 3
	}

	public override bool isStpUsed
	{
		 get { } //Length: 8
	}

	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", True)]
	public String[] lightLayerMaskNames
	{
		 get { } //Length: 50
	}

	public internal LightProbeSystem lightProbeSystem
	{
		 get { } //Length: 4
		internal set { } //Length: 4
	}

	public LODCrossFadeDitheringType lodCrossFadeDitheringType
	{
		 get { } //Length: 4
	}

	public internal LightRenderingMode mainLightRenderingMode
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public int mainLightShadowmapResolution
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public int maxAdditionalLightsCount
	{
		 get { } //Length: 7
		 set { } //Length: 157
	}

	public override ProbeVolumeSHBands maxSHBands
	{
		 get { } //Length: 18
	}

	public int msaaSampleCount
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public int numIterationsEnclosingSphere
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public Downsampling opaqueDownsampling
	{
		 get { } //Length: 4
	}

	[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(23.3)", False)]
	public virtual String[] prefixedRenderingLayerMaskNames
	{
		 get { } //Length: 152
	}

	public internal ProbeVolumeBlendingTextureMemoryBudget probeVolumeBlendingMemoryBudget
	{
		 get { } //Length: 4
		internal set { } //Length: 4
	}

	public internal ProbeVolumeTextureMemoryBudget probeVolumeMemoryBudget
	{
		 get { } //Length: 4
		internal set { } //Length: 4
	}

	[Obsolete("This property is no longer necessary.")]
	public override ProbeVolumeSceneData probeVolumeSceneData
	{
		 get { } //Length: 3
	}

	public internal ProbeVolumeSHBands probeVolumeSHBands
	{
		 get { } //Length: 7
		internal set { } //Length: 7
	}

	public internal bool reflectionProbeBlending
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public internal bool reflectionProbeBoxProjection
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public ReadOnlySpan<ScriptableRendererData> rendererDataList
	{
		 get { } //Length: 87
	}

	internal Int32[] rendererIndexList
	{
		internal get { } //Length: 126
	}

	public ReadOnlySpan<ScriptableRenderer> renderers
	{
		 get { } //Length: 87
	}

	[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(23.3)", False)]
	public virtual String[] renderingLayerMaskNames
	{
		 get { } //Length: 64
	}

	public virtual string renderPipelineShaderTag
	{
		 get { } //Length: 44
	}

	public float renderScale
	{
		 get { } //Length: 6
		 set { } //Length: 117
	}

	public ScriptableRenderer scriptableRenderer
	{
		 get { } //Length: 605
	}

	internal ScriptableRendererData scriptableRendererData
	{
		internal get { } //Length: 170
	}

	[Obsolete("Use GraphicsSettings.GetRenderPipelineSettings<ShaderStrippingSetting>().shaderVariantLogLevel instead.", True)]
	public ShaderVariantLogLevel shaderVariantLogLevel
	{
		 get { } //Length: 95
		 set { } //Length: 109
	}

	public int shadowCascadeCount
	{
		 get { } //Length: 7
		 set { } //Length: 234
	}

	[Obsolete("This is obsolete, please use shadowCascadeCount instead.", True)]
	public ShadowCascadesOption shadowCascadeOption
	{
		 get { } //Length: 139
		 set { } //Length: 151
	}

	public float shadowDepthBias
	{
		 get { } //Length: 9
		 set { } //Length: 103
	}

	public float shadowDistance
	{
		 get { } //Length: 9
		 set { } //Length: 18
	}

	public float shadowNormalBias
	{
		 get { } //Length: 9
		 set { } //Length: 103
	}

	public internal ShEvalMode shEvalMode
	{
		 get { } //Length: 4
		internal set { } //Length: 4
	}

	public float smallMeshScreenPercentage
	{
		 get { } //Length: 9
		 set { } //Length: 181
	}

	internal SoftShadowQuality softShadowQuality
	{
		internal get { } //Length: 7
		internal set { } //Length: 7
	}

	public StoreActionsOptimization storeActionsOptimization
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public bool supportDataDrivenLensFlare
	{
		 get { } //Length: 8
	}

	public override bool supportProbeVolume
	{
		 get { } //Length: 8
	}

	public internal bool supportProbeVolumeDiskStreaming
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public internal bool supportProbeVolumeGPUStreaming
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public internal bool supportProbeVolumeScenarioBlending
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public internal bool supportProbeVolumeScenarios
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	[Obsolete("This is obsolete, use supportProbeVolumeGPUStreaming instead.")]
	public internal bool supportProbeVolumeStreaming
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public internal bool supportsAdditionalLightShadows
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public bool supportsCameraDepthTexture
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool supportsCameraOpaqueTexture
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool supportScreenSpaceLensFlare
	{
		 get { } //Length: 8
	}

	public bool supportsDynamicBatching
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public bool supportsHDR
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool supportsLightCookies
	{
		 get { } //Length: 8
	}

	[Obsolete("This is obsolete, use useRenderingLayers instead.", True)]
	public bool supportsLightLayers
	{
		 get { } //Length: 8
	}

	public internal bool supportsMainLightShadows
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public bool supportsMixedLighting
	{
		 get { } //Length: 8
	}

	public internal bool supportsSoftShadows
	{
		 get { } //Length: 8
		internal set { } //Length: 7
	}

	public bool supportsTerrainHoles
	{
		 get { } //Length: 5
	}

	[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)", False)]
	public TextureResources textures
	{
		 get { } //Length: 117
	}

	private override GPUResidentDrawerSettings UnityEngine.Rendering.IGPUResidentRenderPipeline.gpuResidentDrawerSettings
	{
		private get { } //Length: 181
	}

	public UpscalingFilterSelection upscalingFilter
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool useAdaptivePerformance
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public bool useFastSRGBLinearConversion
	{
		 get { } //Length: 8
	}

	public bool useRenderingLayers
	{
		 get { } //Length: 8
	}

	public bool useSRPBatcher
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public VolumeFrameworkUpdateMode volumeFrameworkUpdateMode
	{
		 get { } //Length: 7
	}

	public VolumeProfile volumeProfile
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	private static UniversalRenderPipelineAsset() { }

	public UniversalRenderPipelineAsset() { }

	protected virtual RenderPipeline CreatePipeline() { }

	private void CreateRenderers() { }

	private void DestroyRenderer(ref ScriptableRenderer renderer) { }

	internal void DestroyRenderers() { }

	protected virtual void EnsureGlobalSettings() { }

	internal GraphicsFormat get_additionalLightsCookieFormat() { }

	internal Vector2Int get_additionalLightsCookieResolution() { }

	public LightRenderingMode get_additionalLightsRenderingMode() { }

	public int get_additionalLightsShadowmapResolution() { }

	public int get_additionalLightsShadowResolutionTierHigh() { }

	public int get_additionalLightsShadowResolutionTierLow() { }

	public int get_additionalLightsShadowResolutionTierMedium() { }

	public bool get_allowPostProcessAlphaOutput() { }

	public float get_cascade2Split() { }

	public Vector2 get_cascade3Split() { }

	public Vector3 get_cascade4Split() { }

	public float get_cascadeBorder() { }

	public int get_colorGradingLutSize() { }

	public ColorGradingMode get_colorGradingMode() { }

	public bool get_conservativeEnclosingSphere() { }

	public PipelineDebugLevel get_debugLevel() { }

	public Material get_decalMaterial() { }

	public virtual Material get_default2DMaskMaterial() { }

	public virtual Material get_default2DMaterial() { }

	public virtual Material get_defaultLineMaterial() { }

	public virtual Material get_defaultMaterial() { }

	public virtual Material get_defaultParticleMaterial() { }

	public virtual Shader get_defaultShader() { }

	public virtual Material get_defaultTerrainMaterial() { }

	public bool get_enableLODCrossFade() { }

	public bool get_enableRenderGraph() { }

	public bool get_fsrOverrideSharpness() { }

	public float get_fsrSharpness() { }

	public bool get_gpuResidentDrawerEnableOcclusionCullingInCameras() { }

	public override GPUResidentDrawerMode get_gpuResidentDrawerMode() { }

	public HDRColorBufferPrecision get_hdrColorBufferPrecision() { }

	public override bool get_isImmediateModeSupported() { }

	public override bool get_isStpUsed() { }

	public String[] get_lightLayerMaskNames() { }

	public LightProbeSystem get_lightProbeSystem() { }

	public LODCrossFadeDitheringType get_lodCrossFadeDitheringType() { }

	public LightRenderingMode get_mainLightRenderingMode() { }

	public int get_mainLightShadowmapResolution() { }

	public int get_maxAdditionalLightsCount() { }

	public override ProbeVolumeSHBands get_maxSHBands() { }

	public int get_msaaSampleCount() { }

	public int get_numIterationsEnclosingSphere() { }

	public Downsampling get_opaqueDownsampling() { }

	public virtual String[] get_prefixedRenderingLayerMaskNames() { }

	public ProbeVolumeBlendingTextureMemoryBudget get_probeVolumeBlendingMemoryBudget() { }

	public ProbeVolumeTextureMemoryBudget get_probeVolumeMemoryBudget() { }

	public override ProbeVolumeSceneData get_probeVolumeSceneData() { }

	public ProbeVolumeSHBands get_probeVolumeSHBands() { }

	public bool get_reflectionProbeBlending() { }

	public bool get_reflectionProbeBoxProjection() { }

	public ReadOnlySpan<ScriptableRendererData> get_rendererDataList() { }

	internal Int32[] get_rendererIndexList() { }

	public ReadOnlySpan<ScriptableRenderer> get_renderers() { }

	public virtual String[] get_renderingLayerMaskNames() { }

	public virtual string get_renderPipelineShaderTag() { }

	public float get_renderScale() { }

	public ScriptableRenderer get_scriptableRenderer() { }

	internal ScriptableRendererData get_scriptableRendererData() { }

	public ShaderVariantLogLevel get_shaderVariantLogLevel() { }

	public int get_shadowCascadeCount() { }

	public ShadowCascadesOption get_shadowCascadeOption() { }

	public float get_shadowDepthBias() { }

	public float get_shadowDistance() { }

	public float get_shadowNormalBias() { }

	public ShEvalMode get_shEvalMode() { }

	public float get_smallMeshScreenPercentage() { }

	internal SoftShadowQuality get_softShadowQuality() { }

	public StoreActionsOptimization get_storeActionsOptimization() { }

	public bool get_supportDataDrivenLensFlare() { }

	public override bool get_supportProbeVolume() { }

	public bool get_supportProbeVolumeDiskStreaming() { }

	public bool get_supportProbeVolumeGPUStreaming() { }

	public bool get_supportProbeVolumeScenarioBlending() { }

	public bool get_supportProbeVolumeScenarios() { }

	public bool get_supportProbeVolumeStreaming() { }

	public bool get_supportsAdditionalLightShadows() { }

	public bool get_supportsCameraDepthTexture() { }

	public bool get_supportsCameraOpaqueTexture() { }

	public bool get_supportScreenSpaceLensFlare() { }

	public bool get_supportsDynamicBatching() { }

	public bool get_supportsHDR() { }

	public bool get_supportsLightCookies() { }

	public bool get_supportsLightLayers() { }

	public bool get_supportsMainLightShadows() { }

	public bool get_supportsMixedLighting() { }

	public bool get_supportsSoftShadows() { }

	public bool get_supportsTerrainHoles() { }

	public TextureResources get_textures() { }

	public UpscalingFilterSelection get_upscalingFilter() { }

	public bool get_useAdaptivePerformance() { }

	public bool get_useFastSRGBLinearConversion() { }

	public bool get_useRenderingLayers() { }

	public bool get_useSRPBatcher() { }

	public VolumeFrameworkUpdateMode get_volumeFrameworkUpdateMode() { }

	public VolumeProfile get_volumeProfile() { }

	internal int GetAdditionalLightsShadowResolution(int additionalLightsShadowResolutionTier) { }

	private Material GetMaterial(DefaultMaterialType materialType) { }

	public ScriptableRenderer GetRenderer(int index) { }

	internal bool IsAtLastVersion() { }

	public override bool IsGPUResidentDrawerSupportedBySRP(out string message, out LogType severty) { }

	public ScriptableRendererData LoadBuiltinRendererData(RendererType type = 1) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	protected virtual void OnDisable() { }

	internal void OnEnableRenderGraphChanged() { }

	internal void set_additionalLightsRenderingMode(LightRenderingMode value) { }

	public void set_additionalLightsShadowmapResolution(int value) { }

	internal void set_additionalLightsShadowResolutionTierHigh(int value) { }

	internal void set_additionalLightsShadowResolutionTierLow(int value) { }

	internal void set_additionalLightsShadowResolutionTierMedium(int value) { }

	public void set_cascade2Split(float value) { }

	public void set_cascade3Split(Vector2 value) { }

	public void set_cascade4Split(Vector3 value) { }

	public void set_cascadeBorder(float value) { }

	public void set_colorGradingLutSize(int value) { }

	public void set_colorGradingMode(ColorGradingMode value) { }

	public void set_conservativeEnclosingSphere(bool value) { }

	public void set_fsrOverrideSharpness(bool value) { }

	public void set_fsrSharpness(float value) { }

	public void set_gpuResidentDrawerEnableOcclusionCullingInCameras(bool value) { }

	public override void set_gpuResidentDrawerMode(GPUResidentDrawerMode value) { }

	public void set_hdrColorBufferPrecision(HDRColorBufferPrecision value) { }

	internal void set_lightProbeSystem(LightProbeSystem value) { }

	internal void set_mainLightRenderingMode(LightRenderingMode value) { }

	public void set_mainLightShadowmapResolution(int value) { }

	public void set_maxAdditionalLightsCount(int value) { }

	public void set_msaaSampleCount(int value) { }

	public void set_numIterationsEnclosingSphere(int value) { }

	internal void set_probeVolumeBlendingMemoryBudget(ProbeVolumeBlendingTextureMemoryBudget value) { }

	internal void set_probeVolumeMemoryBudget(ProbeVolumeTextureMemoryBudget value) { }

	internal void set_probeVolumeSHBands(ProbeVolumeSHBands value) { }

	internal void set_reflectionProbeBlending(bool value) { }

	internal void set_reflectionProbeBoxProjection(bool value) { }

	public void set_renderScale(float value) { }

	public void set_shaderVariantLogLevel(ShaderVariantLogLevel value) { }

	public void set_shadowCascadeCount(int value) { }

	public void set_shadowCascadeOption(ShadowCascadesOption value) { }

	public void set_shadowDepthBias(float value) { }

	public void set_shadowDistance(float value) { }

	public void set_shadowNormalBias(float value) { }

	internal void set_shEvalMode(ShEvalMode value) { }

	public void set_smallMeshScreenPercentage(float value) { }

	internal void set_softShadowQuality(SoftShadowQuality value) { }

	public void set_storeActionsOptimization(StoreActionsOptimization value) { }

	internal void set_supportProbeVolumeDiskStreaming(bool value) { }

	internal void set_supportProbeVolumeGPUStreaming(bool value) { }

	internal void set_supportProbeVolumeScenarioBlending(bool value) { }

	internal void set_supportProbeVolumeScenarios(bool value) { }

	internal void set_supportProbeVolumeStreaming(bool value) { }

	internal void set_supportsAdditionalLightShadows(bool value) { }

	public void set_supportsCameraDepthTexture(bool value) { }

	public void set_supportsCameraOpaqueTexture(bool value) { }

	public void set_supportsDynamicBatching(bool value) { }

	public void set_supportsHDR(bool value) { }

	internal void set_supportsMainLightShadows(bool value) { }

	internal void set_supportsSoftShadows(bool value) { }

	public void set_upscalingFilter(UpscalingFilterSelection value) { }

	public void set_useAdaptivePerformance(bool value) { }

	public void set_useSRPBatcher(bool value) { }

	public void set_volumeProfile(VolumeProfile value) { }

	private override GPUResidentDrawerSettings UnityEngine.Rendering.IGPUResidentRenderPipeline.get_gpuResidentDrawerSettings() { }

	private int ValidatePerObjectLights(int value) { }

	internal bool ValidateRendererData(int index) { }

	internal bool ValidateRendererDataList(bool partial = false) { }

	private float ValidateRenderScale(float value) { }

	private float ValidateShadowBias(float value) { }

}

