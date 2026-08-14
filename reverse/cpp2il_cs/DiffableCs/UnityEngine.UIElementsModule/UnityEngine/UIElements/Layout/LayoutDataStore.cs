namespace UnityEngine.UIElements.Layout;

internal struct LayoutDataStore : IDisposable
{
	private struct Chunk
	{
		[NativeDisableUnsafePtrRestriction]
		public Byte* Buffer; //Field offset: 0x0

	}

	private struct ComponentDataStore : IDisposable
	{
		public Allocator Allocator; //Field offset: 0x0
		public int Size; //Field offset: 0x4
		public int ComponentCountPerChunk; //Field offset: 0x8
		public int ChunkCount; //Field offset: 0xC
		[NativeDisableUnsafePtrRestriction]
		private Chunk* m_Chunks; //Field offset: 0x10

		public ComponentDataStore(int size, Allocator allocator) { }

		public override void Dispose() { }

		public Byte* GetComponentDataPtr(int index) { }

		public void ResizeCapacity(int capacity) { }

	}

	private struct Data
	{
		public int Capacity; //Field offset: 0x0
		public int NextFreeIndex; //Field offset: 0x4
		public int ComponentCount; //Field offset: 0x8
		[NativeDisableUnsafePtrRestriction]
		public Int32* Versions; //Field offset: 0x10
		[NativeDisableUnsafePtrRestriction]
		public ComponentDataStore* Components; //Field offset: 0x18

	}

	private const int k_ChunkSize = 32768; //Field offset: 0x0
	private readonly Allocator m_Allocator; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	private Data* m_Data; //Field offset: 0x8

	public bool IsValid
	{
		 get { } //Length: 9
	}

	public LayoutDataStore(ComponentType[] components, int initialCapacity, Allocator allocator) { }

	private LayoutHandle Allocate(Byte** data, int count) { }

	public LayoutHandle Allocate(in T0 component0) { }

	public LayoutHandle Allocate(in T0 component0, in T1 component1, in T2 component2, in T3 component3) { }

	public override void Dispose() { }

	public bool Exists(in LayoutHandle handle) { }

	public void Free(in LayoutHandle handle) { }

	public bool get_IsValid() { }

	[IsReadOnly]
	internal Void* GetComponentDataPtr(int index, int componentIndex) { }

	private static int GetNextFreeIndex(ComponentDataStore* ptr, int index) { }

	private void IncreaseCapacity() { }

	private static Void* ResizeArray(Void* fromPtr, long fromCount, long toCount, long size, int align, Allocator allocator) { }

	private void ResizeCapacity(int capacity) { }

	private static void SetNextFreeIndex(ComponentDataStore* ptr, int index, int value) { }

}

