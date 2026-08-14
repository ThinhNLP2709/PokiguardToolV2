namespace UnityEngine.Rendering;

internal class InstanceCullingBatcher : IDisposable
{
	private RenderersBatchersContext m_BatchersContext; //Field offset: 0x10
	private CPUDrawInstanceData m_DrawInstanceData; //Field offset: 0x18
	private BatchRendererGroup m_BRG; //Field offset: 0x20
	private NativeParallelHashMap<UInt32, BatchID> m_GlobalBatchIDs; //Field offset: 0x28
	private InstanceCuller m_Culler; //Field offset: 0x38
	private NativeParallelHashMap<Int32, BatchMaterialID> m_BatchMaterialHash; //Field offset: 0x1C0
	private NativeParallelHashMap<Int32, BatchMeshID> m_BatchMeshHash; //Field offset: 0x1D0
	private int m_CachedInstanceDataBufferLayoutVersion; //Field offset: 0x1E0
	private OnCullingCompleteCallback m_OnCompleteCallback; //Field offset: 0x1E8

	public NativeParallelHashMap<Int32, BatchMaterialID> batchMaterialHash
	{
		 get { } //Length: 14
	}

	internal InstanceCuller culler
	{
		internal get { } //Length: 5
	}

	public InstanceCullingBatcher(RenderersBatchersContext batcherContext, InstanceCullingBatcherDesc desc, OnFinishedCulling onFinishedCulling) { }

	public void BuildBatch(NativeArray<InstanceHandle> instances, NativeArray<Int32> usedMaterialIDs, NativeArray<Int32> usedMeshIDs, in GPUDrivenRendererGroupData rendererData) { }

	public void DestroyInstances(NativeArray<InstanceHandle> instances) { }

	public void DestroyMaterials(NativeArray<Int32> destroyedMaterials) { }

	public void DestroyMeshes(NativeArray<Int32> destroyedMeshes) { }

	public override void Dispose() { }

	public NativeParallelHashMap<Int32, BatchMaterialID> get_batchMaterialHash() { }

	internal InstanceCuller get_culler() { }

	private BatchID GetBatchID(InstanceComponentGroup componentsOverriden) { }

	public ParallelBitArray GetCompactedVisibilityMasks(bool syncCullingJobs) { }

	public CPUDrawInstanceData GetDrawInstanceData() { }

	public void InstanceOccludersUpdated(int viewInstanceID, int subviewMask) { }

	public void OnBeginCameraRendering(Camera camera) { }

	public void OnEndCameraRendering(Camera camera) { }

	public void OnEndContextRendering() { }

	public void OnFinishedCulling(IntPtr customCullingResult) { }

	public JobHandle OnPerformCulling(BatchRendererGroup rendererGroup, BatchCullingContext cc, BatchCullingOutput cullingOutput, IntPtr userContext) { }

	public void PostCullBeginCameraRendering(RenderRequestBatcherContext context) { }

	private void RegisterBatchMaterials(in NativeArray<Int32>& usedMaterialIDs) { }

	private void RegisterBatchMeshes(NativeArray<Int32> meshIDs) { }

	public void UpdateFrame() { }

	private void UpdateInstanceDataBufferLayoutVersion() { }

}

