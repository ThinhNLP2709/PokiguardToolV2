namespace UnityEngine.Rendering;

internal struct SilhouettePlaneCache : IDisposable
{
	private struct Slot
	{
		public bool isActive; //Field offset: 0x0
		public int viewInstanceID; //Field offset: 0x4
		public int planeCount; //Field offset: 0x8
		public int lastUsedFrameIndex; //Field offset: 0xC

		public Slot(int viewInstanceID, int planeCount, int frameIndex) { }

	}

	private const int kMaxSilhouettePlanes = 6; //Field offset: 0x0
	private NativeParallelHashMap<Int32, Int32> m_SubviewIDToIndexMap; //Field offset: 0x0
	private NativeList<Int32> m_SlotFreeList; //Field offset: 0x10
	private NativeList<Slot> m_Slots; //Field offset: 0x18
	private NativeList<Plane> m_PlaneStorage; //Field offset: 0x20

	public override void Dispose() { }

	public void FreeUnusedSlots(int frameIndex, int maximumAge) { }

	public NativeArray<Plane> GetSubArray(int viewInstanceID) { }

	public void Init() { }

	public void Update(int viewInstanceID, NativeArray<Plane> planes, int frameIndex) { }

}

