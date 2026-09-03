/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class MeshRendererProcessor : IDisposable // TypeDefIndex: 12942
	{
		// Fields
		private static readonly ProfilerMarker k_DestroyMeshRendererInstances; // 0x00
		private static readonly ProfilerMarker k_GetMaterialsAndMeshesWithChangedData; // 0x08
		private static readonly ProfilerMarker k_ProcessRendererMaterialAndMeshChangesSort; // 0x10
		private static readonly ProfilerMarker k_FindRenderersFromMaterialsOrMeshes; // 0x18
		private static readonly ProfilerMarker k_UpdateRenderers; // 0x20
		private static readonly ProfilerMarker k_ProcessMeshRendererUpdateBatch; // 0x28
		internal static readonly ProfilerMarker k_UploadGPUComponentOverrides; // 0x30
		private static readonly ProfilerMarker k_DeepValidationGPUArchetypesDidNotChange; // 0x38
		private static readonly ProfilerMarker k_ComputeInstanceGPUArchetypes; // 0x40
		private static readonly ProfilerMarker k_BuildGPUComponentOverrideUploadSources; // 0x48
		private static readonly ProfilerMarker k_SyncWriteGPUComponentJobs; // 0x50
		private static readonly ProfilerMarker k_DeepValidationNoInstanceUsesBlendProbes; // 0x58
		private GPUDrivenProcessor m_GPUDrivenProcessor; // 0x10
		private GPUResidentContext m_GRDContext; // 0x18
		private InstanceCullingBatcher m_CullingBatcher; // 0x20
		private NativeReference<GPUArchetypeManager> m_ArchetypeManager; // 0x28
		private InstanceDataSystem m_InstanceDataSystem; // 0x38
		private LODGroupDataSystem m_LODGroupDataSystem; // 0x40
		private GPUDrivenRendererDataCallback m_ProcessGameObjectUpdateBatchCallback; // 0x48
		private NativeArray<uint> m_CPUUploadBuffer; // 0x50
		private GraphicsBuffer m_GPUUploadBuffer; // 0x60
	
		// Nested types
		public struct GPUComponentUploadSource // TypeDefIndex: 12943
		{
			// Fields
			public JaggedSpan<byte> data; // 0x00
			public GPUComponentHandle component; // 0x20
			public int componentSize; // 0x24
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct FindRenderersFromMaterialOrMeshJob : IJobParallelForBatch // TypeDefIndex: 12944
		{
			// Fields
			public const int k_BatchSize = 128; // Metadata: 0x006A7663
			[ReadOnly]
			public RenderWorld renderWorld; // 0x00
			[ReadOnly]
			public NativeHashSet<EntityId> materialIDs; // 0x1E0
			[ReadOnly]
			public NativeHashSet<EntityId> meshIDs; // 0x1E8
			[ReadOnly]
			public NativeArray<EntityId> sortedExcludeRendererIDs; // 0x1F0
			[WriteOnly]
			public NativeList<EntityId> selectedRenderIDsForMaterials; // 0x200
			[WriteOnly]
			public NativeList<EntityId> selectedRenderIDsForMeshes; // 0x208
	
			// Methods
			public void Execute(int startIndex, int count); // 0x0000000181F34140-0x0000000181F34440
		}
	
		// Constructors
		public MeshRendererProcessor(GPUDrivenProcessor gpuDrivenProcessor, GPUResidentContext grdContext); // 0x0000000181F3E2B0-0x0000000181F3E3B0
		static MeshRendererProcessor(); // 0x0000000181F3DF70-0x0000000181F3E2B0
	
		// Methods
		public void Dispose(); // 0x0000000181F3C200-0x0000000181F3C250
		public void DestroyInstances(NativeArray<EntityId> destroyedRenderers); // 0x0000000181F3BF80-0x0000000181F3C170
		public void ProcessGameObjectChanges(NativeArray<EntityId> changedRenderers); // 0x0000000181F3C670-0x0000000181F3C6C0
		public void ProcessGameObjectTransformChanges([IsReadOnly] in TransformDispatchData transformChanges); // 0x0000000181F3C6C0-0x0000000181F3C7E0
		public void ProcessRendererMaterialAndMeshChanges(NativeArray<EntityId> excludedRenderers, NativeArray<EntityId> changedMaterials, NativeArray<GPUDrivenMaterialData> changedMaterialDatas, NativeArray<EntityId> changedMeshes); // 0x0000000181F3CC90-0x0000000181F3D3E0
		private ValueTuple<NativeList<EntityId>, NativeList<EntityId>> FindRenderersFromMaterialsOrMeshes(NativeArray<EntityId> sortedExcludeRenderers, NativeHashSet<EntityId> materials, NativeHashSet<EntityId> meshes, Allocator rendererListAllocator); // 0x0000000181F3C360-0x0000000181F3C670
		public void ProcessUpdateBatch(ref MeshRendererUpdateBatch updateBatch); // 0x0000000181F3D3E0-0x0000000181F3DA80
		private NativeArray<GPUArchetypeHandle> ComputeInstanceGPUArchetypes(ref MeshRendererUpdateBatch updateBatch, GPUComponentSet overrideComponentSet, Allocator allocator); // 0x0000000181F3BD70-0x0000000181F3BF80
		private NativeArray<GPUComponentUploadSource> BuildGPUComponentOverrideUploadSources([IsReadOnly] in MeshRendererUpdateBatch updateBatch, Allocator allocator, out GPUComponentSet overrideComponentSet); // 0x0000000181F3B970-0x0000000181F3BB10
		private void UploadGPUComponentOverrides(GPUComponentSet componentSet, NativeArray<GPUComponentUploadSource> uploadSources, NativeArray<InstanceHandle> instances); // 0x0000000181F3DA80-0x0000000181F3DF70
		private void EnsureUploadBufferUintCount(int uintCount); // 0x0000000181F3C250-0x0000000181F3C360
		private void ProcessGameObjectUpdateBatch([IsReadOnly] in GPUDrivenMeshRendererData rendererData); // 0x0000000181F3C7E0-0x0000000181F3CC90
		internal static GPUComponentSet ComputeComponentSet([IsReadOnly] in DefaultGPUComponents defaultGPUComponents, MeshRendererUpdateBatch.LightmapUsage lightmapUsage, MeshRendererUpdateBatch.BlendProbesUsage blendProbesUsage); // 0x0000000181F3BCE0-0x0000000181F3BD70
		internal static GPUComponentSet ComputeComponentSet([IsReadOnly] in DefaultGPUComponents defaultGPUComponents, InternalMeshRendererSettings rendererSettings, int lightmapIndex); // 0x0000000181F3BBE0-0x0000000181F3BCE0
		internal static GPUComponentSet ComputeComponentSet([IsReadOnly] in DefaultGPUComponents defaultGPUComponents, bool useLightmaps, bool blendProbes, bool hasTree); // 0x0000000181F3BB10-0x0000000181F3BBE0
		private void ValidateNoInstanceUsesBlendProbes(NativeArray<InstanceHandle> instances); // 0x00000001802E76C0-0x00000001802E76D0
		private bool AnyInstanceUseBlendProbes(NativeArray<InstanceHandle> instances); // 0x0000000181F3B930-0x0000000181F3B970
		private void ValidateGPUArchetypesDidNotChange(NativeArray<InstanceHandle> instances, [IsReadOnly] in MeshRendererUpdateBatch updateBatch, GPUComponentSet overrideComponentSet); // 0x00000001802E76C0-0x00000001802E76D0
		private bool DidGPUArchetypesChange(NativeArray<InstanceHandle> instances, [IsReadOnly] in MeshRendererUpdateBatch updateBatch, GPUComponentSet overrideComponentSet); // 0x0000000181F3C170-0x0000000181F3C200
	}
}
