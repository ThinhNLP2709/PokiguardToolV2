namespace UnityEngine.Rendering;

internal class VolumeCollection
{
	internal const int k_MaxLayerCount = 32; //Field offset: 0x0
	private readonly Dictionary<Int32, List`1<Volume>> m_SortedVolumes; //Field offset: 0x10
	private readonly List<Volume> m_Volumes; //Field offset: 0x18
	private readonly Dictionary<Int32, Boolean> m_SortNeeded; //Field offset: 0x20

	public int count
	{
		 get { } //Length: 60
	}

	public VolumeCollection() { }

	public bool ChangeLayer(Volume volume, int previousLayerIndex, int currentLayerIndex) { }

	public int get_count() { }

	public List<Volume> GrabVolumes(LayerMask mask) { }

	public bool IsComponentActiveInMask(LayerMask layerMask) { }

	public bool Register(Volume volume, int layer) { }

	public void SetLayerIndexDirty(int layerIndex) { }

	internal static void SortByPriority(List<Volume> volumes) { }

	public bool Unregister(Volume volume, int layer) { }

}

