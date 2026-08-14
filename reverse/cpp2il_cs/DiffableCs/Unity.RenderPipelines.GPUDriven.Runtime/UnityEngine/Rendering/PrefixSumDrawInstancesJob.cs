namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct PrefixSumDrawInstancesJob : IJob
{
	[ReadOnly]
	public NativeParallelHashMap<RangeKey, Int32> rangeHash; //Field offset: 0x0
	public NativeList<DrawRange> drawRanges; //Field offset: 0x10
	public NativeList<DrawBatch> drawBatches; //Field offset: 0x18
	public NativeArray<Int32> drawBatchIndices; //Field offset: 0x20

	public override void Execute() { }

}

