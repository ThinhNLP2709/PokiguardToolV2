/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ProbeBrickPool // TypeDefIndex: 5549
	{
		// Fields
		private static readonly ProfilerMarker k_CreateProbeBrickPool; // 0x00
		internal static readonly int _Out_L0_L1Rx; // 0x08
		internal static readonly int _Out_L1G_L1Ry; // 0x0C
		internal static readonly int _Out_L1B_L1Rz; // 0x10
		internal static readonly int _Out_Shared; // 0x14
		internal static readonly int _Out_ProbeOcclusion; // 0x18
		internal static readonly int _Out_SkyOcclusionL0L1; // 0x1C
		internal static readonly int _Out_SkyShadingDirectionIndices; // 0x20
		internal static readonly int _Out_L2_0; // 0x24
		internal static readonly int _Out_L2_1; // 0x28
		internal static readonly int _Out_L2_2; // 0x2C
		internal static readonly int _Out_L2_3; // 0x30
		internal static readonly int _ProbeVolumeScratchBufferLayout; // 0x34
		internal static readonly int _ProbeVolumeScratchBuffer; // 0x38
		private const int kChunkSizeInBricks = 128; // Metadata: 0x006616E3
		internal const int kBrickCellCount = 3; // Metadata: 0x006616E5
		internal const int kBrickProbeCountPerDim = 4; // Metadata: 0x006616E6
		internal const int kBrickProbeCountTotal = 64; // Metadata: 0x006616E7
		internal const int kChunkProbeCountPerDim = 512; // Metadata: 0x006616E9
		[CompilerGenerated]
		private int _estimatedVMemCost_k__BackingField; // 0x10
		private const int kMaxPoolWidth = 2048; // Metadata: 0x006616EB
		internal DataLocation m_Pool; // 0x18
		private BrickChunkAlloc m_NextFreeChunk; // 0x80
		private Stack<BrickChunkAlloc> m_FreeList; // 0x90
		private int m_AvailableChunkCount; // 0x98
		private ProbeVolumeSHBands m_SHBands; // 0x9C
		private bool m_ContainsValidity; // 0xA0
		private bool m_ContainsProbeOcclusion; // 0xA1
		private bool m_ContainsRenderingLayers; // 0xA2
		private bool m_ContainsSkyOcclusion; // 0xA3
		private bool m_ContainsSkyShadingDirection; // 0xA4
		private static ComputeShader s_DataUploadCS; // 0x40
		private static int s_DataUploadKernel; // 0x48
		private static ComputeShader s_DataUploadL2CS; // 0x50
		private static int s_DataUploadL2Kernel; // 0x58
		private static LocalKeyword s_DataUpload_Shared; // 0x60
		private static LocalKeyword s_DataUpload_ProbeOcclusion; // 0x78
		private static LocalKeyword s_DataUpload_SkyOcclusion; // 0x90
		private static LocalKeyword s_DataUpload_SkyShadingDirection; // 0xA8
	
		// Properties
		internal int estimatedVMemCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Nested types
		[DebuggerDisplay("Chunk ({x}, {y}, {z})")]
		public struct BrickChunkAlloc // TypeDefIndex: 5550
		{
			// Fields
			public int x; // 0x00
			public int y; // 0x04
			public int z; // 0x08
	
			// Methods
			internal int flattenIndex(int sx, int sy); // 0x0000000181E52A90-0x0000000181E52AB0
		}
	
		public struct DataLocation // TypeDefIndex: 5551
		{
			// Fields
			internal Texture TexL0_L1rx; // 0x00
			internal Texture TexL1_G_ry; // 0x08
			internal Texture TexL1_B_rz; // 0x10
			internal Texture TexL2_0; // 0x18
			internal Texture TexL2_1; // 0x20
			internal Texture TexL2_2; // 0x28
			internal Texture TexL2_3; // 0x30
			internal Texture TexProbeOcclusion; // 0x38
			internal Texture TexValidity; // 0x40
			internal Texture TexSkyOcclusion; // 0x48
			internal Texture TexSkyShadingDirectionIndices; // 0x50
			internal int width; // 0x58
			internal int height; // 0x5C
			internal int depth; // 0x60
	
			// Methods
			internal void Cleanup(); // 0x0000000181E52F60-0x0000000181E530D0
		}
	
		// Constructors
		internal ProbeBrickPool(ProbeVolumeTextureMemoryBudget memoryBudget, ProbeVolumeSHBands shBands, bool allocateValidityData = false /* Metadata: 0x006616DE */, bool allocateRenderingLayerData = false /* Metadata: 0x006616DF */, bool allocateSkyOcclusion = false /* Metadata: 0x006616E0 */, bool allocateSkyShadingData = false /* Metadata: 0x006616E1 */, bool allocateProbeOcclusionData = false /* Metadata: 0x006616E2 */); // 0x0000000181E5A760-0x0000000181E5A960
		static ProbeBrickPool(); // 0x0000000181E5A4C0-0x0000000181E5A760
	
		// Methods
		internal static int DivRoundUp(int x, int y); // 0x0000000181E58550-0x0000000181E58560
		internal static void Initialize(); // 0x0000000181E58EE0-0x0000000181E59350
		internal Texture GetValidityTexture(); // 0x00000001802F4000-0x00000001802F4010
		internal Texture GetSkyOcclusionTexture(); // 0x0000000180333260-0x0000000180333490
		internal Texture GetSkyShadingDirectionIndicesTexture(); // 0x0000000180316960-0x0000000180316970
		internal Texture GetProbeOcclusionTexture(); // 0x00000001806CCC00-0x00000001806CCC10
		internal void AllocatePool(int width, int height, int depth); // 0x0000000181E57760-0x0000000181E578F0
		public int GetRemainingChunkCount(); // 0x000000018033D1D0-0x000000018033D1E0
		internal void EnsureTextureValidity(); // 0x0000000181E58560-0x0000000181E585F0
		internal bool EnsureTextureValidity(bool renderingLayers, bool skyOcclusion, bool skyDirection, bool probeOcclusion); // 0x0000000181E585F0-0x0000000181E586B0
		internal static int GetChunkSizeInBrickCount(); // 0x0000000180A2FCF0-0x0000000180A2FD00
		internal static int GetChunkSizeInProbeCount(); // 0x0000000180A32720-0x0000000180A32730
		internal int GetPoolWidth(); // 0x0000000180CC2260-0x0000000180CC2270
		internal int GetPoolHeight(); // 0x0000000181974810-0x0000000181974820
		internal Vector3Int GetPoolDimensions(); // 0x0000000181E58840-0x0000000181E58860
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr); // 0x0000000181E58860-0x0000000181E58EE0
		internal void Clear(); // 0x0000000181E57B60-0x0000000181E57BA0
		internal static int GetChunkCount(int brickCount); // 0x0000000181E58830-0x0000000181E58840
		internal bool Allocate(int numberOfBrickChunks, List<BrickChunkAlloc> outAllocations, bool ignoreErrorLog); // 0x0000000181E578F0-0x0000000181E57B50
		internal void Deallocate(List<BrickChunkAlloc> allocations); // 0x0000000181E58410-0x0000000181E58540
		internal void Update(DataLocation source, List<BrickChunkAlloc> srcLocations, List<BrickChunkAlloc> dstLocations, int destStartIndex, ProbeVolumeSHBands bands); // 0x0000000181E59E80-0x0000000181E5A4C0
		internal void Update(CommandBuffer cmd, ProbeReferenceVolume.CellStreamingScratchBuffer dataBuffer, ProbeReferenceVolume.CellStreamingScratchBufferLayout layout, List<BrickChunkAlloc> dstLocations, bool updateSharedData, Texture validityTexture, ProbeVolumeSHBands bands, bool skyOcclusion, Texture skyOcclusionTexture, bool skyShadingDirections, Texture skyShadingDirectionsTexture, bool probeOcclusion); // 0x0000000181E595D0-0x0000000181E59E80
		internal void UpdateValidity(DataLocation source, List<BrickChunkAlloc> srcLocations, List<BrickChunkAlloc> dstLocations, int destStartIndex); // 0x0000000181E593D0-0x0000000181E595D0
		internal static Vector3Int ProbeCountToDataLocSize(int numProbes); // 0x0000000181E59350-0x0000000181E593D0
		private static int EstimateMemoryCost(int width, int height, int depth, GraphicsFormat format); // 0x0000000181E587F0-0x0000000181E58830
		internal static int EstimateMemoryCostForBlending(ProbeVolumeTextureMemoryBudget memoryBudget, bool compressed, ProbeVolumeSHBands bands); // 0x0000000181E586B0-0x0000000181E587F0
		public static Texture CreateDataTexture(int width, int height, int depth, GraphicsFormat format, string name, bool allocateRendertexture, ref int allocatedBytes); // 0x0000000181E58180-0x0000000181E58410
		public static DataLocation CreateDataLocation(int numProbes, bool compressed, ProbeVolumeSHBands bands, string name, bool allocateRendertexture, bool allocateValidityData, bool allocateRenderingLayers, bool allocateSkyOcclusionData, bool allocateSkyShadingDirectionData, bool allocateProbeOcclusionData, out int allocatedBytes); // 0x0000000181E57BA0-0x0000000181E58180
		private static void DerivePoolSizeFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget, out int width, out int height, out int depth); // 0x0000000181E58540-0x0000000181E58550
		internal void Cleanup(); // 0x0000000181E57B50-0x0000000181E57B60
	}
}
