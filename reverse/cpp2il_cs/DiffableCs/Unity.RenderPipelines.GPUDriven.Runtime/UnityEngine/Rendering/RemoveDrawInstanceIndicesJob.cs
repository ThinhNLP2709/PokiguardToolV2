namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct RemoveDrawInstanceIndicesJob : IJob
{
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeArray<Int32> drawInstanceIndices; //Field offset: 0x0
	public NativeList<DrawInstance> drawInstances; //Field offset: 0x10
	public NativeParallelHashMap<RangeKey, Int32> rangeHash; //Field offset: 0x18
	public NativeParallelHashMap<DrawKey, Int32> batchHash; //Field offset: 0x28
	public NativeList<DrawRange> drawRanges; //Field offset: 0x38
	public NativeList<DrawBatch> drawBatches; //Field offset: 0x40

	public override void Execute() { }

	public void RemoveDrawBatch(in DrawKey key) { }

	public void RemoveDrawRange(in RangeKey key) { }

}

