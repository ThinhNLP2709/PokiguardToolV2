namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: Universal Renderer Shaders", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class UniversalRendererResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[ResourcePath("Shaders/Utils/CopyDepth.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_CopyDepthPS; //Field offset: 0x18
	[ResourcePath("Shaders/CameraMotionVectors.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_CameraMotionVector; //Field offset: 0x20
	[ResourcePath("Shaders/Utils/StencilDeferred.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_StencilDeferredPS; //Field offset: 0x28
	[Header("Decal Renderer Feature Specific")]
	[ResourcePath("Runtime/Decal/DBuffer/DBufferClear.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_DBufferClear; //Field offset: 0x30

	public Shader cameraMotionVector
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader copyDepthPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader decalDBufferClear
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader stencilDeferredPS
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

	public UniversalRendererResources() { }

	public Shader get_cameraMotionVector() { }

	public Shader get_copyDepthPS() { }

	public Shader get_decalDBufferClear() { }

	public Shader get_stencilDeferredPS() { }

	public override int get_version() { }

	public void set_cameraMotionVector(Shader value) { }

	public void set_copyDepthPS(Shader value) { }

	public void set_decalDBufferClear(Shader value) { }

	public void set_stencilDeferredPS(Shader value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

