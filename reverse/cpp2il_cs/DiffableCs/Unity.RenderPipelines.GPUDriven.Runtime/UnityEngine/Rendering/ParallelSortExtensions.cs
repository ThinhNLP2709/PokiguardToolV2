namespace UnityEngine.Rendering;

[Extension]
internal static class ParallelSortExtensions
{
	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	public struct RadixSortBatchPrefixSumJob : IJobFor
	{
		[ReadOnly]
		public int radix; //Field offset: 0x0
		[ReadOnly]
		public int jobsCount; //Field offset: 0x4
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> array; //Field offset: 0x8
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> counter; //Field offset: 0x18
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> indicesSum; //Field offset: 0x28
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> buckets; //Field offset: 0x38
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> indices; //Field offset: 0x48

		private static int AtomicIncrement(NativeArray<Int32> counter) { }

		public override void Execute(int index) { }

		private int JobIndexPrefixSum(int sum, int i) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	public struct RadixSortBucketCountJob : IJobFor
	{
		[ReadOnly]
		public int radix; //Field offset: 0x0
		[ReadOnly]
		public int jobsCount; //Field offset: 0x4
		[ReadOnly]
		public int batchSize; //Field offset: 0x8
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> array; //Field offset: 0x10
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> buckets; //Field offset: 0x20

		public override void Execute(int index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	public struct RadixSortBucketSortJob : IJobFor
	{
		[ReadOnly]
		public int radix; //Field offset: 0x0
		[ReadOnly]
		public int batchSize; //Field offset: 0x4
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<Int32> array; //Field offset: 0x8
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> indices; //Field offset: 0x18
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> arraySorted; //Field offset: 0x28

		public override void Execute(int index) { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	public struct RadixSortPrefixSumJob : IJobFor
	{
		[ReadOnly]
		public int jobsCount; //Field offset: 0x0
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> indicesSum; //Field offset: 0x8
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<Int32> indices; //Field offset: 0x18

		public override void Execute(int index) { }

	}

	private const int kMinRadixSortArraySize = 2048; //Field offset: 0x0
	private const int kMinRadixSortBatchSize = 256; //Field offset: 0x0

	[CompilerGenerated]
	internal static void <ParallelSort>g__Swap|2_0(ref NativeArray<Int32>& a, ref NativeArray<Int32>& b) { }

	[Extension]
	internal static JobHandle ParallelSort(NativeArray<Int32> array) { }

}

