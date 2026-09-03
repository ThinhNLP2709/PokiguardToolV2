/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	[BurstCompile]
	internal struct ComputeTerrainMeshJob : IJobParallelFor // TypeDefIndex: 14291
	{
		// Fields
		[ReadOnly]
		public NativeArray<float> heightmap; // 0x00
		[ReadOnly]
		public NativeArray<bool> holes; // 0x10
		public int width; // 0x20
		public int height; // 0x24
		public float3 heightmapScale; // 0x28
		public NativeArray<float3> positions; // 0x38
		public NativeArray<float2> uvs; // 0x48
		public NativeArray<float3> normals; // 0x58
		[NativeDisableParallelForRestriction]
		public NativeArray<int> indices; // 0x68
	
		// Methods
		public void DisposeArrays(); // 0x0000000182119A20-0x0000000182119AE0
		public void Execute(int index); // 0x0000000182119AE0-0x0000000182119CD0
		private static float3 CalculateTerrainNormal(NativeArray<float> heightmap, int x, int y, int width, int height, float3 scale); // 0x0000000182119610-0x0000000182119A20
		private static float SampleHeight(int x, int y, int width, int height, NativeArray<float> heightmap, float scale); // 0x0000000182119CD0-0x0000000182119D20
	}
}
