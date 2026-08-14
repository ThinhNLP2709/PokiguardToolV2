namespace UnityEngine.Rendering;

[CategoryInfo(Name = "R: GPU Resident Drawers", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
internal class GPUResidentDrawerResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
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
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceDataBufferCopyKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_InstanceDataBufferCopyKernels; //Field offset: 0x18
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceDataBufferUploadKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_InstanceDataBufferUploadKernels; //Field offset: 0x20
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceTransformUpdateKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_TransformUpdaterKernels; //Field offset: 0x28
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceWindDataUpdateKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	public ComputeShader m_WindDataUpdaterKernels; //Field offset: 0x30
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/OccluderDepthPyramidKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_OccluderDepthPyramidKernels; //Field offset: 0x38
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceOcclusionCullingKernels.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_InstanceOcclusionCullingKernels; //Field offset: 0x40
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/OcclusionCullingDebug.compute", SearchType::ProjectPath (0))]
	[SerializeField]
	private ComputeShader m_OcclusionCullingDebugKernels; //Field offset: 0x48
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/DebugOcclusionTest.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_DebugOcclusionTestPS; //Field offset: 0x50
	[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/DebugOccluder.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_DebugOccluderPS; //Field offset: 0x58

	public Shader debugOccluderPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Shader debugOcclusionTestPS
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader instanceDataBufferCopyKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader instanceDataBufferUploadKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader instanceOcclusionCullingKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader occluderDepthPyramidKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader occlusionCullingDebugKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public ComputeShader transformUpdaterKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.version
	{
		private get { } //Length: 4
	}

	public ComputeShader windDataUpdaterKernels
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public GPUResidentDrawerResources() { }

	public Shader get_debugOccluderPS() { }

	public Shader get_debugOcclusionTestPS() { }

	public ComputeShader get_instanceDataBufferCopyKernels() { }

	public ComputeShader get_instanceDataBufferUploadKernels() { }

	public ComputeShader get_instanceOcclusionCullingKernels() { }

	public ComputeShader get_occluderDepthPyramidKernels() { }

	public ComputeShader get_occlusionCullingDebugKernels() { }

	public ComputeShader get_transformUpdaterKernels() { }

	public ComputeShader get_windDataUpdaterKernels() { }

	public void set_debugOccluderPS(Shader value) { }

	public void set_debugOcclusionTestPS(Shader value) { }

	public void set_instanceDataBufferCopyKernels(ComputeShader value) { }

	public void set_instanceDataBufferUploadKernels(ComputeShader value) { }

	public void set_instanceOcclusionCullingKernels(ComputeShader value) { }

	public void set_occluderDepthPyramidKernels(ComputeShader value) { }

	public void set_occlusionCullingDebugKernels(ComputeShader value) { }

	public void set_transformUpdaterKernels(ComputeShader value) { }

	public void set_windDataUpdaterKernels(ComputeShader value) { }

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_version() { }

}

