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
	internal sealed class RestructureBvh : IDisposable // TypeDefIndex: 14261
	{
		// Fields
		private readonly ComputeShader shader; // 0x10
		private readonly int kernelInitPrimitiveCounts; // 0x18
		private readonly int kernelFindTreeletRoots; // 0x1C
		private readonly int kernelRestructure; // 0x20
		private readonly int kernelPrepareTreeletsDispatchSize; // 0x24
		private const int numIterations = 3; // Metadata: 0x006A9603
		private readonly GraphicsBuffer treeletDispatchIndirectBuffer; // 0x28
		private const uint kGroupSize = 256; // Metadata: 0x006A9604
		private const uint kTrianglesPerThread = 8; // Metadata: 0x006A9606
		private const uint kTrianglesPerGroup = 2048; // Metadata: 0x006A9607
		private const uint kMinPrimitivesPerTreelet = 64; // Metadata: 0x006A9609
		private const int kMaxThreadGroupsPerDispatch = 65535; // Metadata: 0x006A960A
	
		// Nested types
		private struct ScratchBufferLayout // TypeDefIndex: 14262
		{
			// Fields
			public uint LeafParents; // 0x00
			public uint TreeletCount; // 0x04
			public uint TreeletRoots; // 0x08
			public uint PrimitiveCounts; // 0x0C
			public uint TotalSize; // 0x10
	
			// Methods
			public static ScratchBufferLayout Create(uint triangleCount); // 0x00000001821233C0-0x0000000182123400
			private uint Reserve(uint size); // 0x0000000182123570-0x0000000182123580
		}
	
		// Constructors
		public RestructureBvh(RadeonRaysShaders shaders); // 0x00000001821222D0-0x0000000182122420
	
		// Methods
		public void Dispose(); // 0x00000001821219D0-0x00000001821219F0
		public ulong GetScratchDataSizeInDwords(uint triangleCount); // 0x00000001821222C0-0x00000001821222D0
		public void Execute(CommandBuffer cmd, GraphicsBuffer vertices, int verticesOffset, uint vertexStride, uint triangleCount, GraphicsBuffer scratch, [IsReadOnly] in BottomLevelAccelStruct result); // 0x0000000182121D90-0x0000000182122060
		public void Execute(CommandBuffer cmd, GraphicsBuffer aabbBuffer, uint triangleCount, GraphicsBuffer scratch, [IsReadOnly] in BottomLevelAccelStruct result); // 0x0000000182122060-0x00000001821222C0
		private void ExecuteKernels(CommandBuffer cmd, GraphicsBuffer vertices, GraphicsBuffer aabbBuffer, GraphicsBuffer scratch, uint triangleCount, [IsReadOnly] in BottomLevelAccelStruct result); // 0x00000001821219F0-0x0000000182121D90
		private void BindKernelArguments(CommandBuffer cmd, int kernel, GraphicsBuffer vertices, GraphicsBuffer aabbBuffer, GraphicsBuffer scratch, BottomLevelAccelStruct result); // 0x0000000182121810-0x00000001821219D0
	}
}
