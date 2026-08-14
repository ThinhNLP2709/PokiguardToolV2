namespace UnityEngine.Rendering;

internal class CPUDrawInstanceData
{
	private NativeParallelHashMap<RangeKey, Int32> m_RangeHash; //Field offset: 0x10
	private NativeList<DrawRange> m_DrawRanges; //Field offset: 0x20
	private NativeParallelHashMap<DrawKey, Int32> m_BatchHash; //Field offset: 0x28
	private NativeList<DrawBatch> m_DrawBatches; //Field offset: 0x38
	private NativeList<DrawInstance> m_DrawInstances; //Field offset: 0x40
	private NativeList<Int32> m_DrawInstanceIndices; //Field offset: 0x48
	private NativeList<Int32> m_DrawBatchIndices; //Field offset: 0x50
	private bool m_NeedsRebuild; //Field offset: 0x58

	public NativeParallelHashMap<DrawKey, Int32> batchHash
	{
		 get { } //Length: 11
	}

	public NativeList<DrawBatch> drawBatches
	{
		 get { } //Length: 5
	}

	public NativeArray<Int32> drawBatchIndices
	{
		 get { } //Length: 87
	}

	public NativeArray<Int32> drawInstanceIndices
	{
		 get { } //Length: 87
	}

	public NativeList<DrawInstance> drawInstances
	{
		 get { } //Length: 5
	}

	public NativeList<DrawRange> drawRanges
	{
		 get { } //Length: 5
	}

	public NativeParallelHashMap<RangeKey, Int32> rangeHash
	{
		 get { } //Length: 11
	}

	public bool valid
	{
		 get { } //Length: 51
	}

	public CPUDrawInstanceData() { }

	public void DestroyDrawInstanceIndices(NativeArray<Int32> drawInstanceIndicesToDestroy) { }

	public void DestroyDrawInstances(NativeArray<InstanceHandle> destroyedInstances) { }

	public void DestroyMaterialDrawInstances(NativeArray<UInt32> destroyedBatchMaterials) { }

	public void Dispose() { }

	public NativeParallelHashMap<DrawKey, Int32> get_batchHash() { }

	public NativeList<DrawBatch> get_drawBatches() { }

	public NativeArray<Int32> get_drawBatchIndices() { }

	public NativeArray<Int32> get_drawInstanceIndices() { }

	public NativeList<DrawInstance> get_drawInstances() { }

	public NativeList<DrawRange> get_drawRanges() { }

	public NativeParallelHashMap<RangeKey, Int32> get_rangeHash() { }

	public bool get_valid() { }

	public void Initialize() { }

	public void NeedsRebuild() { }

	public void RebuildDrawListsIfNeeded() { }

}

