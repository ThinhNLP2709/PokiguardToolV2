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
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct UpdateLODGroupDataJob : IJobParallelFor // TypeDefIndex: 12813
	{
		// Fields
		[ReadOnly]
		public NativeArray<JaggedJobRange> jobRanges; // 0x00
		[ReadOnly]
		public NativeArray<GPUInstanceIndex> lodGroupInstances; // 0x10
		[ReadOnly]
		public LODGroupUpdateBatch updateBatch; // 0x20
		[ReadOnly]
		public bool supportDitheringCrossFade; // 0xE8
		public NativeArray<LODGroupData> lodGroupsData; // 0xF0
		public NativeArray<LODGroupCullingData> lodGroupsCullingData; // 0x100
		[NativeDisableUnsafePtrRestriction]
		public UnsafeAtomicCounter32 rendererCount; // 0x110
	
		// Methods
		public void Execute(int jobIndex); // 0x0000000181F2E3B0-0x0000000181F2EA70
	}
}
