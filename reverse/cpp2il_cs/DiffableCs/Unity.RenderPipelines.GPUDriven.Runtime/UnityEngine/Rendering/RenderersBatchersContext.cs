namespace UnityEngine.Rendering;

internal class RenderersBatchersContext : IDisposable
{
	private InstanceDataSystem m_InstanceDataSystem; //Field offset: 0x10
	private GPUResidentDrawerResources m_Resources; //Field offset: 0x18
	private GPUDrivenProcessor m_GPUDrivenProcessor; //Field offset: 0x20
	private LODGroupDataPool m_LODGroupDataPool; //Field offset: 0x28
	internal GPUInstanceDataBuffer m_InstanceDataBuffer; //Field offset: 0x30
	private RenderersParameters m_RenderersParameters; //Field offset: 0x38
	private GPUResources m_UploadResources; //Field offset: 0xA0
	private GPUResources m_GrowerResources; //Field offset: 0xE0
	internal CommandBuffer m_CmdBuffer; //Field offset: 0xF0
	private SphericalHarmonicsL2 m_CachedAmbientProbe; //Field offset: 0xF8
	private float m_SmallMeshScreenPercentage; //Field offset: 0x164
	private GPUDrivenLODGroupDataCallback m_UpdateLODGroupCallback; //Field offset: 0x168
	private GPUDrivenLODGroupDataCallback m_TransformLODGroupCallback; //Field offset: 0x170
	private OcclusionCullingCommon m_OcclusionCullingCommon; //Field offset: 0x178
	private DebugRendererBatcherStats m_DebugStats; //Field offset: 0x180

	public int activeLodGroupCount
	{
		 get { } //Length: 86
	}

	public NativeArray<InstanceHandle> aliveInstances
	{
		 get { } //Length: 51
	}

	public SphericalHarmonicsL2 cachedAmbientProbe
	{
		 get { } //Length: 91
	}

	public int crossfadedRendererCount
	{
		 get { } //Length: 26
	}

	internal DebugRendererBatcherStats debugStats
	{
		internal get { } //Length: 8
	}

	public ReadOnly<GPUInstanceComponentDesc> defaultDescriptions
	{
		 get { } //Length: 101
	}

	public NativeArray<MetadataValue> defaultMetadata
	{
		 get { } //Length: 36
	}

	public GraphicsBuffer gpuInstanceDataBuffer
	{
		 get { } //Length: 27
	}

	public bool hasBoundingSpheres
	{
		 get { } //Length: 30
	}

	public ReadOnly instanceData
	{
		 get { } //Length: 174
	}

	public ReadOnly instanceDataBuffer
	{
		 get { } //Length: 51
	}

	public int instanceDataBufferLayoutVersion
	{
		 get { } //Length: 26
	}

	public int instanceDataBufferVersion
	{
		 get { } //Length: 26
	}

	public NativeList<LODGroupCullingData> lodGroupCullingData
	{
		 get { } //Length: 27
	}

	internal OcclusionCullingCommon occlusionCullingCommon
	{
		internal get { } //Length: 8
	}

	public RenderersParameters renderersParameters
	{
		 get { } //Length: 67
	}

	public GPUResidentDrawerResources resources
	{
		 get { } //Length: 5
	}

	public ReadOnly sharedInstanceData
	{
		 get { } //Length: 141
	}

	public float smallMeshScreenPercentage
	{
		 get { } //Length: 9
	}

	public RenderersBatchersContext(in RenderersBatchersContextDesc desc, GPUDrivenProcessor gpuDrivenProcessor, GPUResidentDrawerResources resources) { }

	public void ChangeInstanceBufferVersion() { }

	public GPUInstanceDataBufferUploader CreateDataBufferUploader(int capacity, InstanceType instanceType) { }

	public void DestroyLODGroups(NativeArray<Int32> destroyed) { }

	public override void Dispose() { }

	private void EnsureInstanceBufferCapacity() { }

	public void FreeInstances(NativeArray<InstanceHandle> instances) { }

	public void FreeRendererGroupInstances(NativeArray<Int32> rendererGroupsID) { }

	public int get_activeLodGroupCount() { }

	public NativeArray<InstanceHandle> get_aliveInstances() { }

	public SphericalHarmonicsL2 get_cachedAmbientProbe() { }

	public int get_crossfadedRendererCount() { }

	internal DebugRendererBatcherStats get_debugStats() { }

	public ReadOnly<GPUInstanceComponentDesc> get_defaultDescriptions() { }

	public NativeArray<MetadataValue> get_defaultMetadata() { }

	public GraphicsBuffer get_gpuInstanceDataBuffer() { }

	public bool get_hasBoundingSpheres() { }

	public ReadOnly get_instanceData() { }

	public ReadOnly get_instanceDataBuffer() { }

	public int get_instanceDataBufferLayoutVersion() { }

	public int get_instanceDataBufferVersion() { }

	public NativeList<LODGroupCullingData> get_lodGroupCullingData() { }

	internal OcclusionCullingCommon get_occlusionCullingCommon() { }

	public RenderersParameters get_renderersParameters() { }

	public GPUResidentDrawerResources get_resources() { }

	public ReadOnly get_sharedInstanceData() { }

	public float get_smallMeshScreenPercentage() { }

	public int GetAliveInstancesOfType(InstanceType instanceType) { }

	public GPUInstanceDataBuffer GetInstanceDataBuffer() { }

	public int GetMaxInstancesOfType(InstanceType instanceType) { }

	public InstanceHandle GetRendererInstanceHandle(int rendererID) { }

	public void GetVisibleTreeInstances(in ParallelBitArray compactedVisibilityMasks, in ParallelBitArray processedBits, NativeList<Int32> visibeTreeRendererIDs, NativeList<InstanceHandle> visibeTreeInstances, bool becomeVisibleOnly, out int becomeVisibeTreeInstancesCount) { }

	public void GrowInstanceBuffer(in InstanceNumInfo instanceNumInfo) { }

	public void InitializeInstanceTransforms(NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices, NativeArray<Matrix4x4> prevLocalToWorldMatrices) { }

	public void ReallocateAndGetInstances(in GPUDrivenRendererGroupData rendererData, NativeArray<InstanceHandle> instances) { }

	public JobHandle ScheduleCollectInstancesLODGroupAndMasksJob(NativeArray<InstanceHandle> instances, NativeArray<UInt32> lodGroupAndMasks) { }

	public JobHandle ScheduleQueryMeshInstancesJob(NativeArray<Int32> sortedMeshIDs, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<InstanceHandle> instances) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<Int32> instancesOffset, NativeArray<Int32> instancesCount, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleUpdateInstanceDataJob(NativeArray<InstanceHandle> instances, in GPUDrivenRendererGroupData rendererData) { }

	public void SubmitToGpu(NativeArray<InstanceHandle> instances, ref GPUInstanceDataBufferUploader uploader, bool submitOnlyWrittenParams) { }

	public void SubmitToGpu(NativeArray<GPUInstanceIndex> gpuInstanceIndices, ref GPUInstanceDataBufferUploader uploader, bool submitOnlyWrittenParams) { }

	private void TransformLODGroupData(in GPUDrivenLODGroupData lodGroupData) { }

	public void TransformLODGroups(NativeArray<Int32> lodGroupsID) { }

	public void UpdateAmbientProbeAndGpuBuffer(bool forceUpdate) { }

	public void UpdateFrame() { }

	public void UpdateInstanceMotions() { }

	public void UpdateInstanceTransforms(NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices) { }

	public void UpdateInstanceWindDataHistory(NativeArray<GPUInstanceIndex> gpuInstanceIndices) { }

	private void UpdateLODGroupData(in GPUDrivenLODGroupData lodGroupData) { }

	public void UpdateLODGroups(NativeArray<Int32> changedID) { }

	public void UpdatePerFrameInstanceVisibility(in ParallelBitArray compactedVisibilityMasks) { }

}

