namespace Unity.Collections;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(NativeRingQueueDebugView`1))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[NativeContainer]
public struct NativeRingQueue : INativeDisposable, IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeRingQueue<T>* m_RingQueue; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 112
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 127
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 129
	}

	public int Length
	{
		[IsReadOnly]
		 get { } //Length: 112
	}

	public NativeRingQueue`1(int capacity, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckWrite() { }

	public T Dequeue() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public void Enqueue(T value) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	[IsReadOnly]
	public int get_Length() { }

	public bool TryDequeue(out T item) { }

	public bool TryEnqueue(T value) { }

}

