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
	internal struct WriteGPUComponentDataJob : IJobParallelFor // TypeDefIndex: 12781
	{
		// Fields
		[ReadOnly]
		public NativeArray<JaggedJobRange> JobRanges; // 0x00
		[ReadOnly]
		public int ComponentOffsetInBytes; // 0x10
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public JaggedSpan<byte> JaggedInstanceData; // 0x18
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<byte> UploadBuffer; // 0x38
	
		// Methods
		public void Execute(int jobIndex); // 0x0000000181F1C250-0x0000000181F1C2D0
	}
}
