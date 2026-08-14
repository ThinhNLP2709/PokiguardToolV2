namespace UnityEngine.ResourceManagement.ResourceProviders;

internal class BinaryCatalogInitializationData
{
	[SerializeField]
	public int m_BinaryStorageBufferCacheSize; //Field offset: 0x10
	[SerializeField]
	public int m_CatalogLocationCacheSize; //Field offset: 0x14

	public BinaryCatalogInitializationData() { }

}

