namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
public struct UnsafeAppendBuffer : INativeDisposable, IDisposable
{
	[GenerateTestsForBurstCompatibility]
	internal struct Reader
	{
		public readonly Byte* Ptr; //Field offset: 0x0
		public readonly int Size; //Field offset: 0x8
		public int Offset; //Field offset: 0xC

		public bool EndOfBuffer
		{
			 get { } //Length: 10
		}

		public Reader(ref UnsafeAppendBuffer buffer) { }

		public Reader(Void* ptr, int length) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBounds(int structSize) { }

		public bool get_EndOfBuffer() { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void ReadNext(out T value) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T ReadNext() { }

		public Void* ReadNext(int structSize) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void ReadNext(out NativeArray<T>& value, AllocatorHandle allocator) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public Void* ReadNextArray(out int length) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public Byte* Ptr; //Field offset: 0x0
	public int Length; //Field offset: 0x8
	public int Capacity; //Field offset: 0xC
	public AllocatorHandle Allocator; //Field offset: 0x10
	public readonly int Alignment; //Field offset: 0x14

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

	public UnsafeAppendBuffer(int initialCapacity, int alignment, AllocatorHandle allocator) { }

	public UnsafeAppendBuffer(Void* ptr, int length) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Add(NativeArray<T> value) { }

	public void Add(Void* ptr, int structSize) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Add(T value) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddArray(Void* ptr, int length) { }

	public Reader AsReader() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckAlignment(int alignment) { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public T Pop() { }

	public void Pop(Void* ptr, int structSize) { }

	public void Reset() { }

	public void ResizeUninitialized(int length) { }

	public void SetCapacity(int capacity) { }

}

