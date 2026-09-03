/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	internal static class LODGroupDataSystemBurst // TypeDefIndex: 12822
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int GetOrAllocateLODGroupDataInstances_00000154_PostfixBurstDelegate([IsReadOnly] in JaggedSpan<EntityId> jaggedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeList<LODGroupCullingData> lodGroupCullingData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles, ref NativeArray<GPUInstanceIndex> lodGroupInstances); // TypeDefIndex: 12823; 0x0000000180ED8BF0-0x0000000180ED8C10
	
		internal static class GetOrAllocateLODGroupDataInstances_00000154_BurstDirectCall // TypeDefIndex: 12824
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F21650-0x0000000181F21690
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018661); // 0x0000000181F21690-0x0000000181F21800
			private static IntPtr GetFunctionPointer(); // 0x0000000181F21800-0x0000000181F21960
			public static int Invoke([IsReadOnly] in JaggedSpan<EntityId> jaggedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeList<LODGroupCullingData> lodGroupCullingData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles, ref NativeArray<GPUInstanceIndex> lodGroupInstances); // 0x0000000181F21960-0x0000000181F21B90
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int FreeLODGroupData_00000155_PostfixBurstDelegate([IsReadOnly] in NativeArray<EntityId> destroyedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles); // TypeDefIndex: 12825; 0x000000018043A200-0x000000018043A220
	
		internal static class FreeLODGroupData_00000155_BurstDirectCall // TypeDefIndex: 12826
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F20F60-0x0000000181F20FA0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018675); // 0x0000000181F20FA0-0x0000000181F21110
			private static IntPtr GetFunctionPointer(); // 0x0000000181F21110-0x0000000181F21270
			public static int Invoke([IsReadOnly] in NativeArray<EntityId> destroyedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles); // 0x0000000181F21270-0x0000000181F21470
		}
	
		// Methods
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static int GetOrAllocateLODGroupDataInstances([IsReadOnly] in JaggedSpan<EntityId> jaggedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeList<LODGroupCullingData> lodGroupCullingData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles, ref NativeArray<GPUInstanceIndex> lodGroupInstances); // 0x0000000181F287E0-0x0000000181F287F0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static int FreeLODGroupData([IsReadOnly] in NativeArray<EntityId> destroyedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles); // 0x0000000181F21270-0x0000000181F21470
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(GetOrAllocateLODGroupDataInstances_00000154_PostfixBurstDelegate))]
		internal static int GetOrAllocateLODGroupDataInstances_BurstManaged([IsReadOnly] in JaggedSpan<EntityId> jaggedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeList<LODGroupCullingData> lodGroupCullingData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles, ref NativeArray<GPUInstanceIndex> lodGroupInstances); // 0x0000000181F28540-0x0000000181F287E0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(FreeLODGroupData_00000155_PostfixBurstDelegate))]
		internal static int FreeLODGroupData_BurstManaged([IsReadOnly] in NativeArray<EntityId> destroyedLODGroups, ref NativeList<LODGroupData> lodGroupsData, ref NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash, ref NativeList<GPUInstanceIndex> freeLODGroupDataHandles); // 0x0000000181F28390-0x0000000181F28540
	}
}
