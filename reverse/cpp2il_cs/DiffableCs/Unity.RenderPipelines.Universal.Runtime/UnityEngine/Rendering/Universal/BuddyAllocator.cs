namespace UnityEngine.Rendering.Universal;

internal struct BuddyAllocator : IDisposable
{
	private struct Header
	{
		public int branchingOrder; //Field offset: 0x0
		public int levelCount; //Field offset: 0x4
		public int allocationCount; //Field offset: 0x8
		public int freeAllocationIdsCount; //Field offset: 0xC

	}

	private Void* m_Data; //Field offset: 0x0
	private ValueTuple<Int32, Int32> m_ActiveFreeMaskCounts; //Field offset: 0x8
	private ValueTuple<Int32, Int32> m_FreeMasksStorage; //Field offset: 0x10
	private ValueTuple<Int32, Int32> m_FreeMaskIndicesStorage; //Field offset: 0x18
	private Allocator m_Allocator; //Field offset: 0x20

	private NativeArray<Int32> freeMaskCounts
	{
		private get { } //Length: 99
	}

	private NativeArray<Int32> freeMaskIndicesStorage
	{
		private get { } //Length: 99
	}

	private NativeArray<UInt64> freeMasksStorage
	{
		private get { } //Length: 99
	}

	private Header header
	{
		private get { } //Length: 55
	}

	public int levelCount
	{
		 get { } //Length: 61
	}

	public BuddyAllocator(int levelCount, int branchingOrder, Allocator allocator = 4) { }

	private static int AlignForward(int offset, int alignment) { }

	private static ValueTuple<Int32, Int32> AllocateRange(int length, ref int dataSize) { }

	public override void Dispose() { }

	public void Free(BuddyAllocation allocation) { }

	private NativeArray<Int32> FreeMaskIndices(int level) { }

	private NativeArray<UInt64> FreeMasks(int level) { }

	private NativeArray<Int32> get_freeMaskCounts() { }

	private NativeArray<Int32> get_freeMaskIndicesStorage() { }

	private NativeArray<UInt64> get_freeMasksStorage() { }

	private Header get_header() { }

	public int get_levelCount() { }

	private NativeArray<T> GetNativeArray(int offset, int length) { }

	private static int LevelLength(int level, int branchingOrder) { }

	private static int LevelLength64(int level, int branchingOrder) { }

	private static int LevelOffset(int level, int branchingOrder) { }

	private static int LevelOffset64(int level, int branchingOrder) { }

	private static int Pow2(int n) { }

	private static int Pow2N(int x, int n) { }

	private static Void* PtrAdd(Void* ptr, int bytes) { }

	public bool TryAllocate(int requestedLevel, out BuddyAllocation allocation) { }

}

