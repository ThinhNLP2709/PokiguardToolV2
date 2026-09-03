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
	internal class LODGroupProcessor // TypeDefIndex: 12937
	{
		// Fields
		private static readonly ProfilerMarker k_DestroyLODGroupInstances; // 0x00
		private static readonly ProfilerMarker k_ProcessLODGroupUpdateBatch; // 0x08
		private GPUDrivenProcessor m_GPUDrivenProcessor; // 0x10
		private LODGroupDataSystem m_LODGroupDataSystem; // 0x18
	
		// Constructors
		public LODGroupProcessor(GPUDrivenProcessor gpuDrivenProcessor, GPUResidentContext context); // 0x0000000181F3A290-0x0000000181F3A2F0
		static LODGroupProcessor(); // 0x0000000181F3A1E0-0x0000000181F3A290
	
		// Methods
		public void DestroyInstances(NativeArray<EntityId> destroyedIDs); // 0x0000000181F39B80-0x0000000181F39C90
		public void ProcessGameObjectChanges(NativeArray<EntityId> changedLODGroups, bool transformOnly); // 0x0000000181F39C90-0x0000000181F39D60
		public void ProcessUpdateBatch([IsReadOnly] in LODGroupUpdateBatch updateBatch); // 0x0000000181F39F80-0x0000000181F3A1E0
		private void ProcessGameObjectUpdateBatch([IsReadOnly] in GPUDrivenLODGroupData inputData); // 0x0000000181F39D60-0x0000000181F39F80
	}
}
