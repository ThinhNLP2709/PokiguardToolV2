/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalUpdateCachedSystem // TypeDefIndex: 9434
	{
		// Fields
		private DecalEntityManager m_EntityManager; // 0x10
		private ProfilingSampler m_Sampler; // 0x18
		private ProfilingSampler m_SamplerJob; // 0x20
	
		// Nested types
		[BurstCompile]
		public struct UpdateTransformsJob : IJobParallelForTransform // TypeDefIndex: 9435
		{
			// Fields
			private static readonly quaternion k_MinusYtoZRotation; // 0x00
			public NativeArray<float3> positions; // 0x00
			public NativeArray<quaternion> rotations; // 0x10
			public NativeArray<float3> scales; // 0x20
			public NativeArray<bool> dirty; // 0x30
			[ReadOnly]
			public NativeArray<DecalScaleMode> scaleModes; // 0x40
			[ReadOnly]
			public NativeArray<float4x4> sizeOffsets; // 0x50
			[WriteOnly]
			public NativeArray<float4x4> decalToWorlds; // 0x60
			[WriteOnly]
			public NativeArray<float4x4> normalToWorlds; // 0x70
			[WriteOnly]
			public NativeArray<BoundingSphere> boundingSpheres; // 0x80
			public float minDistance; // 0x90
	
			// Constructors
			static UpdateTransformsJob(); // 0x0000000181F876D0-0x0000000181F87740
	
			// Methods
			private float DistanceBetweenQuaternions(quaternion a, quaternion b); // 0x0000000181F86900-0x0000000181F86960
			public void Execute(int index, TransformAccess transform); // 0x0000000181F86960-0x0000000181F87270
			private BoundingSphere GetDecalProjectBoundingSphere(Matrix4x4 decalToWorld); // 0x0000000181F87270-0x0000000181F876D0
		}
	
		// Constructors
		public DecalUpdateCachedSystem(DecalEntityManager entityManager); // 0x0000000181F7E6B0-0x0000000181F7E780
	
		// Methods
		public void Execute(); // 0x0000000181F7E550-0x0000000181F7E6B0
		private void Execute(DecalEntityChunk entityChunk, DecalCachedChunk cachedChunk, int count); // 0x0000000181F7E250-0x0000000181F7E550
	}
}
