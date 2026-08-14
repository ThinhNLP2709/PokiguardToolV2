namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[NativeContainer]
public struct NativeStream : INativeDisposable, IDisposable
{
	[BurstCompile]
	private struct ConstructJob : IJob
	{
		public NativeStream Container; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> Length; //Field offset: 0x20

		public override void Execute() { }

	}

	[BurstCompile]
	private struct ConstructJobList : IJob
	{
		public NativeStream Container; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public UntypedUnsafeList* List; //Field offset: 0x20

		public override void Execute() { }

	}

	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Reader
	{
		private Reader m_Reader; //Field offset: 0x0

		public int ForEachCount
		{
			 get { } //Length: 32
		}

		public int RemainingItemCount
		{
			 get { } //Length: 4
		}

		internal Reader(ref NativeStream stream) { }

		public int BeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBeginForEachIndex(int forEachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckEndForEachIndex() { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckNotReadingOutOfBounds(int size) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead() { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckReadSize(int size) { }

		public int Count() { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		public int get_RemainingItemCount() { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Peek() { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Read() { }

		public Byte* ReadUnsafePtr(int size) { }

	}

	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	[NativeContainerSupportsMinMaxWriteRestriction]
	internal struct Writer
	{
		private Writer m_Writer; //Field offset: 0x0

		public int ForEachCount
		{
			 get { } //Length: 32
		}

		internal Writer(ref NativeStream stream) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Allocate() { }

		public Byte* Allocate(int size) { }

		public void BeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckAllocateSize(int size) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBeginForEachIndex(int foreachIndex) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckEndForEachIndex() { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		public void PatchMinMaxRange(int foreEachIndex) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void Write(T value) { }

	}

	private UnsafeStream m_Stream; //Field offset: 0x0

	public int ForEachCount
	{
		[IsReadOnly]
		 get { } //Length: 32
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public NativeStream(int bufferCount, AllocatorHandle allocator) { }

	private static void AllocateBlock(out NativeStream stream, AllocatorHandle allocator) { }

	private void AllocateForEach(int forEachCount) { }

	public Reader AsReader() { }

	public Writer AsWriter() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckForEachCountGreaterThanZero(int forEachCount) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	public int Count() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[IsReadOnly]
	public int get_ForEachCount() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool IsEmpty() { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static JobHandle ScheduleConstruct(out NativeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	public static JobHandle ScheduleConstruct(out NativeStream stream, NativeArray<Int32> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

