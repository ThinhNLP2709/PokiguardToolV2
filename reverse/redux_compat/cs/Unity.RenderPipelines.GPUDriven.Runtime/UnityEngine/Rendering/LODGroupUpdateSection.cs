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
	internal struct LODGroupUpdateSection // TypeDefIndex: 12940
	{
		// Fields
		public NativeArray<EntityId> instanceIDs; // 0x00
		public NativeArray<float3> worldSpaceReferencePoints; // 0x10
		public NativeArray<float> worldSpaceSizes; // 0x20
		public NativeArray<InternalLODGroupSettings> lodGroupSettings; // 0x30
		public NativeArray<byte> forceLODMask; // 0x40
		public NativeArray<EmbeddedLODBuffer> lodBuffers; // 0x50
	
		// Methods
		public LODGroupComponentMask BuildComponentMask(); // 0x0000000181F3ACF0-0x0000000181F3AD40
	}
}
