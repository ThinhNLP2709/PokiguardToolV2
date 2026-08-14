namespace UnityEngine.Rendering;

[Obsolete("Use GraphicsSettings.GetRenderPipelineSettings<ShaderStrippingSetting>(). #from(23.3)")]
public interface IShaderVariantSettings
{

	public bool exportShaderVariants
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public ShaderVariantLogLevel shaderVariantLogLevel
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool stripDebugVariants
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public bool get_exportShaderVariants() { }

	public ShaderVariantLogLevel get_shaderVariantLogLevel() { }

	public bool get_stripDebugVariants() { }

	public void set_exportShaderVariants(bool value) { }

	public void set_shaderVariantLogLevel(ShaderVariantLogLevel value) { }

	public void set_stripDebugVariants(bool value) { }

}

