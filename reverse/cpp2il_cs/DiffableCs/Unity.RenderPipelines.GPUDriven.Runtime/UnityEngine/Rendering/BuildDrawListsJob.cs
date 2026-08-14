namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct BuildDrawListsJob : IJobParallelFor
{
	public const int k_BatchSize = 128; //Field offset: 0x0
	public const int k_IntsPerCacheLine = 16; //Field offset: 0x0
	[ReadOnly]
	public NativeParallelHashMap<DrawKey, Int32> batchHash; //Field offset: 0x0
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<DrawInstance> drawInstances; //Field offset: 0x10
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<DrawBatch> drawBatches; //Field offset: 0x18
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> internalDrawIndex; //Field offset: 0x20
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeArray<Int32> drawInstanceIndices; //Field offset: 0x30

	public override void Execute(int index) { }

	private static int IncrementCounter(Int32* counter) { }

}

