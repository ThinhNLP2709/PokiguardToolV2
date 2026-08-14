namespace UnityEngine.Rendering.Universal;

internal class DecalEntityIndexer
{
	internal struct DecalEntityItem
	{
		public int chunkIndex; //Field offset: 0x0
		public int arrayIndex; //Field offset: 0x4
		public int version; //Field offset: 0x8

	}

	private List<DecalEntityItem> m_Entities; //Field offset: 0x10
	private Queue<Int32> m_FreeIndices; //Field offset: 0x18

	public DecalEntityIndexer() { }

	public void Clear() { }

	public DecalEntity CreateDecalEntity(int arrayIndex, int chunkIndex) { }

	public void DestroyDecalEntity(DecalEntity decalEntity) { }

	public DecalEntityItem GetItem(DecalEntity decalEntity) { }

	public bool IsValid(DecalEntity decalEntity) { }

	public void RemapChunkIndices(List<Int32> remaper) { }

	public void UpdateIndex(DecalEntity decalEntity, int newArrayIndex) { }

}

