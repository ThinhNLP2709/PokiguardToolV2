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
	[BurstCompile]
	internal struct IncludeExcludeListFilter // TypeDefIndex: 12846
	{
		// Fields
		public NativeParallelHashSet<EntityId> IncludeInstanceIDs; // 0x00
		public NativeParallelHashSet<EntityId> ExcludeInstanceIDs; // 0x10
		public bool IsIncludeEnabled; // 0x20
		public bool IsExcludeEnabled; // 0x21
	
		// Properties
		public bool IsEnabled { get; } // 0x0000000181F226B0-0x0000000181F226C0 
		public bool IsIncludeEmpty { get; } // 0x0000000180C4EE20-0x0000000180C4EE60 
		public bool IsExcludeEmpty { get; } // 0x0000000181F226C0-0x0000000181F22700 
	
		// Constructors
		public IncludeExcludeListFilter(NativeArray<EntityId> includeGameObjects, NativeArray<EntityId> includeEntities, NativeArray<EntityId> excludeGameObjects, NativeArray<EntityId> excludeEntities, Allocator allocator); // 0x0000000181F224A0-0x0000000181F226B0
	
		// Methods
		public void Dispose(); // 0x0000000181F222B0-0x0000000181F22300
		public JobHandle Dispose(JobHandle dependencies); // 0x0000000181F22300-0x0000000181F223D0
		public bool DoesPassFilter(EntityId instanceID); // 0x0000000181F223D0-0x0000000181F22430
		public static IncludeExcludeListFilter GetEmptyFilter(Allocator allocator); // 0x0000000181F22430-0x0000000181F224A0
	}
}
