/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class ParallelChartIdentification : IDisposable // TypeDefIndex: 13649
	{
		// Fields
		private readonly MeshChartIdentificationJob[] _jobs; // 0x10
		private readonly JobHandle[] _jobHandles; // 0x18
		private readonly NativeArray<uint>[] _outputVertexChartIndices; // 0x20
		private readonly NativeArray<uint>[] _outputVertexChartIndicesIgnoringNormals; // 0x28
		private readonly NativeArray<uint>[] _outputChartCounts; // 0x30
		private readonly Dictionary<Mesh, uint> _meshToJobIdx; // 0x38
	
		// Nested types
		public struct MeshResult // TypeDefIndex: 13650
		{
			// Fields
			public NativeArray<uint> VertexChartIndices; // 0x00
			public uint ChartCount; // 0x10
			public NativeArray<uint> VertexChartIndicesIgnoringNormals; // 0x18
			public uint ChartCountIgnoringNormals; // 0x28
		}
	
		internal struct MeshChartIdentificationJob : IJob // TypeDefIndex: 13651
		{
			// Fields
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<uint> InputVertexIndexBuffer; // 0x00
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<float2> InputVertexUvBuffer; // 0x10
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<float3> InputVertexPositionBuffer; // 0x20
			[DeallocateOnJobCompletion]
			[ReadOnly]
			public NativeArray<float3> InputVertexNormalBuffer; // 0x30
			public NativeArray<uint> OutputVertexChartIndicesBuffer; // 0x40
			public NativeArray<uint> OutputVertexChartIndicesIgnoringNormalsBuffer; // 0x50
			public NativeArray<uint> OutputChartCount; // 0x60
	
			// Methods
			public void Execute(); // 0x0000000181E11420-0x0000000181E11740
		}
	
		// Constructors
		public ParallelChartIdentification(IList<Mesh> meshes); // 0x0000000181E11CB0-0x0000000181E12300
	
		// Methods
		public void Start(); // 0x0000000181E11BD0-0x0000000181E11CB0
		public MeshResult CompleteAndGetResult(Mesh mesh); // 0x0000000181E118F0-0x0000000181E11A30
		public void Dispose(); // 0x0000000181E11A30-0x0000000181E11BD0
	}
}
