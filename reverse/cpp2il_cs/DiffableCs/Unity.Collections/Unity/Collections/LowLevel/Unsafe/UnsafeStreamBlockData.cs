namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
internal struct UnsafeStreamBlockData
{
	internal const int AllocationSize = 4096; //Field offset: 0x0
	internal AllocatorHandle Allocator; //Field offset: 0x0
	internal UnsafeStreamBlock** Blocks; //Field offset: 0x8
	internal int BlockCount; //Field offset: 0x10
	internal Block Ranges; //Field offset: 0x18
	internal int RangeCount; //Field offset: 0x38

	internal UnsafeStreamBlock* Allocate(UnsafeStreamBlock* oldBlock, int threadIndex) { }

	internal void Free(UnsafeStreamBlock* oldBlock) { }

}

