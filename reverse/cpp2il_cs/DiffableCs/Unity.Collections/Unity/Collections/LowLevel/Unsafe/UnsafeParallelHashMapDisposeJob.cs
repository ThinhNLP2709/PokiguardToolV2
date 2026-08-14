namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompile]
internal struct UnsafeParallelHashMapDisposeJob : IJob
{
	[NativeDisableUnsafePtrRestriction]
	public UnsafeParallelHashMapData* Data; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x8

	public override void Execute() { }

}

