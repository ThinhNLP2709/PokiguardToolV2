namespace UnityEngine.Rendering;

internal struct InstanceCullerSplitDebugArray : IDisposable
{
	public struct Info
	{
		public BatchCullingViewType viewType; //Field offset: 0x0
		public int viewInstanceID; //Field offset: 0x4
		public int splitIndex; //Field offset: 0x8

	}

	private const int MaxSplitCount = 64; //Field offset: 0x0
	private NativeList<Info> m_Info; //Field offset: 0x0
	private NativeArray<Int32> m_Counters; //Field offset: 0x8
	private NativeQueue<JobHandle> m_CounterSync; //Field offset: 0x18

	public NativeArray<Int32> Counters
	{
		 get { } //Length: 11
	}

	public void AddSync(int baseIndex, JobHandle jobHandle) { }

	public override void Dispose() { }

	public NativeArray<Int32> get_Counters() { }

	public void Init() { }

	public void MoveToDebugStatsAndClear(DebugRendererBatcherStats debugStats) { }

	public int TryAddSplits(BatchCullingViewType viewType, int viewInstanceID, int splitCount) { }

}

