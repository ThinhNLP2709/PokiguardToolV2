namespace Unity.Collections;

[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
public struct AllocatorHelper : IDisposable
{
	private readonly T* m_allocator; //Field offset: 0x0
	private AllocatorHandle m_backingAllocator; //Field offset: 0x0

	public T Allocator
	{
		 get { } //Length: 36
	}

	[ExcludeFromBurstCompatTesting("CreateAllocator is unburstable")]
	public AllocatorHelper`1(AllocatorHandle backingAllocator, bool isGlobal = false, int globalIndex = 0) { }

	[ExcludeFromBurstCompatTesting("DestroyAllocator is unburstable")]
	public override void Dispose() { }

	public T get_Allocator() { }

}

