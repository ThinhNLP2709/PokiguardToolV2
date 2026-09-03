/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct UpdateLODGroupTransformJob : IJobParallelFor // TypeDefIndex: 12812
	{
		// Fields
		[ReadOnly]
		public NativeArray<JaggedJobRange> jobRanges; // 0x00
		[ReadOnly]
		public NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash; // 0x10
		[ReadOnly]
		public JaggedSpan<EntityId> jaggedLODGroups; // 0x20
		[ReadOnly]
		public JaggedSpan<float> jaggedWorldSpaceSizes; // 0x40
		[ReadOnly]
		public JaggedSpan<float3> jaggedWorldSpaceReferencePoints; // 0x60
		[ReadOnly]
		public bool requiresGPUUpload; // 0x80
		[ReadOnly]
		public bool supportDitheringCrossFade; // 0x81
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeList<LODGroupData> lodGroupDatas; // 0x88
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeList<LODGroupCullingData> lodGroupCullingDatas; // 0x90
	
		// Methods
		public void Execute(int jobIndex); // 0x0000000181F2EA70-0x0000000181F2ED80
	}
}
