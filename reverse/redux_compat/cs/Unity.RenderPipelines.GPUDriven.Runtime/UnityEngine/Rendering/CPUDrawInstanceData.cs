/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class CPUDrawInstanceData // TypeDefIndex: 12734
	{
		// Fields
		private static readonly ProfilerMarker k_DestroyDrawInstanceIndices; // 0x00
		private static readonly ProfilerMarker k_DestroyDrawInstances; // 0x08
		private static readonly ProfilerMarker k_DestroyDrawInstancesParallelSort; // 0x10
		private static readonly ProfilerMarker k_DestroyedBatchMaterialsParallelSort; // 0x18
		private NativeParallelHashMap<RangeKey, int> m_RangeHash; // 0x10
		private NativeList<DrawRange> m_DrawRanges; // 0x20
		private NativeParallelHashMap<DrawKey, int> m_BatchHash; // 0x28
		private NativeList<DrawBatch> m_DrawBatches; // 0x38
		private NativeList<DrawInstance> m_DrawInstances; // 0x40
		private NativeList<int> m_DrawInstanceIndices; // 0x48
		private NativeList<int> m_DrawBatchIndices; // 0x50
		private bool m_NeedsRebuild; // 0x58
	
		// Properties
		public NativeList<DrawInstance> drawInstances { get; } // 0x0000000180377940-0x0000000180377950 
		public NativeParallelHashMap<DrawKey, int> batchHash { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		public NativeList<DrawBatch> drawBatches { get; } // 0x00000001803272A0-0x00000001803272B0 
		public NativeParallelHashMap<RangeKey, int> rangeHash { get; } // 0x00000001802E65B0-0x00000001802E65C0 
		public NativeList<DrawRange> drawRanges { get; } // 0x00000001802F8630-0x00000001802F8640 
		public NativeArray<int> drawBatchIndices { get; } // 0x0000000181F04BD0-0x0000000181F04C00 
		public NativeArray<int> drawInstanceIndices { get; } // 0x0000000181F04C00-0x0000000181F04C30 
		public bool valid { get; } // 0x0000000181F04C30-0x0000000181F04C40 
	
		// Constructors
		public CPUDrawInstanceData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CPUDrawInstanceData(); // 0x0000000181F04A90-0x0000000181F04BD0
	
		// Methods
		public void Initialize(); // 0x0000000181F04720-0x0000000181F04880
		public void Dispose(); // 0x0000000181F04670-0x0000000181F04720
		public void RebuildDrawListsIfNeeded(); // 0x0000000181F04890-0x0000000181F04A90
		public void DestroyDrawInstanceIndices(NativeArray<int> drawInstanceIndicesToDestroy); // 0x0000000181F03E90-0x0000000181F04010
		public void DestroyDrawInstances(NativeArray<InstanceHandle> destroyedInstances); // 0x0000000181F04010-0x0000000181F043A0
		public void DestroyMaterialDrawInstances(NativeArray<uint> destroyedBatchMaterials); // 0x0000000181F043A0-0x0000000181F04670
		public void NeedsRebuild(); // 0x0000000181F04880-0x0000000181F04890
	}
}
