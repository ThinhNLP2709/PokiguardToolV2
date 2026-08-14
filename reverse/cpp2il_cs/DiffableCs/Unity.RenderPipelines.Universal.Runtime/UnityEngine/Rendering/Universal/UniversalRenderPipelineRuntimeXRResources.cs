namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: Runtime XR", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class UniversalRenderPipelineRuntimeXRResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[ResourcePath("Shaders/XR/XROcclusionMesh.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_xrOcclusionMeshPS; //Field offset: 0x10
	[ResourcePath("Shaders/XR/XRMirrorView.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	public Shader m_xrMirrorViewPS; //Field offset: 0x18
	[ResourcePath("Shaders/XR/XRMotionVector.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	public Shader m_xrMotionVector; //Field offset: 0x20

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	internal bool valid
	{
		internal get { } //Length: 193
	}

	public override int version
	{
		 get { } //Length: 3
	}

	public Shader xrMirrorViewPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader xrMotionVector
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader xrOcclusionMeshPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public UniversalRenderPipelineRuntimeXRResources() { }

	internal bool get_valid() { }

	public override int get_version() { }

	public Shader get_xrMirrorViewPS() { }

	public Shader get_xrMotionVector() { }

	public Shader get_xrOcclusionMeshPS() { }

	public void set_xrMirrorViewPS(Shader value) { }

	public void set_xrMotionVector(Shader value) { }

	public void set_xrOcclusionMeshPS(Shader value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

