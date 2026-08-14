namespace UnityEngine.Rendering;

internal class ProbeBrickIndex
{
	[DebuggerDisplay("Brick [{position}, {subdivisionLevel}]")]
	internal struct Brick : IEquatable<Brick>
	{
		public Vector3Int position; //Field offset: 0x0
		public int subdivisionLevel; //Field offset: 0xC

		internal Brick(Vector3Int position, int subdivisionLevel) { }

		public override bool Equals(Brick other) { }

		public bool IntersectArea(Bounds boundInBricksToCheck) { }

	}

	internal struct CellIndexUpdateInfo
	{
		public IndirectionEntryUpdateInfo[] entriesInfo; //Field offset: 0x0

		public int GetNumberOfChunks() { }

	}

	internal struct IndirectionEntryUpdateInfo
	{
		public int firstChunkIndex; //Field offset: 0x0
		public int numberOfChunks; //Field offset: 0x4
		public int minSubdivInCell; //Field offset: 0x8
		public Vector3Int minValidBrickIndexForCellAtMaxRes; //Field offset: 0xC
		public Vector3Int maxValidBrickIndexForCellAtMaxResPlusOne; //Field offset: 0x18
		public Vector3Int entryPositionInBricksAtMaxRes; //Field offset: 0x24
		public bool hasOnlyBiggerBricks; //Field offset: 0x30

	}

	internal const int kMaxSubdivisionLevels = 7; //Field offset: 0x0
	internal const int kIndexChunkSize = 243; //Field offset: 0x0
	internal const int kFailChunkIndex = -1; //Field offset: 0x0
	internal const int kEmptyIndex = -2; //Field offset: 0x0
	private BitArray m_IndexChunks; //Field offset: 0x10
	private BitArray m_IndexChunksCopyForChecks; //Field offset: 0x18
	private int m_ChunksCount; //Field offset: 0x20
	private int m_AvailableChunkCount; //Field offset: 0x24
	private ComputeBuffer m_PhysicalIndexBuffer; //Field offset: 0x28
	private NativeArray<Int32> m_PhysicalIndexBufferData; //Field offset: 0x30
	private ComputeBuffer m_DebugFragmentationBuffer; //Field offset: 0x40
	private Int32[] m_DebugFragmentationData; //Field offset: 0x48
	private bool m_NeedUpdateIndexComputeBuffer; //Field offset: 0x50
	private int m_UpdateMinIndex; //Field offset: 0x54
	private int m_UpdateMaxIndex; //Field offset: 0x58
	[CompilerGenerated]
	private int <estimatedVMemCost>k__BackingField; //Field offset: 0x5C
	[CompilerGenerated]
	private float <fragmentationRate>k__BackingField; //Field offset: 0x60
	private Vector3Int m_CenterRS; //Field offset: 0x64

	internal int estimatedVMemCost
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal float fragmentationRate
	{
		[CompilerGenerated]
		internal get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	internal ProbeBrickIndex(ProbeVolumeTextureMemoryBudget memoryBudget) { }

	public void AddBricks(CellIndexInfo cellInfo, NativeArray<Brick> bricks, List<BrickChunkAlloc> allocations, int allocationSize, int poolWidth, int poolHeight) { }

	internal static bool BrickOverlapEntry(Vector3Int brickMin, Vector3Int brickMax, Vector3Int entryMin, Vector3Int entryMax) { }

	internal void Cleanup() { }

	internal void Clear() { }

	internal void ComputeFragmentationRate() { }

	internal bool FindSlotsForEntries(ref IndirectionEntryUpdateInfo[] entriesInfo) { }

	[CompilerGenerated]
	internal int get_estimatedVMemCost() { }

	[CompilerGenerated]
	internal float get_fragmentationRate() { }

	internal ComputeBuffer GetDebugFragmentationBuffer() { }

	internal int GetNumberOfChunks(int brickCount) { }

	public int GetRemainingChunkCount() { }

	internal void GetRuntimeResources(ref RuntimeResources rr) { }

	private static int LocationToIndex(int x, int y, int z, Vector3Int sizeOfValid) { }

	private void MarkBrickInPhysicalBuffer(in IndirectionEntryUpdateInfo entry, Vector3Int brickMin, Vector3Int brickMax, int brickSubdivLevel, int entrySubdivLevel, int idx) { }

	private int MergeIndex(int index, int size) { }

	public void RemoveBricks(CellIndexInfo cellInfo) { }

	internal bool ReserveChunks(IndirectionEntryUpdateInfo[] entriesInfo, bool ignoreErrorLog) { }

	[CompilerGenerated]
	private void set_estimatedVMemCost(int value) { }

	[CompilerGenerated]
	private void set_fragmentationRate(float value) { }

	private int SizeOfPhysicalIndexFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget) { }

	private void UpdateDebugData() { }

	internal void UploadIndexData() { }

}

