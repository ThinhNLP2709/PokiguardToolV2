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
	internal class HlbvhTopLevelBuilder // TypeDefIndex: 14242
	{
		// Fields
		private readonly ComputeShader shaderBuildHlbvh; // 0x10
		private readonly int kernelInit; // 0x18
		private readonly int kernelCalculateAabb; // 0x1C
		private readonly int kernelCalculateMortonCodes; // 0x20
		private readonly int kernelBuildTreeBottomUp; // 0x24
		private readonly RadixSort radixSort; // 0x28
		private const uint kTrianglesPerThread = 8; // Metadata: 0x006A95EF
		private const uint kGroupSize = 256; // Metadata: 0x006A95F0
		private const uint kTrianglesPerGroup = 2048; // Metadata: 0x006A95F2
	
		// Nested types
		private struct ScratchBufferLayout // TypeDefIndex: 14243
		{
			// Fields
			public uint Aabb; // 0x00
			public uint MortonCodes; // 0x04
			public uint PrimitiveRefs; // 0x08
			public uint SortedMortonCodes; // 0x0C
			public uint SortedPrimitiveRefs; // 0x10
			public uint SortMemory; // 0x14
			public uint InternalNodeRange; // 0x18
			public uint TotalSize; // 0x1C
	
			// Methods
			public static ScratchBufferLayout Create(uint instanceCount); // 0x00000001821234C0-0x0000000182123560
			private uint Reserve(uint size); // 0x0000000182123560-0x0000000182123570
		}
	
		// Constructors
		public HlbvhTopLevelBuilder(RadeonRaysShaders shaders); // 0x000000018211F900-0x000000018211FA40
	
		// Methods
		public static ulong GetScratchDataSizeInDwords(uint instanceCount); // 0x000000018211F8A0-0x000000018211F900
		public static uint GetBvhNodeCount(uint leafCount); // 0x000000018211F890-0x000000018211F8A0
		public void AllocateResultBuffers(uint instanceCount, ref TopLevelAccelStruct accelStruct); // 0x000000018211ED70-0x000000018211EEC0
		public void CreateEmpty(ref TopLevelAccelStruct accelStruct); // 0x000000018211F0C0-0x000000018211F280
		public void Execute(CommandBuffer cmd, GraphicsBuffer scratch, ref TopLevelAccelStruct accelStruct); // 0x000000018211F280-0x000000018211F890
		private void BindKernelArguments(CommandBuffer cmd, int kernel, GraphicsBuffer scratch, ScratchBufferLayout scratchLayout, TopLevelAccelStruct accelStruct, bool setSortedCodes); // 0x000000018211EEC0-0x000000018211F0C0
	}
}
