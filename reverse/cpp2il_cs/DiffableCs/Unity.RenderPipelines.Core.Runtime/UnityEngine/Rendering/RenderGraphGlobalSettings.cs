namespace UnityEngine.Rendering;

[CategoryInfo(Name = "Render Graph", Order = 50)]
[ElementInfo(Order = 0)]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public class RenderGraphGlobalSettings : IRenderPipelineGraphicsSettings
{
	private enum Version
	{
		Initial = 0,
		Count = 1,
		Last = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_version; //Field offset: 0x10
	[RecreatePipelineOnChange]
	[SerializeField]
	[Tooltip("Enable caching of render graph compilation from one frame to another.")]
	private bool m_EnableCompilationCaching; //Field offset: 0x14
	[RecreatePipelineOnChange]
	[SerializeField]
	[Tooltip("Enable validity checks of render graph in Editor and Development mode. Always disabled in Release build.")]
	private bool m_EnableValidityChecks; //Field offset: 0x15

	public bool enableCompilationCaching
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public bool enableValidityChecks
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.version
	{
		private get { } //Length: 4
	}

	public RenderGraphGlobalSettings() { }

	public bool get_enableCompilationCaching() { }

	public bool get_enableValidityChecks() { }

	public void set_enableCompilationCaching(bool value) { }

	public void set_enableValidityChecks(bool value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_version() { }

}

