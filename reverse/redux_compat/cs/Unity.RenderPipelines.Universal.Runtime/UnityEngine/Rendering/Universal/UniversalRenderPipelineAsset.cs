/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[ExcludeFromPreset]
	public class UniversalRenderPipelineAsset : RenderPipelineAsset<UniversalRenderPipeline>, ISerializationCallbackReceiver, IProbeVolumeEnabledRenderPipeline, IGPUResidentRenderPipeline, IRenderGraphEnabledRenderPipeline, ISTPEnabledRenderPipeline // TypeDefIndex: 9312
	{
		// Fields
		private Shader m_DefaultShader; // 0x20
		private ScriptableRenderer[] m_Renderers; // 0x28
		private const int k_LastVersion = 13; // Metadata: 0x0069E94B
		[SerializeField]
		internal int k_AssetVersion; // 0x30
		[SerializeField]
		private int k_AssetPreviousVersion; // 0x34
		[SerializeField]
		private RendererType m_RendererType; // 0x38
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use m_RendererDataList instead. #from(2023.1)")]
		[SerializeField]
		internal ScriptableRendererData m_RendererData; // 0x40
		[SerializeField]
		internal ScriptableRendererData[] m_RendererDataList; // 0x48
		[SerializeField]
		internal int m_DefaultRendererIndex; // 0x50
		[SerializeField]
		private bool m_RequireDepthTexture; // 0x54
		[SerializeField]
		private bool m_RequireOpaqueTexture; // 0x55
		[SerializeField]
		private Downsampling m_OpaqueDownsampling; // 0x58
		[SerializeField]
		private bool m_SupportsTerrainHoles; // 0x5C
		[SerializeField]
		private bool m_SupportsHDR; // 0x5D
		[SerializeField]
		private HDRColorBufferPrecision m_HDRColorBufferPrecision; // 0x60
		[SerializeField]
		private MsaaQuality m_MSAA; // 0x64
		[SerializeField]
		private float m_RenderScale; // 0x68
		[SerializeField]
		private UpscalingFilterSelection m_UpscalingFilter; // 0x6C
		[SerializeField]
		private bool m_FsrOverrideSharpness; // 0x70
		[SerializeField]
		private float m_FsrSharpness; // 0x74
		[SerializeField]
		private bool m_EnableLODCrossFade; // 0x78
		[SerializeField]
		private LODCrossFadeDitheringType m_LODCrossFadeDitheringType; // 0x7C
		[SerializeField]
		private ShEvalMode m_ShEvalMode; // 0x80
		[SerializeField]
		private LightProbeSystem m_LightProbeSystem; // 0x84
		[SerializeField]
		private ProbeVolumeTextureMemoryBudget m_ProbeVolumeMemoryBudget; // 0x88
		[SerializeField]
		private ProbeVolumeBlendingTextureMemoryBudget m_ProbeVolumeBlendingMemoryBudget; // 0x8C
		[FormerlySerializedAs("m_SupportProbeVolumeStreaming")]
		[SerializeField]
		private bool m_SupportProbeVolumeGPUStreaming; // 0x90
		[SerializeField]
		private bool m_SupportProbeVolumeDiskStreaming; // 0x91
		[SerializeField]
		private bool m_SupportProbeVolumeScenarios; // 0x92
		[SerializeField]
		private bool m_SupportProbeVolumeScenarioBlending; // 0x93
		[SerializeField]
		private ProbeVolumeSHBands m_ProbeVolumeSHBands; // 0x94
		[SerializeField]
		private LightRenderingMode m_MainLightRenderingMode; // 0x98
		[SerializeField]
		private bool m_MainLightShadowsSupported; // 0x9C
		[SerializeField]
		private ShadowResolution m_MainLightShadowmapResolution; // 0xA0
		[SerializeField]
		private LightRenderingMode m_AdditionalLightsRenderingMode; // 0xA4
		[SerializeField]
		private int m_AdditionalLightsPerObjectLimit; // 0xA8
		[SerializeField]
		private bool m_AdditionalLightShadowsSupported; // 0xAC
		[SerializeField]
		private ShadowResolution m_AdditionalLightsShadowmapResolution; // 0xB0
		[SerializeField]
		private int m_AdditionalLightsShadowResolutionTierLow; // 0xB4
		[SerializeField]
		private int m_AdditionalLightsShadowResolutionTierMedium; // 0xB8
		[SerializeField]
		private int m_AdditionalLightsShadowResolutionTierHigh; // 0xBC
		[SerializeField]
		private bool m_ReflectionProbeBlending; // 0xC0
		[SerializeField]
		private bool m_ReflectionProbeBoxProjection; // 0xC1
		[SerializeField]
		private bool m_ReflectionProbeAtlas; // 0xC2
		[SerializeField]
		private float m_ShadowDistance; // 0xC4
		[SerializeField]
		private int m_ShadowCascadeCount; // 0xC8
		[SerializeField]
		private float m_Cascade2Split; // 0xCC
		[SerializeField]
		private Vector2 m_Cascade3Split; // 0xD0
		[SerializeField]
		private Vector3 m_Cascade4Split; // 0xD8
		[SerializeField]
		private float m_CascadeBorder; // 0xE4
		[SerializeField]
		private float m_ShadowDepthBias; // 0xE8
		[SerializeField]
		private float m_ShadowNormalBias; // 0xEC
		[SerializeField]
		private bool m_SoftShadowsSupported; // 0xF0
		[SerializeField]
		private bool m_ConservativeEnclosingSphere; // 0xF1
		[SerializeField]
		private int m_NumIterationsEnclosingSphere; // 0xF4
		[SerializeField]
		private SoftShadowQuality m_SoftShadowQuality; // 0xF8
		[SerializeField]
		private LightCookieResolution m_AdditionalLightsCookieResolution; // 0xFC
		[SerializeField]
		private LightCookieFormat m_AdditionalLightsCookieFormat; // 0x100
		[SerializeField]
		private bool m_UseSRPBatcher; // 0x104
		[SerializeField]
		private bool m_SupportsDynamicBatching; // 0x105
		[SerializeField]
		private bool m_MixedLightingSupported; // 0x106
		[SerializeField]
		private bool m_SupportsLightCookies; // 0x107
		[SerializeField]
		private bool m_SupportsLightLayers; // 0x108
		[Obsolete("#from(6000.0) #breakingFrom(6000.4)", true)]
		[SerializeField]
		private StoreActionsOptimization m_StoreActionsOptimization; // 0x10C
		[SerializeField]
		private bool m_UseAdaptivePerformance; // 0x110
		[SerializeField]
		private ColorGradingMode m_ColorGradingMode; // 0x114
		[SerializeField]
		private int m_ColorGradingLutSize; // 0x118
		[SerializeField]
		private bool m_AllowPostProcessAlphaOutput; // 0x11C
		[SerializeField]
		private bool m_UseFastSRGBLinearConversion; // 0x11D
		[SerializeField]
		private bool m_SupportDataDrivenLensFlare; // 0x11E
		[SerializeField]
		private bool m_SupportScreenSpaceLensFlare; // 0x11F
		[FormerlySerializedAs("m_MacroBatcherMode")]
		[SerializeField]
		private GPUResidentDrawerMode m_GPUResidentDrawerMode; // 0x120
		[SerializeField]
		private float m_SmallMeshScreenPercentage; // 0x124
		[SerializeField]
		private Vector4 m_ShadowSmallMeshScreenPercentages; // 0x128
		[SerializeField]
		private bool m_GPUResidentDrawerEnableOcclusionCullingInCameras; // 0x138
		[SerializeField]
		private ShadowQuality m_ShadowType; // 0x13C
		[SerializeField]
		private bool m_LocalShadowsSupported; // 0x140
		[SerializeField]
		private ShadowResolution m_LocalShadowsAtlasResolution; // 0x144
		[SerializeField]
		private int m_MaxPixelLights; // 0x148
		[SerializeField]
		private ShadowResolution m_ShadowAtlasResolution; // 0x14C
		[SerializeField]
		private VolumeFrameworkUpdateMode m_VolumeFrameworkUpdateMode; // 0x150
		[SerializeField]
		private VolumeProfile m_VolumeProfile; // 0x158
		public const int k_MinLutSize = 16; // Metadata: 0x0069E94C
		public const int k_MaxLutSize = 65; // Metadata: 0x0069E94D
		internal const int k_ShadowCascadeMinCount = 1; // Metadata: 0x0069E94F
		internal const int k_ShadowCascadeMaxCount = 4; // Metadata: 0x0069E950
		public static readonly int AdditionalLightsDefaultShadowResolutionTierLow; // 0x00
		public static readonly int AdditionalLightsDefaultShadowResolutionTierMedium; // 0x04
		public static readonly int AdditionalLightsDefaultShadowResolutionTierHigh; // 0x08
		private static string[] s_Names; // 0x10
		private static int[] s_Values; // 0x18
		private static readonly GraphicsFormat[][] k_LightCookieFormatList; // 0x20
		[Obsolete("Kept for migration. #from(2023.3")]
		[SerializeField]
		internal ProbeVolumeSceneData apvScenesData; // 0x160
		[SerializeField]
		private int m_ShaderVariantLogLevel; // 0x168
		[Obsolete("This is obsolete, please use shadowCascadeCount instead. #from(2021.1)")]
		[SerializeField]
		private ShadowCascadesOption m_ShadowCascades; // 0x16C
		[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)")]
		[SerializeField]
		private TextureResources m_Textures; // 0x170
	
		// Properties
		public override Material defaultMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Material defaultParticleMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Material defaultLineMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Material defaultTerrainMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Material default2DMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Material default2DMaskMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public Material decalMaterial { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Shader defaultShader { get; } // 0x0000000181F63E60-0x0000000181F63F10 
		public override Shader terrainDetailLitShader { get; } // 0x0000000181F64730-0x0000000181F647B0 
		public override Shader terrainDetailGrassShader { get; } // 0x0000000181F646B0-0x0000000181F64730 
		public override Shader terrainDetailGrassBillboardShader { get; } // 0x0000000181F64630-0x0000000181F646B0 
		GPUResidentDrawerSettings IGPUResidentRenderPipeline.gpuResidentDrawerSettings { get; } // 0x0000000181F632C0-0x0000000181F633C0 
		public ReadOnlySpan<ScriptableRendererData> rendererDataList { get; } // 0x0000000181F64040-0x0000000181F64070 
		public ReadOnlySpan<ScriptableRenderer> renderers { get; } // 0x0000000181F640F0-0x0000000181F64120 
		public bool isImmediateModeSupported { get; } // 0x00000001802E7840-0x00000001802E7850 
		public ScriptableRenderer scriptableRenderer { get; } // 0x0000000181F64210-0x0000000181F64450 
		internal ScriptableRendererData scriptableRendererData { get; } // 0x0000000181F64160-0x0000000181F64210 
		internal GraphicsFormat additionalLightsCookieFormat { get; } // 0x0000000181F63B90-0x0000000181F63DC0 
		internal Vector2Int additionalLightsCookieResolution { get; } // 0x0000000181F63DC0-0x0000000181F63DE0 
		internal int[] rendererIndexList { get; } // 0x0000000181F64070-0x0000000181F640F0 
		public bool supportsCameraDepthTexture { get; set; } // 0x000000018033D250-0x000000018033D260 0x000000018033E860-0x000000018033E870
		public bool supportsCameraOpaqueTexture { get; set; } // 0x0000000181A856A0-0x0000000181A856B0 0x0000000181F65010-0x0000000181F65020
		public Downsampling opaqueDownsampling { get; } // 0x000000018033D260-0x000000018033D270 
		public bool supportsTerrainHoles { get; } // 0x00000001815D7D00-0x00000001815D7D10 
		[Obsolete("#from(6000.0) #breakingFrom(6000.4)", true)]
		public StoreActionsOptimization storeActionsOptimization { get; set; } // 0x0000000181F645A0-0x0000000181F645B0 0x0000000181F65000-0x0000000181F65010
		public bool supportsHDR { get; set; } // 0x0000000181F645F0-0x0000000181F64600 0x0000000181F65030-0x0000000181F65040
		public HDRColorBufferPrecision hdrColorBufferPrecision { get; set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
		public int msaaSampleCount { get; set; } // 0x00000001802F2020-0x00000001802F2030 0x000000018033EA40-0x000000018033EA50
		public float renderScale { get; set; } // 0x0000000180C245B0-0x0000000180C245C0 0x0000000181F64A50-0x0000000181F64AD0
		public bool enableLODCrossFade { get; } // 0x0000000180B255A0-0x0000000180B255B0 
		public LODCrossFadeDitheringType lodCrossFadeDitheringType { get; } // 0x00000001816A5830-0x00000001816A5840 
		public UpscalingFilterSelection upscalingFilter { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000180C55C60-0x0000000180C55C70
		public string upscalerName { get; } // 0x00000001815B1550-0x00000001815B1570 
		public bool fsrOverrideSharpness { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000180C4A240-0x0000000180C4A250
		public float fsrSharpness { get; set; } // 0x0000000181F63F10-0x0000000181F63F20 0x0000000181F64900-0x0000000181F64910
		public ShEvalMode shEvalMode { get; internal set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x0000000180CC3E80-0x0000000180CC3E90
		public LightProbeSystem lightProbeSystem { get; internal set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
		public ProbeVolumeTextureMemoryBudget probeVolumeMemoryBudget { get; internal set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public ProbeVolumeBlendingTextureMemoryBudget probeVolumeBlendingMemoryBudget { get; internal set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
		[Obsolete("This is obsolete, use supportProbeVolumeGPUStreaming instead. #from(2023.3)")]
		public bool supportProbeVolumeStreaming { get; internal set; } // 0x000000018033D630-0x000000018033D640 0x000000018033EC10-0x000000018033EC20
		public bool supportProbeVolumeGPUStreaming { get; internal set; } // 0x000000018033D630-0x000000018033D640 0x000000018033EC10-0x000000018033EC20
		public bool supportProbeVolumeDiskStreaming { get; internal set; } // 0x0000000181845F90-0x0000000181845FA0 0x0000000181DD9C80-0x0000000181DD9C90
		public bool supportProbeVolumeScenarios { get; internal set; } // 0x0000000181845F80-0x0000000181845F90 0x0000000181DD9C70-0x0000000181DD9C80
		public bool supportProbeVolumeScenarioBlending { get; internal set; } // 0x0000000181845FA0-0x0000000181845FB0 0x0000000181A58D60-0x0000000181A58D70
		public ProbeVolumeSHBands probeVolumeSHBands { get; internal set; } // 0x000000018033D1E0-0x000000018033D1F0 0x000000018033E7C0-0x000000018033E7D0
		public LightRenderingMode mainLightRenderingMode { get; internal set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
		public bool supportsMainLightShadows { get; internal set; } // 0x0000000181974800-0x0000000181974810 0x0000000181F65040-0x0000000181F65050
		public int mainLightShadowmapResolution { get; set; } // 0x000000018033D1F0-0x000000018033D200 0x000000018033E7D0-0x000000018033E7E0
		public LightRenderingMode additionalLightsRenderingMode { get; internal set; } // 0x000000018033D210-0x000000018033D220 0x000000018033E7F0-0x000000018033E800
		public int maxAdditionalLightsCount { get; set; } // 0x00000001806671D0-0x00000001806671E0 0x0000000181F64970-0x0000000181F64A10
		public bool supportsAdditionalLightShadows { get; internal set; } // 0x0000000181EE3C20-0x0000000181EE3C30 0x0000000181EE2470-0x0000000181EE2480
		public int additionalLightsShadowmapResolution { get; set; } // 0x000000018158ACB0-0x000000018158ACC0 0x0000000181727410-0x0000000181727420
		public int additionalLightsShadowResolutionTierLow { get; internal set; } // 0x000000018158AD40-0x000000018158AD50 0x0000000181C4C370-0x0000000181C4C380
		public int additionalLightsShadowResolutionTierMedium { get; internal set; } // 0x00000001806342B0-0x00000001806342C0 0x00000001806342C0-0x00000001806342D0
		public int additionalLightsShadowResolutionTierHigh { get; internal set; } // 0x000000018158B010-0x000000018158B020 0x0000000181F64860-0x0000000181F64870
		public bool reflectionProbeBlending { get; internal set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		public bool reflectionProbeBoxProjection { get; internal set; } // 0x00000001816A4210-0x00000001816A4220 0x0000000181F64A40-0x0000000181F64A50
		public bool reflectionProbeAtlas { get; internal set; } // 0x00000001816A5690-0x00000001816A56A0 0x0000000181F64A20-0x0000000181F64A30
		public float shadowDistance { get; set; } // 0x0000000181F64550-0x0000000181F64560 0x0000000181F64D40-0x0000000181F64D50
		public int shadowCascadeCount { get; set; } // 0x000000018158B020-0x000000018158B030 0x0000000181F64B40-0x0000000181F64C30
		public float cascade2Split { get; set; } // 0x0000000180CC3AB0-0x0000000180CC3AC0 0x0000000180CC3EF0-0x0000000180CC3F00
		public Vector2 cascade3Split { get; set; } // 0x0000000181F63DF0-0x0000000181F63E10 0x0000000181F64870-0x0000000181F64880
		public Vector3 cascade4Split { get; set; } // 0x0000000181F63E10-0x0000000181F63E30 0x0000000181F64880-0x0000000181F648A0
		public float cascadeBorder { get; set; } // 0x0000000181F63E30-0x0000000181F63E40 0x0000000181F648A0-0x0000000181F648B0
		public float shadowDepthBias { get; set; } // 0x0000000181F64540-0x0000000181F64550 0x0000000181F64CD0-0x0000000181F64D40
		public float shadowNormalBias { get; set; } // 0x0000000181F64560-0x0000000181F64570 0x0000000181F64D50-0x0000000181F64DC0
		public bool supportsSoftShadows { get; internal set; } // 0x0000000181708F30-0x0000000181708F40 0x0000000181F65050-0x0000000181F65060
		internal SoftShadowQuality softShadowQuality { get; set; } // 0x0000000181F64590-0x0000000181F645A0 0x0000000180CC3E00-0x0000000180CC3E10
		[Obsolete("supportsDynamicBatching is obsolete.", true)]
		public bool supportsDynamicBatching { get; set; } // 0x0000000181F645E0-0x0000000181F645F0 0x0000000181F65020-0x0000000181F65030
		public bool supportsMixedLighting { get; } // 0x0000000181F64620-0x0000000181F64630 
		public bool supportsLightCookies { get; } // 0x0000000181F64600-0x0000000181F64610 
		[Obsolete("This is obsolete, use useRenderingLayers instead. #from(2023.1) #breakingFrom(2023.1)", true)]
		public bool supportsLightLayers { get; } // 0x0000000181F64610-0x0000000181F64620 
		public bool useRenderingLayers { get; internal set; } // 0x0000000181F64610-0x0000000181F64620 0x0000000181F65060-0x0000000181F65070
		public VolumeFrameworkUpdateMode volumeFrameworkUpdateMode { get; } // 0x0000000181C405B0-0x0000000181C405C0 
		public VolumeProfile volumeProfile { get; set; } // 0x0000000181F64850-0x0000000181F64860 0x00000001813800B0-0x00000001813800D0
		public bool useSRPBatcher { get; set; } // 0x0000000181F64840-0x0000000181F64850 0x0000000181F65070-0x0000000181F65080
		public ColorGradingMode colorGradingMode { get; set; } // 0x0000000181F63E50-0x0000000181F63E60 0x0000000181F648E0-0x0000000181F648F0
		public int colorGradingLutSize { get; set; } // 0x0000000181F63E40-0x0000000181F63E50 0x0000000181F648B0-0x0000000181F648E0
		public bool allowPostProcessAlphaOutput { get; } // 0x0000000181F63DE0-0x0000000181F63DF0 
		public bool useFastSRGBLinearConversion { get; } // 0x0000000181F64830-0x0000000181F64840 
		public bool supportScreenSpaceLensFlare { get; } // 0x0000000181F645D0-0x0000000181F645E0 
		public bool supportDataDrivenLensFlare { get; } // 0x0000000181F645B0-0x0000000181F645C0 
		public bool useAdaptivePerformance { get; set; } // 0x0000000181708F20-0x0000000181708F30 0x0000000181709040-0x0000000181709050
		public bool conservativeEnclosingSphere { get; set; } // 0x0000000181709020-0x0000000181709030 0x0000000181F648F0-0x0000000181F64900
		public int numIterationsEnclosingSphere { get; set; } // 0x0000000181F63F90-0x0000000181F63FA0 0x0000000181F64A10-0x0000000181F64A20
		public override string renderPipelineShaderTag { get; } // 0x0000000181F64010-0x0000000181F64040 
		protected override bool requiresCompatibleRenderPipelineGlobalSettings { get; } // 0x00000001802E7990-0x00000001802E79A0 
		[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(2023.3)")]
		public override string[] renderingLayerMaskNames { get; } // 0x0000000181F64120-0x0000000181F64160 
		[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(2023.3)")]
		public override string[] prefixedRenderingLayerMaskNames { get; } // 0x0000000181F63FA0-0x0000000181F64010 
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2023.1) #breakingFrom(2023.1)", true)]
		public string[] lightLayerMaskNames { get; } // 0x0000000181F63F30-0x0000000181F63F70 
		public GPUResidentDrawerMode gpuResidentDrawerMode { get; set; } // 0x000000018170B040-0x000000018170B050 0x0000000181F64940-0x0000000181F64970
		public bool gpuResidentDrawerEnableOcclusionCullingInCameras { get; set; } // 0x000000018033D280-0x000000018033D290 0x0000000181F64910-0x0000000181F64940
		public float smallMeshScreenPercentage { get; set; } // 0x0000000181F64580-0x0000000181F64590 0x0000000181F64F50-0x0000000181F65000
		public Vector4 shadowSmallMeshScreenPercentages { get; set; } // 0x0000000181F64570-0x0000000181F64580 0x0000000181F64DC0-0x0000000181F64F50
		public bool supportProbeVolume { get; } // 0x0000000181F645C0-0x0000000181F645D0 
		public ProbeVolumeSHBands maxSHBands { get; } // 0x0000000181F63F70-0x0000000181F63F90 
		[Obsolete("This property is no longer necessary. #from(2023.3)")]
		public ProbeVolumeSceneData probeVolumeSceneData { get; } // 0x00000001802E7860-0x00000001802E7870 
		public bool isStpUsed { get; } // 0x0000000181F63F20-0x0000000181F63F30 
		[Obsolete("Use GraphicsSettings.GetRenderPipelineSettings<ShaderStrippingSetting>().shaderVariantLogLevel instead. #from(2022.2)")]
		public ShaderVariantLogLevel shaderVariantLogLevel { get; set; } // 0x0000000181F64450-0x0000000181F644B0 0x0000000181F64AD0-0x0000000181F64B40
		[Obsolete("This is obsolete, please use shadowCascadeCount instead. #from(2021.1) #breakingFrom(2023.1)", true)]
		public ShadowCascadesOption shadowCascadeOption { get; set; } // 0x0000000181F644B0-0x0000000181F64540 0x0000000181F64C30-0x0000000181F64CD0
		[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)")]
		public TextureResources textures { get; } // 0x0000000181F647B0-0x0000000181F64830 
		[Obsolete("This property is not used. #from(6000.3)", false)]
		public IntermediateTextureMode intermediateTextureMode { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
	
		// Nested types
		private static class Strings // TypeDefIndex: 9313
		{
			// Fields
			public static readonly string nullRenderer; // 0x00
			public static readonly string notURPRenderer; // 0x08
			public static readonly string renderingModeIncompatible; // 0x10
	
			// Constructors
			static Strings(); // 0x0000000181F602D0-0x0000000181F603C0
		}
	
		[Serializable]
		[Obsolete("Moved to UniversalRenderPipelineRuntimeTextures on GraphicsSettings. #from(2023.3)")]
		[ReloadGroup]
		public sealed class TextureResources // TypeDefIndex: 9314
		{
			// Fields
			[Reload("Textures/BlueNoise64/L/LDR_LLL1_0.png", ReloadAttribute.Package.Root)]
			public Texture2D blueNoise64LTex; // 0x10
			[Reload("Textures/BayerMatrix.png", ReloadAttribute.Package.Root)]
			public Texture2D bayerMatrixTex; // 0x18
	
			// Constructors
			public TextureResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool NeedsReload(); // 0x0000000181F60A50-0x0000000181F60AD0
		}
	
		// Constructors
		public UniversalRenderPipelineAsset(); // 0x0000000181F63900-0x0000000181F63B90
		static UniversalRenderPipelineAsset(); // 0x0000000181F636D0-0x0000000181F63900
	
		// Methods
		private Material GetMaterial(DefaultMaterialType materialType); // 0x00000001802E7860-0x00000001802E7870
		internal bool IsAtLastVersion(); // 0x0000000181F62D70-0x0000000181F62D80
		public ScriptableRendererData LoadBuiltinRendererData(RendererType type = RendererType.UniversalRenderer /* Metadata: 0x0069E949 */); // 0x0000000181F62F60-0x0000000181F62FB0
		protected override void EnsureGlobalSettings(); // 0x00000001802E5CB0-0x00000001802E5CC0
		protected override RenderPipeline CreatePipeline(); // 0x0000000181F624D0-0x0000000181F62680
		internal void DestroyRenderers(); // 0x0000000181F62940-0x0000000181F629F0
		private void DestroyRenderer(ref ScriptableRenderer renderer); // 0x0000000181F62900-0x0000000181F62940
		protected override void OnDisable(); // 0x0000000181F63250-0x0000000181F63270
		private void CreateRenderers(); // 0x0000000181F62680-0x0000000181F62900
		public ScriptableRenderer GetRenderer(int index); // 0x0000000181F62A80-0x0000000181F62D70
		internal int GetAdditionalLightsShadowResolution(int additionalLightsShadowResolutionTier); // 0x0000000181F629F0-0x0000000181F62A80
		internal bool ShouldUseReflectionProbeBlending(); // 0x0000000181F632A0-0x0000000181F632C0
		internal bool ShouldUseReflectionProbeAtlasBlending(RenderingMode renderingMode); // 0x0000000181F63270-0x0000000181F632A0
		public bool IsGPUResidentDrawerSupportedBySRP(out string message, out LogType severity); // 0x0000000181F62D80-0x0000000181F62F60
		public void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnAfterDeserialize(); // 0x0000000181F62FB0-0x0000000181F63250
		private float ValidateShadowBias(float value); // 0x0000000181F63670-0x0000000181F636D0
		private int ValidatePerObjectLights(int value); // 0x0000000181F633C0-0x0000000181F63450
		private float ValidateRenderScale(float value); // 0x0000000181F63450-0x0000000181F634C0
		internal bool ValidateRendererDataList(bool partial = false /* Metadata: 0x0069E94A */); // 0x0000000181F634C0-0x0000000181F635D0
		internal bool ValidateRendererData(int index); // 0x0000000181F635D0-0x0000000181F63670
	}
}
