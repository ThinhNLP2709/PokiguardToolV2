namespace UnityEngine.Rendering;

internal class ProbeBrickBlendingPool
{
	private static ComputeShader stateBlendShader; //Field offset: 0x0
	private static int scenarioBlendingKernel; //Field offset: 0x8
	private static readonly int _PoolDim_LerpFactor; //Field offset: 0xC
	private static readonly int _ChunkList; //Field offset: 0x10
	private static readonly int _State0_L0_L1Rx; //Field offset: 0x14
	private static readonly int _State0_L1G_L1Ry; //Field offset: 0x18
	private static readonly int _State0_L1B_L1Rz; //Field offset: 0x1C
	private static readonly int _State0_L2_0; //Field offset: 0x20
	private static readonly int _State0_L2_1; //Field offset: 0x24
	private static readonly int _State0_L2_2; //Field offset: 0x28
	private static readonly int _State0_L2_3; //Field offset: 0x2C
	private static readonly int _State0_ProbeOcclusion; //Field offset: 0x30
	private static readonly int _State1_L0_L1Rx; //Field offset: 0x34
	private static readonly int _State1_L1G_L1Ry; //Field offset: 0x38
	private static readonly int _State1_L1B_L1Rz; //Field offset: 0x3C
	private static readonly int _State1_L2_0; //Field offset: 0x40
	private static readonly int _State1_L2_1; //Field offset: 0x44
	private static readonly int _State1_L2_2; //Field offset: 0x48
	private static readonly int _State1_L2_3; //Field offset: 0x4C
	private static readonly int _State1_ProbeOcclusion; //Field offset: 0x50
	private Vector4[] m_ChunkList; //Field offset: 0x10
	private int m_MappedChunks; //Field offset: 0x18
	private ProbeBrickPool m_State0; //Field offset: 0x20
	private ProbeBrickPool m_State1; //Field offset: 0x28
	private ProbeVolumeTextureMemoryBudget m_MemoryBudget; //Field offset: 0x30
	private ProbeVolumeSHBands m_ShBands; //Field offset: 0x34
	private bool m_ProbeOcclusion; //Field offset: 0x38

	internal int estimatedVMemCost
	{
		internal get { } //Length: 547
	}

	internal bool isAllocated
	{
		internal get { } //Length: 9
	}

	private static ProbeBrickBlendingPool() { }

	internal ProbeBrickBlendingPool(ProbeVolumeBlendingTextureMemoryBudget memoryBudget, ProbeVolumeSHBands shBands, bool probeOcclusion) { }

	internal bool Allocate(int numberOfBrickChunks, List<BrickChunkAlloc> outAllocations) { }

	internal void AllocateResourcesIfNeeded() { }

	internal void BlendChunks(Cell cell, ProbeBrickPool dstPool) { }

	internal void Cleanup() { }

	internal void Clear() { }

	internal void Deallocate(List<BrickChunkAlloc> allocations) { }

	internal void EnsureTextureValidity() { }

	internal int get_estimatedVMemCost() { }

	internal bool get_isAllocated() { }

	internal int GetPoolDepth() { }

	internal int GetPoolHeight() { }

	internal int GetPoolWidth() { }

	internal static void Initialize() { }

	internal void PerformBlending(CommandBuffer cmd, float factor, ProbeBrickPool dstPool) { }

	internal void Update(CommandBuffer cmd, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, List<BrickChunkAlloc> dstLocations, ProbeVolumeSHBands bands, int state, Texture validityTexture, bool skyOcclusion, Texture skyOcclusionTexture, bool skyShadingDirections, Texture skyShadingDirectionsTexture, bool probeOcclusion) { }

	internal void Update(DataLocation source, List<BrickChunkAlloc> srcLocations, List<BrickChunkAlloc> dstLocations, int destStartIndex, ProbeVolumeSHBands bands, int state) { }

}

