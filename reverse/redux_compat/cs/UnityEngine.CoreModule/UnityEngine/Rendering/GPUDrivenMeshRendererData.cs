/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	internal struct GPUDrivenMeshRendererData // TypeDefIndex: 8386
	{
		// Fields
		public NativeArray<EntityId> renderer; // 0x00
		public NativeArray<Bounds> localBounds; // 0x10
		public NativeArray<Vector4> lightmapScaleOffset; // 0x20
		public NativeArray<EntityId> lodGroup; // 0x30
		public NativeArray<byte> lodMask; // 0x40
		public NativeArray<short> lightmapIndex; // 0x50
		public NativeArray<InternalMeshRendererSettings> rendererSettings; // 0x60
		public NativeArray<int> rendererPriority; // 0x70
		public NativeArray<Matrix4x4> localToWorldMatrix; // 0x80
		public NativeArray<Matrix4x4> prevLocalToWorldMatrix; // 0x90
		public NativeArray<EntityId> mesh; // 0xA0
		public NativeArray<InternalMeshLodRendererSettings> meshLodSettings; // 0xB0
		public NativeArray<ushort> subMeshStartIndex; // 0xC0
		public NativeArray<ushort> staticBatchSubMeshCount; // 0xD0
		public NativeArray<RangeInt> subMaterialRange; // 0xE0
		public NativeArray<uint> rendererUserValues; // 0xF0
		public NativeArray<byte> lightProbeUsages; // 0x100
		public NativeArray<ulong> sceneCullingMask; // 0x110
		public NativeArray<EntityId> material; // 0x120
		public NativeArray<EntityId> invalidRenderer; // 0x130
		public NativeArray<byte> invalidRendererReason; // 0x140
	}
}
