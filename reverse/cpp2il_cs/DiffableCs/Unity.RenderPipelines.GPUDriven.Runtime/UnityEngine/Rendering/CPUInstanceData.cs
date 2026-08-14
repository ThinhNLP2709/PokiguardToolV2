namespace UnityEngine.Rendering;

internal struct CPUInstanceData : IDisposable
{
	[IsReadOnly]
	public struct ReadOnly
	{
		public readonly ReadOnly<Int32> instanceIndices; //Field offset: 0x0
		public readonly ReadOnly<InstanceHandle> instances; //Field offset: 0x10
		public readonly ReadOnly<SharedInstanceHandle> sharedInstances; //Field offset: 0x20
		public readonly ParallelBitArray localToWorldIsFlippedBits; //Field offset: 0x30
		public readonly ReadOnly<AABB> worldAABBs; //Field offset: 0x50
		public readonly ReadOnly<Int32> tetrahedronCacheIndices; //Field offset: 0x60
		public readonly ParallelBitArray movedInCurrentFrameBits; //Field offset: 0x70
		public readonly ParallelBitArray movedInPreviousFrameBits; //Field offset: 0x90
		public readonly ParallelBitArray visibleInPreviousFrameBits; //Field offset: 0xB0
		public readonly ReadOnly editorData; //Field offset: 0xD0

		public int handlesLength
		{
			 get { } //Length: 46
		}

		public int instancesLength
		{
			 get { } //Length: 46
		}

		public ReadOnly(in CPUInstanceData instanceData) { }

		public int get_handlesLength() { }

		public int get_instancesLength() { }

		public InstanceHandle IndexToInstance(int index) { }

		public int InstanceToIndex(InstanceHandle instance) { }

		public bool IsValidIndex(int index) { }

		public bool IsValidInstance(InstanceHandle instance) { }

	}

	private const int k_InvalidIndex = -1; //Field offset: 0x0
	private NativeArray<Int32> m_StructData; //Field offset: 0x0
	private NativeList<Int32> m_InstanceIndices; //Field offset: 0x10
	public NativeArray<InstanceHandle> instances; //Field offset: 0x18
	public NativeArray<SharedInstanceHandle> sharedInstances; //Field offset: 0x28
	public ParallelBitArray localToWorldIsFlippedBits; //Field offset: 0x38
	public NativeArray<AABB> worldAABBs; //Field offset: 0x58
	public NativeArray<Int32> tetrahedronCacheIndices; //Field offset: 0x68
	public ParallelBitArray movedInCurrentFrameBits; //Field offset: 0x78
	public ParallelBitArray movedInPreviousFrameBits; //Field offset: 0x98
	public ParallelBitArray visibleInPreviousFrameBits; //Field offset: 0xB8
	public EditorInstanceDataArrays editorData; //Field offset: 0xD8

	public int handlesLength
	{
		 get { } //Length: 75
	}

	public int instancesCapacity
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public int instancesLength
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public void Add(InstanceHandle instance) { }

	public void AddNoGrow(InstanceHandle instance) { }

	private void AddUnsafe(InstanceHandle instance) { }

	public ReadOnly AsReadOnly() { }

	public override void Dispose() { }

	public void EnsureFreeInstances(int instancesCount) { }

	public int get_handlesLength() { }

	public int get_instancesCapacity() { }

	public int get_instancesLength() { }

	public bool Get_LocalToWorldIsFlipped(InstanceHandle instance) { }

	public bool Get_MovedInCurrentFrame(InstanceHandle instance) { }

	public bool Get_MovedInPreviousFrame(InstanceHandle instance) { }

	public SharedInstanceHandle Get_SharedInstance(InstanceHandle instance) { }

	public int Get_TetrahedronCacheIndex(InstanceHandle instance) { }

	public bool Get_VisibleInPreviousFrame(InstanceHandle instance) { }

	public AABB Get_WorldAABB(InstanceHandle instance) { }

	public AABB Get_WorldBounds(InstanceHandle instance) { }

	public int GetFreeInstancesCount() { }

	private void Grow(int newCapacity) { }

	public InstanceHandle IndexToInstance(int index) { }

	public void Initialize(int initCapacity) { }

	public int InstanceToIndex(InstanceHandle instance) { }

	public bool IsFreeInstanceHandle(InstanceHandle instance) { }

	public bool IsValidIndex(int index) { }

	public bool IsValidInstance(InstanceHandle instance) { }

	public void Remove(InstanceHandle instance) { }

	public void Set(InstanceHandle instance, SharedInstanceHandle sharedInstance, bool localToWorldIsFlipped, in AABB worldAABB, int tetrahedronCacheIndex, bool movedInCurrentFrame, bool movedInPreviousFrame, bool visibleInPreviousFrame) { }

	public void set_instancesCapacity(int value) { }

	public void set_instancesLength(int value) { }

	public void Set_LocalToWorldIsFlipped(InstanceHandle instance, bool isFlipped) { }

	public void Set_MovedInCurrentFrame(InstanceHandle instance, bool movedInCurrentFrame) { }

	public void Set_MovedInPreviousFrame(InstanceHandle instance, bool movedInPreviousFrame) { }

	public void Set_SharedInstance(InstanceHandle instance, SharedInstanceHandle sharedInstance) { }

	public void Set_TetrahedronCacheIndex(InstanceHandle instance, int tetrahedronCacheIndex) { }

	public void Set_VisibleInPreviousFrame(InstanceHandle instance, bool visibleInPreviousFrame) { }

	public void Set_WorldAABB(InstanceHandle instance, in AABB worldBounds) { }

	public void SetDefault(InstanceHandle instance) { }

}

