namespace UnityEngine.Rendering.Universal;

internal class DecalEntityManager : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<CombinedChunks> <>9__26_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <Update>b__26_0(CombinedChunks a, CombinedChunks b) { }

	}

	private struct CombinedChunks
	{
		public DecalEntityChunk entityChunk; //Field offset: 0x0
		public DecalCachedChunk cachedChunk; //Field offset: 0x8
		public DecalCulledChunk culledChunk; //Field offset: 0x10
		public DecalDrawCallChunk drawCallChunk; //Field offset: 0x18
		public int previousChunkIndex; //Field offset: 0x20
		public bool valid; //Field offset: 0x24

	}

	public List<DecalEntityChunk> entityChunks; //Field offset: 0x10
	public List<DecalCachedChunk> cachedChunks; //Field offset: 0x18
	public List<DecalCulledChunk> culledChunks; //Field offset: 0x20
	public List<DecalDrawCallChunk> drawCallChunks; //Field offset: 0x28
	public int chunkCount; //Field offset: 0x30
	private ProfilingSampler m_AddDecalSampler; //Field offset: 0x38
	private ProfilingSampler m_ResizeChunks; //Field offset: 0x40
	private ProfilingSampler m_SortChunks; //Field offset: 0x48
	private DecalEntityIndexer m_DecalEntityIndexer; //Field offset: 0x50
	private Dictionary<Material, Int32> m_MaterialToChunkIndex; //Field offset: 0x58
	private List<CombinedChunks> m_CombinedChunks; //Field offset: 0x60
	private List<Int32> m_CombinedChunkRemmap; //Field offset: 0x68
	private Material m_ErrorMaterial; //Field offset: 0x70
	private Mesh m_DecalProjectorMesh; //Field offset: 0x78

	public Mesh decalProjectorMesh
	{
		 get { } //Length: 238
	}

	public Material errorMaterial
	{
		 get { } //Length: 186
	}

	public DecalEntityManager() { }

	private int CreateChunkIndex(Material material) { }

	public DecalEntity CreateDecalEntity(DecalProjector decalProjector) { }

	public void DestroyDecalEntity(DecalEntity decalEntity) { }

	public override void Dispose() { }

	public Mesh get_decalProjectorMesh() { }

	public Material get_errorMaterial() { }

	public bool IsValid(DecalEntity decalEntity) { }

	public void Update() { }

	public void UpdateAllDecalEntitiesData() { }

	public void UpdateDecalEntityData(DecalEntity decalEntity, DecalProjector decalProjector) { }

}

