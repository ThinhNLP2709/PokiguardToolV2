namespace Unity.Collections.LowLevel.Unsafe;

internal struct UntypedUnsafeList
{
	[NativeDisableUnsafePtrRestriction]
	internal readonly Void* Ptr; //Field offset: 0x0
	internal readonly int m_length; //Field offset: 0x8
	internal readonly int m_capacity; //Field offset: 0xC
	internal readonly AllocatorHandle Allocator; //Field offset: 0x10
	internal readonly int padding; //Field offset: 0x14

}

