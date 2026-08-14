namespace UnityEngine.Rendering;

internal struct InstanceOcclusionEventDebugArray : IDisposable
{
	public struct Info
	{
		public int viewInstanceID; //Field offset: 0x0
		public InstanceOcclusionEventType eventType; //Field offset: 0x4
		public int occluderVersion; //Field offset: 0x8
		public int subviewMask; //Field offset: 0xC
		public OcclusionTest occlusionTest; //Field offset: 0x10

		public bool HasVersion() { }

	}

	public struct Request
	{
		public UnsafeList<Info> info; //Field offset: 0x0
		public AsyncGPUReadbackRequest readback; //Field offset: 0x18

	}

	private const int InitialPassCount = 4; //Field offset: 0x0
	private const int MaxPassCount = 64; //Field offset: 0x0
	private GraphicsBuffer m_CounterBuffer; //Field offset: 0x0
	private UnsafeList<Info> m_PendingInfo; //Field offset: 0x8
	private NativeQueue<Request> m_Requests; //Field offset: 0x20
	private UnsafeList<Info> m_LatestInfo; //Field offset: 0x28
	private NativeArray<Int32> m_LatestCounters; //Field offset: 0x40
	private bool m_HasLatest; //Field offset: 0x50

	public GraphicsBuffer CounterBuffer
	{
		 get { } //Length: 4
	}

	public override void Dispose() { }

	public GraphicsBuffer get_CounterBuffer() { }

	public void Init() { }

	public void MoveToDebugStatsAndClear(DebugRendererBatcherStats debugStats) { }

	public int TryAdd(int viewInstanceID, InstanceOcclusionEventType eventType, int occluderVersion, int subviewMask, OcclusionTest occlusionTest) { }

}

