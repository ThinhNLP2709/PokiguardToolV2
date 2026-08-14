namespace UnityEngine.Rendering;

[CategoryInfo(Name = "R: Adaptive Probe Volumes", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
internal class ProbeVolumeBakingResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[Header("Baking")]
	[ResourcePath("Editor/Lighting/ProbeVolume/ProbeVolumeCellDilation.compute", SearchType::ProjectPath (0))]
	public ComputeShader dilationShader; //Field offset: 0x18
	[ResourcePath("Editor/Lighting/ProbeVolume/ProbeVolumeSubdivide.compute", SearchType::ProjectPath (0))]
	public ComputeShader subdivideSceneCS; //Field offset: 0x20
	[ResourcePath("Editor/Lighting/ProbeVolume/VoxelizeScene.shader", SearchType::ProjectPath (0))]
	public Shader voxelizeSceneShader; //Field offset: 0x28
	[ResourcePath("Editor/Lighting/ProbeVolume/VirtualOffset/TraceVirtualOffset.urtshader", SearchType::ProjectPath (0))]
	public ComputeShader traceVirtualOffsetCS; //Field offset: 0x30
	[ResourcePath("Editor/Lighting/ProbeVolume/VirtualOffset/TraceVirtualOffset.urtshader", SearchType::ProjectPath (0))]
	public RayTracingShader traceVirtualOffsetRT; //Field offset: 0x38
	[ResourcePath("Editor/Lighting/ProbeVolume/DynamicGI/DynamicGISkyOcclusion.urtshader", SearchType::ProjectPath (0))]
	public ComputeShader skyOcclusionCS; //Field offset: 0x40
	[ResourcePath("Editor/Lighting/ProbeVolume/DynamicGI/DynamicGISkyOcclusion.urtshader", SearchType::ProjectPath (0))]
	public RayTracingShader skyOcclusionRT; //Field offset: 0x48
	[ResourcePath("Editor/Lighting/ProbeVolume/RenderingLayerMask/TraceRenderingLayerMask.urtshader", SearchType::ProjectPath (0))]
	public ComputeShader renderingLayerCS; //Field offset: 0x50
	[ResourcePath("Editor/Lighting/ProbeVolume/RenderingLayerMask/TraceRenderingLayerMask.urtshader", SearchType::ProjectPath (0))]
	public RayTracingShader renderingLayerRT; //Field offset: 0x58

	public override int version
	{
		 get { } //Length: 4
	}

	public ProbeVolumeBakingResources() { }

	public override int get_version() { }

}

