/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ProbeBrickBlendingPool // TypeDefIndex: 5552
	{
		// Fields
		private static ComputeShader stateBlendShader; // 0x00
		private static int scenarioBlendingKernel; // 0x08
		private static readonly int _PoolDim_LerpFactor; // 0x0C
		private static readonly int _ChunkList; // 0x10
		private static readonly int _State0_L0_L1Rx; // 0x14
		private static readonly int _State0_L1G_L1Ry; // 0x18
		private static readonly int _State0_L1B_L1Rz; // 0x1C
		private static readonly int _State0_L2_0; // 0x20
		private static readonly int _State0_L2_1; // 0x24
		private static readonly int _State0_L2_2; // 0x28
		private static readonly int _State0_L2_3; // 0x2C
		private static readonly int _State0_ProbeOcclusion; // 0x30
		private static readonly int _State1_L0_L1Rx; // 0x34
		private static readonly int _State1_L1G_L1Ry; // 0x38
		private static readonly int _State1_L1B_L1Rz; // 0x3C
		private static readonly int _State1_L2_0; // 0x40
		private static readonly int _State1_L2_1; // 0x44
		private static readonly int _State1_L2_2; // 0x48
		private static readonly int _State1_L2_3; // 0x4C
		private static readonly int _State1_ProbeOcclusion; // 0x50
		private Vector4[] m_ChunkList; // 0x10
		private int m_MappedChunks; // 0x18
		private ProbeBrickPool m_State0; // 0x20
		private ProbeBrickPool m_State1; // 0x28
		private ProbeVolumeTextureMemoryBudget m_MemoryBudget; // 0x30
		private ProbeVolumeSHBands m_ShBands; // 0x34
		private bool m_ProbeOcclusion; // 0x38
	
		// Properties
		internal bool isAllocated { get; } // 0x00000001817D1AF0-0x00000001817D1B00 
		internal int estimatedVMemCost { get; } // 0x0000000181E55BD0-0x0000000181E55DD0 
	
		// Constructors
		internal ProbeBrickBlendingPool(ProbeVolumeBlendingTextureMemoryBudget memoryBudget, ProbeVolumeSHBands shBands, bool probeOcclusion); // 0x0000000181E55B80-0x0000000181E55BD0
		static ProbeBrickBlendingPool(); // 0x0000000181E55830-0x0000000181E55B80
	
		// Methods
		internal static void Initialize(); // 0x0000000181E54830-0x0000000181E54990
		internal int GetPoolWidth(); // 0x0000000181E54810-0x0000000181E54830
		internal int GetPoolHeight(); // 0x0000000181E547F0-0x0000000181E54810
		internal int GetPoolDepth(); // 0x0000000181E547D0-0x0000000181E547F0
		internal void AllocateResourcesIfNeeded(); // 0x0000000181E541F0-0x0000000181E54380
		internal void Update(ProbeBrickPool.DataLocation source, List<ProbeBrickPool.BrickChunkAlloc> srcLocations, List<ProbeBrickPool.BrickChunkAlloc> dstLocations, int destStartIndex, ProbeVolumeSHBands bands, int state); // 0x0000000181E55650-0x0000000181E556F0
		internal void Update(CommandBuffer cmd, ProbeReferenceVolume.CellStreamingScratchBuffer dataBuffer, ProbeReferenceVolume.CellStreamingScratchBufferLayout layout, List<ProbeBrickPool.BrickChunkAlloc> dstLocations, ProbeVolumeSHBands bands, int state, Texture validityTexture, bool skyOcclusion, Texture skyOcclusionTexture, bool skyShadingDirections, Texture skyShadingDirectionsTexture, bool probeOcclusion); // 0x0000000181E556F0-0x0000000181E55830
		internal void PerformBlending(CommandBuffer cmd, float factor, ProbeBrickPool dstPool); // 0x0000000181E54990-0x0000000181E55650
		internal void BlendChunks(ProbeReferenceVolume.Cell cell, ProbeBrickPool dstPool); // 0x0000000181E54560-0x0000000181E546D0
		internal void Clear(); // 0x0000000181E54720-0x0000000181E54760
		internal bool Allocate(int numberOfBrickChunks, List<ProbeBrickPool.BrickChunkAlloc> outAllocations); // 0x0000000181E54380-0x0000000181E54560
		internal void Deallocate(List<ProbeBrickPool.BrickChunkAlloc> allocations); // 0x0000000181E54760-0x0000000181E54790
		internal void EnsureTextureValidity(); // 0x0000000181E54790-0x0000000181E547D0
		internal void Cleanup(); // 0x0000000181E546D0-0x0000000181E54720
	}
}
