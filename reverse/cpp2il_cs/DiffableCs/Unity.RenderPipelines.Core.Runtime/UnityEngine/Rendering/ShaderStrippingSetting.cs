namespace UnityEngine.Rendering;

[CategoryInfo(Name = "Additional Shader Stripping Settings", Order = 40)]
[ElementInfo(Order = 0)]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public class ShaderStrippingSetting : IRenderPipelineGraphicsSettings
{
	public enum Version
	{
		Initial = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Controls whether to output shader variant information to a file.")]
	private bool m_ExportShaderVariants; //Field offset: 0x14
	[SerializeField]
	[Tooltip("Controls the level of logging of shader variant information outputted during the build process. Information appears in the Unity Console when the build finishes.")]
	private ShaderVariantLogLevel m_ShaderVariantLogLevel; //Field offset: 0x18
	[SerializeField]
	[Tooltip("When enabled, all debug display shader variants are removed when you build for the Unity Player. This decreases build time, but prevents the use of most Rendering Debugger features in Player builds.")]
	private bool m_StripRuntimeDebugShaders; //Field offset: 0x1C

	public bool exportShaderVariants
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public ShaderVariantLogLevel shaderVariantLogLevel
	{
		 get { } //Length: 4
		 set { } //Length: 100
	}

	public bool stripRuntimeDebugShaders
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	public override int version
	{
		 get { } //Length: 4
	}

	public ShaderStrippingSetting() { }

	public bool get_exportShaderVariants() { }

	public ShaderVariantLogLevel get_shaderVariantLogLevel() { }

	public bool get_stripRuntimeDebugShaders() { }

	public override int get_version() { }

	public void set_exportShaderVariants(bool value) { }

	public void set_shaderVariantLogLevel(ShaderVariantLogLevel value) { }

	public void set_stripRuntimeDebugShaders(bool value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

