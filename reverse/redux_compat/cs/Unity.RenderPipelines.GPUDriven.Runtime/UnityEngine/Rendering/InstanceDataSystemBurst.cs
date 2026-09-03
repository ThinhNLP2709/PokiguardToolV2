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
	internal static class InstanceDataSystemBurst // TypeDefIndex: 12802
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void AllocateInstances_00000145_PostfixBurstDelegate(InstanceAllocatorVariant allocVariant, [IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // TypeDefIndex: 12803; 0x00000001818295E0-0x0000000181829600
	
		internal static class AllocateInstances_00000145_BurstDirectCall // TypeDefIndex: 12804
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F1D540-0x0000000181F1D580
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018610); // 0x0000000181F1D580-0x0000000181F1D6E0
			private static IntPtr GetFunctionPointer(); // 0x0000000181F1D6E0-0x0000000181F1D830
			public static unsafe void Invoke(InstanceAllocatorVariant allocVariant, [IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F1D830-0x0000000181F1DA60
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void FreeInstances_00000146_PostfixBurstDelegate([IsReadOnly] in NativeArray<InstanceHandle> instances, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // TypeDefIndex: 12805; 0x000000018043A200-0x000000018043A220
	
		internal static class FreeInstances_00000146_BurstDirectCall // TypeDefIndex: 12806
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F20970-0x0000000181F209B0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018625); // 0x0000000181F209B0-0x0000000181F20B20
			private static IntPtr GetFunctionPointer(); // 0x0000000181F20B20-0x0000000181F20C80
			public static unsafe void Invoke([IsReadOnly] in NativeArray<InstanceHandle> instances, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F20C80-0x0000000181F20E80
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int ComputeTotalTreeCount_00000147_PostfixBurstDelegate([IsReadOnly] in NativeArray<InternalMeshRendererSettings> rendererSettings); // TypeDefIndex: 12807; 0x00000001804A78A0-0x00000001804A78B0
	
		internal static class ComputeTotalTreeCount_00000147_BurstDirectCall // TypeDefIndex: 12808
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F1DD70-0x0000000181F1DDB0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018631); // 0x0000000181F1DDB0-0x0000000181F1DF20
			private static IntPtr GetFunctionPointer(); // 0x0000000181F1DF20-0x0000000181F1E080
			public static int Invoke([IsReadOnly] in NativeArray<InternalMeshRendererSettings> rendererSettings); // 0x0000000181F1E080-0x0000000181F1E250
		}
	
		// Methods
		private static GPUArchetypeHandle FetchArchetype([IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, int index); // 0x0000000181F27310-0x0000000181F27330
		private static unsafe void AllocOnlyIteration(NativeArray<EntityId> instanceIDSection, int absoluteIndex, int localIndex, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F26C90-0x0000000181F26E00
		private static unsafe void AllocOnly([IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F26E00-0x0000000181F26F70
		private static unsafe void GPUReallocOnlyIteration(InstanceHandle instance, GPUArchetypeHandle archetype, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld); // 0x0000000181F27520-0x0000000181F27720
		private static unsafe void GPUReallocOnly([IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances); // 0x0000000181F27720-0x0000000181F27810
		private static unsafe void AllocOrGPURealloc([IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F26F70-0x0000000181F271C0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static unsafe void AllocateInstances(InstanceAllocatorVariant allocVariant, [IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F1D830-0x0000000181F1DA60
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static unsafe void FreeInstances([IsReadOnly] in NativeArray<InstanceHandle> instances, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F20C80-0x0000000181F20E80
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static int ComputeTotalTreeCount([IsReadOnly] in NativeArray<InternalMeshRendererSettings> rendererSettings); // 0x0000000181F1E080-0x0000000181F1E250
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(AllocateInstances_00000145_PostfixBurstDelegate))]
		internal static unsafe void AllocateInstances_BurstManaged(InstanceAllocatorVariant allocVariant, [IsReadOnly] in JaggedSpan<EntityId> jaggedInstanceIDs, [IsReadOnly] in NativeArray<GPUArchetypeHandle> archetypes, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeArray<InstanceHandle> instances, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F1C440-0x0000000181F1CC90
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(FreeInstances_00000146_PostfixBurstDelegate))]
		internal static unsafe void FreeInstances_BurstManaged([IsReadOnly] in NativeArray<InstanceHandle> instances, InstanceAllocators* instanceAllocators, ref RenderWorld renderWorld, ref NativeParallelHashMap<EntityId, InstanceHandle> rendererToInstanceMap); // 0x0000000181F27330-0x0000000181F27520
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(ComputeTotalTreeCount_00000147_PostfixBurstDelegate))]
		internal static int ComputeTotalTreeCount_BurstManaged([IsReadOnly] in NativeArray<InternalMeshRendererSettings> rendererSettings); // 0x0000000181F271C0-0x0000000181F27310
	}
}
