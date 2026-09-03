/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct ReceiverSphereCuller // TypeDefIndex: 12981
	{
		// Fields
		public NativeList<SplitInfo> splitInfos; // 0x00
		public float3x3 worldToLightSpaceRotation; // 0x08
	
		// Nested types
		internal struct SplitInfo // TypeDefIndex: 12982
		{
			// Fields
			public float4 receiverSphereLightSpace; // 0x00
			public float cascadeBlendCullingFactor; // 0x10
		}
	
		// Methods
		internal static ReceiverSphereCuller CreateEmptyForTesting(Allocator allocator); // 0x0000000181F50CF0-0x0000000181F50D70
		internal void Dispose(JobHandle job); // 0x0000000181F512B0-0x0000000181F512E0
		internal bool UseReceiverPlanes(); // 0x0000000181F51400-0x0000000181F51410
		internal static ReceiverSphereCuller Create([IsReadOnly] in BatchCullingContext cc, Allocator allocator); // 0x0000000181F50D70-0x0000000181F512B0
		internal static float DistanceUntilCylinderFullyCrossesPlane(float3 cylinderCenter, float3 cylinderDirection, float cylinderRadius, Plane plane); // 0x0000000181F512E0-0x0000000181F51400
		internal static uint ComputeSplitVisibilityMask(NativeArray<Plane> lightFacingFrustumPlanes, NativeArray<SplitInfo> splitInfos, float3x3 worldToLightSpaceRotation, [IsReadOnly] in AABB bounds); // 0x0000000181F50840-0x0000000181F50CF0
	}
}
