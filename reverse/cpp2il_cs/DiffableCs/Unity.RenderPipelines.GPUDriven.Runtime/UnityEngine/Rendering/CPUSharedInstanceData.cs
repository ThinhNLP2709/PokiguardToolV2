namespace UnityEngine.Rendering;

internal struct CPUSharedInstanceData : IDisposable
{
	[IsReadOnly]
	public struct ReadOnly
	{
		public readonly ReadOnly<Int32> instanceIndices; //Field offset: 0x0
		public readonly ReadOnly<SharedInstanceHandle> instances; //Field offset: 0x10
		public readonly ReadOnly<Int32> rendererGroupIDs; //Field offset: 0x20
		public readonly ReadOnly<SmallIntegerArray> materialIDArrays; //Field offset: 0x30
		public readonly ReadOnly<Int32> meshIDs; //Field offset: 0x40
		public readonly ReadOnly<AABB> localAABBs; //Field offset: 0x50
		public readonly ReadOnly<CPUSharedInstanceFlags> flags; //Field offset: 0x60
		public readonly ReadOnly<UInt32> lodGroupAndMasks; //Field offset: 0x70
		public readonly ReadOnly<Int32> gameObjectLayers; //Field offset: 0x80
		public readonly ReadOnly<Int32> refCounts; //Field offset: 0x90

		public int handlesLength
		{
			 get { } //Length: 46
		}

		public int instancesLength
		{
			 get { } //Length: 46
		}

		public ReadOnly(in CPUSharedInstanceData instanceData) { }

		public int get_handlesLength() { }

		public int get_instancesLength() { }

		public SharedInstanceHandle IndexToSharedInstance(int index) { }

		public int InstanceToIndex(in ReadOnly instanceData, InstanceHandle instance) { }

		public bool IsValidIndex(int index) { }

		public bool IsValidSharedInstance(SharedInstanceHandle instance) { }

		public int SharedInstanceToIndex(SharedInstanceHandle instance) { }

	}

	private const int k_InvalidIndex = -1; //Field offset: 0x0
	private const uint k_InvalidLODGroupAndMask = 4294967295; //Field offset: 0x0
	private NativeArray<Int32> m_StructData; //Field offset: 0x0
	private NativeList<Int32> m_InstanceIndices; //Field offset: 0x10
	public NativeArray<SharedInstanceHandle> instances; //Field offset: 0x18
	public NativeArray<Int32> rendererGroupIDs; //Field offset: 0x28
	public NativeArray<SmallIntegerArray> materialIDArrays; //Field offset: 0x38
	public NativeArray<Int32> meshIDs; //Field offset: 0x48
	public NativeArray<AABB> localAABBs; //Field offset: 0x58
	public NativeArray<CPUSharedInstanceFlags> flags; //Field offset: 0x68
	public NativeArray<UInt32> lodGroupAndMasks; //Field offset: 0x78
	public NativeArray<Int32> gameObjectLayers; //Field offset: 0x88
	public NativeArray<Int32> refCounts; //Field offset: 0x98

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

	public void Add(SharedInstanceHandle instance) { }

	public void AddNoGrow(SharedInstanceHandle instance) { }

	private void AddUnsafe(SharedInstanceHandle instance) { }

	public ReadOnly AsReadOnly() { }

	public override void Dispose() { }

	public void EnsureFreeInstances(int instancesCount) { }

	public CPUSharedInstanceFlags Get_Flags(SharedInstanceHandle instance) { }

	public int Get_GameObjectLayer(SharedInstanceHandle instance) { }

	public int get_handlesLength() { }

	public int get_instancesCapacity() { }

	public int get_instancesLength() { }

	public AABB Get_LocalAABB(SharedInstanceHandle instance) { }

	public uint Get_LODGroupAndMask(SharedInstanceHandle instance) { }

	public SmallIntegerArray Get_MaterialIDs(SharedInstanceHandle instance) { }

	public int Get_MeshID(SharedInstanceHandle instance) { }

	public int Get_RefCount(SharedInstanceHandle instance) { }

	public int Get_RendererGroupID(SharedInstanceHandle instance) { }

	public int GetFreeInstancesCount() { }

	private void Grow(int newCapacity) { }

	public SharedInstanceHandle IndexToSharedInstance(int index) { }

	public void Initialize(int initCapacity) { }

	public int InstanceToIndex(in CPUInstanceData instanceData, InstanceHandle instance) { }

	public bool IsFreeInstanceHandle(SharedInstanceHandle instance) { }

	public bool IsValidIndex(int index) { }

	public bool IsValidInstance(SharedInstanceHandle instance) { }

	public void Remove(SharedInstanceHandle instance) { }

	public void Set(SharedInstanceHandle instance, int rendererGroupID, in SmallIntegerArray materialIDs, int meshID, in AABB localAABB, TransformUpdateFlags transformUpdateFlags, InstanceFlags instanceFlags, uint lodGroupAndMask, int gameObjectLayer, int refCount) { }

	public void Set_Flags(SharedInstanceHandle instance, CPUSharedInstanceFlags instanceFlags) { }

	public void Set_GameObjectLayer(SharedInstanceHandle instance, int gameObjectLayer) { }

	public void set_instancesCapacity(int value) { }

	public void set_instancesLength(int value) { }

	public void Set_LocalAABB(SharedInstanceHandle instance, in AABB localAABB) { }

	public void Set_LODGroupAndMask(SharedInstanceHandle instance, uint lodGroupAndMask) { }

	public void Set_MaterialIDs(SharedInstanceHandle instance, in SmallIntegerArray materialIDs) { }

	public void Set_MeshID(SharedInstanceHandle instance, int meshID) { }

	public void Set_RefCount(SharedInstanceHandle instance, int refCount) { }

	public void Set_RendererGroupID(SharedInstanceHandle instance, int rendererGroupID) { }

	public void SetDefault(SharedInstanceHandle instance) { }

	public int SharedInstanceToIndex(SharedInstanceHandle instance) { }

}

