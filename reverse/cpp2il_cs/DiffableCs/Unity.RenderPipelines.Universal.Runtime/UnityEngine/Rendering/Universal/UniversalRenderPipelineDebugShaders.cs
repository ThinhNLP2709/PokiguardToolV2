namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: Debug Shaders", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class UniversalRenderPipelineDebugShaders : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[ResourcePath("Shaders/Debug/DebugReplacement.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_DebugReplacementPS; //Field offset: 0x10
	[ResourcePath("Shaders/Debug/HDRDebugView.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_HdrDebugViewPS; //Field offset: 0x18
	[ResourcePath("Shaders/Debug/ProbeVolumeSamplingDebugPositionNormal.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_ProbeVolumeSamplingDebugComputeShader; //Field offset: 0x20

	public Shader debugReplacementPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader hdrDebugViewPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader probeVolumeSamplingDebugComputeShader
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	public override int version
	{
		 get { } //Length: 3
	}

	public UniversalRenderPipelineDebugShaders() { }

	public Shader get_debugReplacementPS() { }

	public Shader get_hdrDebugViewPS() { }

	public ComputeShader get_probeVolumeSamplingDebugComputeShader() { }

	public override int get_version() { }

	public void set_debugReplacementPS(Shader value) { }

	public void set_hdrDebugViewPS(Shader value) { }

	public void set_probeVolumeSamplingDebugComputeShader(ComputeShader value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

