namespace UnityEngine.Rendering;

internal class GPUResidentBatcher : IDisposable
{
	private RenderersBatchersContext m_BatchersContext; //Field offset: 0x10
	private GPUDrivenProcessor m_GPUDrivenProcessor; //Field offset: 0x18
	private GPUDrivenRendererDataCallback m_UpdateRendererDataCallback; //Field offset: 0x20
	private InstanceCullingBatcher m_InstanceCullingBatcher; //Field offset: 0x28
	private ParallelBitArray m_ProcessedThisFrameTreeBits; //Field offset: 0x30

	internal RenderersBatchersContext batchersContext
	{
		internal get { } //Length: 5
	}

	internal InstanceCullingBatcher instanceCullingBatcher
	{
		internal get { } //Length: 5
	}

	internal OcclusionCullingCommon occlusionCullingCommon
	{
		internal get { } //Length: 30
	}

	public GPUResidentBatcher(RenderersBatchersContext batcherContext, InstanceCullingBatcherDesc instanceCullerBatcherDesc, GPUDrivenProcessor gpuDrivenProcessor) { }

	public void DestroyInstances(NativeArray<InstanceHandle> instances) { }

	public void DestroyMaterials(NativeArray<Int32> destroyedMaterials) { }

	public void DestroyMeshes(NativeArray<Int32> destroyedMeshes) { }

	public override void Dispose() { }

	internal void FreeRendererGroupInstances(NativeArray<Int32> rendererGroupIDs) { }

	internal RenderersBatchersContext get_batchersContext() { }

	internal InstanceCullingBatcher get_instanceCullingBatcher() { }

	internal OcclusionCullingCommon get_occlusionCullingCommon() { }

	public void InstanceOcclusionTest(RenderGraph renderGraph, in OcclusionCullingSettings settings, ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests) { }

	public void OnBeginCameraRendering(Camera camera) { }

	public void OnBeginContextRendering() { }

	public void OnEndCameraRendering(Camera camera) { }

	public void OnEndContextRendering() { }

	private void OnFinishedCulling(IntPtr customCullingResult) { }

	public void OnSetupAmbientProbe() { }

	public void PostCullBeginCameraRendering(RenderRequestBatcherContext context) { }

	private void ProcessTrees() { }

	public void UpdateFrame() { }

	public void UpdateInstanceOccluders(RenderGraph renderGraph, in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates) { }

	private void UpdateRendererData(in GPUDrivenRendererGroupData rendererData, IList<Mesh> meshes, IList<Material> materials) { }

	public void UpdateRenderers(NativeArray<Int32> renderersID) { }

	private void UpdateSpeedTreeWindAndUploadWindParamsToGPU(NativeArray<Int32> treeRendererIDs, NativeArray<InstanceHandle> treeInstances, bool history) { }

}

