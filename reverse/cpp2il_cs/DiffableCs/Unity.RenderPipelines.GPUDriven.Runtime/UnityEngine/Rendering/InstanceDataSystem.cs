namespace UnityEngine.Rendering;

internal class InstanceDataSystem : IDisposable
{
	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct CalculateInterpolatedLightAndOcclusionProbesBatchJob : IJobParallelFor
	{
		public const int k_BatchSize = 1; //Field offset: 0x0
		public const int k_CalculatedProbesPerBatch = 8; //Field offset: 0x0
		[ReadOnly]
		public int probesCount; //Field offset: 0x0
		[ReadOnly]
		public LightProbesQuery lightProbesQuery; //Field offset: 0x8
		[NativeDisableParallelForRestriction]
		[ReadOnly]
		public NativeArray<Vector3> queryPostitions; //Field offset: 0x18
		[NativeDisableParallelForRestriction]
		public NativeArray<Int32> compactTetrahedronCache; //Field offset: 0x28
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<SphericalHarmonicsL2> probesSphericalHarmonics; //Field offset: 0x38
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<Vector4> probesOcclusion; //Field offset: 0x48

		public override void Execute(int index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct CollectInstancesLODGroupsAndMasksJob : IJobParallelFor
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x0
		[ReadOnly]
		public ReadOnly instanceData; //Field offset: 0x10
		[ReadOnly]
		public ReadOnly sharedInstanceData; //Field offset: 0xE8
		[WriteOnly]
		public NativeArray<UInt32> lodGroupAndMasks; //Field offset: 0x188

		public override void Execute(int index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct ComputeInstancesOffsetAndResizeInstancesArrayJob : IJob
	{
		[ReadOnly]
		public NativeArray<Int32> instancesCount; //Field offset: 0x0
		[WriteOnly]
		public NativeArray<Int32> instancesOffset; //Field offset: 0x10
		public NativeList<InstanceHandle> instances; //Field offset: 0x20

		public override void Execute() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct FreeInstancesJob : IJob
	{
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x0
		public InstanceAllocators instanceAllocators; //Field offset: 0x10
		public CPUInstanceData instanceData; //Field offset: 0x70
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0x150
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x1F8

		public override void Execute() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct FreeRendererGroupInstancesJob : IJob
	{
		[ReadOnly]
		public NativeArray<Int32> rendererGroupsID; //Field offset: 0x0
		public InstanceAllocators instanceAllocators; //Field offset: 0x10
		public CPUInstanceData instanceData; //Field offset: 0x70
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0x150
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x1F8

		public override void Execute() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct GetVisibleNonProcessedTreeInstancesJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 64; //Field offset: 0x0
		[ReadOnly]
		public CPUInstanceData instanceData; //Field offset: 0x0
		[ReadOnly]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0xE0
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public ParallelBitArray compactedVisibilityMasks; //Field offset: 0x188
		[ReadOnly]
		public bool becomeVisible; //Field offset: 0x1A8
		[NativeDisableParallelForRestriction]
		public ParallelBitArray processedBits; //Field offset: 0x1B0
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<Int32> rendererIDs; //Field offset: 0x1D0
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x1E0
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicTreeInstancesCount; //Field offset: 0x1F0

		public override void Execute(int startIndex, int count) { }

	}

	private static class InstanceTransformUpdateIDs
	{
		public static readonly int _TransformUpdateQueueCount; //Field offset: 0x0
		public static readonly int _TransformUpdateOutputL2WVec4Offset; //Field offset: 0x4
		public static readonly int _TransformUpdateOutputW2LVec4Offset; //Field offset: 0x8
		public static readonly int _TransformUpdateOutputPrevL2WVec4Offset; //Field offset: 0xC
		public static readonly int _TransformUpdateOutputPrevW2LVec4Offset; //Field offset: 0x10
		public static readonly int _BoundingSphereOutputVec4Offset; //Field offset: 0x14
		public static readonly int _TransformUpdateDataQueue; //Field offset: 0x18
		public static readonly int _TransformUpdateIndexQueue; //Field offset: 0x1C
		public static readonly int _BoundingSphereDataQueue; //Field offset: 0x20
		public static readonly int _OutputTransformBuffer; //Field offset: 0x24
		public static readonly int _ProbeUpdateQueueCount; //Field offset: 0x28
		public static readonly int _SHUpdateVec4Offset; //Field offset: 0x2C
		public static readonly int _ProbeUpdateDataQueue; //Field offset: 0x30
		public static readonly int _ProbeOcclusionUpdateDataQueue; //Field offset: 0x34
		public static readonly int _ProbeUpdateIndexQueue; //Field offset: 0x38
		public static readonly int _OutputProbeBuffer; //Field offset: 0x3C

		private static InstanceTransformUpdateIDs() { }

	}

	private static class InstanceWindDataUpdateIDs
	{
		public static readonly int _WindDataQueueCount; //Field offset: 0x0
		public static readonly int _WindDataUpdateIndexQueue; //Field offset: 0x4
		public static readonly int _WindDataBuffer; //Field offset: 0x8
		public static readonly int _WindParamAddressArray; //Field offset: 0xC
		public static readonly int _WindHistoryParamAddressArray; //Field offset: 0x10

		private static InstanceWindDataUpdateIDs() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct MotionUpdateJob : IJobParallelFor
	{
		public const int k_BatchSize = 16; //Field offset: 0x0
		[ReadOnly]
		public int queueWriteBase; //Field offset: 0x0
		[NativeDisableParallelForRestriction]
		public CPUInstanceData instanceData; //Field offset: 0x8
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicUpdateQueueCount; //Field offset: 0xE8
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeArray<InstanceHandle> transformUpdateInstanceQueue; //Field offset: 0xF0

		public override void Execute(int chunk_index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct ProbesUpdateJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 64; //Field offset: 0x0
		[ReadOnly]
		public bool initialize; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x8
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		[NoAlias]
		public CPUInstanceData instanceData; //Field offset: 0x18
		[ReadOnly]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0xF8
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicProbesQueueCount; //Field offset: 0x1A0
		[NativeDisableParallelForRestriction]
		public NativeArray<InstanceHandle> probeInstanceQueue; //Field offset: 0x1A8
		[NativeDisableParallelForRestriction]
		public NativeArray<Int32> compactTetrahedronCache; //Field offset: 0x1B8
		[NativeDisableParallelForRestriction]
		public NativeArray<Vector3> probeQueryPosition; //Field offset: 0x1C8

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct QueryRendererGroupInstancesCountJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public CPUInstanceData instanceData; //Field offset: 0x0
		[ReadOnly]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0xE0
		[ReadOnly]
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x188
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> rendererGroupIDs; //Field offset: 0x198
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<Int32> instancesCount; //Field offset: 0x1A8

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct QueryRendererGroupInstancesJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> rendererGroupIDs; //Field offset: 0x10
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x20
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicNonFoundInstancesCount; //Field offset: 0x30

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct QueryRendererGroupInstancesMultiJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> rendererGroupIDs; //Field offset: 0x10
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> instancesOffsets; //Field offset: 0x20
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> instancesCounts; //Field offset: 0x30
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x40
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicNonFoundSharedInstancesCount; //Field offset: 0x50
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicNonFoundInstancesCount; //Field offset: 0x58

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct QuerySortedMeshInstancesJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 64; //Field offset: 0x0
		[ReadOnly]
		public CPUInstanceData instanceData; //Field offset: 0x0
		[ReadOnly]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0xE0
		[ReadOnly]
		public NativeArray<Int32> sortedMeshID; //Field offset: 0x188
		[NativeDisableParallelForRestriction]
		[WriteOnly]
		public NativeList<InstanceHandle> instances; //Field offset: 0x198

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct ReallocateInstancesJob : IJob
	{
		[ReadOnly]
		public bool implicitInstanceIndices; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> rendererGroupIDs; //Field offset: 0x8
		[ReadOnly]
		public NativeArray<GPUDrivenPackedRendererData> packedRendererData; //Field offset: 0x18
		[ReadOnly]
		public NativeArray<Int32> instanceOffsets; //Field offset: 0x28
		[ReadOnly]
		public NativeArray<Int32> instanceCounts; //Field offset: 0x38
		public InstanceAllocators instanceAllocators; //Field offset: 0x48
		public CPUInstanceData instanceData; //Field offset: 0xA8
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0x188
		public NativeArray<InstanceHandle> instances; //Field offset: 0x230
		public NativeParallelMultiHashMap<Int32, InstanceHandle> rendererGroupInstanceMultiHash; //Field offset: 0x240

		public override void Execute() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct ScatterTetrahedronCacheIndicesJob : IJobParallelFor
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<InstanceHandle> probeInstances; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> compactTetrahedronCache; //Field offset: 0x10
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		[NoAlias]
		public CPUInstanceData instanceData; //Field offset: 0x20

		public override void Execute(int index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct TransformUpdateJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 64; //Field offset: 0x0
		[ReadOnly]
		public bool initialize; //Field offset: 0x0
		[ReadOnly]
		public bool enableBoundingSpheres; //Field offset: 0x1
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x8
		[ReadOnly]
		public NativeArray<Matrix4x4> localToWorldMatrices; //Field offset: 0x18
		[ReadOnly]
		public NativeArray<Matrix4x4> prevLocalToWorldMatrices; //Field offset: 0x28
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 atomicTransformQueueCount; //Field offset: 0x38
		[NativeDisableParallelForRestriction]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0x40
		[NativeDisableParallelForRestriction]
		public CPUInstanceData instanceData; //Field offset: 0xE8
		[NativeDisableParallelForRestriction]
		public NativeArray<InstanceHandle> transformUpdateInstanceQueue; //Field offset: 0x1C8
		[NativeDisableParallelForRestriction]
		public NativeArray<TransformUpdatePacket> transformUpdateDataQueue; //Field offset: 0x1D8
		[NativeDisableParallelForRestriction]
		public NativeArray<float4> boundingSpheresDataQueue; //Field offset: 0x1E8

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct UpdateCompactedInstanceVisibilityJob : IJobParallelForBatch
	{
		public const int k_BatchSize = 64; //Field offset: 0x0
		[ReadOnly]
		public ParallelBitArray compactedVisibilityMasks; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		[NoAlias]
		public CPUInstanceData instanceData; //Field offset: 0x20

		public override void Execute(int startIndex, int count) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct UpdateRendererInstancesJob : IJobParallelFor
	{
		public const int k_BatchSize = 128; //Field offset: 0x0
		[ReadOnly]
		public bool implicitInstanceIndices; //Field offset: 0x0
		[ReadOnly]
		public GPUDrivenRendererGroupData rendererData; //Field offset: 0x8
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x1C8
		[ReadOnly]
		public NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataMap; //Field offset: 0x1D8
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		[NoAlias]
		public CPUInstanceData instanceData; //Field offset: 0x1E8
		[NativeDisableContainerSafetyRestriction]
		[NativeDisableParallelForRestriction]
		[NoAlias]
		public CPUSharedInstanceData sharedInstanceData; //Field offset: 0x2C8

		public override void Execute(int index) { }

	}

	private InstanceAllocators m_InstanceAllocators; //Field offset: 0x10
	private CPUSharedInstanceData m_SharedInstanceData; //Field offset: 0x70
	private CPUInstanceData m_InstanceData; //Field offset: 0x118
	private NativeParallelMultiHashMap<Int32, InstanceHandle> m_RendererGroupInstanceMultiHash; //Field offset: 0x1F8
	private ComputeShader m_TransformUpdateCS; //Field offset: 0x208
	private ComputeShader m_WindDataUpdateCS; //Field offset: 0x210
	private int m_TransformInitKernel; //Field offset: 0x218
	private int m_TransformUpdateKernel; //Field offset: 0x21C
	private int m_MotionUpdateKernel; //Field offset: 0x220
	private int m_ProbeUpdateKernel; //Field offset: 0x224
	private int m_LODUpdateKernel; //Field offset: 0x228
	private int m_WindDataCopyHistoryKernel; //Field offset: 0x22C
	private ComputeBuffer m_UpdateIndexQueueBuffer; //Field offset: 0x230
	private ComputeBuffer m_ProbeUpdateDataQueueBuffer; //Field offset: 0x238
	private ComputeBuffer m_ProbeOcclusionUpdateDataQueueBuffer; //Field offset: 0x240
	private ComputeBuffer m_TransformUpdateDataQueueBuffer; //Field offset: 0x248
	private ComputeBuffer m_BoundingSpheresUpdateDataQueueBuffer; //Field offset: 0x250
	private bool m_EnableBoundingSpheres; //Field offset: 0x258
	private readonly Int32[] m_ScratchWindParamAddressArray; //Field offset: 0x260

	public NativeArray<InstanceHandle> aliveInstances
	{
		 get { } //Length: 108
	}

	public bool hasBoundingSpheres
	{
		 get { } //Length: 8
	}

	public ReadOnly instanceData
	{
		 get { } //Length: 204
	}

	public ReadOnly sharedInstanceData
	{
		 get { } //Length: 169
	}

	public InstanceDataSystem(int maxInstances, bool enableBoundingSpheres, GPUResidentDrawerResources resources) { }

	private static int AtomicAddLengthNoResize(in NativeList<T>& list, int count) { }

	private void DispatchMotionUpdateCommand(int motionQueueCount, NativeArray<InstanceHandle> transformInstanceQueue, RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void DispatchProbeUpdateCommand(int queueCount, NativeArray<InstanceHandle> probeInstanceQueue, NativeArray<SphericalHarmonicsL2> probeUpdateDataQueue, NativeArray<Vector4> probeOcclusionUpdateDataQueue, RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void DispatchTransformUpdateCommand(bool initialize, int transformQueueCount, NativeArray<InstanceHandle> transformInstanceQueue, NativeArray<TransformUpdatePacket> updateDataQueue, NativeArray<float4> boundingSphereUpdateDataQueue, RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void DispatchWindDataCopyHistoryCommand(NativeArray<GPUInstanceIndex> gpuInstanceIndices, RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public override void Dispose() { }

	private void EnsureIndexQueueBufferCapacity(int capacity) { }

	private void EnsureProbeBuffersCapacity(int capacity) { }

	private void EnsureTransformBuffersCapacity(int capacity) { }

	public void FreeInstances(NativeArray<InstanceHandle> instances) { }

	public void FreeRendererGroupInstances(NativeArray<Int32> rendererGroupsID) { }

	public NativeArray<InstanceHandle> get_aliveInstances() { }

	public bool get_hasBoundingSpheres() { }

	public ReadOnly get_instanceData() { }

	public ReadOnly get_sharedInstanceData() { }

	public int GetAliveInstancesOfType(InstanceType instanceType) { }

	public int GetMaxInstancesOfType(InstanceType instanceType) { }

	public void GetVisibleTreeInstances(in ParallelBitArray compactedVisibilityMasks, in ParallelBitArray processedBits, NativeList<Int32> visibeTreeRendererIDs, NativeList<InstanceHandle> visibeTreeInstances, bool becomeVisibleOnly, out int becomeVisibeTreeInstancesCount) { }

	public void InitializeInstanceTransforms(NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices, NativeArray<Matrix4x4> prevLocalToWorldMatrices, in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public bool InternalSanityCheckStates() { }

	public void ReallocateAndGetInstances(in GPUDrivenRendererGroupData rendererData, NativeArray<InstanceHandle> instances) { }

	public JobHandle ScheduleCollectInstancesLODGroupAndMasksJob(NativeArray<InstanceHandle> instances, NativeArray<UInt32> lodGroupAndMasks) { }

	private JobHandle ScheduleInterpolateProbesAndUpdateTetrahedronCache(int queueCount, NativeArray<InstanceHandle> probeUpdateInstanceQueue, NativeArray<Int32> compactTetrahedronCache, NativeArray<Vector3> probeQueryPosition, NativeArray<SphericalHarmonicsL2> probeUpdateDataQueue, NativeArray<Vector4> probeOcclusionUpdateDataQueue) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<Int32> instancesOffset, NativeArray<Int32> instancesCount, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<InstanceHandle> instances) { }

	public JobHandle ScheduleQuerySortedMeshInstancesJob(NativeArray<Int32> sortedMeshIDs, NativeList<InstanceHandle> instances) { }

	public JobHandle ScheduleUpdateInstanceDataJob(NativeArray<InstanceHandle> instances, in GPUDrivenRendererGroupData rendererData, NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataMap) { }

	public void UpdateAllInstanceProbes(in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public void UpdateInstanceMotions(in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void UpdateInstanceMotionsData(in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void UpdateInstanceProbesData(NativeArray<InstanceHandle> instances, in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public void UpdateInstanceTransforms(NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices, in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	private void UpdateInstanceTransformsData(bool initialize, NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices, NativeArray<Matrix4x4> prevLocalToWorldMatrices, in RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public void UpdateInstanceWindDataHistory(NativeArray<GPUInstanceIndex> gpuInstanceIndices, RenderersParameters renderersParameters, GPUInstanceDataBuffer outputBuffer) { }

	public void UpdatePerFrameInstanceVisibility(in ParallelBitArray compactedVisibilityMasks) { }

}

