/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal class HlbvhBuilder // TypeDefIndex: 14236
	{
		// Fields
		private readonly ComputeShader shaderBuildHlbvh; // 0x10
		private readonly int kernelInit; // 0x18
		private readonly int kernelCalculateAabb; // 0x1C
		private readonly int kernelCalculateMortonCodes; // 0x20
		private readonly int kernelBuildTreeBottomUp; // 0x24
		private readonly RadixSort radixSort; // 0x28
		private const uint kTrianglesPerThread = 8; // Metadata: 0x006A95E8
		private const uint kGroupSize = 256; // Metadata: 0x006A95E9
		private const uint kTrianglesPerGroup = 2048; // Metadata: 0x006A95EB
	
		// Nested types
		private interface IKernelResourcesBinder // TypeDefIndex: 14237
		{
			// Methods
			void BindTexAndBuffers(CommandBuffer cmd, int kernel, bool setSortedCodes);
		}
	
		private struct AabbsBvhResourcesBinder : IKernelResourcesBinder // TypeDefIndex: 14238
		{
			// Fields
			public ComputeShader shaderBuildHlbvh; // 0x00
			public GraphicsBuffer aabbBuffer; // 0x08
			public GraphicsBuffer scratch; // 0x10
			public ScratchBufferLayout scratchLayout; // 0x18
			public BottomLevelAccelStruct blas; // 0x40
	
			// Methods
			public void Init(ComputeShader shaderBuildHlbvh, GraphicsBuffer aabbBuffer, GraphicsBuffer scratch, ScratchBufferLayout scratchLayout, BottomLevelAccelStruct blas); // 0x000000018210AC20-0x000000018210ACB0
			public void BindTexAndBuffers(CommandBuffer cmd, int kernel, bool setSortedCodes); // 0x000000018210AA70-0x000000018210AC20
		}
	
		private struct TrianglesBvhResourcesBinder : IKernelResourcesBinder // TypeDefIndex: 14239
		{
			// Fields
			public ComputeShader shaderBuildHlbvh; // 0x00
			public GraphicsBuffer vertices; // 0x08
			public GraphicsBuffer indices; // 0x10
			public GraphicsBuffer scratch; // 0x18
			public ScratchBufferLayout scratchLayout; // 0x20
			public BottomLevelAccelStruct blas; // 0x48
	
			// Methods
			public void Init(ComputeShader shaderBuildHlbvh, GraphicsBuffer vertices, GraphicsBuffer indices, GraphicsBuffer scratch, ScratchBufferLayout scratchLayout, BottomLevelAccelStruct blas); // 0x0000000182124AE0-0x0000000182124B80
			public void BindTexAndBuffers(CommandBuffer cmd, int kernel, bool setSortedCodes); // 0x0000000182124900-0x0000000182124AE0
		}
	
		private struct ScratchBufferLayout // TypeDefIndex: 14240
		{
			// Fields
			public uint PrimitiveRefs; // 0x00
			public uint MortonCodes; // 0x04
			public uint SortedPrimitiveRefs; // 0x08
			public uint SortedMortonCodes; // 0x0C
			public uint SortMemory; // 0x10
			public uint Aabb; // 0x14
			public uint LeafParents; // 0x18
			public uint InternalNodeRange; // 0x1C
			public uint TotalSize; // 0x20
	
			// Methods
			public static ScratchBufferLayout Create(uint triangleCount); // 0x0000000182123400-0x00000001821234C0
			private uint Reserve(uint size); // 0x0000000182123580-0x0000000182123590
		}
	
		// Constructors
		public HlbvhBuilder(RadeonRaysShaders shaders); // 0x000000018211EC30-0x000000018211ED70
	
		// Methods
		public static uint GetScratchDataSizeInDwords(uint triangleCount); // 0x000000018211EC10-0x000000018211EC30
		public static uint GetBvhNodeCount(uint leafCount); // 0x00000001805DFE90-0x00000001805DFEA0
		public static uint GetResultDataSizeInDwords(uint triangleCount); // 0x000000018211EC00-0x000000018211EC10
		public void Execute(CommandBuffer cmd, GraphicsBuffer vertices, int verticesOffset, uint vertexStride, GraphicsBuffer indices, int indicesOffset, int baseIndex, IndexFormat indexFormat, uint triangleCount, GraphicsBuffer scratch, [IsReadOnly] in BottomLevelAccelStruct result); // 0x000000018211E280-0x000000018211E7B0
		public void Execute(CommandBuffer cmd, GraphicsBuffer aabbBuffer, uint primCount, GraphicsBuffer scratch, [IsReadOnly] in BottomLevelAccelStruct result); // 0x000000018211E7B0-0x000000018211EC00
		private void ExecuteKernels<TKernelResourcesBinder>(TKernelResourcesBinder binder, CommandBuffer cmd, GraphicsBuffer scratchBuffer, ScratchBufferLayout scratchLayout, uint primCount)
			where TKernelResourcesBinder : IKernelResourcesBinder;
	}
}
