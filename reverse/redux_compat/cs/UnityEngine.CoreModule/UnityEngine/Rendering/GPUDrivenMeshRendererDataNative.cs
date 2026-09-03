/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	internal struct GPUDrivenMeshRendererDataNative // TypeDefIndex: 8379
	{
		// Fields
		public unsafe EntityId* renderer; // 0x00
		public unsafe Bounds* localBounds; // 0x08
		public unsafe Vector4* lightmapScaleOffset; // 0x10
		public unsafe EntityId* lodGroup; // 0x18
		public unsafe byte* lodMask; // 0x20
		public unsafe short* lightmapIndex; // 0x28
		public unsafe InternalMeshRendererSettings* rendererSettings; // 0x30
		public unsafe int* rendererPriority; // 0x38
		public unsafe Matrix4x4* localToWorldMatrix; // 0x40
		public unsafe Matrix4x4* prevLocalToWorldMatrix; // 0x48
		public unsafe EntityId* mesh; // 0x50
		public unsafe InternalMeshLodRendererSettings* meshLodSettings; // 0x58
		public unsafe ushort* subMeshStartIndex; // 0x60
		public unsafe ushort* staticBatchSubMeshCount; // 0x68
		public unsafe RangeInt* subMaterialRange; // 0x70
		public unsafe uint* rendererUserValues; // 0x78
		public unsafe byte* lightProbeUsages; // 0x80
		public unsafe ulong* sceneCullingMask; // 0x88
		public int rendererCount; // 0x90
		public int materialCount; // 0x94
		public unsafe EntityId* material; // 0x98
		public unsafe EntityId* invalidRenderer; // 0xA0
		public int invalidRendererCount; // 0xA8
		public unsafe byte* invalidRendererReason; // 0xB0
	}
}
