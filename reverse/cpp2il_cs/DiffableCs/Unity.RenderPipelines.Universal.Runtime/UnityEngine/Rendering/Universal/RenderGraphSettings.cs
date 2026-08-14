namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "Render Graph", Order = 50)]
[ElementInfo(Order = -10)]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class RenderGraphSettings : IRenderPipelineGraphicsSettings
{
	public enum Version
	{
		Initial = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x10
	[RecreatePipelineOnChange]
	[SerializeField]
	[Tooltip("When enabled, URP does not use the Render Graph API to construct and execute the frame. Use this option only for compatibility purposes.")]
	private bool m_EnableRenderCompatibilityMode; //Field offset: 0x14

	public bool enableRenderCompatibilityMode
	{
		 get { } //Length: 147
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

	public RenderGraphSettings() { }

	public bool get_enableRenderCompatibilityMode() { }

	public override int get_version() { }

	public void set_enableRenderCompatibilityMode(bool value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

