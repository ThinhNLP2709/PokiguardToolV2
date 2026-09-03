/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class UVOverlapDetection : IDisposable // TypeDefIndex: 13655
	{
		// Fields
		private int _lightmapResolution; // 0x10
		private ComputeShader _shader; // 0x18
		private NativeArray<float4> _triangleEdges; // 0x20
		private NativeArray<uint> _chartIndices; // 0x30
		private GraphicsBuffer _triangleEdgesBuffer; // 0x40
		private GraphicsBuffer _chartIndicesBuffer; // 0x48
		private GraphicsBuffer _perPixelChart; // 0x50
		private GraphicsBuffer _overlapPixelsBuffer; // 0x58
		private GraphicsBuffer _overlapInstancesBuffer; // 0x60
		private int _overlapKernel; // 0x68
		private uint _overlapKernelSize; // 0x6C
	
		// Nested types
		private static class ShaderProperties // TypeDefIndex: 13656
		{
			// Fields
			public static readonly int TextureSize; // 0x00
			public static readonly int PerPixelChart; // 0x04
			public static readonly int InstanceIndex; // 0x08
			public static readonly int EdgeCount; // 0x0C
			public static readonly int TriangleEdges; // 0x10
			public static readonly int ChartIndices; // 0x14
			public static readonly int OverlapPixels; // 0x18
			public static readonly int OverlapInstances; // 0x1C
			public static readonly int TileX; // 0x20
			public static readonly int TileY; // 0x24
			public static readonly int TileSize; // 0x28
	
			// Constructors
			static ShaderProperties(); // 0x0000000181E132A0-0x0000000181E134B0
		}
	
		// Constructors
		public UVOverlapDetection(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Initialize(ComputeShader shader, uint lightmapResolution, uint maxEdgeCount, uint instanceCount); // 0x0000000181E14B40-0x0000000181E14E50
		public void MarkOverlapsInInstance(CommandBuffer cmd, Mesh uvMesh, NativeArray<uint> vertexToChartIndex, float4 occupiedST, uint instanceIndex, uint chartIndexOffset); // 0x0000000181E14E50-0x0000000181E15350
		public void CompactAndReadbackOverlaps(CommandBuffer cmd, out uint[] uniqueOverlapPixelIndices, out ulong[] uniqueOverlapInstanceIndices); // 0x0000000181E146B0-0x0000000181E14A00
		public void Dispose(); // 0x0000000181E14A00-0x0000000181E14B40
	}
}
