namespace UnityEngine.Rendering;

internal struct InstanceCuller : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<InstanceOcclusionTestPassData, ComputeGraphContext> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <InstanceOcclusionTest>b__26_0(InstanceOcclusionTestPassData data, ComputeGraphContext context) { }

	}

	private class InstanceOcclusionTestPassData
	{
		public OcclusionCullingSettings settings; //Field offset: 0x10
		public InstanceOcclusionTestSubviewSettings subviewSettings; //Field offset: 0x1C
		public OccluderHandles occluderHandles; //Field offset: 0x30
		public IndirectBufferContextHandles bufferHandles; //Field offset: 0x4C

		public InstanceOcclusionTestPassData() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct SetupCullingJobInput : IJob
	{
		public float lodBias; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		public BatchCullingContext* context; //Field offset: 0x8
		[NativeDisableUnsafePtrRestriction]
		public ReceiverPlanes* receiverPlanes; //Field offset: 0x10
		[NativeDisableUnsafePtrRestriction]
		public ReceiverSphereCuller* receiverSphereCuller; //Field offset: 0x18
		[NativeDisableUnsafePtrRestriction]
		public FrustumPlaneCuller* frustumPlaneCuller; //Field offset: 0x20
		[NativeDisableUnsafePtrRestriction]
		public Single* screenRelativeMetric; //Field offset: 0x28

		public override void Execute() { }

	}

	private static class ShaderIDs
	{
		public static readonly int InstanceOcclusionCullerShaderVariables; //Field offset: 0x0
		public static readonly int _DrawInfo; //Field offset: 0x4
		public static readonly int _InstanceInfo; //Field offset: 0x8
		public static readonly int _DrawArgs; //Field offset: 0xC
		public static readonly int _InstanceIndices; //Field offset: 0x10
		public static readonly int _InstanceDataBuffer; //Field offset: 0x14
		public static readonly int _OccluderDepthPyramid; //Field offset: 0x18
		public static readonly int _OcclusionDebugCounters; //Field offset: 0x1C

		private static ShaderIDs() { }

	}

	private ParallelBitArray m_CompactedVisibilityMasks; //Field offset: 0x0
	private JobHandle m_CompactedVisibilityMasksJobsHandle; //Field offset: 0x20
	private IndirectBufferContextStorage m_IndirectStorage; //Field offset: 0x30
	private OcclusionTestComputeShader m_OcclusionTestShader; //Field offset: 0xB0
	private int m_ResetDrawArgsKernel; //Field offset: 0xD0
	private int m_CopyInstancesKernel; //Field offset: 0xD4
	private int m_CullInstancesKernel; //Field offset: 0xD8
	private DebugRendererBatcherStats m_DebugStats; //Field offset: 0xE0
	private InstanceCullerSplitDebugArray m_SplitDebugArray; //Field offset: 0xE8
	private InstanceOcclusionEventDebugArray m_OcclusionEventDebugArray; //Field offset: 0x108
	private ProfilingSampler m_ProfilingSampleInstanceOcclusionTest; //Field offset: 0x160
	private NativeArray<InstanceOcclusionCullerShaderVariables> m_ShaderVariables; //Field offset: 0x168
	private ComputeBuffer m_ConstantBuffer; //Field offset: 0x178
	private CommandBuffer m_CommandBuffer; //Field offset: 0x180

	private void AddOcclusionCullingDispatch(ComputeCommandBuffer cmd, in OcclusionCullingSettings settings, in InstanceOcclusionTestSubviewSettings subviewSettings, in IndirectBufferContextHandles bufferHandles, in OccluderHandles occluderHandles, RenderersBatchersContext batchersContext) { }

	private int ComputeWorstCaseDrawCommandCount(in BatchCullingContext cc, BinningConfig binningConfig, CPUDrawInstanceData drawInstanceData, int crossFadedRendererCount) { }

	private JobHandle CreateCompactedVisibilityMaskJob(in ReadOnly instanceData, NativeArray<Byte> rendererVisibilityMasks, JobHandle cullingJobHandle) { }

	public JobHandle CreateCullJobTree(in BatchCullingContext cc, BatchCullingOutput cullingOutput, in ReadOnly instanceData, in ReadOnly sharedInstanceData, in ReadOnly instanceDataBuffer, NativeList<LODGroupCullingData> lodGroupCullingData, CPUDrawInstanceData drawInstanceData, NativeParallelHashMap<UInt32, BatchID> batchIDs, int crossFadedRendererCount, float smallMeshScreenPercentage, OcclusionCullingCommon occlusionCullingCommon) { }

	private JobHandle CreateFrustumCullingJob(in BatchCullingContext cc, in ReadOnly instanceData, in ReadOnly sharedInstanceData, NativeList<LODGroupCullingData> lodGroupCullingData, in BinningConfig binningConfig, float smallMeshScreenPercentage, OcclusionCullingCommon occlusionCullingCommon, NativeArray<Byte> rendererVisibilityMasks, NativeArray<Byte> rendererCrossFadeValues) { }

	public override void Dispose() { }

	private void DisposeCompactVisibilityMasks() { }

	private void DisposeSceneViewHiddenBits() { }

	internal void EnsureValidOcclusionTestResults(int viewInstanceID) { }

	private void FlushDebugCounters() { }

	public ParallelBitArray GetCompactedVisibilityMasks(bool syncCullingJobs) { }

	internal void Init(GPUResidentDrawerResources resources, DebugRendererBatcherStats debugStats = null) { }

	public void InstanceOccludersUpdated(int viewInstanceID, int subviewMask, RenderersBatchersContext batchersContext) { }

	public void InstanceOcclusionTest(RenderGraph renderGraph, in OcclusionCullingSettings settings, ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests, RenderersBatchersContext batchersContext) { }

	public void OnBeginCameraRendering(Camera camera) { }

	private void OnBeginSceneViewCameraRendering() { }

	public void OnEndCameraRendering(Camera camera) { }

	private void OnEndSceneViewCameraRendering() { }

	public void UpdateFrame() { }

}

