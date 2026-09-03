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
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalCreateDrawCallSystem // TypeDefIndex: 9422
	{
		// Fields
		private DecalEntityManager m_EntityManager; // 0x10
		private ProfilingSampler m_Sampler; // 0x18
		private float m_MaxDrawDistance; // 0x20
	
		// Properties
		public float maxDrawDistance { get; set; } // 0x0000000181CE2820-0x0000000181CE2830 0x0000000181CE28D0-0x0000000181CE28E0
	
		// Nested types
		[BurstCompile]
		internal struct DrawCallJob : IJob // TypeDefIndex: 9423
		{
			// Fields
			[ReadOnly]
			public NativeArray<float4x4> decalToWorlds; // 0x00
			[ReadOnly]
			public NativeArray<float4x4> normalToWorlds; // 0x10
			[ReadOnly]
			public NativeArray<float4x4> sizeOffsets; // 0x20
			[ReadOnly]
			public NativeArray<float2> drawDistances; // 0x30
			[ReadOnly]
			public NativeArray<float2> angleFades; // 0x40
			[ReadOnly]
			public NativeArray<float4> uvScaleBiases; // 0x50
			[ReadOnly]
			public NativeArray<int> layerMasks; // 0x60
			[ReadOnly]
			public NativeArray<ulong> sceneLayerMasks; // 0x70
			[ReadOnly]
			public NativeArray<float> fadeFactors; // 0x80
			[ReadOnly]
			public NativeArray<BoundingSphere> boundingSpheres; // 0x90
			[ReadOnly]
			public NativeArray<uint> renderingLayerMasks; // 0xA0
			public Vector3 cameraPosition; // 0xB0
			public ulong sceneCullingMask; // 0xC0
			public int cullingMask; // 0xC8
			[ReadOnly]
			public NativeArray<int> visibleDecalIndices; // 0xD0
			public int visibleDecalCount; // 0xE0
			public float maxDrawDistance; // 0xE4
			[WriteOnly]
			public NativeArray<float4x4> decalToWorldsDraw; // 0xE8
			[WriteOnly]
			public NativeArray<float4x4> normalToDecalsDraw; // 0xF8
			[WriteOnly]
			public NativeArray<float> renderingLayerMasksDraw; // 0x108
			[WriteOnly]
			public NativeArray<DecalSubDrawCall> subCalls; // 0x118
			[WriteOnly]
			public NativeArray<int> subCallCount; // 0x128
	
			// Methods
			public void Execute(); // 0x0000000181F7EFA0-0x0000000181F7F430
		}
	
		// Constructors
		public DecalCreateDrawCallSystem(DecalEntityManager entityManager, float maxDrawDistance); // 0x0000000181F73890-0x0000000181F73930
	
		// Methods
		public void Execute(); // 0x0000000181F73270-0x0000000181F73660
		private void Execute(DecalCachedChunk cachedChunk, DecalCulledChunk culledChunk, DecalDrawCallChunk drawCallChunk, int count); // 0x0000000181F73660-0x0000000181F73890
	}
}
