namespace UnityEngine.Rendering.RenderGraphModule.Util;

[Category("Resources/Render Graph Helper Function Resources")]
[HideInInspector]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
internal class RenderGraphUtilsResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	internal enum Version
	{
		Initial = 0,
		Count = 1,
		Latest = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x10
	[ResourcePath("Shaders/CoreCopy.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	internal Shader m_CoreCopyPS; //Field offset: 0x18

	public Shader coreCopyPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.version
	{
		private get { } //Length: 4
	}

	public RenderGraphUtilsResources() { }

	public Shader get_coreCopyPS() { }

	public void set_coreCopyPS(Shader value) { }

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_version() { }

}

