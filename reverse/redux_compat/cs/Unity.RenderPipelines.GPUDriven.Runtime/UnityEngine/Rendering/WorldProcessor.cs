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
	internal class WorldProcessor : IDisposable // TypeDefIndex: 12964
	{
		// Fields
		internal static readonly ProfilerMarker k_Update; // 0x00
		private static readonly ProfilerMarker k_FetchAllChanges; // 0x08
		private static readonly ProfilerMarker k_ProcessCameraChanges; // 0x10
		private static readonly ProfilerMarker k_DestroyUnsupportedRenderers; // 0x18
		private static readonly ProfilerMarker k_DestroyMeshes; // 0x20
		private static readonly ProfilerMarker k_ProcessLODGroupChanges; // 0x28
		private static readonly ProfilerMarker k_ProcessLODGroupTransformChanges; // 0x30
		private static readonly ProfilerMarker k_ProcessMeshRendererChanges; // 0x38
		private static readonly ProfilerMarker k_ProcessMeshRendererTransformChanges; // 0x40
		private static readonly ProfilerMarker k_ProcessRendererMaterialAndMeshChanges; // 0x48
		private static readonly ProfilerMarker k_ClassifyMaterials; // 0x50
		private static readonly ProfilerMarker k_FindOnlyUsedMeshes; // 0x58
		private static readonly ProfilerMarker k_FindUnsupportedRenderers; // 0x60
		private GPUDrivenProcessor m_GPUDrivenProcessor; // 0x10
		private ObjectDispatcher m_ObjectDispatcher; // 0x18
		private GPUResidentContext m_GRDContext; // 0x20
		private InstanceDataSystem m_InstanceDataSystem; // 0x28
		private InstanceCullingBatcher m_Batcher; // 0x30
		private MeshRendererProcessor m_MeshRendererProcessor; // 0x38
		private LODGroupProcessor m_LODGroupProcessor; // 0x40
		private NativeList<MeshRendererUpdateBatch> m_MeshRendererUpdateBatches; // 0x48
		private NativeList<LODGroupUpdateBatch> m_LODGroupUpdateBatches; // 0x50
		private NativeList<NativeArray<EntityId>> m_MeshRendererDeletionBatches; // 0x58
		private NativeList<NativeArray<EntityId>> m_LODGroupDeletionBatches; // 0x60
	
		// Properties
		public MeshRendererProcessor meshRendererProcessor { get; } // 0x00000001803272A0-0x00000001803272B0 
		public LODGroupProcessor lodDGroupProcessor { get; } // 0x0000000180377940-0x0000000180377950 
	
		// Constructors
		public WorldProcessor(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static WorldProcessor(); // 0x0000000181F551D0-0x0000000181F55560
	
		// Methods
		public void Initialize(GPUDrivenProcessor gpuDrivenProcessor, ObjectDispatcher objectDispatcher, GPUResidentContext context); // 0x0000000181F53530-0x0000000181F53700
		public void Dispose(); // 0x0000000181F531A0-0x0000000181F53220
		public void Update(); // 0x0000000181F53E10-0x0000000181F551D0
		public void PushMeshRendererUpdateBatches(NativeArray<MeshRendererUpdateBatch> batches); // 0x0000000181F53BF0-0x0000000181F53E10
		public void PushLODGroupUpdateBatches(NativeArray<LODGroupUpdateBatch> batches); // 0x0000000181F539D0-0x0000000181F53BC0
		public void PushMeshRendererDeletionBatch(NativeArray<NativeArray<EntityId>> batches); // 0x0000000181F53BC0-0x0000000181F53BF0
		public void PushLODGroupDeletionBatch(NativeArray<NativeArray<EntityId>> batches); // 0x0000000181F539A0-0x0000000181F539D0
		private void ProcessUpdateBatches(); // 0x0000000181F53700-0x0000000181F539A0
		private void ClearUpdateBatches(); // 0x0000000181F52A50-0x0000000181F531A0
		public void ClassifyMaterials(NativeArray<EntityId> allChangedMaterials, NativeArray<EntityId> allDestroyedMaterials, out NativeList<EntityId> unsupportedMaterials, out NativeList<EntityId> changedMaterials, out NativeList<EntityId> destroyedMaterials, out NativeList<GPUDrivenMaterialData> changedMaterialDatas, Allocator allocator); // 0x0000000181F528D0-0x0000000181F52A50
		public NativeList<EntityId> FindOnlyUsedMeshes(NativeArray<EntityId> changedMeshes, Allocator allocator); // 0x0000000181F53220-0x0000000181F53360
		private NativeList<EntityId> FindUnsupportedRenderers(NativeArray<EntityId> unsupportedMaterials, Allocator allocator); // 0x0000000181F53360-0x0000000181F53530
	}
}
