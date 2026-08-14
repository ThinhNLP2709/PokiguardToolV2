namespace UnityEngine.Rendering.Universal;

[DisplayInfo(name = "URP Global Settings Asset", order = 40002)]
[DisplayName("URP")]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
internal class UniversalRenderPipelineGlobalSettings : RenderPipelineGlobalSettings<UniversalRenderPipelineGlobalSettings, UniversalRenderPipeline>
{
	internal const int k_LastVersion = 8; //Field offset: 0x0
	public const string defaultAssetName = "UniversalRenderPipelineGlobalSettings"; //Field offset: 0x0
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal ShaderStrippingSetting m_ShaderStrippingSetting; //Field offset: 0x20
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal URPShaderStrippingSetting m_URPShaderStrippingSetting; //Field offset: 0x28
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal ShaderVariantLogLevel m_ShaderVariantLogLevel; //Field offset: 0x30
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_ExportShaderVariants; //Field offset: 0x34
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_StripDebugVariants; //Field offset: 0x35
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_StripUnusedPostProcessingVariants; //Field offset: 0x36
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_StripUnusedVariants; //Field offset: 0x37
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_StripScreenCoordOverrideVariants; //Field offset: 0x38
	[Obsolete("Please use stripRuntimeDebugShaders instead. #from(23.1)", False)]
	public bool supportRuntimeDebugDisplay; //Field offset: 0x39
	[Obsolete("Keep for migration. #from(23.2)")]
	[SerializeField]
	internal bool m_EnableRenderGraph; //Field offset: 0x3A
	[SerializeField]
	private RenderPipelineGraphicsSettingsContainer m_Settings; //Field offset: 0x40
	[FormerlySerializedAs("k_AssetVersion")]
	[SerializeField]
	internal int m_AssetVersion; //Field offset: 0x48
	[FormerlySerializedAs("m_DefaultVolumeProfile")]
	[Obsolete("Kept For Migration. #from(2023.3)")]
	[SerializeField]
	internal VolumeProfile m_ObsoleteDefaultVolumeProfile; //Field offset: 0x50
	[SerializeField]
	internal String[] m_RenderingLayerNames; //Field offset: 0x58
	[SerializeField]
	private uint m_ValidRenderingLayers; //Field offset: 0x60
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName0; //Field offset: 0x68
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName1; //Field offset: 0x70
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName2; //Field offset: 0x78
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName3; //Field offset: 0x80
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName4; //Field offset: 0x88
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName5; //Field offset: 0x90
	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public string lightLayerName6; //Field offset: 0x98
	[Obsolete("This is obsolete, please use renderingLayerNames instead.", False)]
	public string lightLayerName7; //Field offset: 0xA0
	[SerializeField]
	internal ProbeVolumeSceneData apvScenesData; //Field offset: 0xA8

	[Obsolete("This is obsolete, please use renderingLayerMaskNames instead.", False)]
	public String[] lightLayerNames
	{
		 get { } //Length: 50
	}

	[Obsolete("This is obsolete, please use prefixedRenderingLayerMaskNames instead.", True)]
	public String[] prefixedLightLayerNames
	{
		 get { } //Length: 50
	}

	protected virtual List<IRenderPipelineGraphicsSettings> settingsList
	{
		 get { } //Length: 29
	}

	[Obsolete("No longer used as Shader Prefiltering automatically strips out unused LOD Crossfade variants. Please use the LOD Crossfade setting in the URP Asset to disable the feature if not used. #from(2023.1)", False)]
	public bool stripUnusedLODCrossFadeVariants
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public UniversalRenderPipelineGlobalSettings() { }

	public String[] get_lightLayerNames() { }

	public String[] get_prefixedLightLayerNames() { }

	protected virtual List<IRenderPipelineGraphicsSettings> get_settingsList() { }

	public bool get_stripUnusedLODCrossFadeVariants() { }

	internal ProbeVolumeSceneData GetOrCreateAPVSceneData() { }

	internal static VolumeProfile GetOrCreateDefaultVolumeProfile(VolumeProfile defaultVolumeProfile) { }

	internal bool IsAtLastVersion() { }

	public virtual void Reset() { }

	internal void ResetRenderingLayerNames() { }

	public void set_stripUnusedLODCrossFadeVariants(bool value) { }

}

