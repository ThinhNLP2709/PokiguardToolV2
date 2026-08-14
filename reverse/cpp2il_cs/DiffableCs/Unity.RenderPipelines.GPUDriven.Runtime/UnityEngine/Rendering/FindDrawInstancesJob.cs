namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct FindDrawInstancesJob : IJobParallelForBatch
{
	public const int k_BatchSize = 128; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<InstanceHandle> instancesSorted; //Field offset: 0x0
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<DrawInstance> drawInstances; //Field offset: 0x10
	[WriteOnly]
	public ParallelWriter<Int32> outDrawInstanceIndicesWriter; //Field offset: 0x18

	public override void Execute(int startIndex, int count) { }

}

