namespace UnityEngine.Rendering;

[MovedFrom(False, "UnityEngine.Rendering", "Unity.RenderPipelines.Core.Runtime", "ProbeVolumeBakingSet.StreamableAsset")]
internal class ProbeVolumeStreamableAsset
{
	[MovedFrom(False, "UnityEngine.Rendering", "Unity.RenderPipelines.Core.Runtime", "ProbeVolumeBakingSet.StreamableAsset.StreamableCellDesc")]
	internal struct StreamableCellDesc
	{
		public int offset; //Field offset: 0x0
		public int elementCount; //Field offset: 0x4

	}

	[FormerlySerializedAs("assetGUID")]
	[SerializeField]
	private string m_AssetGUID; //Field offset: 0x10
	[FormerlySerializedAs("streamableAssetPath")]
	[SerializeField]
	private string m_StreamableAssetPath; //Field offset: 0x18
	[FormerlySerializedAs("elementSize")]
	[SerializeField]
	private int m_ElementSize; //Field offset: 0x20
	[FormerlySerializedAs("streamableCellDescs")]
	[SerializeField]
	private SerializedDictionary<Int32, StreamableCellDesc> m_StreamableCellDescs; //Field offset: 0x28
	[SerializeField]
	private TextAsset m_Asset; //Field offset: 0x30
	private string m_FinalAssetPath; //Field offset: 0x38
	private FileHandle m_AssetFileHandle; //Field offset: 0x40

	public TextAsset asset
	{
		 get { } //Length: 5
	}

	public string assetGUID
	{
		 get { } //Length: 5
	}

	public int elementSize
	{
		 get { } //Length: 4
	}

	public SerializedDictionary<Int32, StreamableCellDesc> streamableCellDescs
	{
		 get { } //Length: 5
	}

	public ProbeVolumeStreamableAsset(string apvStreamingAssetsPath, SerializedDictionary<Int32, StreamableCellDesc> cellDescs, int elementSize, string bakingSetGUID, string assetGUID) { }

	public void CloseFile() { }

	public void Dispose() { }

	public bool FileExists() { }

	public TextAsset get_asset() { }

	public string get_assetGUID() { }

	public int get_elementSize() { }

	public SerializedDictionary<Int32, StreamableCellDesc> get_streamableCellDescs() { }

	public string GetAssetPath() { }

	public long GetFileSize() { }

	public bool IsOpen() { }

	public bool IsValid() { }

	public FileHandle OpenFile() { }

	internal void RefreshAssetPath() { }

}

