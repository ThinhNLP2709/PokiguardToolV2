namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafeRingQueueDebugView`1))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct UnsafeRingQueue : INativeDisposable, IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	public T* Ptr; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x0
	internal readonly int m_Capacity; //Field offset: 0x0
	internal int m_Filled; //Field offset: 0x0
	internal int m_Write; //Field offset: 0x0
	internal int m_Read; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 4
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public int Length
	{
		[IsReadOnly]
		 get { } //Length: 4
	}

	public UnsafeRingQueue`1(T* ptr, int capacity) { }

	public UnsafeRingQueue`1(int capacity, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	internal static UnsafeRingQueue<T>* Alloc(AllocatorHandle allocator) { }

	public T Dequeue() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	public void Enqueue(T value) { }

	internal static void Free(UnsafeRingQueue<T>* data) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	[IsReadOnly]
	public int get_Length() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void ThrowQueueEmpty() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void ThrowQueueFull() { }

	public bool TryDequeue(out T item) { }

	private bool TryDequeueInternal(out T item) { }

	public bool TryEnqueue(T value) { }

	private bool TryEnqueueInternal(T value) { }

}

