/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct InstancesToGPUIndicesJob : IJobParallelFor // TypeDefIndex: 12782
	{
		// Fields
		[ReadOnly]
		public RenderWorld renderWorld; // 0x00
		[ReadOnly]
		public NativeArray<int> instancesCountPrefixSum; // 0x1E0
		[ReadOnly]
		public GPUInstanceDataBufferLayout layout; // 0x1F0
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; // 0x208
		[WriteOnly]
		public NativeArray<GPUInstanceIndex> gpuIndices; // 0x218
	
		// Methods
		public void Execute(int index); // 0x0000000181F17F60-0x0000000181F181D0
	}
}
