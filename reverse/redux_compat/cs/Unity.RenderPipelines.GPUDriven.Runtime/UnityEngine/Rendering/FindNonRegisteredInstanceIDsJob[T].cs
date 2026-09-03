/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct FindNonRegisteredInstanceIDsJob<T> : IJobParallelFor // TypeDefIndex: 12742
		where T : struct
	{
		// Fields
		public const int MaxBatchSize = 128; // Metadata: 0x006A7589
		[ReadOnly]
		public NativeArray<JaggedJobRange> jobRanges;
		[ReadOnly]
		public JaggedSpan<EntityId> jaggedInstanceIDs;
		[ReadOnly]
		public NativeParallelHashMap<EntityId, T> hashMap;
		[WriteOnly]
		public NativeParallelHashSet<EntityId> outInstanceIDWriter;
	
		// Methods
		public void Execute(int jobIndex);
	}
}
