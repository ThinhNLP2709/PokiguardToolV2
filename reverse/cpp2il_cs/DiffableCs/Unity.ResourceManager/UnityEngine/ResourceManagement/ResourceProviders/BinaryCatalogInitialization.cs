namespace UnityEngine.ResourceManagement.ResourceProviders;

public class BinaryCatalogInitialization : IInitializableObject
{
	public const int kDefaultBinaryStorageBufferCacheSize = 128; //Field offset: 0x0
	public const int kCatalogLocationCacheSize = 32; //Field offset: 0x0
	private static int s_BinaryStorageBufferCacheSize; //Field offset: 0x0
	private static int s_CatalogLocationCacheSize; //Field offset: 0x4

	public static int BinaryStorageBufferCacheSize
	{
		 get { } //Length: 77
	}

	public static int CatalogLocationCacheSize
	{
		 get { } //Length: 78
	}

	private static BinaryCatalogInitialization() { }

	public BinaryCatalogInitialization() { }

	public static int get_BinaryStorageBufferCacheSize() { }

	public static int get_CatalogLocationCacheSize() { }

	public override bool Initialize(string id, string dataStr) { }

	public override AsyncOperationHandle<Boolean> InitializeAsync(ResourceManager resourceManager, string id, string dataStr) { }

	public static void ResetToDefaults() { }

}

