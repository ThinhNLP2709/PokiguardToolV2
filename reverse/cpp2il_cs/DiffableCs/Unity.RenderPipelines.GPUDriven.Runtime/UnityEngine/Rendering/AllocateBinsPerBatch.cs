namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct AllocateBinsPerBatch : IJobParallelFor
{
	[ReadOnly]
	public BinningConfig binningConfig; //Field offset: 0x0
	[ReadOnly]
	public NativeList<DrawBatch> drawBatches; //Field offset: 0x8
	[ReadOnly]
	public NativeArray<Int32> drawInstanceIndices; //Field offset: 0x10
	[ReadOnly]
	public ReadOnly instanceData; //Field offset: 0x20
	[ReadOnly]
	public NativeArray<Byte> rendererVisibilityMasks; //Field offset: 0xF8
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> batchBinAllocOffsets; //Field offset: 0x108
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> batchBinCounts; //Field offset: 0x118
	[DeallocateOnJobCompletion]
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	public NativeArray<Int32> binAllocCounter; //Field offset: 0x128
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int16> binConfigIndices; //Field offset: 0x138
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> binVisibleInstanceCounts; //Field offset: 0x148
	[ReadOnly]
	public int debugCounterIndexBase; //Field offset: 0x158
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	public NativeArray<Int32> splitDebugCounters; //Field offset: 0x160

	public override void Execute(int batchIndex) { }

	private bool IsInstanceFlipped(int rendererIndex) { }

}

