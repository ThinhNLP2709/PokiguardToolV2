namespace UnityEngine.Rendering;

internal class ProbeGlobalIndirection
{
	public struct IndexMetaData
	{
		private static UInt32[] s_PackedValues; //Field offset: 0x0
		internal Vector3Int minLocalIdx; //Field offset: 0x0
		internal Vector3Int maxLocalIdxPlusOne; //Field offset: 0xC
		internal int firstChunkIndex; //Field offset: 0x18
		internal int minSubdiv; //Field offset: 0x1C

		private static IndexMetaData() { }

		internal void Pack(out UInt32[] vals) { }

	}

	private const int kUintPerEntry = 3; //Field offset: 0x0
	internal const int kEntryMaxSubdivLevel = 3; //Field offset: 0x0
	[CompilerGenerated]
	private int <estimatedVMemCost>k__BackingField; //Field offset: 0x10
	private ComputeBuffer m_IndexOfIndicesBuffer; //Field offset: 0x18
	private UInt32[] m_IndexOfIndicesData; //Field offset: 0x20
	private int m_CellSizeInMinBricks; //Field offset: 0x28
	private Vector3Int m_EntriesCount; //Field offset: 0x2C
	private Vector3Int m_EntryMin; //Field offset: 0x38
	private Vector3Int m_EntryMax; //Field offset: 0x44
	private bool m_NeedUpdateComputeBuffer; //Field offset: 0x50

	internal int entriesPerCellDimension
	{
		internal get { } //Length: 64
	}

	private int entrySizeInBricks
	{
		private get { } //Length: 40
	}

	internal int estimatedVMemCost
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal ProbeGlobalIndirection(Vector3Int cellMin, Vector3Int cellMax, int cellSizeInMinBricks) { }

	internal void Cleanup() { }

	internal int get_entriesPerCellDimension() { }

	private int get_entrySizeInBricks() { }

	[CompilerGenerated]
	internal int get_estimatedVMemCost() { }

	internal int GetFlatIdxForEntry(Vector3Int entryPosition) { }

	private int GetFlatIndex(Vector3Int normalizedPos) { }

	internal Int32[] GetFlatIndicesForCell(Vector3Int cellPosition) { }

	internal Vector3Int GetGlobalIndirectionDimension() { }

	internal Vector3Int GetGlobalIndirectionMinEntry() { }

	internal void GetMinMaxEntry(out Vector3Int minEntry, out Vector3Int maxEntry) { }

	internal void GetRuntimeResources(ref RuntimeResources rr) { }

	internal void MarkEntriesAsUnloaded(Int32[] entriesFlatIndices) { }

	internal void PushComputeData() { }

	[CompilerGenerated]
	private void set_estimatedVMemCost(int value) { }

	internal void UpdateCell(CellIndexInfo cellInfo) { }

}

