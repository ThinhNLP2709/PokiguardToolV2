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
	internal static class InstanceCullingBatcherBurst // TypeDefIndex: 12748
	{
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass4_0 // TypeDefIndex: 12749
		{
			// Fields
			public ushort subMeshStartIndex; // 0x00
			public int subMeshCount; // 0x04
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void UpdateMaterialData_0000003B_PostfixBurstDelegate([IsReadOnly] in NativeArray<EntityId> materialIDs, [IsReadOnly] in NativeArray<GPUDrivenMaterialData> materialDatas, ref NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeHashSet<EntityId> changedMaterialIDs); // TypeDefIndex: 12750; 0x000000018043A200-0x000000018043A220
	
		internal static class UpdateMaterialData_0000003B_BurstDirectCall // TypeDefIndex: 12751
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F1B4C0-0x0000000181F1B500
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001847f); // 0x0000000181F1B500-0x0000000181F1B670
			private static IntPtr GetFunctionPointer(); // 0x0000000181F1B670-0x0000000181F1B7D0
			public static void Invoke([IsReadOnly] in NativeArray<EntityId> materialIDs, [IsReadOnly] in NativeArray<GPUDrivenMaterialData> materialDatas, ref NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeHashSet<EntityId> changedMaterialIDs); // 0x0000000181F0D270-0x0000000181F0D470
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void UpdateMeshData_0000003C_PostfixBurstDelegate([IsReadOnly] in NativeArray<EntityId> meshIDs, [IsReadOnly] in NativeArray<GPUDrivenMeshData> meshDatas, [IsReadOnly] in NativeArray<int> subMeshOffsets, [IsReadOnly] in NativeArray<GPUDrivenSubMesh> subMeshBuffer, ref NativeParallelHashMap<EntityId, MeshInfo> meshMap, ref NativeHashSet<EntityId> changedMeshIDs); // TypeDefIndex: 12752; 0x0000000180ED8BF0-0x0000000180ED8C10
	
		internal static class UpdateMeshData_0000003C_BurstDirectCall // TypeDefIndex: 12753
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F1B9B0-0x0000000181F1B9F0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_00018495); // 0x0000000181F1B9F0-0x0000000181F1BB60
			private static IntPtr GetFunctionPointer(); // 0x0000000181F1BB60-0x0000000181F1BCC0
			public static void Invoke([IsReadOnly] in NativeArray<EntityId> meshIDs, [IsReadOnly] in NativeArray<GPUDrivenMeshData> meshDatas, [IsReadOnly] in NativeArray<int> subMeshOffsets, [IsReadOnly] in NativeArray<GPUDrivenSubMesh> subMeshBuffer, ref NativeParallelHashMap<EntityId, MeshInfo> meshMap, ref NativeHashSet<EntityId> changedMeshIDs); // 0x0000000181F1BCC0-0x0000000181F1BEF0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CreateDrawBatches_00000040_PostfixBurstDelegate([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches, ref NativeList<DrawInstance> drawInstances); // TypeDefIndex: 12754; 0x0000000181828BB0-0x0000000181828C20
	
		internal static class CreateDrawBatches_00000040_BurstDirectCall // TypeDefIndex: 12755
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F04EE0-0x0000000181F04F20
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000184b3); // 0x0000000181F04F20-0x0000000181F05090
			private static IntPtr GetFunctionPointer(); // 0x0000000181F05090-0x0000000181F051F0
			public static void Invoke([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches, ref NativeList<DrawInstance> drawInstances); // 0x0000000181F051F0-0x0000000181F05470
		}
	
		// Methods
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void UpdateMaterialData([IsReadOnly] in NativeArray<EntityId> materialIDs, [IsReadOnly] in NativeArray<GPUDrivenMaterialData> materialDatas, ref NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeHashSet<EntityId> changedMaterialIDs); // 0x0000000181F0D270-0x0000000181F0D470
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void UpdateMeshData([IsReadOnly] in NativeArray<EntityId> meshIDs, [IsReadOnly] in NativeArray<GPUDrivenMeshData> meshDatas, [IsReadOnly] in NativeArray<int> subMeshOffsets, [IsReadOnly] in NativeArray<GPUDrivenSubMesh> subMeshBuffer, ref NativeParallelHashMap<EntityId, MeshInfo> meshMap, ref NativeHashSet<EntityId> changedMeshIDs); // 0x0000000181F0D820-0x0000000181F0D830
		private static ref DrawRange EditDrawRange([IsReadOnly] in RangeKey key, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges); // 0x0000000181F0C620-0x0000000181F0C720
		private static ref DrawBatch EditDrawBatch([IsReadOnly] in DrawKey key, [IsReadOnly] in GPUDrivenSubMesh subMesh, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches); // 0x0000000181F0C4C0-0x0000000181F0C620
		private static void ProcessRenderer(InstanceHandle instance, ref RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches, ref NativeList<DrawInstance> drawInstances); // 0x0000000181F0C720-0x0000000181F0D150
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void CreateDrawBatches([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches, ref NativeList<DrawInstance> drawInstances); // 0x0000000181F0C4B0-0x0000000181F0C4C0
		[CompilerGenerated]
		internal static int _ProcessRenderer_g__GetSubMeshIndexForMaterial_4_0(int materialIndex, ref __c__DisplayClass4_0 param_0001845e); // 0x0000000181F0D150-0x0000000181F0D160
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(UpdateMaterialData_0000003B_PostfixBurstDelegate))]
		internal static void UpdateMaterialData_BurstManaged([IsReadOnly] in NativeArray<EntityId> materialIDs, [IsReadOnly] in NativeArray<GPUDrivenMaterialData> materialDatas, ref NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeHashSet<EntityId> changedMaterialIDs); // 0x0000000181F0D160-0x0000000181F0D270
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(UpdateMeshData_0000003C_PostfixBurstDelegate))]
		internal static void UpdateMeshData_BurstManaged([IsReadOnly] in NativeArray<EntityId> meshIDs, [IsReadOnly] in NativeArray<GPUDrivenMeshData> meshDatas, [IsReadOnly] in NativeArray<int> subMeshOffsets, [IsReadOnly] in NativeArray<GPUDrivenSubMesh> subMeshBuffer, ref NativeParallelHashMap<EntityId, MeshInfo> meshMap, ref NativeHashSet<EntityId> changedMeshIDs); // 0x0000000181F0D470-0x0000000181F0D820
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(CreateDrawBatches_00000040_PostfixBurstDelegate))]
		internal static void CreateDrawBatches_BurstManaged([IsReadOnly] in NativeArray<InstanceHandle> instances, ref RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawBatch> drawBatches, ref NativeList<DrawInstance> drawInstances); // 0x0000000181F03520-0x0000000181F03AE0
	}
}
