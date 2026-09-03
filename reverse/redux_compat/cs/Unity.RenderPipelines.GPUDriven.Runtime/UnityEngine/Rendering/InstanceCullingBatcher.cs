/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class InstanceCullingBatcher : IDisposable // TypeDefIndex: 12747
	{
		// Fields
		private static readonly ProfilerMarker k_RegisterMeshes; // 0x00
		private static readonly ProfilerMarker k_RegisterMaterials; // 0x08
		private static readonly ProfilerMarker k_DestroyMaterials; // 0x10
		private static readonly ProfilerMarker k_DestroyMeshes; // 0x18
		internal static readonly ProfilerMarker k_BuildBatches; // 0x20
		private static readonly ProfilerMarker k_RegisterAndBuildBatches; // 0x28
		internal static readonly ProfilerMarker k_RegisterMaterialsAndMeshes; // 0x30
		internal static readonly ProfilerMarker k_CreateCullJobTree; // 0x38
		private GPUResidentContext m_GRDContext; // 0x10
		private InstanceDataSystem m_InstanceDataSystem; // 0x18
		private LODGroupDataSystem m_LODGroupDataSystem; // 0x20
		private CPUDrawInstanceData m_DrawInstanceData; // 0x28
		private BatchRendererGroup m_BRG; // 0x30
		private OnCullingCompleteCallback m_OnCompleteCallback; // 0x38
		private NativeParallelHashMap<GPUArchetypeHandle, BatchID> m_BatchIDs; // 0x40
		private NativeParallelHashMap<EntityId, GPUDrivenMaterial> m_MaterialMap; // 0x50
		private NativeParallelHashMap<EntityId, MeshInfo> m_MeshMap; // 0x60
		private int m_CachedInstanceDataBufferLayoutVersion; // 0x70
		private NativeArray<BatchMeshID> m_TempBatchMeshIDs; // 0x78
		private NativeHashSet<EntityId> m_TempChangedMeshIDs; // 0x88
	
		// Properties
		public NativeParallelHashMap<EntityId, GPUDrivenMaterial> materialMap { get; } // 0x0000000180E14960-0x0000000180E14970 
		public NativeParallelHashMap<EntityId, MeshInfo> meshMap { get; } // 0x00000001816A56A0-0x00000001816A56B0 
	
		// Constructors
		public InstanceCullingBatcher(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static InstanceCullingBatcher(); // 0x0000000181F10830-0x0000000181F10A60
	
		// Methods
		public void Initialize(GPUResidentContext grdContext, [IsReadOnly] in GPUResidentDrawerSettings settings, BatchRendererGroup.OnFinishedCulling onFinishedCulling, OnCullingCompleteCallback onCompleteCallback = null); // 0x0000000181F0E730-0x0000000181F0EB80
		public void Dispose(); // 0x0000000181F0E290-0x0000000181F0E730
		private BatchID AddBatch(GPUArchetypeHandle archetype); // 0x0000000181F0D830-0x0000000181F0DB10
		private void UpdateInstanceDataBufferLayoutVersion(); // 0x0000000181F103F0-0x0000000181F106B0
		private void OnFetchMeshesDataForRegistration(NativeArray<EntityId> meshIDs, NativeArray<GPUDrivenMeshData> meshDatas, NativeArray<int> subMeshOffsets, NativeArray<GPUDrivenSubMesh> subMeshes); // 0x0000000181F0EB80-0x0000000181F0EC90
		private void RegisterMeshes(JaggedSpan<EntityId> meshIDs); // 0x0000000181F0FF40-0x0000000181F103F0
		private void RegisterMaterials(JaggedSpan<EntityId> materials); // 0x0000000181F0FA80-0x0000000181F0FF40
		private void OnFetchMeshesDataForUpdate(NativeArray<EntityId> meshIDs, NativeArray<GPUDrivenMeshData> meshDatas, NativeArray<int> subMeshOffsets, NativeArray<GPUDrivenSubMesh> subMeshBuffer); // 0x0000000181F0EC90-0x0000000181F0ECE0
		public NativeHashSet<EntityId> UpdateMeshData(NativeArray<EntityId> meshIDs, Allocator allocator); // 0x0000000181F10730-0x0000000181F10830
		public NativeHashSet<EntityId> UpdateMaterialData(NativeArray<EntityId> materials, NativeArray<GPUDrivenMaterialData> materialDatas, Allocator allocator); // 0x0000000181F106B0-0x0000000181F10730
		public CPUDrawInstanceData GetDrawInstanceData(); // 0x000000018033D240-0x000000018033D250
		public JobHandle OnPerformCulling(BatchRendererGroup rendererGroup, BatchCullingContext context, BatchCullingOutput cullingOutput, IntPtr userContext); // 0x0000000181F0ECE0-0x0000000181F0F720
		public void DestroyDrawInstances(NativeArray<InstanceHandle> instances); // 0x0000000181F0DD50-0x0000000181F0DD80
		public void DestroyMaterials(NativeArray<EntityId> destroyedInstanceIDs); // 0x0000000181F0DD80-0x0000000181F0E040
		public void DestroyMeshes(NativeArray<EntityId> destroyedInstanceIDs); // 0x0000000181F0E040-0x0000000181F0E290
		public void BuildBatches(NativeArray<InstanceHandle> instances); // 0x0000000181F0DB10-0x0000000181F0DD50
		public void RegisterAndBuildBatches(NativeArray<InstanceHandle> instances, [IsReadOnly] in MeshRendererUpdateBatch updateBatch); // 0x0000000181F0F720-0x0000000181F0FA80
	}
}
