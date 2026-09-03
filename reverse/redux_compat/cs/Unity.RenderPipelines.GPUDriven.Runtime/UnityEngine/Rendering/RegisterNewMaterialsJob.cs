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
	internal struct RegisterNewMaterialsJob : IJobParallelFor // TypeDefIndex: 12743
	{
		// Fields
		[ReadOnly]
		public NativeArray<EntityId> instanceIDs; // 0x00
		[ReadOnly]
		public NativeArray<GPUDrivenMaterial> materials; // 0x10
		[WriteOnly]
		public NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap; // 0x20
	
		// Methods
		public void Execute(int index); // 0x0000000181F19D70-0x0000000181F19DC0
	}
}
