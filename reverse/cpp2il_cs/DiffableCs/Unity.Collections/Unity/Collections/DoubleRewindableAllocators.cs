namespace Unity.Collections;

public struct DoubleRewindableAllocators : IDisposable
{
	private RewindableAllocator* Pointer; //Field offset: 0x0
	private AllocatorHelper<RewindableAllocator> UpdateAllocatorHelper0; //Field offset: 0x8
	private AllocatorHelper<RewindableAllocator> UpdateAllocatorHelper1; //Field offset: 0x18

	public RewindableAllocator Allocator
	{
		 get { } //Length: 55
	}

	internal bool EnableBlockFree
	{
		internal get { } //Length: 68
		internal set { } //Length: 114
	}

	public bool IsCreated
	{
		 get { } //Length: 8
	}

	public DoubleRewindableAllocators(AllocatorHandle backingAllocator, int initialSizeInBytes) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckIsCreated() { }

	public override void Dispose() { }

	public RewindableAllocator get_Allocator() { }

	internal bool get_EnableBlockFree() { }

	public bool get_IsCreated() { }

	public void Initialize(AllocatorHandle backingAllocator, int initialSizeInBytes) { }

	internal void set_EnableBlockFree(bool value) { }

	public void Update() { }

}

