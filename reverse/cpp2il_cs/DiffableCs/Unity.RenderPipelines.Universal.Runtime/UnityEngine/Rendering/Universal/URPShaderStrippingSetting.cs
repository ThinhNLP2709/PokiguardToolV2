namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "Additional Shader Stripping Settings", Order = 40)]
[ElementInfo(Order = 10)]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class URPShaderStrippingSetting : IRenderPipelineGraphicsSettings
{
	public enum Version
	{
		Initial = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Controls whether to automatically strip post processing shader variants based on VolumeProfile components. Stripping is done based on VolumeProfiles in project, their usage in scenes is not considered.")]
	private bool m_StripUnusedPostProcessingVariants; //Field offset: 0x14
	[SerializeField]
	[Tooltip("Controls whether to strip variants if the feature is disabled.")]
	private bool m_StripUnusedVariants; //Field offset: 0x15
	[SerializeField]
	[Tooltip("Controls whether Screen Coordinates Override shader variants are automatically stripped.")]
	private bool m_StripScreenCoordOverrideVariants; //Field offset: 0x16

	public bool stripScreenCoordOverrideVariants
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public bool stripUnusedPostProcessingVariants
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public bool stripUnusedVariants
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public override int version
	{
		 get { } //Length: 4
	}

	public URPShaderStrippingSetting() { }

	public bool get_stripScreenCoordOverrideVariants() { }

	public bool get_stripUnusedPostProcessingVariants() { }

	public bool get_stripUnusedVariants() { }

	public override int get_version() { }

	public void set_stripScreenCoordOverrideVariants(bool value) { }

	public void set_stripUnusedPostProcessingVariants(bool value) { }

	public void set_stripUnusedVariants(bool value) { }

}

