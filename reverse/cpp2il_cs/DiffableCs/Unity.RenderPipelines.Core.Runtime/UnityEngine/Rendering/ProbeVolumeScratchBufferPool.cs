namespace UnityEngine.Rendering;

internal class ProbeVolumeScratchBufferPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ScratchBufferPool> <>9__26_0; //Field offset: 0x8
		public static Predicate<ScratchBufferPool> <>9__27_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <AllocateScratchBuffer>b__26_0(ScratchBufferPool o) { }

		internal bool <ReleaseScratchBuffer>b__27_0(ScratchBufferPool o) { }

	}

	[DebuggerDisplay("ChunkCount = {chunkCount} ElementCount = {pool.Count}")]
	private class ScratchBufferPool : IComparable<ScratchBufferPool>
	{
		public int chunkCount; //Field offset: 0x10
		public Stack<CellStreamingScratchBuffer> pool; //Field offset: 0x18

		public ScratchBufferPool(int chunkCount) { }

		private ScratchBufferPool() { }

		public override int CompareTo(ScratchBufferPool other) { }

	}

	private static int s_ChunkCount; //Field offset: 0x0
	[CompilerGenerated]
	private int <chunkSize>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <maxChunkCount>k__BackingField; //Field offset: 0x14
	private int m_L0Size; //Field offset: 0x18
	private int m_L1Size; //Field offset: 0x1C
	private int m_ValiditySize; //Field offset: 0x20
	private int m_ValidityLayerCount; //Field offset: 0x24
	private int m_L2Size; //Field offset: 0x28
	private int m_ProbeOcclusionSize; //Field offset: 0x2C
	private int m_SkyOcclusionSize; //Field offset: 0x30
	private int m_SkyShadingDirectionSize; //Field offset: 0x34
	private int m_CurrentlyAllocatedChunkCount; //Field offset: 0x38
	private List<ScratchBufferPool> m_Pools; //Field offset: 0x40
	private Dictionary<Int32, CellStreamingScratchBufferLayout> m_Layouts; //Field offset: 0x48

	public int allocatedMemory
	{
		 get { } //Length: 8
	}

	public private int chunkSize
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int maxChunkCount
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public ProbeVolumeScratchBufferPool(ProbeVolumeBakingSet bakingSet, ProbeVolumeSHBands shBands) { }

	public bool AllocateScratchBuffer(int chunkCount, out CellStreamingScratchBuffer scratchBuffer, out CellStreamingScratchBufferLayout layout, bool allocateGraphicsBuffers) { }

	public void Cleanup() { }

	private CellStreamingScratchBuffer CreateScratchBuffer(int chunkCount, bool allocateGraphicsBuffers) { }

	public int get_allocatedMemory() { }

	[CompilerGenerated]
	public int get_chunkSize() { }

	[CompilerGenerated]
	public int get_maxChunkCount() { }

	private CellStreamingScratchBufferLayout GetOrCreateScratchBufferLayout(int chunkCount) { }

	public void ReleaseScratchBuffer(CellStreamingScratchBuffer scratchBuffer) { }

	[CompilerGenerated]
	private void set_chunkSize(int value) { }

	[CompilerGenerated]
	private void set_maxChunkCount(int value) { }

}

