/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct MeshRendererUpdateBatch : IDisposable // TypeDefIndex: 12960
	{
		// Fields
		public JaggedSpan<EntityId> instanceIDs; // 0x00
		public JaggedSpan<float4x4> localToWorlds; // 0x20
		public JaggedSpan<float4x4> prevLocalToWorlds; // 0x40
		public JaggedSpan<EntityId> meshIDs; // 0x60
		public JaggedSpan<EntityId> materialIDs; // 0x80
		public JaggedSpan<RangeInt> subMaterialRanges; // 0xA0
		public JaggedSpan<ushort> subMeshStartIndices; // 0xC0
		public JaggedSpan<ushort> staticBatchSubMeshCounts; // 0xE0
		public JaggedSpan<AABB> localBounds; // 0x100
		public JaggedSpan<InternalMeshRendererSettings> rendererSettings; // 0x120
		public JaggedSpan<EntityId> parentLODGroupIDs; // 0x140
		public JaggedSpan<byte> lodMasks; // 0x160
		public JaggedSpan<InternalMeshLodRendererSettings> meshLodSettings; // 0x180
		public JaggedSpan<short> lightmapIndices; // 0x1A0
		public JaggedSpan<int> rendererPriorities; // 0x1C0
		public JaggedSpan<ulong> sceneCullingMasks; // 0x1E0
		public NativeList<ulong> sharedSceneCullingMasks; // 0x200
		public NativeArray<GPUComponentJaggedUpdate> gpuComponentUpdates; // 0x208
		public JaggedBitSpan renderingEnabled; // 0x218
		public MeshRendererComponentMask componentMask; // 0x238
		public MeshRendererUpdateType updateType; // 0x23C
		public LightmapUsage lightmapUsage; // 0x240
		public BlendProbesUsage blendProbesUsage; // 0x244
		public bool useSharedSceneCullingMask; // 0x248
		internal bool mightIncludeTrees; // 0x249
	
		// Properties
		public int SectionCount { get; } // 0x0000000181F3ACE0-0x0000000181F3ACF0 
		public int TotalLength { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Nested types
		public enum LightmapUsage // TypeDefIndex: 12961
		{
			Unknown = 0,
			All = 1,
			None = 2
		}
	
		public enum BlendProbesUsage // TypeDefIndex: 12962
		{
			Unknown = 0,
			AllEnabled = 1,
			AllDisabled = 2
		}
	
		// Constructors
		public MeshRendererUpdateBatch(MeshRendererComponentMask componentMask, NativeArray<GPUComponent> gpuComponents, MeshRendererUpdateType updateType, LightmapUsage lightmapUsage, BlendProbesUsage blendProbesUsage, bool useSharedSceneCullingMask, int initialCapacity, Allocator allocator); // 0x0000000181F40060-0x0000000181F40690
	
		// Methods
		public void Dispose(); // 0x0000000181F3E770-0x0000000181F3EA00
		public int GetSectionLength(int sectionIndex); // 0x0000000181F3A440-0x0000000181F3A460
		public bool HasAnyComponent(MeshRendererComponentMask bits); // 0x0000000181F3F050-0x0000000181F3F060
		public NativeArray<float4x4> GetLocalToWorldSectionOrDefault(int index); // 0x0000000181F3EB50-0x0000000181F3EBC0
		public NativeArray<AABB> GetLocalBoundsSectionOrDefault(int index); // 0x0000000181F3EAE0-0x0000000181F3EB50
		public NativeArray<EntityId> GetMaterialSectionOrDefault(int index); // 0x0000000181F3EBC0-0x0000000181F3EC30
		public NativeArray<RangeInt> GetSubMaterialRangeSectionOrDefault(int index); // 0x0000000181F3EF70-0x0000000181F3EFE0
		public NativeArray<EntityId> GetMeshSectionOrDefault(int index); // 0x0000000181F3ECA0-0x0000000181F3ED10
		public NativeArray<short> GetLightmapIndexSectionOrDefault(int index); // 0x0000000181F3EA70-0x0000000181F3EAE0
		public NativeArray<int> GetRendererPrioritySectionOrDefault(int index); // 0x0000000181F3ED80-0x0000000181F3EDF0
		public NativeArray<ushort> GetSubMeshStartIndexSectionOrDefault(int index); // 0x0000000181F3EFE0-0x0000000181F3F050
		public NativeArray<ushort> GetStaticBatchSubMeshCountSectionOrDefault(int index); // 0x0000000181F3EF00-0x0000000181F3EF70
		public NativeArray<InternalMeshRendererSettings> GetRendererSettingsSectionOrDefault(int index); // 0x0000000181F3EDF0-0x0000000181F3EE60
		public NativeArray<EntityId> GetParentLODGroupIDSectionOrDefault(int index); // 0x0000000181F3ED10-0x0000000181F3ED80
		public NativeArray<byte> GetLODMaskSectionOrDefault(int index); // 0x0000000181F3EA00-0x0000000181F3EA70
		public NativeArray<InternalMeshLodRendererSettings> GetMeshLodSettingsSectionOrDefault(int index); // 0x0000000181F3EC30-0x0000000181F3ECA0
		public UnsafeBitArray GetRenderingEnabledSectionOrDefault(int index); // 0x0000000181F3EE60-0x0000000181F3EF00
		public void AddSection([IsReadOnly] in MeshRendererUpdateSection section); // 0x0000000181F3E3B0-0x0000000181F3E770
		internal void Validate(); // 0x00000001802E76C0-0x00000001802E76D0
		private void ValidateImpl(); // 0x0000000181F3F3F0-0x0000000181F3FDA0
		private bool DeepValidateImpl(); // 0x00000001802E7990-0x00000001802E79A0
		private bool ValidateSceneCullingMask(JaggedSpan<ulong> sceneCullingMasks, NativeList<ulong> sharedSceneCullingMasks, bool useSharedSceneCullingMask, JaggedSpan<EntityId> instanceIDs); // 0x0000000181F3FEF0-0x0000000181F40060
		private bool ValidateGPUComponentUpdates([IsReadOnly] in GPUComponentJaggedUpdate update, JaggedSpan<EntityId> instanceIDs); // 0x0000000181F3F1C0-0x0000000181F3F3F0
		private bool ValidateNoDuplicatePropertyID([IsReadOnly] in NativeArray<GPUComponentJaggedUpdate> updates); // 0x0000000181F3FDA0-0x0000000181F3FEF0
		private bool ValidateEmptyOrSameLayout<T>(MeshRendererComponentMask component, JaggedSpan<T> components, JaggedSpan<EntityId> instanceIDs)
			where T : struct;
		private bool ValidateEmptyOrSameSectionCount<T>(MeshRendererComponentMask component, JaggedSpan<T> components, JaggedSpan<EntityId> instanceIDs)
			where T : struct;
		private bool HasSameLayout([IsReadOnly] in GPUComponentJaggedUpdate update, [IsReadOnly] in JaggedSpan<EntityId> instanceIDs); // 0x0000000181F3F060-0x0000000181F3F1C0
	}
}
