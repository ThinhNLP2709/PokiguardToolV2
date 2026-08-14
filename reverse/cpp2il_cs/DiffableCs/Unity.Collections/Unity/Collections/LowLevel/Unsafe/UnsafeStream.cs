namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
public struct UnsafeStream : INativeDisposable, IDisposable
{
	[BurstCompile]
	private struct ConstructJob : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> Length; //Field offset: 0x20

		public override void Execute() { }

	}

	[BurstCompile]
	private struct ConstructJobList : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public UntypedUnsafeList* List; //Field offset: 0x20

		public override void Execute() { }

	}

	[BurstCompile]
	private struct DisposeJob : IJob
	{
		public UnsafeStream Container; //Field offset: 0x0

		public override void Execute() { }

	}

	[GenerateTestsForBurstCompatibility]
	internal struct Reader
	{
		[NativeDisableUnsafePtrRestriction]
		internal Block m_BlockData; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeStreamBlock* m_CurrentBlock; //Field offset: 0x20
		[NativeDisableUnsafePtrRestriction]
		internal Byte* m_CurrentPtr; //Field offset: 0x28
		[NativeDisableUnsafePtrRestriction]
		internal Byte* m_CurrentBlockEnd; //Field offset: 0x30
		internal int m_RemainingItemCount; //Field offset: 0x38
		internal int m_LastBlockSize; //Field offset: 0x3C

		public int ForEachCount
		{
			 get { } //Length: 32
		}

		public int RemainingItemCount
		{
			 get { } //Length: 4
		}

		internal Reader(ref UnsafeStream stream) { }

		public int BeginForEachIndex(int foreachIndex) { }

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
	internal struct Writer
	{
		[NativeDisableUnsafePtrRestriction]
		internal Block m_BlockData; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		private UnsafeStreamBlock* m_CurrentBlock; //Field offset: 0x20
		[NativeDisableUnsafePtrRestriction]
		private Byte* m_CurrentPtr; //Field offset: 0x28
		[NativeDisableUnsafePtrRestriction]
		private Byte* m_CurrentBlockEnd; //Field offset: 0x30
		internal int m_ForeachIndex; //Field offset: 0x38
		private int m_ElementCount; //Field offset: 0x3C
		[NativeDisableUnsafePtrRestriction]
		private UnsafeStreamBlock* m_FirstBlock; //Field offset: 0x40
		private int m_FirstOffset; //Field offset: 0x48
		private int m_NumberOfBlocks; //Field offset: 0x4C
		[NativeSetThreadIndex]
		private int m_ThreadIndex; //Field offset: 0x50

		public int ForEachCount
		{
			 get { } //Length: 32
		}

		internal Writer(ref UnsafeStream stream) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public T Allocate() { }

		public Byte* Allocate(int size) { }

		public void BeginForEachIndex(int foreachIndex) { }

		public void EndForEachIndex() { }

		public int get_ForEachCount() { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void Write(T value) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal Block m_BlockData; //Field offset: 0x0

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

	public UnsafeStream(int bufferCount, AllocatorHandle allocator) { }

	internal static void AllocateBlock(out UnsafeStream stream, AllocatorHandle allocator) { }

	internal void AllocateForEach(int forEachCount) { }

	public Reader AsReader() { }

	public Writer AsWriter() { }

	public int Count() { }

	private void Deallocate() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[IsReadOnly]
	public int get_ForEachCount() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool IsEmpty() { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeList<T> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	public static JobHandle ScheduleConstruct(out UnsafeStream stream, NativeArray<Int32> bufferCount, JobHandle dependency, AllocatorHandle allocator) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

