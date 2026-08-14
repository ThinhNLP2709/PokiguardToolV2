namespace UnityEngine.Rendering.Universal;

internal class RTHandleResourcePool
{
	protected static int s_CurrentStaleResourceCount; //Field offset: 0x0
	protected static int s_StaleResourceLifetime; //Field offset: 0x4
	protected static int s_StaleResourceMaxCapacity; //Field offset: 0x8
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"resource", "frameIndex"})]
	protected Dictionary<Int32, SortedList`2<Int32, ValueTuple`2<RTHandle, Int32>>> m_ResourcePool; //Field offset: 0x10
	protected List<Int32> m_RemoveList; //Field offset: 0x18

	internal int staleResourceCapacity
	{
		internal get { } //Length: 78
		internal set { } //Length: 135
	}

	private static RTHandleResourcePool() { }

	public RTHandleResourcePool() { }

	internal bool AddResourceToPool(in TextureDesc texDesc, RTHandle resource, int currentFrameIndex) { }

	internal void Cleanup() { }

	internal static TextureDesc CreateTextureDesc(RenderTextureDescriptor desc, TextureSizeMode textureSizeMode = 0, int anisoLevel = 1, float mipMapBias = 0, FilterMode filterMode = 0, TextureWrapMode wrapMode = 1, string name = "") { }

	internal int get_staleResourceCapacity() { }

	internal int GetHashCodeWithNameHash(in TextureDesc texDesc) { }

	internal void LogDebugInfo() { }

	internal void PurgeUnusedResources(int currentFrameIndex) { }

	internal void set_staleResourceCapacity(int value) { }

	protected static bool ShouldReleaseResource(int lastUsedFrameIndex, int currentFrameIndex) { }

	internal bool TryGetResource(in TextureDesc texDesc, out RTHandle resource, bool usepool = true) { }

}

