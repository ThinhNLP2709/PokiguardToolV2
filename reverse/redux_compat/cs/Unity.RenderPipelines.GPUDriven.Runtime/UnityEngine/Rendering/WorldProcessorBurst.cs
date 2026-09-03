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
	internal static class WorldProcessorBurst // TypeDefIndex: 12965
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ClassifyMaterials_0000037B_PostfixBurstDelegate([IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, [IsReadOnly] in NativeArray<EntityId> allChangedMaterials, [IsReadOnly] in NativeArray<EntityId> allDestroyedMaterials, out NativeList<EntityId> supportedChangedMaterials, out NativeList<EntityId> unsupportedChangedMaterials, out NativeList<EntityId> destroyedMaterials, out NativeList<GPUDrivenMaterialData> supportedChangedMaterialDatas, Allocator allocator); // TypeDefIndex: 12966; 0x0000000180ED9060-0x0000000180ED9080
	
		internal static class ClassifyMaterials_0000037B_BurstDirectCall // TypeDefIndex: 12967
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F4BED0-0x0000000181F4BF10
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018947); // 0x0000000181F4BF10-0x0000000181F4C080
			private static IntPtr GetFunctionPointer(); // 0x0000000181F4C080-0x0000000181F4C1E0
			public static void Invoke([IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, [IsReadOnly] in NativeArray<EntityId> allChangedMaterials, [IsReadOnly] in NativeArray<EntityId> allDestroyedMaterials, out NativeList<EntityId> supportedChangedMaterials, out NativeList<EntityId> unsupportedChangedMaterials, out NativeList<EntityId> destroyedMaterials, out NativeList<GPUDrivenMaterialData> supportedChangedMaterialDatas, Allocator allocator); // 0x0000000181F4C1E0-0x0000000181F4C440
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void FindOnlyUsedMeshes_0000037C_PostfixBurstDelegate([IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeArray<EntityId> changedMeshes, Allocator allocator, out NativeList<EntityId> usedMeshes); // TypeDefIndex: 12968; 0x000000018043A200-0x000000018043A220
	
		internal static class FindOnlyUsedMeshes_0000037C_BurstDirectCall // TypeDefIndex: 12969
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F4CDB0-0x0000000181F4CDF0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001895d); // 0x0000000181F4CDF0-0x0000000181F4CF60
			private static IntPtr GetFunctionPointer(); // 0x0000000181F4CF60-0x0000000181F4D0C0
			public static void Invoke([IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeArray<EntityId> changedMeshes, Allocator allocator, out NativeList<EntityId> usedMeshes); // 0x0000000181F4D0C0-0x0000000181F4D2C0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void FindUnsupportedRenderers_0000037D_PostfixBurstDelegate([IsReadOnly] in NativeArray<EntityId> unsupportedMaterials, [IsReadOnly] in NativeArray<EmbeddedArray32<EntityId>> materialArrays, [IsReadOnly] in NativeArray<EntityId> renderers, ref NativeList<EntityId> unsupportedRenderers); // TypeDefIndex: 12970; 0x000000018043A200-0x000000018043A220
	
		internal static class FindUnsupportedRenderers_0000037D_BurstDirectCall // TypeDefIndex: 12971
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F4D4A0-0x0000000181F4D4E0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001896f); // 0x0000000181F4D4E0-0x0000000181F4D650
			private static IntPtr GetFunctionPointer(); // 0x0000000181F4D650-0x0000000181F4D7B0
			public static void Invoke([IsReadOnly] in NativeArray<EntityId> unsupportedMaterials, [IsReadOnly] in NativeArray<EmbeddedArray32<EntityId>> materialArrays, [IsReadOnly] in NativeArray<EntityId> renderers, ref NativeList<EntityId> unsupportedRenderers); // 0x0000000181F4D7B0-0x0000000181F4D9B0
		}
	
		// Methods
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void ClassifyMaterials([IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, [IsReadOnly] in NativeArray<EntityId> allChangedMaterials, [IsReadOnly] in NativeArray<EntityId> allDestroyedMaterials, out NativeList<EntityId> supportedChangedMaterials, out NativeList<EntityId> unsupportedChangedMaterials, out NativeList<EntityId> destroyedMaterials, out NativeList<GPUDrivenMaterialData> supportedChangedMaterialDatas, Allocator allocator); // 0x0000000181F52750-0x0000000181F52760
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void FindOnlyUsedMeshes([IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeArray<EntityId> changedMeshes, Allocator allocator, out NativeList<EntityId> usedMeshes); // 0x0000000181F4D0C0-0x0000000181F4D2C0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void FindUnsupportedRenderers([IsReadOnly] in NativeArray<EntityId> unsupportedMaterials, [IsReadOnly] in NativeArray<EmbeddedArray32<EntityId>> materialArrays, [IsReadOnly] in NativeArray<EntityId> renderers, ref NativeList<EntityId> unsupportedRenderers); // 0x0000000181F4D7B0-0x0000000181F4D9B0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(ClassifyMaterials_0000037B_PostfixBurstDelegate))]
		internal static void ClassifyMaterials_BurstManaged([IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, [IsReadOnly] in NativeArray<EntityId> allChangedMaterials, [IsReadOnly] in NativeArray<EntityId> allDestroyedMaterials, out NativeList<EntityId> supportedChangedMaterials, out NativeList<EntityId> unsupportedChangedMaterials, out NativeList<EntityId> destroyedMaterials, out NativeList<GPUDrivenMaterialData> supportedChangedMaterialDatas, Allocator allocator); // 0x0000000181F52150-0x0000000181F52750
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(FindOnlyUsedMeshes_0000037C_PostfixBurstDelegate))]
		internal static void FindOnlyUsedMeshes_BurstManaged([IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeArray<EntityId> changedMeshes, Allocator allocator, out NativeList<EntityId> usedMeshes); // 0x0000000181F52760-0x0000000181F528D0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(FindUnsupportedRenderers_0000037D_PostfixBurstDelegate))]
		internal static void FindUnsupportedRenderers_BurstManaged([IsReadOnly] in NativeArray<EntityId> unsupportedMaterials, [IsReadOnly] in NativeArray<EmbeddedArray32<EntityId>> materialArrays, [IsReadOnly] in NativeArray<EntityId> renderers, ref NativeList<EntityId> unsupportedRenderers); // 0x0000000181F4BBD0-0x0000000181F4BD10
	}
}
