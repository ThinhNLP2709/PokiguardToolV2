namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct PrefixSumDrawsAndInstances : IJob
{
	[ReadOnly]
	public NativeList<DrawRange> drawRanges; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Int32> drawBatchIndices; //Field offset: 0x8
	[ReadOnly]
	public NativeArray<Int32> batchBinAllocOffsets; //Field offset: 0x18
	[ReadOnly]
	public NativeArray<Int32> batchBinCounts; //Field offset: 0x28
	[ReadOnly]
	public NativeArray<Int32> binVisibleInstanceCounts; //Field offset: 0x38
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> batchDrawCommandOffsets; //Field offset: 0x48
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> binVisibleInstanceOffsets; //Field offset: 0x58
	[NativeDisableUnsafePtrRestriction]
	public NativeArray<BatchCullingOutputDrawCommands> cullingOutput; //Field offset: 0x68
	[ReadOnly]
	public IndirectBufferLimits indirectBufferLimits; //Field offset: 0x78
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	public NativeArray<IndirectBufferAllocInfo> indirectBufferAllocInfo; //Field offset: 0x80
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	public NativeArray<Int32> indirectAllocationCounters; //Field offset: 0x90

	public override void Execute() { }

}

