namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DefaultMember("Item")]
internal class ResourcesData
{
	public const int MaxVersions = 20; //Field offset: 0x0
	public const int MaxReaders = 100; //Field offset: 0x0
	public NativeList<ResourceUnversionedData>[] unversionedData; //Field offset: 0x10
	public NativeList<ResourceVersionedData>[] versionedData; //Field offset: 0x18
	public NativeList<ResourceReaderData>[] readerData; //Field offset: 0x20
	public DynamicArray<Name>[] resourceNames; //Field offset: 0x28

	public ResourceVersionedData Item
	{
		 get { } //Length: 269
	}

	public ResourcesData() { }

	public void Clear() { }

	public void Dispose() { }

	public ResourceVersionedData get_Item(ResourceHandle h) { }

	public static int Index(ResourceHandle h) { }

	public static int IndexReader(ResourceHandle h, int readerID) { }

	public void Initialize(RenderGraphResourceRegistry resources) { }

}

