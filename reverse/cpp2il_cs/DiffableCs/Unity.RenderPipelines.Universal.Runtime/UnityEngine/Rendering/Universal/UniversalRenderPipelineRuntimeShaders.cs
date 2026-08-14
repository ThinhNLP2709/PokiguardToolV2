namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: Runtime Shaders", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class UniversalRenderPipelineRuntimeShaders : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[ResourcePath("Shaders/Utils/FallbackError.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_FallbackErrorShader; //Field offset: 0x18
	[ResourcePath("Shaders/Utils/BlitHDROverlay.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	internal Shader m_BlitHDROverlay; //Field offset: 0x20
	[ResourcePath("Shaders/Utils/CoreBlit.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	internal Shader m_CoreBlitPS; //Field offset: 0x28
	[ResourcePath("Shaders/Utils/CoreBlitColorAndDepth.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	internal Shader m_CoreBlitColorAndDepthPS; //Field offset: 0x30
	[ResourcePath("Shaders/Utils/Sampling.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_SamplingPS; //Field offset: 0x38

	public Shader blitHDROverlay
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader coreBlitColorAndDepthPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader coreBlitPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader fallbackErrorShader
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader samplingPS
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
		 get { } //Length: 4
	}

	public UniversalRenderPipelineRuntimeShaders() { }

	public Shader get_blitHDROverlay() { }

	public Shader get_coreBlitColorAndDepthPS() { }

	public Shader get_coreBlitPS() { }

	public Shader get_fallbackErrorShader() { }

	public Shader get_samplingPS() { }

	public override int get_version() { }

	public void set_blitHDROverlay(Shader value) { }

	public void set_coreBlitColorAndDepthPS(Shader value) { }

	public void set_coreBlitPS(Shader value) { }

	public void set_fallbackErrorShader(Shader value) { }

	public void set_samplingPS(Shader value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

