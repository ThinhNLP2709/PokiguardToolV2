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
	internal struct PrefixSumDrawInstancesJob : IJob // TypeDefIndex: 12738
	{
		// Fields
		[ReadOnly]
		public NativeParallelHashMap<RangeKey, int> rangeHash; // 0x00
		public NativeList<DrawRange> drawRanges; // 0x10
		public NativeList<DrawBatch> drawBatches; // 0x18
		public NativeArray<int> drawBatchIndices; // 0x20
	
		// Methods
		public void Execute(); // 0x0000000181F19300-0x0000000181F194A0
	}
}
