namespace UnityEngine.Rendering;

internal class ProbeBrickPool
{
	[DebuggerDisplay("Chunk ({x}, {y}, {z})")]
	internal struct BrickChunkAlloc
	{
		public int x; //Field offset: 0x0
		public int y; //Field offset: 0x4
		public int z; //Field offset: 0x8

		internal int flattenIndex(int sx, int sy) { }

	}

	internal struct DataLocation
	{
		internal Texture TexL0_L1rx; //Field offset: 0x0
		internal Texture TexL1_G_ry; //Field offset: 0x8
		internal Texture TexL1_B_rz; //Field offset: 0x10
		internal Texture TexL2_0; //Field offset: 0x18
		internal Texture TexL2_1; //Field offset: 0x20
		internal Texture TexL2_2; //Field offset: 0x28
		internal Texture TexL2_3; //Field offset: 0x30
		internal Texture TexProbeOcclusion; //Field offset: 0x38
		internal Texture TexValidity; //Field offset: 0x40
		internal Texture TexSkyOcclusion; //Field offset: 0x48
		internal Texture TexSkyShadingDirectionIndices; //Field offset: 0x50
		internal int width; //Field offset: 0x58
		internal int height; //Field offset: 0x5C
		internal int depth; //Field offset: 0x60

		internal void Cleanup() { }

	}

	internal static readonly int _Out_L0_L1Rx; //Field offset: 0x0
	internal const int kBrickProbeCountPerDim = 4; //Field offset: 0x0
	internal const int kBrickCellCount = 3; //Field offset: 0x0
	private const int kChunkSizeInBricks = 128; //Field offset: 0x0
	private const int kMaxPoolWidth = 2048; //Field offset: 0x0
	internal const int kBrickProbeCountTotal = 64; //Field offset: 0x0
	internal const int kChunkProbeCountPerDim = 512; //Field offset: 0x0
	internal static readonly int _Out_L1G_L1Ry; //Field offset: 0x4
	internal static readonly int _Out_L1B_L1Rz; //Field offset: 0x8
	internal static readonly int _Out_Shared; //Field offset: 0xC
	internal static readonly int _Out_ProbeOcclusion; //Field offset: 0x10
	internal static readonly int _Out_SkyOcclusionL0L1; //Field offset: 0x14
	internal static readonly int _Out_SkyShadingDirectionIndices; //Field offset: 0x18
	internal static readonly int _Out_L2_0; //Field offset: 0x1C
	internal static readonly int _Out_L2_1; //Field offset: 0x20
	internal static readonly int _Out_L2_2; //Field offset: 0x24
	internal static readonly int _Out_L2_3; //Field offset: 0x28
	internal static readonly int _ProbeVolumeScratchBufferLayout; //Field offset: 0x2C
	internal static readonly int _ProbeVolumeScratchBuffer; //Field offset: 0x30
	private static ComputeShader s_DataUploadCS; //Field offset: 0x38
	private static int s_DataUploadKernel; //Field offset: 0x40
	private static ComputeShader s_DataUploadL2CS; //Field offset: 0x48
	private static int s_DataUploadL2Kernel; //Field offset: 0x50
	private static LocalKeyword s_DataUpload_Shared; //Field offset: 0x58
	private static LocalKeyword s_DataUpload_ProbeOcclusion; //Field offset: 0x70
	private static LocalKeyword s_DataUpload_SkyOcclusion; //Field offset: 0x88
	private static LocalKeyword s_DataUpload_SkyShadingDirection; //Field offset: 0xA0
	[CompilerGenerated]
	private int <estimatedVMemCost>k__BackingField; //Field offset: 0x10
	internal DataLocation m_Pool; //Field offset: 0x18
	private BrickChunkAlloc m_NextFreeChunk; //Field offset: 0x80
	private Stack<BrickChunkAlloc> m_FreeList; //Field offset: 0x90
	private int m_AvailableChunkCount; //Field offset: 0x98
	private ProbeVolumeSHBands m_SHBands; //Field offset: 0x9C
	private bool m_ContainsValidity; //Field offset: 0xA0
	private bool m_ContainsProbeOcclusion; //Field offset: 0xA1
	private bool m_ContainsRenderingLayers; //Field offset: 0xA2
	private bool m_ContainsSkyOcclusion; //Field offset: 0xA3
	private bool m_ContainsSkyShadingDirection; //Field offset: 0xA4

	internal int estimatedVMemCost
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private static ProbeBrickPool() { }

	internal ProbeBrickPool(ProbeVolumeTextureMemoryBudget memoryBudget, ProbeVolumeSHBands shBands, bool allocateValidityData = false, bool allocateRenderingLayerData = false, bool allocateSkyOcclusion = false, bool allocateSkyShadingData = false, bool allocateProbeOcclusionData = false) { }

	internal bool Allocate(int numberOfBrickChunks, List<BrickChunkAlloc> outAllocations, bool ignoreErrorLog) { }

	internal void AllocatePool(int width, int height, int depth) { }

	internal void Cleanup() { }

	internal void Clear() { }

	public static DataLocation CreateDataLocation(int numProbes, bool compressed, ProbeVolumeSHBands bands, string name, bool allocateRendertexture, bool allocateValidityData, bool allocateRenderingLayers, bool allocateSkyOcclusionData, bool allocateSkyShadingDirectionData, bool allocateProbeOcclusionData, out int allocatedBytes) { }

	public static Texture CreateDataTexture(int width, int height, int depth, GraphicsFormat format, string name, bool allocateRendertexture, ref int allocatedBytes) { }

	internal void Deallocate(List<BrickChunkAlloc> allocations) { }

	private static void DerivePoolSizeFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget, out int width, out int height, out int depth) { }

	internal static int DivRoundUp(int x, int y) { }

	internal void EnsureTextureValidity() { }

	internal bool EnsureTextureValidity(bool renderingLayers, bool skyOcclusion, bool skyDirection, bool probeOcclusion) { }

	private static int EstimateMemoryCost(int width, int height, int depth, GraphicsFormat format) { }

	internal static int EstimateMemoryCostForBlending(ProbeVolumeTextureMemoryBudget memoryBudget, bool compressed, ProbeVolumeSHBands bands) { }

	[CompilerGenerated]
	internal int get_estimatedVMemCost() { }

	internal static int GetChunkCount(int brickCount) { }

	internal static int GetChunkSizeInBrickCount() { }

	internal static int GetChunkSizeInProbeCount() { }

	internal Vector3Int GetPoolDimensions() { }

	internal int GetPoolHeight() { }

	internal int GetPoolWidth() { }

	internal Texture GetProbeOcclusionTexture() { }

	public int GetRemainingChunkCount() { }

	internal void GetRuntimeResources(ref RuntimeResources rr) { }

	internal Texture GetSkyOcclusionTexture() { }

	internal Texture GetSkyShadingDirectionIndicesTexture() { }

	internal Texture GetValidityTexture() { }

	internal static void Initialize() { }

	internal static Vector3Int ProbeCountToDataLocSize(int numProbes) { }

	[CompilerGenerated]
	private void set_estimatedVMemCost(int value) { }

	internal void Update(DataLocation source, List<BrickChunkAlloc> srcLocations, List<BrickChunkAlloc> dstLocations, int destStartIndex, ProbeVolumeSHBands bands) { }

	internal void Update(CommandBuffer cmd, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, List<BrickChunkAlloc> dstLocations, bool updateSharedData, Texture validityTexture, ProbeVolumeSHBands bands, bool skyOcclusion, Texture skyOcclusionTexture, bool skyShadingDirections, Texture skyShadingDirectionsTexture, bool probeOcclusion) { }

	internal void UpdateValidity(DataLocation source, List<BrickChunkAlloc> srcLocations, List<BrickChunkAlloc> dstLocations, int destStartIndex) { }

}

