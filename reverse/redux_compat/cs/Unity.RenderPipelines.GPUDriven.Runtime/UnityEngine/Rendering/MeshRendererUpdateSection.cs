/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct MeshRendererUpdateSection // TypeDefIndex: 12959
	{
		// Fields
		public NativeArray<EntityId> instanceIDs; // 0x00
		public NativeArray<float4x4> localToWorlds; // 0x10
		public NativeArray<float4x4> prevLocalToWorlds; // 0x20
		public NativeArray<EntityId> meshIDs; // 0x30
		public NativeArray<EntityId> materialIDs; // 0x40
		public NativeArray<RangeInt> subMaterialRanges; // 0x50
		public NativeArray<ushort> subMeshStartIndices; // 0x60
		public NativeArray<ushort> staticBatchSubMeshCounts; // 0x70
		public NativeArray<AABB> localBounds; // 0x80
		public NativeArray<InternalMeshRendererSettings> rendererSettings; // 0x90
		public NativeArray<EntityId> parentLODGroupIDs; // 0xA0
		public NativeArray<byte> lodMasks; // 0xB0
		public NativeArray<InternalMeshLodRendererSettings> meshLodSettings; // 0xC0
		public NativeArray<short> lightmapIndices; // 0xD0
		public NativeArray<int> rendererPriorities; // 0xE0
		public NativeArray<GPUComponentUpdate> gpuComponentUpdates; // 0xF0
		public NativeBitArray renderingEnabled; // 0x100
		public NativeArray<ulong> sceneCullingMasks; // 0x110
		public ulong sharedSceneCullingMask; // 0x120
	}
}
