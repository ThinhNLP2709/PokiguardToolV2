namespace UnityEngine.Rendering;

[CategoryInfo(Name = "R: Adaptive Probe Volumes", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
internal class ProbeVolumeRuntimeResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[Header("Runtime")]
	[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeBlendStates.compute", SearchType::ProjectPath (0))]
	public ComputeShader probeVolumeBlendStatesCS; //Field offset: 0x18
	[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeUploadData.compute", SearchType::ProjectPath (0))]
	public ComputeShader probeVolumeUploadDataCS; //Field offset: 0x20
	[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeUploadDataL2.compute", SearchType::ProjectPath (0))]
	public ComputeShader probeVolumeUploadDataL2CS; //Field offset: 0x28

	public override int version
	{
		 get { } //Length: 4
	}

	public ProbeVolumeRuntimeResources() { }

	public override int get_version() { }

}

