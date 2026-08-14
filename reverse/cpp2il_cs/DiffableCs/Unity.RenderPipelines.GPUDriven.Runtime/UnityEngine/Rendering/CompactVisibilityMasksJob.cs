namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct CompactVisibilityMasksJob : IJobParallelForBatch
{
	public const int k_BatchSize = 64; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Byte> rendererVisibilityMasks; //Field offset: 0x0
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	public ParallelBitArray compactedVisibilityMasks; //Field offset: 0x10

	public override void Execute(int startIndex, int count) { }

}

