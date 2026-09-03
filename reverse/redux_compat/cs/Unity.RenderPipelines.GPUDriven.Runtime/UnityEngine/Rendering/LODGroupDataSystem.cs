/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class LODGroupDataSystem : IDisposable // TypeDefIndex: 12821
	{
		// Fields
		private NativeList<LODGroupData> m_LODGroupData; // 0x10
		private NativeParallelHashMap<EntityId, GPUInstanceIndex> m_LODGroupDataHash; // 0x18
		private NativeList<LODGroupCullingData> m_LODGroupCullingData; // 0x28
		private NativeList<GPUInstanceIndex> m_FreeLODGroupDataHandles; // 0x30
		private int m_CrossfadedRendererCount; // 0x38
		private bool m_SupportDitheringCrossFade; // 0x3C
	
		// Properties
		public NativeParallelHashMap<EntityId, GPUInstanceIndex> lodGroupDataHash { get; } // 0x0000000180A5E120-0x0000000180A5E130 
		public NativeList<LODGroupCullingData> lodGroupCullingData { get; } // 0x000000018033D240-0x000000018033D250 
		public int crossfadedRendererCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		public int activeLodGroupCount { get; } // 0x0000000181F28E40-0x0000000181F28E50 
	
		// Constructors
		public LODGroupDataSystem(bool supportDitheringCrossFade); // 0x0000000181F28D60-0x0000000181F28E40
	
		// Methods
		public void Dispose(); // 0x0000000181F287F0-0x0000000181F28830
		public NativeArray<GPUInstanceIndex> GetOrAllocateInstances([IsReadOnly] in LODGroupUpdateBatch updateBatch, Allocator allocator); // 0x0000000181F28870-0x0000000181F289B0
		public void UpdateLODGroupData([IsReadOnly] in LODGroupUpdateBatch updateBatch, NativeArray<GPUInstanceIndex> instances); // 0x0000000181F289B0-0x0000000181F28C00
		public void UpdateLODGroupTransforms([IsReadOnly] in LODGroupUpdateBatch updateBatch); // 0x0000000181F28C00-0x0000000181F28D60
		public void FreeLODGroups(NativeArray<EntityId> destroyedLODGroupsID); // 0x0000000181F28830-0x0000000181F28870
	}
}
