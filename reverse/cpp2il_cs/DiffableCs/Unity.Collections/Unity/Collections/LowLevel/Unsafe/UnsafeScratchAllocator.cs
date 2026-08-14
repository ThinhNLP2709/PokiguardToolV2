namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
public struct UnsafeScratchAllocator
{
	private Void* m_Pointer; //Field offset: 0x0
	private int m_LengthInBytes; //Field offset: 0x8
	private readonly int m_CapacityInBytes; //Field offset: 0xC

	public UnsafeScratchAllocator(Void* ptr, int capacityInBytes) { }

	public Void* Allocate(int sizeInBytes, int alignmentInBytes) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public Void* Allocate(int count = 1) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckAllocationDoesNotExceedCapacity(ulong requestedSize) { }

}

